using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scheduler
{
    class CoTaughtCourses
    {

        private string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        private string filename = "cotaughtCourses.csv";
        private Scheduler gui;
        private char DEFAULT_SEPARATOR = ',';
        private char DEFAULT_QUOTE = '"';

        public CoTaughtCourses(Scheduler gui)
        {
            this.gui = gui;
        }

        public string coTaughtCourse(string course)
        {
            StreamReader readFile;
            try
            {
                readFile = new StreamReader(filename);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return "";
            }

            List<string> data;
            string line;
            while ((line = readFile.ReadLine()) != null)
            {
                data = ParseLine(line);
                
                if (course.Equals(data.ElementAt(0)))
                {
                    readFile.Close();
                    return data.ElementAt(1);
                }
                else if (course.Equals(data.ElementAt(1)))
                {
                    readFile.Close();
                    return data.ElementAt(0);
                }
            }

            readFile.Close();
            return "";
        }

        public bool isCotaught(string course1, string course2)
        {
            return coTaughtCourse(course1).Equals(course2);
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
