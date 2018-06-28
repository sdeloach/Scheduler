using System;
using System.Collections.Generic;
using System.Linq;

namespace Scheduler
{
    public class Semester
    {
        public string Name { set; get; } = "";
        public string FileName { get; set; }

        private IGui gui;
        private List<Section> semesterList = new List<Section>(0);
        private bool Verified = false;

        public Semester(IGui gui)
        {
            this.gui = gui;
        }

        public void KSISread(string filename)
        {
            KSISCSVReader importReader = new KSISCSVReader(gui);
            Semester temp = importReader.Read(filename);
            semesterList = temp.semesterList;
            Name = temp.Name;
        }

        public void LocalRead(string filename)
        {
            LocalCSVReader localReader = new LocalCSVReader(gui);
            Semester temp = localReader.Read(filename);
            semesterList = temp.semesterList;
            Name = temp.Name;
        }

        public bool Save(string filename)
        {
            LocalCSVWriter localWriter = new LocalCSVWriter(gui);
            return localWriter.Write(filename, this);
        }

        public void VerifyAgainst(Semester KSISsemester)
        {
            // compare against KSIS data to set verification flags in each section
            this.CompareToSemester(KSISsemester);

            // create a semester sorted by instructor, the other by room
            // since semesters hold sections by reference, they "share" the sections
            Semester semesterByInstructor = this.SortByInstructor();
            Semester semesterByFacility = this.SortByFacilityId();

            //create interval list to check overlaps
            IntervalList list = new IntervalList(gui);

            try
            {
                for (int i = 0; i < semesterByInstructor.Size(); i++)
                {
                    Section sec = semesterByInstructor.ElementAt(i);
                    Interval interval = new Interval(sec.Instructor, sec.CatalogNbr, sec.SectionName,
                            ConvertTimeToInt(sec.MeetingTimeStart), ConvertTimeToInt(sec.MeetingTimeEnd), sec.MeetingStartDt,
                            sec.MeetingEndDt, sec.Mon, sec.Tues, sec.Wed, sec.Thurs, sec.Fri);

                    // ignore {0,0} and (2400,2400), sections added to denote deleted sections, and hidden files
                    if (interval.Start != interval.End && !sec.HasBeenDeleted && !sec.IsHidden)
                    {
                        list.Add(interval);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
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
                        ConvertTimeToInt(sec.MeetingTimeStart), ConvertTimeToInt(sec.MeetingTimeEnd), sec.MeetingStartDt,
                        sec.MeetingEndDt, sec.Mon, sec.Tues, sec.Wed, sec.Thurs, sec.Fri);

                // ignore sections with intervals of {0,0} and (2400,2400) as well as sections that are deleted, hidden, or not assigned to a room yet
                if (interval.Start != interval.End && !sec.HasBeenDeleted && interval.Entity.Any()
                                && !interval.Entity.StartsWith("zz") && !sec.IsHidden)
                    list.Add(interval);
            }

            // verify room schedules do not overlap
            list.CheckForOverlaps();

            this.Verified = true;
        }

        private Semester ShallowDuplicate()
        {
            var semesterCopy = new Semester(gui);
            // copy semester attributes 
            semesterCopy.Name = Name;
            semesterCopy.Verified = Verified;
            semesterCopy.FileName = FileName;
            // perform shallow copy of semester section references
            semesterList.ForEach(sec => semesterCopy.Add(sec));
            return semesterCopy;
        }

        public Semester SortByInstructor() // and then by catalog number and section
        {
            var semesterCopy = this.ShallowDuplicate();
            //semesterCopy.semesterList.Sort((x, y) => x.Instructor.CompareTo(y.Instructor));
            semesterCopy.semesterList.Sort((x, y) => 
                x.Instructor == y.Instructor ? 
                    (x.CatalogNbr == y.CatalogNbr ? string.Compare(x.SectionName, y.SectionName) : string.Compare(x.CatalogNbr, y.CatalogNbr))
                    :  string.Compare(x.Instructor, y.Instructor));
            return semesterCopy;
        }

        public Semester SortByFacilityId()
        {
            var semesterCopy = this.ShallowDuplicate();
            semesterCopy.semesterList.Sort((x, y) => x.FacilityId.CompareTo(y.FacilityId));
            return semesterCopy;
        }

        public Semester SortByCatalogNbr() // and then by section
        {
            var semesterCopy = this.ShallowDuplicate();
            //semesterCopy.semesterList.Sort((x, y) => x.CatalogNbr.CompareTo(y.CatalogNbr));
            semesterCopy.semesterList.Sort((x, y) => x.CatalogNbr == y.CatalogNbr ?
                string.Compare(x.SectionName, y.SectionName)
                : string.Compare(x.CatalogNbr, y.CatalogNbr));
            return semesterCopy;
        }

        private void CompareToSemester(Semester comparisonSemester)
        {

            if (semesterList.Count() <= 0)
            {
                gui.WriteLine("No file loaded for comparison.");
                return;
            }

            // look for sections in s but not semester
            int j = 0;
            foreach (var comparisonSection in comparisonSemester.semesterList)
            {
                bool found = false;
                foreach (var section in semesterList)
                    if (section.CatalogNbr.Equals(comparisonSection.CatalogNbr) && section.SectionName.Equals(comparisonSection.SectionName))
                    {
                        found = true;
                        break;
                    }

                // add section to semester to denote problem
                if (!found)
                {
                    Section sec = new Section(comparisonSection.Subject, comparisonSection.CatalogNbr,
                        comparisonSection.ClassDescr, comparisonSection.SectionName, comparisonSection.Instructor,
                        comparisonSection.Consent, comparisonSection.EnrlCap, comparisonSection.TopicDescr,
                        comparisonSection.MeetingStartDt, comparisonSection.MeetingEndDt,
                        comparisonSection.FacilityId, comparisonSection.MeetingTimeStart,
                        comparisonSection.MeetingTimeEnd, comparisonSection.Mon, comparisonSection.Tues,
                        comparisonSection.Wed, comparisonSection.Thurs, comparisonSection.Fri,
                        comparisonSection.Sat, comparisonSection.Sun, comparisonSection.UnitsMin,
                        comparisonSection.UnitsMax, comparisonSection.ClassAssnComponent, "", "");
                    semesterList.Insert(0, sec);
                    //semesterList.Add(comparisonSection);
                    sec.HasBeenDeleted = true;
                }
                j++;
            }

            // look for sections in semester but not s

            foreach (var section in semesterList)
            {
                bool found = false;
                foreach (var comparisonSection in comparisonSemester.semesterList)
                    if (section.CatalogNbr.Equals(comparisonSection.CatalogNbr) && section.SectionName.Equals(comparisonSection.SectionName))
                        found = true;
                if (!found)
                    section.FlagChangesFromSection(new Section());
            }

            // reset verification flags against the correct section
            foreach (var section in semesterList)
                foreach (var comparisonSection in comparisonSemester.semesterList)
                    if (section.CatalogNbr.Equals(comparisonSection.CatalogNbr) && section.SectionName.Equals(comparisonSection.SectionName))
                    {
                        if (section.FlagChangesFromSection(comparisonSection))
                            break;
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
        private int ConvertTimeToInt(string s)
        {
            bool am = s.Trim().EndsWith("AM");
            s = s.PadLeft(8, '0');
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

        // Retrun true if semester has been verified against KSIS semester
        public bool IsVerified()
        {
            return this.Verified;
        }

        public void Add(Section s)
        {
            semesterList.Add(s);
        }

    }
}