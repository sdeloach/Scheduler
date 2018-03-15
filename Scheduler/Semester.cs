using System.Collections.Generic;
using System.Linq;

namespace Scheduler
{
    public class Semester
    {
        IGui gui;
        private List<Section> semesterList = new List<Section>(0);
        public string Name { set; get; } = "";
        private bool verified = false;
        public string filename { get; set; }

        public Semester(IGui gui)
        {
            this.gui = gui;
        }

        public void KSISread(string filename)
        {
            KSISCSVReader importReader = new KSISCSVReader(gui);
            Semester temp = importReader.read(filename);
            semesterList = temp.semesterList;
            Name = temp.Name;
        }

        public void localRead(string filename)
        {
            LocalCSVReader localReader = new LocalCSVReader(gui);
            Semester temp = localReader.Read(filename);
            semesterList = temp.semesterList;
            Name = temp.Name;
        }

        public bool save(string filename)
        {
            LocalCSVWriter localWriter = new LocalCSVWriter(gui);
            return localWriter.write(filename, this);
        }

        public void verifyAgainst(Semester KSISsemester)
        {
            // compare against KSIS data to set verification flags in each section
            this.compareToSemester(KSISsemester);

            // create a semester sorted by instructor, the other by room
            // since semesters hold sections by reference, they "share" the sections
            Semester semesterByInstructor = this.sortByInstructor();
            Semester semesterByFacility = this.sortByFacilityId();

            //create interval list to check overlaps
            IntervalList list = new IntervalList(gui);

            for (int i = 0; i < semesterByInstructor.Size(); i++)
            {
                Section sec = semesterByInstructor.ElementAt(i);
                Interval interval = new Interval(sec.Instructor, sec.CatalogNbr, sec.SectionName,
                        convertTimeToInt(sec.MeetingTimeStart), convertTimeToInt(sec.MeetingTimeEnd), sec.MeetingStartDt,
                        sec.MeetingEndDt, sec.Mon, sec.Tues, sec.Wed, sec.Thurs, sec.Fri);

                // ignore {0,0} and (2400,2400), sections added to denote deleted sections, and hidden files
                if (interval.Start != interval.End && !sec.HasBeenDeleted && !sec.IsHidden)
                {
                    list.Add(interval);
                }
            }

            // verify instructor schedules do not overlap
            list.CheckForOverlaps();

            //create interval list to check overlaps
            list = new IntervalList(gui);

            for (int i = 0; i < semesterByFacility.Size(); i++)
            {
                // create an interval for each section in the semester
                Section sec = semesterByFacility.ElementAt(i);
                Interval interval = new Interval(sec.FacilityId, sec.CatalogNbr, sec.SectionName,
                        convertTimeToInt(sec.MeetingTimeStart), convertTimeToInt(sec.MeetingTimeEnd), sec.MeetingStartDt,
                        sec.MeetingEndDt, sec.Mon, sec.Tues, sec.Wed, sec.Thurs, sec.Fri);

                // ignore sections with intervals of {0,0} and (2400,2400) as well as sections that are deleted, hidden, or not assigned to a room yet
                if (interval.Start != interval.End && !sec.HasBeenDeleted && interval.Entity.Any()
                                && !interval.Entity.StartsWith("zz") && !sec.IsHidden)
                    list.Add(interval);
            }

            // verify room schedules do not overlap
            list.CheckForOverlaps();

            this.verified = true;
        }

        private Semester ShallowDuplicate()
        {
            var semesterCopy = new Semester(gui);
            // copy semester attributes 
            semesterCopy.Name = Name;
            semesterCopy.verified = verified;
            semesterCopy.filename = filename;
            // perform shallow copy of semester section references
            semesterList.ForEach(sec => semesterCopy.Add(sec));
            return semesterCopy;
        }

        public Semester sortByInstructor()
        {
            var semesterCopy = this.ShallowDuplicate();
            semesterCopy.semesterList.Sort((x, y) => x.Instructor.CompareTo(y.Instructor));
            return semesterCopy;
        }

        public Semester sortByFacilityId()
        {
            var semesterCopy = this.ShallowDuplicate();
            semesterCopy.semesterList.Sort((x, y) => x.FacilityId.CompareTo(y.FacilityId));
            return semesterCopy;
        }

        public Semester sortByCatalogNbr()
        {
            var semesterCopy = this.ShallowDuplicate();
            semesterCopy.semesterList.Sort((x, y) => x.CatalogNbr.CompareTo(y.CatalogNbr));
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
                    if (semesterList.ElementAt(i).CatalogNbr.Equals(s.ElementAt(j).CatalogNbr)
                            && semesterList.ElementAt(i).SectionName.Equals(s.ElementAt(j).SectionName))
                    {
                        found = true;
                        break;
                    }
                }

                // add section to semester to denote problem
                if (!found)
                {
                    Section sec = new Section(s.ElementAt(j).Subject, s.ElementAt(j).CatalogNbr, s.ElementAt(j).ClassDescr,
                            s.ElementAt(j).SectionName, s.ElementAt(j).Instructor, s.ElementAt(j).Consent, s.ElementAt(j).EnrlCap,
                            s.ElementAt(j).TopicDescr, s.ElementAt(j).MeetingStartDt, s.ElementAt(j).MeetingEndDt,
                            s.ElementAt(j).FacilityId, s.ElementAt(j).MeetingTimeStart, s.ElementAt(j).MeetingTimeEnd,
                            s.ElementAt(j).Mon, s.ElementAt(j).Tues, s.ElementAt(j).Wed, s.ElementAt(j).Thurs,
                            s.ElementAt(j).Fri, s.ElementAt(j).Sat, s.ElementAt(j).Sun, s.ElementAt(j).UnitsMin,
                            s.ElementAt(j).UnitsMax, s.ElementAt(j).ClassAssnComponent, s.ElementAt(j).MyNotes,
                            s.ElementAt(j).Hidden);
                    semesterList.Insert(j++, sec);
                    sec.HasBeenDeleted = true;
                }
            }

            // look for sections in semester but not s
            for (int i = 0; i < semesterList.Count(); i++)
            {
                for (int j = 0; j < s.Size(); j++)
                    if (semesterList.ElementAt(i).CatalogNbr.Equals(s.ElementAt(j).CatalogNbr) && semesterList.ElementAt(i).SectionName.Equals(s.ElementAt(j).SectionName))
                        break;
                Section sec = new Section();
                semesterList.ElementAt(i).compareTo(sec);
            }

            // check to ensure sections that match are valid
            for (int i = 0; i < semesterList.Count; i++)
            {
                for (int j = 0; j < s.Size(); j++)
                {
                    if (semesterList.ElementAt(i).CatalogNbr.Equals(s.ElementAt(j).CatalogNbr) && semesterList.ElementAt(i).SectionName.Equals(s.ElementAt(j).SectionName))
                    {
                        if (semesterList.ElementAt(i).compareTo(s.ElementAt(j)))
                            break;

                    }
                }
            }
        }

        public int Size()
        {
            return semesterList.Count;
        }

        public Section ElementAt(int j)
        {
            return semesterList.ElementAt(j);
        }
        
        // convert string in form "12:00 AM" or 3:45 PM" to 1200 or 1545 integers
        private int convertTimeToInt(string s)
        {
            bool am = s.Trim().EndsWith("AM");
            s = Utility.padFront(s, 8);
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
        
        public void Add(Section s)
        {
            semesterList.Add(s);
        }

    }
}