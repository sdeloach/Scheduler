using System;
using System.Linq;
using System.Windows.Forms;

namespace Scheduler
{
    class HTMLLineSchedulePrinter : IPrinter
    {
        private IGui gui;

        // string constants
        const string OneSpace = "&nbsp;";
        const string TwoSpaces = "&ensp;";
        const string StartMark = "<span style=\"background-color: #FFFF00\">";
        const string EndMark = "</span>";
        const string Tab = "&emsp;";
        const string StartNote = "<span style=\"background-color: #D2B4DE\">";
        const string EndNote = "</span>";

        public HTMLLineSchedulePrinter(IGui gui)
        {
            this.gui = gui;
        }

        public string Print(Semester s)
        {
            if (s.Size() <= 0)
            {
                gui.WriteLine("No file loaded for printing.");
                return "";
            }

            // initialize local variables
            string lastCatalogNbr = "";
            string lastTopicDescr = "";

            // making dangerous assumption that "standard" semester start and end dates are identical to the first section
            string standardMeetingStartDt = s.ElementAt(0).MeetingStartDt;
            string standardMeetingEndDt = s.ElementAt(0).MeetingEndDt;

            // sort by catalog number 
            Semester semester = s.SortByCatalogNbr();

            // construct the output filename
            string filename = s.FileName.Substring(0, s.FileName.Length - 4) + "_schedule.html";

            //open file
            try
            {
                using (System.IO.StreamWriter printer = new System.IO.StreamWriter(filename, false))
                {
                    // print HTML header
                    printer.WriteLine("<html>");
                    printer.WriteLine("<head>");
                    printer.WriteLine("<title>" + semester.Name + " Line Schedule</title>");
                    printer.WriteLine("</head>");
                    printer.WriteLine("<body style='font-family=\"courier\"'>");
                    printer.WriteLine("<h1>" + semester.Name + "</h1>");
                    printer.WriteLine("<i>printed " + DateTime.Today.ToString("MMM dd, yyyy") + " " + DateTime.Now.ToString("HH:mm") + "</i>");

                    for (int x = 0; x < semester.Size(); x++)
                    {
                        Section sec = semester.ElementAt(x);
                        
                        // skip sections we are not interested in seeing

                        if (!sec.HasBeenDeleted) // print all sections that have been deleted regardless of number
                            if (!sec.Instructor.Any()
                                    || sec.CatalogNbr.Equals("999") || sec.CatalogNbr.Equals("990")
                                    || sec.CatalogNbr.Equals("899") || sec.CatalogNbr.Equals("897")
                                    || sec.CatalogNbr.Equals("898") || sec.CatalogNbr.Equals("895")
                                    || (sec.CatalogNbr.Equals("690") && sec.TopicDescr.Equals(" "))
                                    || (sec.CatalogNbr.Equals("798") && sec.TopicDescr.Equals("Top/Vary By Student"))
                                    || (sec.CatalogNbr.Equals("890") && sec.TopicDescr.Equals("Top/Vary By Student")))
                                            continue; //skip all the 80s, 798s, etc.

                        // print out lines for sections of interest
                        if (!sec.CatalogNbr.Equals(lastCatalogNbr) || (sec.CatalogNbr.Equals(lastCatalogNbr) && !sec.TopicDescr.Equals(lastTopicDescr)))
                        {
                            printer.WriteLine("</p>");
                            printer.WriteLine();
                            printer.Write("<p style=\"font-family:monospace;\"><strong>");
                            lastCatalogNbr = sec.CatalogNbr;
                            lastTopicDescr = sec.TopicDescr;
                            printer.Write(sec.Subject + OneSpace + sec.CatalogNbr + TwoSpaces + sec.ClassDescr +
                            (!sec.TopicDescr.Equals(" ") ? " - " + sec.TopicDescr : ""));
                            printer.WriteLine("</strong><br>");
                        }

                        // highlight sections that were removed from the current semester
                        if (sec.HasBeenDeleted)
                            printer.Write("<span style=\"text-decoration: line-through\">");

                        // highlight sections that are listed as "hidden" in the current semester
                        if (sec.IsHidden)
                            printer.Write("<span style=\"color:blue; font-style: italic\">");

                        // format section number
                        string section = Utility.PadRightWithString(sec.SectionName, 3);
                        section = sec.SectionVer ? section : StartMark + section + EndMark;

                        //format enrollment cap
                        string enrlCap = Utility.PadFrontWithString(sec.EnrlCap, 3);
                        enrlCap = (sec.EnrlCapVer ? enrlCap : StartMark + enrlCap + EndMark);

                        // format class association component
                        string component = Utility.PadFrontWithString(sec.ClassAssnComponent, 4);
                        component = sec.ClassAssnComponentVer ? component : StartMark + component + EndMark;

                        // format credits
                        string credits = (sec.UnitsMin.Equals(sec.UnitsMax) ? sec.UnitsMin
                                : sec.UnitsMin + "-" + Utility.PadFrontWithString(sec.UnitsMax, 5));
                        credits = sec.UnitsMinVer && sec.UnitsMaxVer ? credits : StartMark + credits + EndMark;

                        // format days of the week
                        string days = (sec.Mon.Equals("Y")) ? "M" : OneSpace;
                        days += (sec.Tues.Equals("Y")) ? "T" : OneSpace;
                        days += (sec.Wed.Equals("Y")) ? "W" : OneSpace;
                        days += (sec.Thurs.Equals("Y")) ? "U" : OneSpace;
                        days += (sec.Fri.Equals("Y")) ? "F" : OneSpace;
                        days = (sec.MonVer && sec.TuesVer && sec.WedVer && sec.ThursVer && sec.FriVer
                                && sec.SatVer && sec.SunVer) ? days : StartMark + days + EndMark;

                        // format times of classes
                        string times = (sec.MeetingTimeStartVer ? "" : StartMark) + Utility.PadFrontWithString(sec.MeetingTimeStart, 8)
                                + (sec.MeetingTimeStartVer ? "" : EndMark) + "-" + (sec.MeetingTimeEndVer ? "" : StartMark)
                                + Utility.PadFrontWithString(sec.MeetingTimeEnd, 8) + (sec.MeetingTimeEndVer ? "" : EndMark);

                        if (times.Equals(StartMark + "12:00 AM" + EndMark + "-" + StartMark + "12:00 AM" + EndMark))
                            times = StartMark + "  By Appointment  " + EndMark;
                        if (times.Equals("12:00 AM-12:00 AM"))
                            times = "  By Appointment  ";

                        // format faculty name
                        string faculty = sec.Instructor;
                        faculty = faculty.Substring(0, faculty.Length > 17 ? 17 : faculty.Length - 1);
                        faculty = Utility.PadRightWithString(faculty, 18);
                        faculty = (sec.InstructorVer ? faculty : StartMark + faculty + EndMark);

                        // format building and classroom number
                        string facility = (sec.FacilityIdVer ? "" : StartMark) + Utility.PadRightWithString(sec.FacilityId, 8)
                                + (sec.FacilityIdVer ? "" : EndMark);

                        string nonStd = standardMeetingStartDt.Equals(sec.MeetingStartDt) && standardMeetingEndDt.Equals(sec.MeetingEndDt)
                                && sec.MeetingStartDtVer && sec.MeetingEndDtVer ?
                                "" : ((sec.MeetingStartDtVer && sec.MeetingEndDtVer) ? "   [" : TwoSpaces + StartMark + "]")
                                            + sec.MeetingStartDt + "-" + sec.MeetingEndDt
                                            + ((sec.MeetingStartDtVer && sec.MeetingEndDtVer) ? "]" : "]" + EndMark);

                        // print first part of line
                        printer.Write(section + Tab + enrlCap + Tab + component + Tab + credits + Tab + days + Tab + times + Tab
                                + facility + Tab + faculty + Tab + nonStd);

                        if (sec.HasBeenDeleted) printer.Write("</span>");

                        if (sec.IsHidden) printer.Write("</span>");

                        // print out notes if they are there
                        if (sec.MyNotes.Trim().Any())
                            printer.WriteLine("<br><em>" + Tab + Tab + StartNote + sec.MyNotes + EndNote + "</em><br>");
                        else
                            printer.WriteLine("<br>");

                    }
                    printer.WriteLine("</body>");
                    printer.WriteLine("</html>");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return filename;
        }
    }
}
