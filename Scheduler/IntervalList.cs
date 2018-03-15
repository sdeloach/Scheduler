using System.Collections.Generic;
using System.Linq;

namespace Scheduler
{
    public class IntervalList
    {
        private List<Interval> list = new List<Interval>(0);
        private IGui gui;
        private CoTaughtCourses ctc;
        
        public IntervalList(IGui gui)
        {
            this.gui = gui;
            ctc = new CoTaughtCourses(gui);
        }

        public void Add(Interval i)
        {
            list.Add(i);
        }

        public Interval Get(int i)
        {
            return list.ElementAt(i);
        }

        public int Size()
        {
            return list.Count();
        }

        // Function to check if any two intervals overlap
        public bool CheckForOverlaps()
        {
            bool result = false;

            list = this.SortByStartTime();
            list = this.SortByEntity();

            for (int i = 1; i < list.Count(); i++)
            {
                Interval int0 = list.ElementAt(i - 1);
                Interval int1 = list.ElementAt(i);

                // int0.end >= int1.start assumes lists are sorted by start time
                if (int0.End >= int1.Start && int1.Entity.Equals(int0.Entity)
                        && int1.MeetingStart.Equals(int0.MeetingStart)
                        && ((int0.Mon.Equals("Y") && int1.Mon.Equals("Y"))
                                || (int0.Tues.Equals("Y") && int1.Tues.Equals("Y"))
                                || (int0.Wed.Equals("Y") && int1.Wed.Equals("Y"))
                                || (int0.Thurs.Equals("Y") && int1.Thurs.Equals("Y"))
                                || (int0.Fri.Equals("Y") && int1.Fri.Equals("Y"))))
                {

                    if (!ctc.isCotaught(int0.CatalogNbr, int1.CatalogNbr) && !int1.ToString().Equals(int0.ToString()))
                    {
                        gui.printMessage("For " + int0.Entity + ": " + int0.CatalogNbr + " section " + int0.Section
                                + " overlaps " + int1.CatalogNbr + " section " + int1.Section);
                        result = true;
                    }
                }
            }

            return result;
        }

        private bool Overlaps(Interval one, Interval two)
        {
            return (one.Start >= two.Start && one.Start <= two.End) 
                || (one.End >= two.Start && one.End >= two.End)
                || (two.Start >= one.Start && two.Start <= one.End) 
                || (two.End >= one.Start && two.End >= one.End);  
        }

        //public List<Interval> SortByEntity()
        //{
        //    var copyList = this.ShallowDuplicate();
        //    copyList.Sort((x, y) => x.Entity.CompareTo(y.Entity));
        //    return copyList;
        //}
        //public List<Interval> SortByStartTime()
        //{
        //    var copyList = this.ShallowDuplicate();
        //    copyList.Sort((x, y) => x.Start.CompareTo(y.Start));
        //    return copyList;
        //}

        private List<Interval> ShallowDuplicate()
        {
            var copyList = new List<Interval>();
            list.ForEach(interval => copyList.Add(interval));
            return copyList;
        }

        private List<Interval> SortByEntity()
        {

            var listCopy = ShallowDuplicate();
            var sortedList = new List<Interval>();

            while (listCopy.Any())
            {
                Interval interval = listCopy.ElementAt(0);
                listCopy.Remove(interval);

                int size = sortedList.Count();
                if (size == 0)
                    sortedList.Add(interval);
                else
                {
                    for (int i = 0; i <= size; i++)
                    {
                        if (i == size)
                        {
                            sortedList.Add(interval);
                            break;
                        }

                        // we have found the place to insert a new entity
                        if (sortedList.ElementAt(i).Entity.CompareTo(interval.Entity) > 0)
                        {
                            sortedList.Insert(i, interval);
                            break;
                        }

                        // we have found the entity already in the list
                        if (sortedList.ElementAt(i).Entity.Equals(interval.Entity))
                        {
                            // skip to the end of the instructor's intervals
                            while (i < size && sortedList.ElementAt(i).Entity.Equals(interval.Entity))
                                i++;
                            sortedList.Insert(i, interval);
                            break;
                        }
                    }
                }
            }
            return sortedList;
        }

        private List<Interval> SortByStartTime()
        {

            List<Interval> listCopy = new List<Interval>();
            List<Interval> sortedList = new List<Interval>();

            // duplicate semester so we don't ruin it
            for (int x = 0; x < list.Count(); x++)
            {
                Interval interval = list.ElementAt(x);
                listCopy.Add(interval);
            }

            while (listCopy.Any())
            {
                Interval interval = listCopy.ElementAt(0);
                listCopy.Remove(interval);

                int size = sortedList.Count();
                if (size == 0)
                    sortedList.Add(interval);
                else
                {
                    for (int i = 0; i <= size; i++)
                    {
                        if (i == size)
                        {
                            sortedList.Add(interval);
                            break;
                        }

                        // we have found the place to insert a new start time
                        if (sortedList.ElementAt(i).Start >= interval.Start)
                        {
                            sortedList.Insert(i, interval);
                            break;
                        }
                    }
                }
            }
            return sortedList;
        }
    }
}