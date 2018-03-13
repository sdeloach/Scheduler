using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scheduler
{
    public class Semester
    {
        Scheduler gui;
        private List<Section> semesterList = new List<Section>(0);
        private string name = "";
        private bool verified = false;

        public Semester(Scheduler gui)
        {
            this.gui = gui;
        }

        public void KSISread(string filename)
        {
            KSISCSVReader importReader = new KSISCSVReader(gui);
            Semester temp = importReader.read(filename);
            semesterList = temp.semesterList;
            name = temp.name;
        }

        public void localRead(string filename)
        {
            LocalCSVReader localReader = new LocalCSVReader(gui);
            Semester temp = localReader.Read(filename);
            semesterList = temp.semesterList;
            name = temp.name;
        }

        public bool save(string filename)
        {
            LocalCSVWriter localWriter = new LocalCSVWriter(gui);
            return localWriter.write(filename, this);
        }

        public void verify(Semester KSISsemester)
        {
            // compare against KSIS data to set verification flags in each section
            // use verification flags to highlight when printing line schedules
            this.compareToSemester(KSISsemester);

            // create two semesters, one sorted by instructor, the other by room
            // sort semesters by instructor and facility
            // note - semesters hold sections by reference, thus they "share" the sections
            Semester semesterByInstructor = this.sortByInstructor();
            Semester semesterByFacility = this.sortByFacilityId();

            //create interval list to check overlaps
            IntervalList list = new IntervalList(gui);

            for (int i = 0; i < semesterByInstructor.Count(); i++)
            {
                Section sec = semesterByInstructor.ElementAt(i);
                Interval interval = new Interval(sec.GetInstructor(), sec.GetCatalogNbr(), sec.GetSection(),
                        convertToInt(sec.GetMeetingTimeStart()), convertToInt(sec.GetMeetingTimeEnd()), sec.GetMeetingStartDt(),
                        sec.GetMeetingEndDt(), sec.GetMon(), sec.GetTues(), sec.GetWed(), sec.GetThurs(), sec.GetFri());

                // ignore {0,0} and (2400,2400), sections added to denote deleted sections, and hidden files
                if (interval.GetStart() != interval.GetEnd() && !sec.GetHasBeenDeleted() && !sec.GetHidden().ToLower().Equals("true"))
                {
                    list.Add(interval);
                }
            }

            // verify instructor schedules do not overlap
            list.CheckForOverlaps();

            //create interval list to check overlaps
            list = new IntervalList(gui);

            for (int i = 0; i < semesterByFacility.Count(); i++)
            {
                Section sec = semesterByFacility.ElementAt(i);
                Interval interval = new Interval(sec.GetFacilityId(), sec.GetCatalogNbr(), sec.GetSection(),
                        convertToInt(sec.GetMeetingTimeStart()), convertToInt(sec.GetMeetingTimeEnd()), sec.GetMeetingStartDt(),
                        sec.GetMeetingEndDt(), sec.GetMon(), sec.GetTues(), sec.GetWed(), sec.GetThurs(), sec.GetFri());

                // ignore {0,0} and (2400,2400), sections added to denote deleted sections, and hidden files, and classes not assigned to rooms
                if (interval.GetStart() != interval.GetEnd() && !sec.GetHasBeenDeleted() && interval.GetEntity().Any()
                        && !interval.GetEntity().StartsWith("zz")
                        && !sec.GetHidden().Equals("true", StringComparison.InvariantCultureIgnoreCase))
                {
                    list.Add(interval);
                }
            }

            // verify room schedules do not overlap
            list.CheckForOverlaps();

            this.verified = true;
        }

        private Semester ShallowDuplicate()
        {
            var semesterCopy = new Semester(gui);
            semesterList.ForEach(sec => semesterCopy.Add(sec));
            return semesterCopy;
        }

        public void print(Semester semester)
        {
            for (int x = 0; x < semester.Count(); x++)
            {
                Section sec = semester.ElementAt(x);
                
                string section = padEnd(sec.GetSection(), 3);
                string enrlCap = padFront(sec.GetEnrlCap(), 3);
                string component = padEnd(sec.GetClassAssnComponent(), 4);
                string credits = padFront(((sec.GetUnitsMin().Equals(sec.GetUnitsMax()) ? sec.GetUnitsMin() : sec.GetUnitsMin() + "-" + sec.GetUnitsMax())), 5);
                string days = ((sec.GetMon().Equals("Y")) ? "M" : " ") + ((sec.GetTues().Equals("Y")) ? "T" : " ") + ((sec.GetWed().Equals("Y")) ? "W" : " ") + ((sec.GetThurs().Equals("Y")) ? "U" : " ") + ((sec.GetFri().Equals("Y")) ? "F" : " ");
                string times = padFront(sec.GetMeetingTimeStart(), 8) + "-" + padFront(sec.GetMeetingTimeEnd(), 8);
                if (times.Equals("12:00 AM-12:00 AM")) times = "  By Appointment  ";
                string faculty = padEnd(sec.GetInstructor().Substring(0, sec.GetInstructor().Length > 17 ? 17 : sec.GetInstructor().Length - 1), 18);
                string facility = padEnd(sec.GetFacilityId(), 8);

                Console.Write(sec.GetSubject() + " " + sec.GetCatalogNbr() + "  " + sec.GetClassDescr() + (!sec.GetTopicDescr().Equals(" ") ? " - " + sec.GetTopicDescr() : ""));
                Console.WriteLine(section + " " + enrlCap + " " + component + " " + credits + " " + days + " " + times + " " + facility + " " + faculty + " ");
            }
        }

        public Semester sortByInstructor()
        {
            var semesterCopy = this.ShallowDuplicate();
            semesterCopy.semesterList.Sort((x, y) => x.GetInstructor().CompareTo(y.GetInstructor()));
            return semesterCopy;
        }

        private Semester sortByFacilityId()
        {
            var semesterCopy = this.ShallowDuplicate();
            semesterCopy.semesterList.Sort((x, y) => x.GetFacilityId().CompareTo(y.GetFacilityId()));
            return semesterCopy;
        }


        private void compareToSemester(Semester s)
        {

            if (semesterList.Count() <= 0)
            {
                gui.printMessage("No file loaded for comparison.");
                return;
            }

            // look for sections in s but not semester
            for (int j = 0; j < s.Size(); j++)
            {
                bool found = false;
                for (int i = 0; i < semesterList.Count(); i++)
                {
                    if (semesterList.ElementAt(i).GetCatalogNbr().Equals(s.ElementAt(j).GetCatalogNbr())
                            && semesterList.ElementAt(i).GetSection().Equals(s.ElementAt(j).GetSection()))
                    {
                        found = true;
                        break;
                    }
                }

                // add section to semester to denote problem
                if (!found)
                {
                    Section sec = new Section(s.ElementAt(j).GetSubject(), s.ElementAt(j).GetCatalogNbr(), s.ElementAt(j).GetClassDescr(),
                            s.ElementAt(j).GetSection(), s.ElementAt(j).GetInstructor(), s.ElementAt(j).GetConsent(), s.ElementAt(j).GetEnrlCap(),
                            s.ElementAt(j).GetTopicDescr(), s.ElementAt(j).GetMeetingStartDt(), s.ElementAt(j).GetMeetingEndDt(),
                            s.ElementAt(j).GetFacilityId(), s.ElementAt(j).GetMeetingTimeStart(), s.ElementAt(j).GetMeetingTimeEnd(),
                            s.ElementAt(j).GetMon(), s.ElementAt(j).GetTues(), s.ElementAt(j).GetWed(), s.ElementAt(j).GetThurs(),
                            s.ElementAt(j).GetFri(), s.ElementAt(j).GetSat(), s.ElementAt(j).GetSun(), s.ElementAt(j).GetUnitsMin(),
                            s.ElementAt(j).GetUnitsMax(), s.ElementAt(j).GetClassAssnComponent(), s.ElementAt(j).GetMyNotes(),
                            s.ElementAt(j).GetHidden());
                    semesterList.Insert(j++, sec);
                    sec.SetHasBeenDeleted(true);
                }
            }

            // look for sections in semester but not s
            for (int i = 0; i < semesterList.Count(); i++)
            {
                for (int j = 0; j < s.Size(); j++)
                    if (semesterList.ElementAt(i).GetCatalogNbr().Equals(s.ElementAt(j).GetCatalogNbr()) && semesterList.ElementAt(i).GetSection().Equals(s.ElementAt(j).GetSection()))
                        break;
                Section sec = new Section();
                semesterList.ElementAt(i).compare(sec);
            }

            // check to ensure sections that match are valid
            for (int i = 0; i < semesterList.Count; i++)
            {
                for (int j = 0; j < s.Size(); j++)
                {
                    if (semesterList.ElementAt(i).GetCatalogNbr().Equals(s.ElementAt(j).GetCatalogNbr()) && semesterList.ElementAt(i).GetSection().Equals(s.ElementAt(j).GetSection()))
                    {
                        if (semesterList.ElementAt(i).compare(s.ElementAt(j)))
                            break;

                    }
                }
            }
        }

        public int Count()
        {
            return semesterList.Count;
        }

        public Section ElementAt(int j)
        {
            return semesterList.ElementAt(j);
        }

        private string padEnd(string s, int length)
        {
            for (int i = s.Length; i < length; i++)
                s += " ";
            return (s);
        }

        private string padFront(string s, int length)
        {
            for (int i = s.Length; i < length; i++)
                s = " " + s;
            return (s);
        }

        // convert string in form "12:00 AM" or 3:45 PM" to 1200 or 1545 integers
        private int convertToInt(string s)
        {
            bool am = s.Trim().EndsWith("AM");
            s = padFront(s, 8);
            s = (s.Substring(0, 2) + s.Substring(3, 2)).Trim();

            if (string.IsNullOrEmpty(s)) return 0;

            if (am)
                return int.Parse(s);
            else
            {
                int x = int.Parse(s);
                if (x < 1200) x += 1200;
                return x;
            }
        }

        public bool isVerified()
        {
            return this.verified;
        }

        public bool isEmpty()
        {
            return !semesterList.Any();
        }

        public void Add(Section s)
        {
            semesterList.Add(s);
        }

        public void Insert(int i, Section s)
        {
            semesterList.Insert(i, s);
        }

        public void Remove(Section s)
        {
            semesterList.Remove(s);
        }

        public Section get(int i)
        {
            return semesterList.ElementAt(i);
        }

        public Section Replace(int i, Section s)
        {
            semesterList.RemoveAt(i);
            this.semesterList.Insert(i, s);
            return s;
        }

        public int Size()
        {
            return semesterList.Count;
        }

        public string GetName()
        {
            return name;
        }

        public void SetName(string name)
        {
            this.name = name;
        }

    }
}