using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scheduler
{
    public class Semester
    {
        Scheduler gui;
        private List<Section> semester = new List<Section>(0);
        private string name = "";

        public Semester(Scheduler gui)
        {
            this.gui = gui;
        }

        public void KSISread(string filename)
        {
            KSISCSVReader importReader = new KSISCSVReader(gui);
            Semester temp = importReader.read(filename);
            semester = temp.semester;
            name = temp.name;
        }

        public void localRead(string filename)
        {
            LocalCSVReader localReader = new LocalCSVReader(gui);
            Semester temp = localReader.Read(filename);
            semester = temp.semester;
            name = temp.name;
        }

        public bool save(string filename)
        {
            LocalCSVWriter localWriter = new LocalCSVWriter(gui);
            return localWriter.write(filename, this);
        }

        public void verify(Semester KSISsemester)
        {
            // compare against KSIS data to highlight as appropriate when printing
            this.compareToSemester(KSISsemester);

            // create two semesters, one sorted by instructor, the other by room
            // sort semesters by instructor and facility
            // note - semesters hold sections by reference, thus they "share" the sections
            Semester sI = this.sortByInstructor();
            Semester sF = this.sortByFacilityId();

            //create interval list to check overlaps
            IntervalList list = new IntervalList(gui);

            for (int i = 0; i < sI.Count(); i++)
            {
                Section sec = sI.ElementAt(i);
                Interval interval = new Interval(sec.GetInstructor(), sec.GetCatalogNbr(), sec.GetSection(),
                        convertToInt(sec.GetMeetingTimeStart()), convertToInt(sec.GetMeetingTimeEnd()), sec.GetMeetingStartDt(),
                        sec.GetMeetingEndDt(), sec.GetMon(), sec.GetTues(), sec.GetWed(), sec.GetThurs(), sec.GetFri());

                // ignore {0,0} and (2400,2400), sections added to denote deleted sections, and hidden files
                if (interval.GetStart() != interval.GetEnd() && !sec.GetKSISVerified() && !sec.GetHidden().ToLower().Equals("true"))
                {
                    list.Add(interval);
                }
            }

            // verify instructor schedules do not overlap
            list.CheckForOverlaps();

            //create interval list to check overlaps
            list = new IntervalList(gui);

            for (int i = 0; i < sF.Count(); i++)
            {
                Section sec = sF.ElementAt(i);
                Interval interval = new Interval(sec.GetFacilityId(), sec.GetCatalogNbr(), sec.GetSection(),
                        convertToInt(sec.GetMeetingTimeStart()), convertToInt(sec.GetMeetingTimeEnd()), sec.GetMeetingStartDt(),
                        sec.GetMeetingEndDt(), sec.GetMon(), sec.GetTues(), sec.GetWed(), sec.GetThurs(), sec.GetFri());

                // ignore {0,0} and (2400,2400), sections added to denote deleted sections, and hidden files, and classes not assigned to rooms
                if (interval.GetStart() != interval.GetEnd() && !sec.GetKSISVerified() && interval.GetEntity().Any()
                        && !interval.GetEntity().StartsWith("zz")
                        && !sec.GetHidden().Equals("true", StringComparison.InvariantCultureIgnoreCase))
                {
                    list.Add(interval);
                }
            }

            // verify room schedules do not overlap
            list.CheckForOverlaps();
        }

        private Semester Duplicate()
        {
            var semesterCopy = new Semester(gui); 
            semester.ForEach(sec => semesterCopy.Add(sec));
            return semesterCopy;
        }

        private Semester sortByInstructor()
        {
            var semesterCopy = this.Duplicate();
            semesterCopy.semester.Sort((x, y) => x.GetInstructor().CompareTo(y.GetInstructor()));
            return semesterCopy;

            //while (s1.semester.Any())
            //{
            //    Section section = s1.ElementAt(0);
            //    s1.Remove(section);

            //    int size = s2.Size();
            //    if (size == 0)
            //        s2.Add(section);
            //    else
            //    {
            //        for (int i = 0; i <= size; i++)
            //        {
            //            if (i == size)
            //            {
            //                s2.Add(section);
            //                break;
            //            }

            //            // we have found the place to insert a new instructor 
            //            if (s2.ElementAt(i).GetInstructor().CompareTo(section.GetInstructor()) > 0)
            //            {
            //                s2.Insert(i, section);
            //                break;
            //            }

            //            // we have found the instructor already in the list
            //            if (s2.ElementAt(i).GetInstructor().Equals(section.GetInstructor()))
            //            {
            //                // skip to the end of the instructor's sections
            //                while (i < size && s2.ElementAt(i).GetInstructor().Equals(section.GetInstructor())) i++;
            //                s2.Insert(i, section);
            //                break;
            //            }
            //        }
            //    }
            //}
        }

        private Semester sortByFacilityId()
        {
            var semesterCopy = this.Duplicate();
            semesterCopy.semester.Sort((x, y) => x.GetFacilityId().CompareTo(y.GetFacilityId()));
            return semesterCopy;

            //Semester s2 = new Semester(gui); // new semester sorted by instructor
            //Semester s1 = new Semester(gui);    // duplicate of original semester

            //// duplicate semester so we don't ruin it
            //for (int x = 0; x < semester.Count; x++)
            //{
            //    Section sec = semester.ElementAt(x);
            //    s1.Add(sec);
            //}

            //while (!s1.isEmpty())
            //{
            //    Section section = s1.ElementAt(0);
            //    s1.Remove(section);

            //    int size = s2.Size();
            //    if (size == 0)
            //        s2.Add(section);
            //    else
            //    {
            //        for (int i = 0; i <= size; i++)
            //        {
            //            if (i == size)
            //            {
            //                s2.Add(section);
            //                break;
            //            }

            //            // we have found the place to insert a new instructor 
            //            if (s2.ElementAt(i).GetFacilityId().CompareTo(section.GetFacilityId()) > 0)
            //            {
            //                s2.Insert(i, section);
            //                break;
            //            }

            //            // we have found the instructor already in the list
            //            if (s2.ElementAt(i).GetFacilityId().Equals(section.GetFacilityId()))
            //            {
            //                // skip to the end of the instructor's sections
            //                while (i < size && s2.ElementAt(i).GetFacilityId().Equals(section.GetFacilityId())) i++;
            //                s2.Insert(i, section);
            //                break;
            //            }
            //        }
            //    }
            //}
            //return s2;
        }


        private void compareToSemester(Semester s)
        {

            if (semester.Count() <= 0)
            {
                gui.printMessage("No file loaded for comparison.");
                return;
            }

            // look for sections in s but not semester
            for (int j = 0; j < s.Size(); j++)
            {
                bool found = false;
                for (int i = 0; i < semester.Count(); i++)
                {
                    if (semester.ElementAt(i).GetCatalogNbr().Equals(s.ElementAt(j).GetCatalogNbr())
                            && semester.ElementAt(i).GetSection().Equals(s.ElementAt(j).GetSection()))
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
                    semester.Insert(j++, sec);
                    sec.setKSISVerified(true);
                }
            }

            // look for sections in semester but not s
            for (int i = 0; i < semester.Count(); i++)
            {
                for (int j = 0; j < s.Size(); j++)
                    if (semester.ElementAt(i).GetCatalogNbr().Equals(s.ElementAt(j).GetCatalogNbr()) && semester.ElementAt(i).GetSection().Equals(s.ElementAt(j).GetSection()))
                        break;
                Section sec = new Section();
                semester.ElementAt(i).compare(sec);
            }

            // check to ensure sections that match are valid
            for (int i = 0; i < semester.Count; i++)
            {
                for (int j = 0; j < s.Size(); j++)
                {
                    if (semester.ElementAt(i).GetCatalogNbr().Equals(s.ElementAt(j).GetCatalogNbr()) && semester.ElementAt(i).GetSection().Equals(s.ElementAt(j).GetSection()))
                    {
                        if (semester.ElementAt(i).compare(s.ElementAt(j)))
                            break;

                    }
                }
            }
        }


        public int Count()
        {
            return semester.Count;
        }

        public Section ElementAt(int j)
        {
            return semester.ElementAt(j);
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

        public bool isEmpty()
        {
            return !semester.Any();
        }

        public void Add(Section s)
        {
            semester.Add(s);
        }

        public void Insert(int i, Section s)
        {
            semester.Insert(i, s);
        }

        public void Remove(Section s)
        {
            semester.Remove(s);
        }

        public Section get(int x)
        {
            return semester.ElementAt(x);
        }

        public Section Replace(int x, Section s)
        {
            semester.RemoveAt(x);
            this.semester.Insert(x, s);
            return s;
        }

        public int Size()
        {
            return semester.Count;
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