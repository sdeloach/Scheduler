using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler
{
    public class Configuration
    {
        private string configFilename = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Scheduler\\bin\\config.properties";
        private Dictionary<string, string> list = new Dictionary<string, string>();

        public Configuration()
        {
            if (System.IO.File.Exists(configFilename))
                loadFromFile(configFilename);
        }

        private void loadFromFile(string file)
        {
            foreach (string line in System.IO.File.ReadAllLines(file))
            {
                if ((!String.IsNullOrEmpty(line)) &&
                    (!line.StartsWith(";")) &&
                    (!line.StartsWith("#")) &&
                    (!line.StartsWith("'")) &&
                    (line.Contains('=')))
                {
                    int index = line.IndexOf('=');
                    string key = line.Substring(0, index).Trim();
                    string value = line.Substring(index + 1).Trim();

                    if ((value.StartsWith("\"") && value.EndsWith("\"")) ||
                        (value.StartsWith("'") && value.EndsWith("'")))
                    {
                        value = value.Substring(1, value.Length - 2);
                    }

                    try
                    {
                        //ignore dublicates
                        list.Add(key, value);
                    }
                    catch { }
                }
            }
        }

        public string getICSDIRECTORY()
        {
            return ValueFor("icsdirectory");
        }

        public string getMSWORD()
        {
            return ValueFor("msword");
        }

        public string getWEBBROWSER()
        {
            return ValueFor("webbrowser");
        }

        private string ValueFor(string field, string defValue)
        {
            return (ValueFor(field) == null) ? (defValue) : (ValueFor(field));
        }

        private string ValueFor(string field)
        {
            return (list.ContainsKey(field)) ? (list[field]) : (null);
        }

    }
}
