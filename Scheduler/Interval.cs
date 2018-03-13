using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scheduler
{
    public class Interval
    {
        private string entity = "";
        private string catalogNbr = "";
        private string section = "";
        private int start;
        private int end;
        private string meetingStart;
        private string meetingEnd;
        private string mon;
        private string tues;
        private string wed;
        private string thurs;
        private string fri;

        public Interval(string entity, string catalogNbr, string section, int start, int end, string meetingStart,
                string meetingEnd, string mon, string tues, string wed, string thurs, string fri)
        {
            this.entity = entity;
            this.catalogNbr = catalogNbr;
            this.section = section;
            this.start = start;
            this.end = end;
            this.meetingStart = meetingStart;
            this.meetingEnd = meetingEnd;
            this.mon = mon;
            this.tues = tues;
            this.wed = wed;
            this.thurs = thurs;
            this.fri = fri;
        }
        
    public int compareTo(Interval o)
        {
            /* For Ascending order */
            if (this.start > o.start)
                return 1;
            else
                return -1;
        }

        public override string ToString() 
        {
            return (entity + " " + catalogNbr + " " + section + " " + "{" + start + "," + end + "} [" + meetingStart + "-"
                    + meetingEnd + "] " + mon + tues + wed + thurs + fri);
        }

        public string GetEntity()
        {
            return entity;
        }

        public void setEntity(string entity)
        {
            this.entity = entity;
        }

        public string GetCatalogNbr()
        {
            return catalogNbr;
        }

        public void setCatalogNbr(string catalogNbr)
        {
            this.catalogNbr = catalogNbr;
        }

        public string GetSection()
        {
            return section;
        }

        public void setSection(string section)
        {
            this.section = section;
        }

        public int GetStart()
        {
            return start;
        }

        public void setStart(int start)
        {
            this.start = start;
        }

        public int GetEnd()
        {
            return end;
        }

        public void setEnd(int end)
        {
            this.end = end;
        }

        public string GetMeetingStart()
        {
            return meetingStart;
        }

        public void setMeetingStart(string meetingStart)
        {
            this.meetingStart = meetingStart;
        }

        public string GetMeetingEnd()
        {
            return meetingEnd;
        }

        public void setMeetingEnd(string meetingEnd)
        {
            this.meetingEnd = meetingEnd;
        }

        public string GetMon()
        {
            return mon;
        }

        public void setMon(string mon)
        {
            this.mon = mon;
        }

        public string GetTues()
        {
            return tues;
        }

        public void setTues(string tues)
        {
            this.tues = tues;
        }

        public string GetWed()
        {
            return wed;
        }

        public void setWed(string wed)
        {
            this.wed = wed;
        }

        public string GetThurs()
        {
            return thurs;
        }

        public void setThurs(string thurs)
        {
            this.thurs = thurs;
        }

        public string GetFri()
        {
            return fri;
        }

        public void setFri(string fri)
        {
            this.fri = fri;
        }
    }
}