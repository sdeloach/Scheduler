using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scheduler
{
    class HTMLSchedulePrinter
    {

        private Scheduler gui;
        private Configuration config;
        private bool PrintFullSchedule = true;

        private string space1 = "&nbsp;";
        private string space2 = "&ensp;";

        public HTMLSchedulePrinter(Scheduler gui, Configuration config)
        {
            this.gui = gui;
            this.config = config;
        }

        public void print(Semester semester, string filename, bool full)
        {
            this.PrintFullSchedule = full;
            print(semester, filename);
        }

        public void print(Semester semester, string filename)
        {
            if (semester.Size() <= 0)
            {
                gui.printMessage("No file loaded for printing.");
                return;
            }

            // initialize local variables
            string lastCatalogNbr = "";
            string mark = "<span style=\"background-color: #FFFF00\">";
            string endMark = "</span>";
            string tab = "&emsp;";
            string startNote = "<span style=\"background-color: #D2B4DE\">";
            string endNote = "</span>";
            string lastTopicDescr = "";

            // making dangerous assumption that "standard" semester start and end dates are identical to the first section
            string standardMeetingStartDt = semester.ElementAt(0).GetMeetingStartDt();
            string standardMeetingEndDt = semester.ElementAt(0).GetMeetingEndDt();

            // sort by instructor 
            //Semester semester = s.sortByInstructor();

            //open file
            try
            {
                using (System.IO.StreamWriter printer = new System.IO.StreamWriter(filename, false))
                {
                    // print HTML header
                    //printer.WriteLine("<!DOCTYPE html>");
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
                            if (!sec.GetInstructor().Any() || sec.GetClassMtgNbr1().Equals("0"))
                                continue; // skip
                        }

                        if (sec.GetHasBeenDeleted() || sec.HasBeenChanged())
                            ;
                        else
                        {
                            if ((!semester.isVerified() && sec.GetHidden().ToLower().Equals("true"))
                                    || !sec.GetInstructor().Any() || sec.GetClassMtgNbr1().Equals("0")
                                    || sec.GetCatalogNbr().Equals("999") || sec.GetCatalogNbr().Equals("990")
                                    || sec.GetCatalogNbr().Equals("899") || sec.GetCatalogNbr().Equals("897")
                                    || sec.GetCatalogNbr().Equals("898") || sec.GetCatalogNbr().Equals("895")
                                    || (sec.GetCatalogNbr().Equals("690") && sec.GetTopicDescr().Equals(" "))
                                    || (sec.GetCatalogNbr().Equals("798") && sec.GetTopicDescr().Equals("Top/Vary By Student"))
                                    || (sec.GetCatalogNbr().Equals("890") && sec.GetTopicDescr().Equals("Top/Vary By Student")))
                                continue; //skip
                        }
                        
                        // print out lines for sections of interest
                        if (!sec.GetCatalogNbr().Equals(lastCatalogNbr) || (sec.GetCatalogNbr().Equals(lastCatalogNbr) && !sec.GetTopicDescr().Equals(lastTopicDescr)))
                        {
                            printer.WriteLine("</p>");
                            printer.WriteLine();
                            printer.Write("<p style=\"font-family:monospace;\"><strong>");
                            lastCatalogNbr = sec.GetCatalogNbr();
                            lastTopicDescr = sec.GetTopicDescr();
                            printer.Write(sec.GetSubject() + space1 + sec.GetCatalogNbr() + space2 + sec.GetClassDescr() +
                            (!sec.GetTopicDescr().Equals(" ") ? " - " + sec.GetTopicDescr() : ""));
                            printer.WriteLine("</strong><br>");
                        }

                        // highlight sections that were removed from the current semester
                        if (sec.GetHasBeenDeleted())
                            printer.Write("<span style=\"text-decoration: line-through\">");

                        // highlight sections that are listed as "hidden" in the current semester
                        if (sec.GetHidden().ToLower().Equals("true"))
                            printer.Write("<span style=\"color:blue; font-style: italic\">");

                        // format section number
                        string section = sec.GetSection().PadRight(3);
                        section = sec.GetSectionVer() ? section : mark + section + endMark;

                        //format enrollment cap
                        string enrlCap = sec.GetEnrlCap().PadLeft(3);
                        enrlCap = (sec.GetEnrlCapVer() ? enrlCap : mark + enrlCap + endMark);

                        // format class association component
                        string component = sec.GetClassAssnComponent().PadLeft(4);
                        component = sec.GetClassAssnComponentVer() ? component : mark + component + endMark;

                        // format credits
                        string credits = (sec.GetUnitsMin().Equals(sec.GetUnitsMax()) ? sec.GetUnitsMin()
                                : sec.GetUnitsMin() + "-" + sec.GetUnitsMax()).PadLeft(5);
                        credits = sec.GetUnitsMinVer() && sec.GetUnitsMaxVer() ? credits : mark + credits + endMark;

                        // format days of the week
                        string days = (sec.GetMon().Equals("Y")) ? "M" : space1;
                        days += (sec.GetTues().Equals("Y")) ? "T" : space1;
                        days += (sec.GetWed().Equals("Y")) ? "W" : space1;
                        days += (sec.GetThurs().Equals("Y")) ? "U" : space1;
                        days += (sec.GetFri().Equals("Y")) ? "F" : space1;
                        days = (sec.GetMonVer() && sec.GetTuesVer() && sec.GetWedVer() && sec.GetThursVer() && sec.GetFriVer()
                                && sec.GetSatVer() && sec.GetSunVer()) ? days : mark + days + endMark;

                        // format times of classes
                        string times = (sec.GetMeetingTimeStartVer() ? "" : mark) + sec.GetMeetingTimeStart().PadLeft(8)
                                + (sec.GetMeetingTimeStartVer() ? "" : endMark) + "-" + (sec.GetMeetingTimeEndVer() ? "" : mark)
                                + sec.GetMeetingTimeEnd().PadLeft(8) + (sec.GetMeetingTimeEndVer() ? "" : endMark);

                        if (times.Equals(mark + "12:00 AM" + endMark + "-" + mark + "12:00 AM" + endMark))
                            times = mark + "  By Appointment  " + endMark;
                        if (times.Equals("12:00 AM-12:00 AM"))
                            times = "  By Appointment  ";

                        // format faculty name
                        string faculty = sec.GetInstructor();
                        faculty = faculty.Substring(0, faculty.Length > 17 ? 17 : faculty.Length - 1);
                        faculty = faculty.PadRight(18);
                        faculty = (sec.GetInstructorVer() ? faculty : mark + faculty + endMark);

                        // format building and classroom number
                        string facility = (sec.GetFacilityIdVer() ? "" : mark) + sec.GetFacilityId().PadRight(8)
                                + (sec.GetFacilityIdVer() ? "" : endMark);

                        string nonStd = standardMeetingStartDt.Equals(sec.GetMeetingStartDt()) && standardMeetingEndDt.Equals(sec.GetMeetingEndDt())
                                && sec.GetMeetingStartDtVer() && sec.GetMeetingEndDtVer() ?
                                "" : ((sec.GetMeetingStartDtVer() && sec.GetMeetingEndDtVer()) ? "   [" : space2 + mark + "[")
                                            + sec.GetMeetingStartDt() + "-" + sec.GetMeetingEndDt()
                                            + ((sec.GetMeetingStartDtVer() && sec.GetMeetingEndDtVer()) ? "]" : "]" + endMark);

                        // print first part of line
                        printer.Write(section + tab + enrlCap + tab + component + tab + credits + tab + days + tab + times + tab
                                + facility + tab + faculty + tab + nonStd);



                        if (sec.GetHasBeenDeleted())
                            printer.Write("</span>");

                        if (sec.GetHidden().ToLower().Equals("true"))
                            printer.Write("</span>");

                        // print out notes if they are there
                        if (sec.GetMyNotes().Trim().Any())
                            printer.WriteLine("<br><em>" + tab + tab + startNote + sec.GetMyNotes() + endNote + "</em><br>");
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
        }

        public void View(string document)
        {
            // Prepare the process to run
            ProcessStartInfo start = new ProcessStartInfo();
            // Enter in the command line arguments, everything you would enter after the executable name itself
            start.Arguments = document;
            // Enter the executable to run, including the complete path
            start.FileName = @"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe ";
            // Do you want to show a console window?
            start.WindowStyle = ProcessWindowStyle.Hidden;
            start.CreateNoWindow = true;
            Process proc = Process.Start(start);
        }
   }
}
