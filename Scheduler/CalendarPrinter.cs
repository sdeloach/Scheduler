using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace Scheduler
{
    class CalendarPrinter 
    {
        private IGui gui;
        private string[] roomList = { "DUE1114", "DUE1116", "DUE1117", "other", "graduate", "undergraduate", "service" };

        public CalendarPrinter(IGui gui)
        {
            this.gui = gui;
        }

        public string print(Semester semester)
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

                    for (int iRoom = 0; iRoom < roomList.Length; iRoom++)
                    {
                        string filename = Configuration.ICSDIRECTORY + semester.Name + " - " + roomList[iRoom] + ".ics";
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
                                if (catNumber.Equals(lastCatalogNbr) && sec.GetSection().Equals(lastSection))
                                    continue;
                                else
                                {
                                    lastCatalogNbr = catNumber;
                                    lastSection = sec.GetSection();
                                }

                                // combine courses with co-taught numbers into a single event, but only create event for lowest catalog number
                                CoTaughtCourses cotaught = new CoTaughtCourses(gui);
                                string ctc = cotaught.coTaughtCourse(catNumber);
                                if (ctc.Any())
                                {
                                    int cNum = int.Parse(catNumber);
                                    int ctcNum = int.Parse(ctc);
                                    if ((!roomList[iRoom].Equals("graduate") && !roomList[iRoom].Equals("undergraduate"))
                                            || (roomList[iRoom].Equals("graduate") && isGraduate(cNum) && isGraduate(ctcNum))
                                            || (roomList[iRoom].Equals("undergraduate") && isUnderGraduate(cNum) && isUnderGraduate(ctcNum)))
                                    {
                                        if (cNum > ctcNum)
                                            continue; // skip courses whose number is greater than their cotaught course
                                        else
                                            catNumber += "/" + ctc;
                                    }
                                }

                                // skip sections we are not interested in scheduling
                                int catNbr = int.Parse(sec.CatalogNbr);
                                if (sec.IsHidden()
                                        || !sec.GetInstructor().Any()
                                        || catNbr == 497 || catNbr == 999 || catNbr == 990 || catNbr == 899 || catNbr == 897 || catNbr == 898 || catNbr == 895
                                        || (catNbr == 690 && sec.GetTopicDescr().Equals(" "))
                                        || (catNbr == 798 && sec.GetTopicDescr().Equals("Top/Vary By Student"))
                                        || (catNbr == 890 && sec.GetTopicDescr().Equals("Top/Vary By Student"))
                                        || (sec.GetMeetingTimeStart().Equals("12:00 AM") && sec.GetMeetingTimeEnd().Equals("12:00 AM"))
                                        || (sec.GetSection().StartsWith("Z"))
                                        || (!roomList[iRoom].Equals(sec.GetFacilityId()) && !isOtherRoom(sec.GetFacilityId(), iRoom))
                                        // For graduate, undergraduate, and service listings
                                        && !((roomList[iRoom].Equals("graduate") && isGraduate(catNbr))
                                                || (roomList[iRoom].Equals("undergraduate") && isUnderGraduate(catNbr) && !isService(catNbr))
                                                || (roomList[iRoom].Equals("service") && isService(catNbr))
                                                )
                                        )
                                    continue; // do not print these rooms
                                else
                                {
                                    // format values for event

                                    string today = icsToday();

                                    string startDate = icsDate(sec.GetMeetingStartDt());
                                    string endDate = icsDate(addDaysToDate(sec.GetMeetingEndDt(), 1)); // add 1 day to last class date
                                    string startTime = icsTime(sec.GetMeetingTimeStart());
                                    string endTime = icsTime(sec.GetMeetingTimeEnd());

                                    string daysOfWeek = icsDaysOfWeek(sec);

                                    startDate = icsDate(calculateActualStartDate(sec.GetMeetingStartDt(), daysOfWeek));

                                    // print out lines for sections of interest
                                    printer.WriteLine("BEGIN:VEVENT");
                                    printer.WriteLine("CATEGORIES:Student/Teaching");
                                    printer.WriteLine("CLASS:PUBLIC");
                                    printer.WriteLine("CREATED:" + today);
                                    printer.WriteLine("DESCRIPTION:" + sec.Subject + " " + catNumber + "  " + sec.GetClassDescr()
                                    + (!sec.GetTopicDescr().Equals(" ") ? " - " + sec.GetTopicDescr() : ""));
                                    printer.WriteLine("DTEND;TZID=\"Central Standard Time\":" + startDate + endTime + "00");
                                    printer.WriteLine("DTSTAMP:" + today);
                                    printer.WriteLine("DTSTART;TZID=\"Central Standard Time\":" + startDate + startTime + "00");
                                    printer.WriteLine("LAST-MODIFIED:" + today);
                                    printer.WriteLine("LOCATION:" + sec.GetFacilityId());
                                    printer.WriteLine("PRIORITY:5");
                                    printer.WriteLine("RRULE:FREQ=WEEKLY;UNTIL=" + endDate + "000000" + ";" + daysOfWeek);
                                    printer.WriteLine("SEQUENCE:0");
                                    printer.WriteLine("SUMMARY;LANGUAGE=en-us:" + sec.Subject + " " + catNumber + " - "
                                            + sec.GetSection() + " (" + sec.GetInstructor() + ")");
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
                            printer.Close();
                        }
                    }
                }
                catch (Exception e)
                {
                    gui.printMessage(e.Message);
                }

                gui.printMessage("Calendar events generated.");
            }
            return "";
        }

        private string calculateActualStartDate(string startDate, string daysOfWeek)
        {
            // startDate = mm/dd/yyyy
            // daysOfWeek = "dd,dd,..."

            string startDay = getDay(startDate); // should be "Monday", "Tuesday", etc.

            int x = -1;
            if (startDay.ToUpper().Equals("MONDAY")) x = 1;
            if (startDay.ToUpper().Equals("TUESDAY")) x = 2;
            if (startDay.ToUpper().Equals("WEDNESDAY")) x = 3;
            if (startDay.ToUpper().Equals("THURSDAY")) x = 4;
            if (startDay.ToUpper().Equals("FRIDAY")) x = 5;

            var y = new List<int>(0);
            if (daysOfWeek.ToUpper().Contains("MO")) y.Add(1);
            if (daysOfWeek.ToUpper().Contains("TU")) y.Add(2);
            if (daysOfWeek.ToUpper().Contains("WE")) y.Add(3);
            if (daysOfWeek.ToUpper().Contains("TH")) y.Add(4);
            if (daysOfWeek.ToUpper().Contains("FR")) y.Add(5);

            // if the class starts of the first day of the semester just return that day
            for (int i = 0; i < y.Count; i++)
            {
                if (y.ElementAt(i) == x)
                    return startDate;
            }

            // otherwise, if course start later in the same week as semester starts
            int diff = 0;
            if (y.Count > 0)
            {
                for (int i = 0; i < y.Count; i++)
                {
                    if (x < y.ElementAt(i))
                    {
                        diff = y.ElementAt(i) - x;
                        break;
                    }
                }

                // otherwise, course start the week after the semester starts
                if (x > y.ElementAt(y.Count - 1))
                    diff = 7 - (x - y.ElementAt(y.Count - 1));
            }

            return addDaysToDate(startDate, diff);
        }

        // returns day of week in text for a given date
        private string getDay(string date)
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

        private string addDaysToDate(string initialDate, int days)
        {
            DateTime newDate = Convert.ToDateTime(initialDate).AddDays(days);
            return newDate.ToString();
        }

        private string icsToday()
        {
            return DateTime.Now.ToString("yyyyMMdd'T'HHmmss'Z'");
        }

        private string icsDaysOfWeek(Section sec)
        {

            string byDay = "BYDAY=";
            if (sec.GetMon().Equals("Y"))
                byDay += "MO";
            if (sec.GetTues().Equals("Y"))
                byDay += (byDay.Length == 6 ? "" : ",") + "TU";
            if (sec.GetWed().Equals("Y"))
                byDay += (byDay.Length == 6 ? "" : ",") + "WE";
            if (sec.GetThurs().Equals("Y"))
                byDay += (byDay.Length == 6 ? "" : ",") + "TH";
            if (sec.GetFri().Equals("Y"))
                byDay += (byDay.Length == 6 ? "" : ",") + "FR";

            return byDay;
        }

        // takes date in "mm/dd/yyyy" and converts it to "yyyymmddT" format
        private string icsDate(string date)
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
        private string icsTime(string s)
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

        private bool isOtherRoom(string facility, int iRoom)
        {
            if (roomList[iRoom].Equals("other"))
            {
                for (int i = 0; i < roomList.Length - 1; i++)
                    if (facility.Equals(roomList[i]))
                        return false;
                return true;
            }
            else return false;
        }

        private bool isGraduate(int catNbr)
        {
            return catNbr > 599;
        }

        private bool isUnderGraduate(int catNbr)
        {
            return catNbr < 700;
        }

        private bool isService(int catNbr)
        {
            return (catNbr == 101 || catNbr == 102 || catNbr == 103 || catNbr == 104 || catNbr == 111 || catNbr == 209);
        }
    }
}
