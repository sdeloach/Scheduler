using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Scheduler
{
    static class Utility
    {
        static public void RunProcess(string filename, string arguments)
        {
            // Prepare the process to run
            ProcessStartInfo start = new ProcessStartInfo();
            // Enter in the command line arguments, everything you would enter after the executable name itself
            start.Arguments = arguments;
            // Enter the executable to run, including the complete path
            start.FileName = filename;
            // Do you want to show a console window?
            start.WindowStyle = ProcessWindowStyle.Normal;
            start.CreateNoWindow = true;
            Process proc = Process.Start(start);
        }

        static private char DEFAULT_SEPARATOR = ',';
        static private char DEFAULT_QUOTE = '"';

        static public List<string> ParseLine(string cvsLine)
        {
            return ParseLine(cvsLine, DEFAULT_SEPARATOR, DEFAULT_QUOTE);
        }

        static public List<string> ParseLine(string cvsLine, char separators)
        {
            return ParseLine(cvsLine, separators, DEFAULT_QUOTE);
        }

        // these two helper functions cannot be replace with .PadRight/.PadLeft
        // since we are padding with strings "&nbsp;" instead of characters
        public static string PadRightWithString(string str, int length)
        {
            for (int i = str.Length; i < length; i++)
                str += "&nbsp;";
            return str;
        }

        public static string PadFrontWithString(string str, int length)
        {
            for (int i = str.Length; i < length; i++)
                str = "&nbsp;" + str;
            return str;
        }

        static public List<string> ParseLine(string cvsLine, char separators, char customQuote)
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
