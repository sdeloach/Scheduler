using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Scheduler
{
    public class IntervalList
    {
        private List<Interval> list = new List<Interval>(0);
        private string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Scheduler\\bin\\";
        private string filename = "cotaughtCourses.csv";
        private Scheduler gui;

        private char DEFAULT_SEPARATOR = ',';
        private char DEFAULT_QUOTE = '"';

        public IntervalList(Scheduler gui)
        {
            this.gui = gui;
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
                if (int0.GetEnd() >= int1.GetStart() && int1.GetEntity().Equals(int0.GetEntity())
                        && int1.GetMeetingStart().Equals(int0.GetMeetingStart())
                        && ((int0.GetMon().Equals("Y") && int1.GetMon().Equals("Y"))
                                || (int0.GetTues().Equals("Y") && int1.GetTues().Equals("Y"))
                                || (int0.GetWed().Equals("Y") && int1.GetWed().Equals("Y"))
                                || (int0.GetThurs().Equals("Y") && int1.GetThurs().Equals("Y"))
                                || (int0.GetFri().Equals("Y") && int1.GetFri().Equals("Y"))))
                {

                    if (!IsCotaught(int0.GetCatalogNbr().Trim(), int1.GetCatalogNbr().Trim())
                            && !int1.ToString().Equals(int0.ToString()))
                    {
                        gui.printMessage("For " + int0.GetEntity() + ": " + int0.GetCatalogNbr() + " section " + int0.GetSection()
                                + " overlaps " + int1.GetCatalogNbr() + " section " + int1.GetSection());
                        result = true;
                    }
                }
            }

            return result;
        }

        private bool Overlaps(Interval one, Interval two)
        {
            if ((one.GetStart() >= two.GetStart() && one.GetStart() <= two.GetEnd()) || (one.GetEnd() >= two.GetStart() && one.GetEnd() >= two.GetEnd())
                    || (two.GetStart() >= one.GetStart() && two.GetStart() <= one.GetEnd()) || (two.GetEnd() >= one.GetStart() && two.GetEnd() >= one.GetEnd()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private List<Interval> SortByEntity()
        {

            List<Interval> listCopy = new List<Interval>();
            List<Interval> sortedList = new List<Interval>();

            // duplicate the semester data structure so we don't overwrite it
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

                        // we have found the place to insert a new entity
                        if (sortedList.ElementAt(i).GetEntity().CompareTo(interval.GetEntity()) > 0)
                        {
                            sortedList.Insert(i, interval);
                            break;
                        }

                        // we have found the entity already in the list
                        if (sortedList.ElementAt(i).GetEntity().Equals(interval.GetEntity()))
                        {
                            // skip to the end of the instructor's intervals
                            while (i < size && sortedList.ElementAt(i).GetEntity().Equals(interval.GetEntity()))
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
                        if (sortedList.ElementAt(i).GetStart() >= interval.GetStart())
                        {
                            sortedList.Insert(i, interval);
                            break;
                        }
                    }
                }
            }
            return sortedList;
        }

        public bool IsCotaught(string c1, string c2)
        {
            StreamReader readFile;
            try
            {
                readFile = new StreamReader(path + filename);
            }
            catch (Exception e)
            {
                gui.printMessage(e.Message);
                return false;
            }
            
            string line;
            while ((line = readFile.ReadLine()) != null)
            {
                List<string> data = ParseLine(line);

                if ((c1.Equals(data.ElementAt(0)) && c2.Equals(data.ElementAt(1)))
                        || (c1.Equals(data.ElementAt(1)) && c2.Equals(data.ElementAt(0))))
                {
                    readFile.Close();
                    return true;
                }
            }
            readFile.Close();
            return false;
        }


        private List<string> ParseLine(string cvsLine)
        {
            return ParseLine(cvsLine, DEFAULT_SEPARATOR, DEFAULT_QUOTE);
        }


        private List<string> ParseLine(string cvsLine, char separators)
        {
            return ParseLine(cvsLine, separators, DEFAULT_QUOTE);
        }

        private List<string> ParseLine(string cvsLine, char separators, char customQuote)
        {

            List<string> result = new List<string>();

            // if empty, return!
            if (cvsLine == null && !cvsLine.Any())
            {
                return result;
            }

            if (customQuote == ' ')
            {
                customQuote = DEFAULT_QUOTE;
            }

            if (separators == ' ')
            {
                separators = DEFAULT_SEPARATOR;
            }

            StringBuilder curVal = new StringBuilder();
            bool inQuotes = false;
            bool startCollectChar = false;
            bool doubleQuotesInColumn = false;

            char[] chars = cvsLine.ToCharArray();

            foreach (char ch in chars)
            {

                if (inQuotes)
                {
                    startCollectChar = true;
                    if (ch == customQuote)
                    {
                        inQuotes = false;
                        doubleQuotesInColumn = false;
                    }
                    else
                    {
                        if (ch == '\"')
                        {
                            if (!doubleQuotesInColumn)
                            {
                                curVal.Append(ch);
                                doubleQuotesInColumn = true;
                            }
                        }
                        else
                        {
                            curVal.Append(ch);
                        }

                    }
                }
                else
                {
                    if (ch == customQuote)
                    {

                        inQuotes = true;

                        // Fixed : allow "" in empty quote enclosed
                        if (chars[0] != '"' && customQuote == '\"')
                        {
                            curVal.Append('"');
                        }

                        // double quotes in column will hit this!
                        if (startCollectChar)
                        {
                            curVal.Append('"');
                        }

                    }
                    else if (ch == separators)
                    {

                        result.Add(curVal.ToString());

                        curVal = new StringBuilder();
                        startCollectChar = false;

                    }
                    else if (ch == '\r')
                    {
                        // ignore LF characters
                        continue;
                    }
                    else if (ch == '\n')
                    {
                        // the end, break!
                        break;
                    }
                    else
                    {
                        curVal.Append(ch);
                    }
                }

            }

            result.Add(curVal.ToString());

            return result;
        }
    }
}