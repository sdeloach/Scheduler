using System;
using System.Linq;
using System.Windows.Forms;

namespace Scheduler
{
    class HTMLInstructorSchedulePrinter : IPrinter
    {

        private IGui gui;
        private bool PrintFullSchedule = false;

        const string OneSpace = "&nbsp;";
        const string TwoSpaces = "&ensp;";
        const string StartMark = "<span style=\"background-color: #FFFF00\">";
        const string EndMark = "</span>";
        const string Tab = "&emsp;";


        public HTMLInstructorSchedulePrinter(IGui gui)
        {
            this.gui = gui;
        }

        public string print(Semester s)
        {
            if (s.Size() <= 0)
            {
                gui.printMessage("No file loaded for printing.");
                return "";
            }

            // initialize local variables
            string lastCatalogNbr = "";
            string lastInstructor = "";

            // making dangerous assumption that "standard" semester start and end dates are identical to the first section
            string standardMeetingStartDt = s.ElementAt(0).MeetingStartDt;
            string standardMeetingEndDt = s.ElementAt(0).MeetingEndDt;

            // sort by instructor 
            Semester semester = s.sortByInstructor();

            // contruct file name
            string filename = s.filename.Substring(0, s.filename.Length - 4) + "_instructor.html";

            //open file
            try
            {
                using (System.IO.StreamWriter printer = new System.IO.StreamWriter(filename, false))
                {
                    //print HTML header
                    printer.WriteLine("<!DOCTYPE html>");
                    printer.WriteLine("<head>");
                    printer.WriteLine("<title>" + s.Name + " Instructor Schedule</title>");
                    printer.WriteLine("</head>");
                    printer.WriteLine("<body style='font-family=\"sans-serif\"'>");
                    printer.WriteLine("<h1>" + s.Name + "</h1>");
                    printer.WriteLine("<i>printed " + DateTime.Today.ToString("MMM dd, yyyy") + DateTime.Now.ToString("HH:mm") + "</i>");


                    for (int x = 0; x < semester.Size(); x++)
                    {
                        Section sec = semester.ElementAt(x);

                        // skip sections we are not interested in scheduling
                        if (PrintFullSchedule)
                        {
                            if (!sec.Instructor.Any())
                                continue;
                        }
                        else
                            if ((!semester.isVerified() && sec.HasBeenDeleted)
                                    || sec.IsHidden
                                    || !sec.Instructor.Any()
                                    || sec.CatalogNbr.Equals("999") || sec.CatalogNbr.Equals("990")
                                    || sec.CatalogNbr.Equals("899") || sec.CatalogNbr.Equals("897")
                                    || sec.CatalogNbr.Equals("898") || sec.CatalogNbr.Equals("895")
                                    || (sec.CatalogNbr.Equals("690"))
                                    || (sec.CatalogNbr.Equals("798") && sec.TopicDescr.Equals("Top/Vary By Student"))
                                    || (sec.CatalogNbr.Equals("890") && sec.TopicDescr.Equals("Top/Vary By Student")))
                            continue;

                        // print out lines for sections of interest
                        if (!sec.Instructor.Equals(lastInstructor))
                        {
                            lastInstructor = sec.Instructor;
                            printer.WriteLine("</p>");
                            printer.WriteLine("<p style=\"font-family:monospace;\"><strong>" + sec.Instructor + "</strong><br>");
                        }

                        // print out lines for sections of interest
                        if (sec.CatalogNbr.Equals(lastCatalogNbr))
                            printer.WriteLine("<br>");
                        else
                        {
                            printer.WriteLine("</p>");
                            printer.WriteLine();
                            printer.Write("<p style=\"font-family:monospace;\"><strong>" + Tab);
                            lastCatalogNbr = sec.CatalogNbr;
                            printer.Write(sec.Subject + OneSpace + sec.CatalogNbr + TwoSpaces + sec.ClassDescr);
                            if (!sec.TopicDescr.Equals(" "))
                                printer.Write(" - " + sec.TopicDescr);
                            printer.WriteLine("</strong><br>");
                        }

                        if (sec.HasBeenDeleted)
                            printer.Write("<span style=\"background-color: #A9A9A9\">");

                        // format section number
                        string section = Utility.padEnd(sec.SectionName, 3);
                        section = sec.SectionVer ? section : StartMark + section + EndMark;

                        //format enrollment cap
                        string enrlCap = Utility.padFront(sec.EnrlCap, 3);
                        enrlCap = (sec.EnrlCapVer ? enrlCap : StartMark + enrlCap + EndMark);

                        // format class association component
                        string component = Utility.padEnd(sec.ClassAssnComponent, 4);
                        component = sec.ClassAssnComponentVer ? component : StartMark + component + EndMark;

                        // format credits
                        string credits = (sec.UnitsMin.Equals(sec.UnitsMax) ? sec.UnitsMin
                                : sec.UnitsMin + "-" + Utility.padFront(sec.UnitsMax, 5));
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
                        string times = (sec.MeetingTimeStartVer ? "" : StartMark) + Utility.padFront(sec.MeetingTimeStart, 8)
                                + (sec.MeetingTimeStartVer ? "" : EndMark) + "-" + (sec.MeetingTimeEndVer ? "" : StartMark)
                                + Utility.padFront(sec.MeetingTimeEnd, 8) + (sec.MeetingTimeEndVer ? "" : EndMark);

                        if (times.Equals(StartMark + "12:00 AM" + EndMark + "-" + StartMark + "12:00 AM" + EndMark))
                            times = StartMark + "     By Appointment   " + EndMark;
                        if (times.Equals("12:00 AM-12:00 AM"))
                            times = "     By Appointment   ";

                        // format faculty name
                        string faculty = sec.Instructor;
                        faculty = faculty.Substring(0, faculty.Length > 15 ? 15 : faculty.Length - 1);
                        faculty = Utility.padEnd(faculty, 16);
                        faculty = (sec.InstructorVer ? faculty : StartMark + faculty + EndMark);

                        // format building and classroom number
                        string facility = (sec.FacilityIdVer ? "" : StartMark) + Utility.padEnd(sec.FacilityId, 8)
                                + (sec.FacilityIdVer ? "" : EndMark);

                        string nonStd = standardMeetingStartDt.Equals(sec.MeetingStartDt) && standardMeetingEndDt.Equals(sec.MeetingEndDt) ?
                                "" : ((sec.MeetingStartDtVer && sec.MeetingEndDtVer) ? "   [" : TwoSpaces + StartMark + "]")
                                            + sec.MeetingStartDt + "-" + sec.MeetingEndDt
                                            + ((sec.MeetingStartDtVer && sec.MeetingEndDtVer) ? "]" : "]" + EndMark);

                        // print line
                        printer.WriteLine(Tab + Tab + section + Tab + enrlCap + Tab + component + Tab + credits + Tab + days + Tab + times + Tab
                                + facility + Tab + faculty + Tab + nonStd);

                        if (sec.HasBeenDeleted)
                            printer.Write("</span>");

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
