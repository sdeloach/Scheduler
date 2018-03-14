using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Scheduler
{
    public class LocalCSVWriter
    {
        IGui gui;

        public LocalCSVWriter(IGui gui)
        {
            this.gui = gui;
        }

        public Boolean write(string filename, Semester semester)
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
                    gui.printMessage(e.Message);
                    return false;
                }
               
                // printer header in file		
                file.WriteLine(semester.GetName());
                file.WriteLine("Subject,CatalogNbr,ClassDescr,Section,Instructor,Consent,EnrlCap,TopicDescr,MeetingStartDt,MeetingEndDt,FacilityId,"
                                + "MeetingTimeStart,MeetingTimeEnd,Mon,Tues,Wed,Thurs,Fri,Sat,SunUnitsMin,UnitsMax,ClassAssnComponent,Hidden,MyNotes");

                // print each section as a line of data in CSV format
                for (int x = 0; x < semester.Size(); x++)
                {
                    Section sec = semester.ElementAt(x);
                    file.WriteLine(sec.Subject + "," + sec.CatalogNbr + "," + sec.GetClassDescr() + ","
                            + sec.GetSection() + ",\"" + sec.GetInstructor() + "\"," + sec.GetConsent() + ","
                            + sec.GetEnrlCap() + "," + sec.GetTopicDescr() + "," + sec.GetMeetingStartDt() + "," + sec.GetMeetingEndDt() + ","
                            + sec.GetFacilityId() + "," + sec.GetMeetingTimeStart() + "," + sec.GetMeetingTimeEnd() + ","
                            + sec.GetMon() + "," + sec.GetTues() + "," + sec.GetWed() + "," + sec.GetThurs() + ","
                            + sec.GetFri() + "," + sec.GetSat() + "," + sec.GetSun() + "," + sec.GetUnitsMin() + ","
                            + sec.GetUnitsMax() + "," + sec.GetClassAssnComponent() + ","
                            + sec.GetHidden() + "," + sec.GetMyNotes()
                            );
                }

                return true;

            }
            catch (IOException e)
            {
                gui.printMessage(e.Message);
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