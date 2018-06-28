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

        // Function to check if any two intervals overlap
        public void CheckForOverlaps()
        {            
            // sort interval list by entity then by start time
            SortListByEntityThenStartTime();

            // loop through list looking at each pair of intervals
            for (int i = 1; i < list.Count(); i++)
            {
 //               
                Interval int1 = list.ElementAt(i);

                for (int j = 0; j <= i; j++)
                {
                    Interval int0 = list.ElementAt(j);

                    // if entities are equal but times overlap on the same days
                    if (int0.End >= int1.Start && int1.Entity.Equals(int0.Entity)
                            && int1.MeetingStart.Equals(int0.MeetingStart)
                            && ((int0.Mon.Equals("Y") && int1.Mon.Equals("Y"))
                                    || (int0.Tues.Equals("Y") && int1.Tues.Equals("Y"))
                                    || (int0.Wed.Equals("Y") && int1.Wed.Equals("Y"))
                                    || (int0.Thurs.Equals("Y") && int1.Thurs.Equals("Y"))
                                    || (int0.Fri.Equals("Y") && int1.Fri.Equals("Y"))))
                        // then if they aren't cotaught courses or the same course number then write error message
                        if (!ctc.IsCotaught(int0.CatalogNbr, int1.CatalogNbr) && !int1.ToString().Equals(int0.ToString()))
                            gui.WriteLine("For " + int0.Entity + ": " + int0.CatalogNbr + " section " + int0.Section
                                    + " overlaps " + int1.CatalogNbr + " section " + int1.Section);
                }
            }
        }

        private void SortListByEntityThenStartTime()
        {
            list.Sort((x, y) => x.Entity == y.Entity ? x.Start.CompareTo(y.Start) : string.Compare(x.Entity, y.Entity));
        }
    }
}