using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Scheduler
{
    class CalendarPrinter : IPrinter
    {
        private IGui gui;
        private string[] roomList = { "DUE1114", "DUE1116", "DUE1117", "other", "graduate", "undergraduate", "preprofessional", "professional", "service" };

        public CalendarPrinter(IGui gui)
        {
            this.gui = gui;
        }

        public string Print(Semester semester, bool printAllSections, bool printAllDates)
        {
            if (semester == null)
            {
                MessageBox.Show("No semester loaded.");
            }
            else
            {

                // open file for each room in roomList array defined above
                //open file
                try
                {
                    string lastCatalogNbr = "";
                    string lastSection = "";
                    
                    foreach (var room in roomList)
                    {
                        string filename = Configuration.ICSDIRECTORY + semester.Name + " - " + room + ".ics";
                        using (System.IO.StreamWriter printer = new System.IO.StreamWriter(filename, false))
                        {
                            // print header
                            printer.WriteLine("BEGIN:VCALENDAR");
                            printer.WriteLine("PRODID:-//Microsoft Corporation//Outlook 16.0 MIMEDIR//EN");
                            printer.WriteLine("VERSION:2.0");
                            printer.WriteLine("METHOD:PUBLISH");
                            printer.WriteLine("X-MS-OLK-FORCEINSPECTOROPEN:TRUE");
                            printer.WriteLine("BEGIN:VTIMEZONE");
                            printer.WriteLine("TZID:Central Standard Time");
                            printer.WriteLine("BEGIN:STANDARD");
                            printer.WriteLine("DTSTART:16011104T020000"); //
                            printer.WriteLine("RRULE:FREQ=YEARLY;BYDAY=1SU;BYMONTH=11");
                            printer.WriteLine("TZOFFSETFROM:-0500");
                            printer.WriteLine("TZOFFSETTO:-0600");
                            printer.WriteLine("END:STANDARD");
                            printer.WriteLine("BEGIN:DAYLIGHT");
                            printer.WriteLine("DTSTART:16010311T020000");
                            printer.WriteLine("RRULE:FREQ=YEARLY;BYDAY=2SU;BYMONTH=3");
                            printer.WriteLine("TZOFFSETFROM:-0600");
                            printer.WriteLine("TZOFFSETTO:-0500");
                            printer.WriteLine("END:DAYLIGHT");
                            printer.WriteLine("END:VTIMEZONE");

                            // start processing courses as calendar events
                            for (int x = 0; x < semester.Size(); x++)
                            {
                                Section sec = semester.ElementAt(x);
                                string catNumber = sec.CatalogNbr;

                                // don't add event for second/third instructors of same section
                                if (catNumber.Equals(lastCatalogNbr) && sec.SectionName.Equals(lastSection))
                                    continue;
                                else
                                {
                                    lastCatalogNbr = catNumber;
                                    lastSection = sec.SectionName;
                                }

                                // combine courses with co-taught numbers into a single event, but only create event for lowest catalog number
                                CoTaughtCourses cotaught = new CoTaughtCourses(gui);
                                string ctc = cotaught.CoTaughtCourseOf(catNumber);
                                if (ctc.Any())
                                {
                                    int cNum = int.Parse(catNumber);
                                    int ctcNum = int.Parse(ctc);
                                    if ((!room.Equals("graduate") && !room.Equals("undergraduate"))
                                            || (room.Equals("graduate") && IsGraduateCourse(cNum) && IsGraduateCourse(ctcNum))
                                            || (room.Equals("undergraduate") && IsUnderGraduateCourse(cNum) && IsUnderGraduateCourse(ctcNum)))
                                    {
                                        if (cNum > ctcNum)
                                            continue; // skip courses whose number is greater than their cotaught course
                                        else
                                            catNumber += "/" + ctc;
                                    }
                                }

                                // skip sections we are not interested in scheduling
                                if (NonPrintedSection(sec, room))
                                    continue; // do not print these sections
                                else
                                {
                                    // format values for event

                                    string today = ICSToday();

                                    string startDate = ICSDate(sec.MeetingStartDt);
                                    string endDate = ICSDate(AddDaysToDate(sec.MeetingEndDt, 1)); // add 1 day to last class date
                                    string startTime = ICSTime(sec.MeetingTimeStart);
                                    string endTime = ICSTime(sec.MeetingTimeEnd);

                                    string daysOfWeek = ICSDaysOfWeek(sec);

                                    startDate = ICSDate(CalculateActualStartDate(sec.MeetingStartDt, daysOfWeek));

                                    // print out lines for sections of interest
                                    printer.WriteLine("BEGIN:VEVENT");
                                    printer.WriteLine("CATEGORIES:Student/Teaching");
                                    printer.WriteLine("CLASS:PUBLIC");
                                    printer.WriteLine("CREATED:" + today);
                                    printer.WriteLine("DESCRIPTION:" + sec.Subject + " " + catNumber + "  " + sec.ClassDescr
                                                        + (!sec.TopicDescr.Equals(" ") ? " - " + sec.TopicDescr : ""));
                                    printer.WriteLine("DTEND;TZID=\"Central Standard Time\":" + startDate + endTime + "00");
                                    printer.WriteLine("DTSTAMP:" + today);
                                    printer.WriteLine("DTSTART;TZID=\"Central Standard Time\":" + startDate + startTime + "00");
                                    printer.WriteLine("LAST-MODIFIED:" + today);
                                    printer.WriteLine("LOCATION:" + sec.FacilityId);
                                    printer.WriteLine("PRIORITY:5");
                                    printer.WriteLine("RRULE:FREQ=WEEKLY;UNTIL=" + endDate + "000000" + ";" + daysOfWeek);
                                    printer.WriteLine("SEQUENCE:0");
                                    printer.WriteLine("SUMMARY;LANGUAGE=en-us:" + sec.Subject + " " + catNumber + " - "
                                                        + sec.SectionName + " (" + sec.Instructor + ")");
                                    printer.WriteLine("TRANSP:OPAQUE");
                                    printer.WriteLine("UID:" + Guid.NewGuid());
                                    printer.WriteLine("X-ALT-DESC;");
                                    printer.WriteLine("X-MICROSOFT-CDO-BUSYSTATUS:BUSY");
                                    printer.WriteLine("X-MICROSOFT-CDO-IMPORTANCE:1");
                                    printer.WriteLine("X-MICROSOFT-DISALLOW-COUNTER:FALSE");
                                    printer.WriteLine("X-MS-OLK-AUTOFILLLOCATION:FALSE");
                                    printer.WriteLine("X-MS-OLK-AUTOSTARTCHECK:FALSE");
                                    printer.WriteLine("X-MS-OLK-CONFTYPE:0");
                                    printer.WriteLine("END:VEVENT");
                                }
                            }
                            printer.WriteLine("END:VCALENDAR");
                        }
                    }
                }
                catch (Exception e)
                {
                    gui.WriteLine(e.Message);
                }

                gui.WriteLine("Calendar events generated.");
            }
            return "";
        }

        private bool NonPrintedSection(Section sec, string room)
        {
            int catNbr = int.Parse(sec.CatalogNbr);
            return sec.IsHidden || !sec.Instructor.Any()
                                || catNbr == 497 || catNbr == 999 || catNbr == 990 || catNbr == 899 || catNbr == 897 || catNbr == 898 || catNbr == 895
                                || (catNbr == 690 && sec.TopicDescr.Equals(" "))
                                || (catNbr == 798 && sec.TopicDescr.Equals("Top/Vary By Student"))
                                || (catNbr == 890 && sec.TopicDescr.Equals("Top/Vary By Student"))
                                || (sec.MeetingTimeStart.Equals("12:00 AM") && sec.MeetingTimeEnd.Equals("12:00 AM"))
                                || (sec.SectionName.StartsWith("Z"))
                                || (!room.Equals(sec.FacilityId) && !IsOtherRoom(sec.FacilityId, room))
                                // For graduate, undergraduate, and service listings
                                && !((room.Equals("graduate") && IsGraduateCourse(catNbr))
                                      || (room.Equals("preprofessional") && IsPreprofessionalCourse(catNbr))
                                      || (room.Equals("professional") && IsProfessionalCourse(catNbr))
                                      || (room.Equals("undergraduate") && IsUnderGraduateCourse(catNbr) && !IsServiceCourse(catNbr))
                                      || (room.Equals("service") && IsServiceCourse(catNbr)));
        }

        private string CalculateActualStartDate(string startDate, string daysOfWeek)
        {
            // startDate = mm/dd/yyyy
            // daysOfWeek = "dd,dd,..."

            string startDay = GetDay(startDate); // should be "Monday", "Tuesday", etc.

            int startDayInt = -1;
            if (startDay.ToUpper().Equals("MONDAY")) startDayInt = 1;
            if (startDay.ToUpper().Equals("TUESDAY")) startDayInt = 2;
            if (startDay.ToUpper().Equals("WEDNESDAY")) startDayInt = 3;
            if (startDay.ToUpper().Equals("THURSDAY")) startDayInt = 4;
            if (startDay.ToUpper().Equals("FRIDAY")) startDayInt = 5;

            var meetingDaysList = new List<int>(0);
            if (daysOfWeek.ToUpper().Contains("MO")) meetingDaysList.Add(1);
            if (daysOfWeek.ToUpper().Contains("TU")) meetingDaysList.Add(2);
            if (daysOfWeek.ToUpper().Contains("WE")) meetingDaysList.Add(3);
            if (daysOfWeek.ToUpper().Contains("TH")) meetingDaysList.Add(4);
            if (daysOfWeek.ToUpper().Contains("FR")) meetingDaysList.Add(5);

            // if the class starts of the first day of the semester just return that day
            for (int i = 0; i < meetingDaysList.Count; i++)
            {
                if (meetingDaysList.ElementAt(i) == startDayInt)
                    return startDate;
            }

            // otherwise, if course start later in the same week as semester starts
            int diff = 0;
            if (meetingDaysList.Count > 0)
            {
                for (int i = 0; i < meetingDaysList.Count; i++)
                {
                    if (startDayInt < meetingDaysList.ElementAt(i))
                    {
                        diff = meetingDaysList.ElementAt(i) - startDayInt;
                        break;
                    }
                }

                // otherwise, course start the week after the semester starts
                if (startDayInt > meetingDaysList.ElementAt(meetingDaysList.Count - 1))
                    diff = 7 - (startDayInt - meetingDaysList.ElementAt(meetingDaysList.Count - 1));
            }

            return AddDaysToDate(startDate, diff);
        }

        // returns day of week in text for a given date
        private string GetDay(string date)
        {

            string month = date.Substring(0, date.IndexOf("/"));
            if (month.Length == 1)
                month = "0" + month;

            string temp = date.Substring(date.IndexOf("/") + 1);

            string day = temp.Substring(0, temp.IndexOf("/"));
            if (day.Length == 1)
                day = "0" + day;

            string year = temp.Substring(temp.IndexOf("/") + 1);
            if (year.Length == 1)
                year = "0" + year;

            return new DateTime(int.Parse(year), int.Parse(month), int.Parse(day)).DayOfWeek.ToString();
        }

        private string AddDaysToDate(string initialDate, int days)
        {
            DateTime newDate = Convert.ToDateTime(initialDate).AddDays(days);
            return newDate.ToString();
        }

        private string ICSToday()
        {
            return DateTime.Now.ToString("yyyyMMdd'T'HHmmss'Z'");
        }

        private string ICSDaysOfWeek(Section sec)
        {

            string byDay = "BYDAY=";
            if (sec.Mon.Equals("Y"))
                byDay += "MO";
            if (sec.Tues.Equals("Y"))
                byDay += (byDay.Length == 6 ? "" : ",") + "TU";
            if (sec.Wed.Equals("Y"))
                byDay += (byDay.Length == 6 ? "" : ",") + "WE";
            if (sec.Thurs.Equals("Y"))
                byDay += (byDay.Length == 6 ? "" : ",") + "TH";
            if (sec.Fri.Equals("Y"))
                byDay += (byDay.Length == 6 ? "" : ",") + "FR";

            return byDay;
        }

        // takes date in "mm/dd/yyyy" and converts it to "yyyymmddT" format
        private string ICSDate(string date)
        {
            // strip anything after first space
            if (date.IndexOf(" ") > 0)
                date = date.Substring(0, date.IndexOf(" "));

            // copy the month part of date
            string month = date.Substring(0, date.IndexOf("/")).PadLeft(2, '0');

            //remove the month
            string ddyyy = date.Substring(date.IndexOf("/") + 1);

            // copy the day part of date
            string day = ddyyy.Substring(0, ddyyy.IndexOf("/")).PadLeft(2, '0');

            string year = ddyyy.Substring(ddyyy.IndexOf("/") + 1).PadLeft(2, '0');
            return year + month + day + "T";
        }

        // convert string in form "12:00 AM" or 3:45 PM" to 1200 or 1545 integers
        private string ICSTime(string s)
        {
            bool AM = s.Trim().EndsWith("AM");
            s = s.PadLeft(8, '0');
            s = (s.Substring(0, 2) + s.Substring(3, 2)).Trim();
            if (!s.Any()) return "";
            if (AM) return s;
            else
            {
                int x = int.Parse(s);
                if (x < 1200) x += 1200;
                return x.ToString();
            }
        }

        private bool IsOtherRoom(string facility, string room)
        {
            if (room.Equals("other"))
            {
                foreach (var rm in roomList)
                    if (facility.Equals(rm))
                        return false;
                return true;
            }
            else return false;
        }

        private bool IsGraduateCourse(int catNbr)
        {
            return catNbr > 599;
        }

        private bool IsUnderGraduateCourse(int catNbr)
        {
            return catNbr < 700;
        }

        private bool IsPreprofessionalCourse(int catNbr)
        {
            return (catNbr == 115 || catNbr == 200 || catNbr == 300 || catNbr == 301 || catNbr == 241 || catNbr == 015);
        }
        private bool IsProfessionalCourse(int catNbr)
        {
            return IsUnderGraduateCourse(catNbr) && !IsPreprofessionalCourse(catNbr) && !IsServiceCourse(catNbr);
        }

        private bool IsServiceCourse(int catNbr)
        {
            return (catNbr == 101 || catNbr == 102 || catNbr == 103 || catNbr == 104 || catNbr == 111 || catNbr == 209);
        }
    }
}
