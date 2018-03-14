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
        
        const string OneSpace = "&nbsp;";
        const string TwoSpaces = "&ensp;";
        const string StartMark = "<span style=\"background-color: #FFFF00\">";
        const string EndMark = "</span>";
        const string Tab = "&emsp;";


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
            string lastInstructor = "";

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
                            if (!sec.GetInstructor().Any())
                                continue;
                        }
                        else
                            if ((!semester.isVerified() && sec.GetHasBeenDeleted())
                                    || sec.IsHidden()
                                    || !sec.GetInstructor().Any()
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
                            printer.Write("<p style=\"font-family:monospace;\"><strong>" + Tab);
                            lastCatalogNbr = sec.GetCatalogNbr();
                            printer.Write(sec.Subject + OneSpace + sec.GetCatalogNbr() + TwoSpaces + sec.GetClassDescr());
                            if (!sec.GetTopicDescr().Equals(" "))
                                printer.Write(" - " + sec.GetTopicDescr());
                            printer.WriteLine("</strong><br>");
                        }

                        if (sec.GetHasBeenDeleted())
                            printer.Write("<span style=\"background-color: #A9A9A9\">");

                        // format section number
                        string section = padEnd(sec.GetSection(), 3);
                        section = sec.GetSectionVer() ? section : StartMark + section + EndMark;

                        //format enrollment cap
                        string enrlCap = padFront(sec.GetEnrlCap(), 3);
                        enrlCap = (sec.GetEnrlCapVer() ? enrlCap : StartMark + enrlCap + EndMark);

                        // format class association component
                        string component = padEnd(sec.GetClassAssnComponent(), 4);
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
                            times = StartMark + "     By Appointment   " + EndMark;
                        if (times.Equals("12:00 AM-12:00 AM"))
                            times = "     By Appointment   ";

                        // format faculty name
                        string faculty = sec.GetInstructor();
                        faculty = faculty.Substring(0, faculty.Length > 15 ? 15 : faculty.Length - 1);
                        faculty = padEnd(faculty, 16);
                        faculty = (sec.GetInstructorVer() ? faculty : StartMark + faculty + EndMark);

                        // format building and classroom number
                        string facility = (sec.GetFacilityIdVer() ? "" : StartMark) + padEnd(sec.GetFacilityId(), 8)
                                + (sec.GetFacilityIdVer() ? "" : EndMark);

                        string nonStd = standardMeetingStartDt.Equals(sec.GetMeetingStartDt()) && standardMeetingEndDt.Equals(sec.GetMeetingEndDt()) ?
                                "" : ((sec.GetMeetingStartDtVer() && sec.GetMeetingEndDtVer()) ? "   [" : TwoSpaces + StartMark + "[")
                                            + sec.GetMeetingStartDt() + "-" + sec.GetMeetingEndDt()
                                            + ((sec.GetMeetingStartDtVer() && sec.GetMeetingEndDtVer()) ? "]" : "]" + EndMark);

                        // print line
                        printer.WriteLine(Tab + Tab + section + Tab + enrlCap + Tab + component + Tab + credits + Tab + days + Tab + times + Tab
                                + facility + Tab + faculty + Tab + nonStd);

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
