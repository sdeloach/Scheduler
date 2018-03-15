namespace Scheduler
{
    public class Interval
    {
        public string Entity = "";
        public string CatalogNbr { get; set; } = "";
        public string Section { get; set; } = "";
        public int Start { get; set; }
        public int End { get; set; }
        public string MeetingStart { get; set; }
        public string MeetingEnd { get; set; }
        public string Mon { get; set; }
        public string Tues { get; set; }
        public string Wed { get; set; }
        public string Thurs { get; set; }
        public string Fri { get; set; }

        public Interval(string entity, string catalogNbr, string section, int start, int end, string meetingStart,
                string meetingEnd, string mon, string tues, string wed, string thurs, string fri)
        {
            Entity = entity;
            CatalogNbr = catalogNbr;
            Section = section;
            Start = start;
            End = end;
            MeetingStart = meetingStart;
            MeetingEnd = meetingEnd;
            Mon = mon;
            Tues = tues;
            Wed = wed;
            Thurs = thurs;
            Fri = fri;
        }

        public int compareTo(Interval o)
        {
            /* For Ascending order */
            return (Start > o.Start ? 1 : -1);
        }

        public override string ToString()
        {
            return (Entity + " " + CatalogNbr + " " + Section + " " + "{" + Start + "," + End + "} [" + MeetingStart + "-"
                    + MeetingEnd + "] " + Mon + Tues + Wed + Thurs + Fri);
        }
    }
}