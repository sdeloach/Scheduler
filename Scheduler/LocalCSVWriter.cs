using System;
using System.IO;

namespace Scheduler
{
    public class LocalCSVWriter
    {
        IGui gui;

        public LocalCSVWriter(IGui gui)
        {
            this.gui = gui;
        }

        public bool Write(string filename, Semester semester)
        {
            StreamWriter file = null;

            try
            {
                try
                {
                    file = new StreamWriter(filename);
                }
                catch (Exception e)
                {
                    gui.WriteLine(e.Message);
                    return false;
                }
               
                // printer header in file		
                file.WriteLine(semester.Name);
                file.WriteLine("Subject,CatalogNbr,ClassDescr,Section,Instructor,Consent,EnrlCap,TopicDescr,MeetingStartDt,MeetingEndDt,FacilityId,"
                                + "MeetingTimeStart,MeetingTimeEnd,Mon,Tues,Wed,Thurs,Fri,Sat,SunUnitsMin,UnitsMax,ClassAssnComponent,Hidden,MyNotes");

                // print each section as a line of data in CSV format
                for (int x = 0; x < semester.Size(); x++)
                {
                    Section sec = semester.ElementAt(x);
                    file.WriteLine(sec.Subject + "," + sec.CatalogNbr + "," + sec.ClassDescr + ","
                            + sec.SectionName + ",\"" + sec.Instructor + "\"," + sec.Consent + ","
                            + sec.EnrlCap + "," + sec.TopicDescr + "," + sec.MeetingStartDt + "," + sec.MeetingEndDt + ","
                            + sec.FacilityId + "," + sec.MeetingTimeStart + "," + sec.MeetingTimeEnd + ","
                            + sec.Mon + "," + sec.Tues + "," + sec.Wed + "," + sec.Thurs + ","
                            + sec.Fri + "," + sec.Sat + "," + sec.Sun + "," + sec.UnitsMin + ","
                            + sec.UnitsMax + "," + sec.ClassAssnComponent + ","
                            + sec.Hidden + "," + sec.MyNotes);
                }

                return true;

            }
            catch (IOException e)
            {
                gui.WriteLine(e.Message);
                return false;
            }
            finally
            {
                if (file != null)
                {
                    file.Close();
                }
            }
        }
    }
}