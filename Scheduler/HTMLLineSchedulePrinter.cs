using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scheduler
{
    class HTMLLineSchedulePrinter
    {
        private IGui gui;
        private IConfiguration config;
        private bool PrintFullSchedule = true;

        // string constants
        const string OneSpace = "&nbsp;";
        const string TwoSpaces = "&ensp;";
        const string StartMark = "<span style=\"background-color: #FFFF00\">";
        const string EndMark = "</span>";
        const string Tab = "&emsp;";
        const string StartNote = "<span style=\"background-color: #D2B4DE\">";
        const string EndNote = "</span>";

        public HTMLLineSchedulePrinter(IGui gui, IConfiguration config)
        {
            this.gui = gui;
            this.config = config;
        }

        public void print(Semester semester, string filename, bool full)
        {
            this.PrintFullSchedule = full;
            print(semester, filename);
        }

        public void print(Semester s, string filename)
        {
            if (s.Size() <= 0)
            {
                gui.printMessage("No file loaded for printing.");
                return;
            }

            // initialize local variables
            string lastCatalogNbr = "";
            string lastTopicDescr = "";

            // making dangerous assumption that "standard" semester start and end dates are identical to the first section
            string standardMeetingStartDt = s.ElementAt(0).GetMeetingStartDt();
            string standardMeetingEndDt = s.ElementAt(0).GetMeetingEndDt();

            // sort by instructor 
            Semester semester = s.sortByCatalogNbr();

            //open file
            try
            {
                using (System.IO.StreamWriter printer = new System.IO.StreamWriter(filename, false))
                {
                    // print HTML header
                    printer.WriteLine("<html>");
                    printer.WriteLine("<head>");
                    printer.WriteLine("<title>" + semester.GetName() + " Line Schedule</title>");
                    printer.WriteLine("</head>");
                    printer.WriteLine("<body style='font-family=\"courier\"'>");
                    printer.WriteLine("<h1>" + semester.GetName() + "</h1>");
                    printer.WriteLine("<i>printed " + DateTime.Today.ToString("dd-MM-yyyy") + DateTime.Now.ToString("HH:mm:ss") + "</i>");

                    for (int x = 0; x < semester.Size(); x++)
                    {
                        Section sec = semester.ElementAt(x);

                        // skip sections we are not interested in scheduling
                        if (PrintFullSchedule)
                        {
                            if (!sec.GetInstructor().Any())
                                continue; // skip
                        }

                        if (sec.GetHasBeenDeleted() || sec.HasBeenChanged())
                                ;
                        else
                        {
                            if ((!semester.isVerified() && sec.IsHidden())
                                    || !sec.GetInstructor().Any()
                                    || sec.CatalogNbr.Equals("999") || sec.CatalogNbr.Equals("990")
                                    || sec.CatalogNbr.Equals("899") || sec.CatalogNbr.Equals("897")
                                    || sec.CatalogNbr.Equals("898") || sec.CatalogNbr.Equals("895")
                                    || (sec.CatalogNbr.Equals("690") && sec.GetTopicDescr().Equals(" "))
                                    || (sec.CatalogNbr.Equals("798") && sec.GetTopicDescr().Equals("Top/Vary By Student"))
                                    || (sec.CatalogNbr.Equals("890") && sec.GetTopicDescr().Equals("Top/Vary By Student")))
                                continue; //skip
                        }
                        
                        // print out lines for sections of interest
                        if (!sec.CatalogNbr.Equals(lastCatalogNbr) || (sec.CatalogNbr.Equals(lastCatalogNbr) && !sec.GetTopicDescr().Equals(lastTopicDescr)))
                        {
                            printer.WriteLine("</p>");
                            printer.WriteLine();
                            printer.Write("<p style=\"font-family:monospace;\"><strong>");
                            lastCatalogNbr = sec.CatalogNbr;
                            lastTopicDescr = sec.GetTopicDescr();
                            printer.Write(sec.Subject + OneSpace + sec.CatalogNbr + TwoSpaces + sec.GetClassDescr() +
                            (!sec.GetTopicDescr().Equals(" ") ? " - " + sec.GetTopicDescr() : ""));
                            printer.WriteLine("</strong><br>");
                        }

                        // highlight sections that were removed from the current semester
                        if (sec.GetHasBeenDeleted())
                            printer.Write("<span style=\"text-decoration: line-through\">");

                        // highlight sections that are listed as "hidden" in the current semester
                        if (sec.IsHidden())
                            printer.Write("<span style=\"color:blue; font-style: italic\">");

                        // format section number
                        string section = padEnd(sec.GetSection(), 3);
                        //gui.printMessage("[" + section + "] " + section.Length);
                        section = sec.GetSectionVer() ? section : StartMark + section + EndMark;

                        //format enrollment cap
                        string enrlCap = padFront(sec.GetEnrlCap(), 3);
                        enrlCap = (sec.GetEnrlCapVer() ? enrlCap : StartMark + enrlCap + EndMark);

                        // format class association component
                        string component = padFront(sec.GetClassAssnComponent(), 4);
                        component = sec.GetClassAssnComponentVer() ? component : StartMark + component + EndMark;

                        // format credits
                        string credits = (sec.GetUnitsMin().Equals(sec.GetUnitsMax()) ? sec.GetUnitsMin()
                                : sec.GetUnitsMin() + "-" + padFront(sec.GetUnitsMax(), 5));
                        credits = sec.GetUnitsMinVer() && sec.GetUnitsMaxVer() ? credits : StartMark + credits + EndMark;

                        // format days of the week
                        string days = (sec.GetMon().Equals("Y")) ? "M" : OneSpace;
                        days += (sec.GetTues().Equals("Y")) ? "T" : OneSpace;
                        days += (sec.GetWed().Equals("Y")) ? "W" : OneSpace;
                        days += (sec.GetThurs().Equals("Y")) ? "U" : OneSpace;
                        days += (sec.GetFri().Equals("Y")) ? "F" : OneSpace;
                        days = (sec.GetMonVer() && sec.GetTuesVer() && sec.GetWedVer() && sec.GetThursVer() && sec.GetFriVer()
                                && sec.GetSatVer() && sec.GetSunVer()) ? days : StartMark + days + EndMark;

                        // format times of classes
                        string times = (sec.GetMeetingTimeStartVer() ? "" : StartMark) + padFront(sec.GetMeetingTimeStart(), 8)
                                + (sec.GetMeetingTimeStartVer() ? "" : EndMark) + "-" + (sec.GetMeetingTimeEndVer() ? "" : StartMark)
                                + padFront(sec.GetMeetingTimeEnd(), 8) + (sec.GetMeetingTimeEndVer() ? "" : EndMark);

                        if (times.Equals(StartMark + "12:00 AM" + EndMark + "-" + StartMark + "12:00 AM" + EndMark))
                            times = StartMark + "  By Appointment  " + EndMark;
                        if (times.Equals("12:00 AM-12:00 AM"))
                            times = "  By Appointment  ";

                        // format faculty name
                        string faculty = sec.GetInstructor();
                        faculty = faculty.Substring(0, faculty.Length > 17 ? 17 : faculty.Length - 1);
                        faculty = padEnd(faculty, 18);
                        faculty = (sec.GetInstructorVer() ? faculty : StartMark + faculty + EndMark);

                        // format building and classroom number
                        string facility = (sec.GetFacilityIdVer() ? "" : StartMark) + padEnd(sec.GetFacilityId(), 8)
                                + (sec.GetFacilityIdVer() ? "" : EndMark);

                        string nonStd = standardMeetingStartDt.Equals(sec.GetMeetingStartDt()) && standardMeetingEndDt.Equals(sec.GetMeetingEndDt())
                                && sec.GetMeetingStartDtVer() && sec.GetMeetingEndDtVer() ?
                                "" : ((sec.GetMeetingStartDtVer() && sec.GetMeetingEndDtVer()) ? "   [" : TwoSpaces + StartMark + "[")
                                            + sec.GetMeetingStartDt() + "-" + sec.GetMeetingEndDt()
                                            + ((sec.GetMeetingStartDtVer() && sec.GetMeetingEndDtVer()) ? "]" : "]" + EndMark);

                        // print first part of line
                        printer.Write(section + Tab + enrlCap + Tab + component + Tab + credits + Tab + days + Tab + times + Tab
                                + facility + Tab + faculty + Tab + nonStd);



                        if (sec.GetHasBeenDeleted())
                            printer.Write("</span>");

                        if (sec.IsHidden())
                            printer.Write("</span>");

                        // print out notes if they are there
                        if (sec.GetMyNotes().Trim().Any())
                            printer.WriteLine("<br><em>" + Tab + Tab + StartNote + sec.GetMyNotes() + EndNote + "</em><br>");
                        else
                            printer.WriteLine("<br>");

                    }
                    printer.WriteLine("</body>");
                    printer.WriteLine("</html>");
                    printer.Close();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        // these two helper functions cannot be replace with .PadRight/.PadLeft
        // since we are padding with strings "&nbsp;" instead of characters
        private String padEnd(String str, int length)
        {
            for (int i = str.Length; i < length; i++)
                str += OneSpace;
            return str;
        }

        private String padFront(String str, int length)
        {
            for (int i = str.Length; i < length; i++)
                str = OneSpace + str;
            return str;
        }
    }
}
