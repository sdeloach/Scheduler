using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scheduler
{
    class HTMLInstructorSchedulePrinter
    {

        private Scheduler gui;
        private Configuration config;
        private bool PrintFullSchedule = true;
        
        private string space1 = "&nbsp;";
        private string space2 = "&ensp;";

        public HTMLInstructorSchedulePrinter(Scheduler gui, Configuration config)
        {
            this.gui = gui;
            this.config = config;
        }

        public void print(Semester semester, string filename, bool full)
        {
            PrintFullSchedule = full;
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
            string mark = "<span style=\"background-color: #FFFF00\">";
            string endMark = "</span>";
            string lastInstructor = "";
            string tab = "&emsp;";

            // making dangerous assumption that "standard" semester start and end dates are identical to the first section
            string standardMeetingStartDt = s.ElementAt(0).GetMeetingStartDt();
            string standardMeetingEndDt = s.ElementAt(0).GetMeetingEndDt();

            // sort by instructor 
            Semester semester = s.sortByInstructor();

            //open file
            try
            {
                using (System.IO.StreamWriter printer = new System.IO.StreamWriter(filename, false))
                {
                    //print HTML header
                    printer.WriteLine("<!DOCTYPE html>");
                    printer.WriteLine("<head>");
                    printer.WriteLine("<title>" + s.GetName() + " Instructor Schedule</title>");
                    printer.WriteLine("</head>");
                    printer.WriteLine("<body style='font-family=\"sans-serif\"'>");
                    printer.WriteLine("<h1>" + s.GetName() + "</h1>");
                    printer.WriteLine("<i>printed " + DateTime.Today.ToString("dd-MM-yyyy") + DateTime.Now.ToString("HH:mm:ss") + "</i>");


                    for (int x = 0; x < semester.Size(); x++)
                    {
                        Section sec = semester.ElementAt(x);

                        // skip sections we are not interested in scheduling
                        if (PrintFullSchedule)
                        {
                            if (!sec.GetInstructor().Any() || sec.GetClassMtgNbr1().Equals("0"))
                                continue;
                        }
                        else
                            if ((!semester.isVerified() && sec.GetHasBeenDeleted())
                                    || sec.GetHidden().ToLower().Equals("true")
                                    || !sec.GetInstructor().Any() || sec.GetClassMtgNbr1().Equals("0")
                                    || sec.GetCatalogNbr().Equals("999") || sec.GetCatalogNbr().Equals("990")
                                    || sec.GetCatalogNbr().Equals("899") || sec.GetCatalogNbr().Equals("897")
                                    || sec.GetCatalogNbr().Equals("898") || sec.GetCatalogNbr().Equals("895")
                                    || (sec.GetCatalogNbr().Equals("690"))
                                    || (sec.GetCatalogNbr().Equals("798") && sec.GetTopicDescr().Equals("Top/Vary By Student"))
                                    || (sec.GetCatalogNbr().Equals("890") && sec.GetTopicDescr().Equals("Top/Vary By Student")))
                            continue;

                        // print out lines for sections of interest
                        if (!sec.GetInstructor().Equals(lastInstructor))
                        {
                            lastInstructor = sec.GetInstructor();
                            printer.WriteLine("</p>");
                            printer.WriteLine("<p style=\"font-family:monospace;\"><strong>" + sec.GetInstructor() + "</strong><br>");
                        }

                        // print out lines for sections of interest
                        if (sec.GetCatalogNbr().Equals(lastCatalogNbr))
                            printer.WriteLine("<br>");
                        else
                        {
                            printer.WriteLine("</p>");
                            printer.WriteLine();
                            printer.Write("<p style=\"font-family:monospace;\"><strong>" + tab);
                            lastCatalogNbr = sec.GetCatalogNbr();
                            printer.Write(sec.GetSubject() + space1 + sec.GetCatalogNbr() + space2 + sec.GetClassDescr());
                            if (!sec.GetTopicDescr().Equals(" "))
                                printer.Write(" - " + sec.GetTopicDescr());
                            printer.WriteLine("</strong><br>");
                        }

                        if (sec.GetHasBeenDeleted())
                            printer.Write("<span style=\"background-color: #A9A9A9\">");

                        // format section number
                        string section = sec.GetSection().PadRight(3);
                        section = sec.GetSectionVer() ? section : mark + section + endMark;

                        //format enrollment cap
                        string enrlCap = sec.GetEnrlCap().PadLeft(3);
                        enrlCap = (sec.GetEnrlCapVer() ? enrlCap : mark + enrlCap + endMark);

                        // format class association component
                        string component = sec.GetClassAssnComponent().PadRight(4);
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
                            times = mark + "     By Appointment   " + endMark;
                        if (times.Equals("12:00 AM-12:00 AM"))
                            times = "     By Appointment   ";

                        // format faculty name
                        string faculty = sec.GetInstructor();
                        faculty = faculty.Substring(0, faculty.Length > 15 ? 15 : faculty.Length - 1);
                        faculty = faculty.PadRight(16);
                        faculty = (sec.GetInstructorVer() ? faculty : mark + faculty + endMark);

                        // format building and classroom number
                        string facility = (sec.GetFacilityIdVer() ? "" : mark) + sec.GetFacilityId().PadRight(8)
                                + (sec.GetFacilityIdVer() ? "" : endMark);

                        string nonStd = standardMeetingStartDt.Equals(sec.GetMeetingStartDt()) && standardMeetingEndDt.Equals(sec.GetMeetingEndDt()) ?
                                "" : ((sec.GetMeetingStartDtVer() && sec.GetMeetingEndDtVer()) ? "   [" : space2 + mark + "[")
                                            + sec.GetMeetingStartDt() + "-" + sec.GetMeetingEndDt()
                                            + ((sec.GetMeetingStartDtVer() && sec.GetMeetingEndDtVer()) ? "]" : "]" + endMark);

                        // print line
                        printer.WriteLine(tab + tab + section + tab + enrlCap + tab + component + tab + credits + tab + days + tab + times + tab
                                + facility + tab + faculty + tab + nonStd);

                        if (sec.GetHasBeenDeleted())
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
        }

        public void Open(string document)
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
