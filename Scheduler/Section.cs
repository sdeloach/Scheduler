using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scheduler
{
    public class Section
    {

        public string Name { get; set; } = "";
        public string Subject { get; set; } = "";
        public string CatalogNbr { get; set; } = "";
        private string ClassDescr = "";
        private string SectionName = "";
        private string Consent = "";
        private string EnrlCap = "";
        private string TopicDescr = "";
        private string MeetingStartDt = "";
        private string MeetingEndDt = "";
        private string FacilityId = "";
        private string MeetingTimeStart = "";
        private string MeetingTimeEnd = "";
        private string Mon = "";
        private string Tues = "";
        private string Wed = "";
        private string Thurs = "";
        private string Fri = "";
        private string Sat = "";
        private string Sun = "";
        private string Instructor = "";
        private string UnitsMin = "";
        private string UnitsMax = "";
        private string ClassAssnComponent = "";
        private string myNotes = ""; // holds local notes only
        private string Hidden = ""; // determines if we should hide section - local only

        private bool HasBeenDeleted = false;
        private bool STRMVer = true;
        private bool SubjectVer = true;
        private bool CatalogNbrVer = true;
        private bool ClassDescrVer = true;
        private bool SectionVer = true;
        private bool ConsentVer = true;
        private bool EnrlCapVer = true;
        private bool TopicDescrVer = true;
        private bool MeetingStartDtVer = true;
        private bool MeetingEndDtVer = true;
        private bool FacilityIdVer = true;
        private bool MeetingTimeStartVer = true;
        private bool MeetingTimeEndVer = true;
        private bool MonVer = true;
        private bool TuesVer = true;
        private bool WedVer = true;
        private bool ThursVer = true;
        private bool FriVer = true;
        private bool SatVer = true;
        private bool SunVer = true;
        private bool InstructorVer = true;
        private bool UnitsMinVer = true;
        private bool UnitsMaxVer = true;
        private bool ClassAssnComponentVer = true;

        // general constructor that sets no initial values
        public Section()
        {
        }

        // constructor for creating KSIS version of sections with all attributes
        public Section(string courseID, string classNbr, string offerNbr, string sTRM, string session, string acadGroup,
                string subject, string catalogNbr, string classDescr, string acadCareer, string component,
                string enrlStatus, string classStatus, string classType, string section, string associatedClass,
                string autoEnroll1, string autoEnroll2, string schedulePrint, string consent, string roomCapRequest,
                string enrlCap, string enrlTotal, string waitCap, string waitTotal, string minEnrl, string topicId,
                string topicDescr, string printTopic, string acadOrg, string nextStdntPosition, string location,
                string roomEventNbr, string instructionMode, string startDt, string endDt, string meetingStartDt,
                string meetingEndDt, string cancelDt, string combinedSection, string classMtgNbr1, string facilityId,
                string meetingTimeStart, string meetingTimeEnd, string mon, string tues, string wed, string thurs,
                string fri, string sat, string sun, string instructor, string instreID, string classMtgNbr2,
                string instrRole, string schedPrintInstr, string roomChrstc1, string roomChrstc2, string classNotesSeq,
                string printAt, string classNoteNbr, string printNoteWOCls, string classNoteLong, string classNote,
                string rsrvCapNbr, string resCapEnrlCap, string resCapEnrlTot, string rqrmntGroup1, string rqrmntGroupDesc,
                string roomChrstcQty, string unitsMin, string unitsMax, string unitsAcadProg, string gradingBasis,
                string gradeRosterPrint, string classAssnComponent, string rqrmntGroup2, string useCatlgRqs,
                string sctnCombinedId, string combSecClassNbr, string combSecDescription, string classTableDescr,
                string cmbndSubject, string cmbndCatNbr, string rqmntDesigntn, string rqmntDesigDescr,
                string rqmntDesigDescrformal, string classAttr, string classAttrDescr, string attrValue,
                string attrValueDescr, string reportDate)
        {
            setupParameters(subject, catalogNbr, classDescr, section, instructor, consent, enrlCap, topicDescr, meetingStartDt, meetingEndDt,
                            facilityId, meetingTimeStart, meetingTimeEnd, mon, tues, wed, thurs, fri, sat, sun, unitsMin, unitsMax,
                            classAssnComponent, "FALSE", "");
        }

        // constructor for creating local version of section that do not include values
        // for all attributes
        public Section(string subject, string catalogNbr, string classDescr, string section, string instructor,
                string consent, string enrlCap, string topicDescr, string meetingStartDt, string meetingEndDt,
                string facilityId, string meetingTimeStart, string meetingTimeEnd, string mon, string tues, string wed,
                string thurs, string fri, string sat, string sun, string unitsMin, string unitsMax,
                string classAssnComponent, string hidden, string mynotes)
        {
            setupParameters(subject, catalogNbr, classDescr, section, instructor, consent, enrlCap, topicDescr, meetingStartDt, meetingEndDt,
                   facilityId, meetingTimeStart, meetingTimeEnd, mon, tues, wed, thurs, fri, sat, sun, unitsMin, unitsMax,
                   classAssnComponent, hidden, mynotes);
        }

        private void setupParameters(string subject, string catalogNbr, string classDescr, string section, string instructor,
                    string consent, string enrlCap, string topicDescr, string meetingStartDt, string meetingEndDt,
                    string facilityId, string meetingTimeStart, string meetingTimeEnd, string mon, string tues, string wed,
                    string thurs, string fri, string sat, string sun, string unitsMin, string unitsMax,
                    string classAssnComponent, string hidden, string mynotes)
        {
            Subject = subject;
            CatalogNbr = catalogNbr.PadLeft(3, '0');
            ClassDescr = classDescr;
            SectionName = section;
            Consent = consent;
            EnrlCap = enrlCap;
            TopicDescr = topicDescr;
            MeetingStartDt = meetingStartDt;
            MeetingEndDt = meetingEndDt;
            FacilityId = facilityId;
            MeetingTimeStart = meetingTimeStart;
            MeetingTimeEnd = meetingTimeEnd;
            Mon = mon;
            Tues = tues;
            Wed = wed;
            Thurs = thurs;
            Fri = fri;
            Sat = sat;
            Sun = sun;
            //strip " at beginning/end if needed
            Instructor = instructor.Trim('\"');
            UnitsMin = unitsMin;
            UnitsMax = unitsMax;
            ClassAssnComponent = classAssnComponent;
            myNotes = mynotes;
            Hidden = hidden;
        }

        public bool compare(Section verSec)
        {
            this.setSubjectVer(this.Subject.Equals(verSec.Subject));
            this.setCatalogNbrVer(this.CatalogNbr.Equals(verSec.CatalogNbr));
            this.setClassDescrVer(this.GetClassDescr().Equals(verSec.GetClassDescr()));
            this.setSectionVer(this.GetSection().Equals(verSec.GetSection()));
            this.setConsentVer(this.GetConsent().Equals(verSec.GetConsent()));
            this.setEnrlCapVer(this.GetEnrlCap().Equals(verSec.GetEnrlCap()));
            this.setTopicDescrVer(this.GetTopicDescr().Equals(verSec.GetTopicDescr()));
            this.setMeetingStartDtVer(this.GetMeetingStartDt().Equals(verSec.GetMeetingStartDt()));
            this.setMeetingEndDtVer(this.GetMeetingEndDt().Equals(verSec.GetMeetingEndDt()));
            this.setFacilityIdVer(this.GetFacilityId().Equals(verSec.GetFacilityId()));
            this.setMeetingTimeStartVer(this.GetMeetingTimeStart().Equals(verSec.GetMeetingTimeStart()));
            this.setMeetingTimeEndVer(this.GetMeetingTimeEnd().Equals(verSec.GetMeetingTimeEnd()));
            this.setMonVer(this.GetMon().Equals(verSec.GetMon()));
            this.setTuesVer(this.GetTues().Equals(verSec.GetTues()));
            this.setWedVer(this.GetWed().Equals(verSec.GetWed()));
            this.setThursVer(this.GetThurs().Equals(verSec.GetThurs()));
            this.setFriVer(this.GetFri().Equals(verSec.GetFri()));
            this.setSatVer(this.GetSat().Equals(verSec.GetSat()));
            this.setSunVer(this.GetSun().Equals(verSec.GetSun()));
            this.setInstructorVer(this.GetInstructor().Equals(verSec.GetInstructor()));
            this.setUnitsMinVer(this.GetUnitsMin().Equals(verSec.GetUnitsMin()));
            this.setUnitsMaxVer(this.GetUnitsMax().Equals(verSec.GetUnitsMax()));
            this.setClassAssnComponentVer(this.GetClassAssnComponent().Equals(verSec.GetClassAssnComponent()));

            return this.GetSubjectVer() && this.GetCatalogNbrVer() && this.GetClassDescrVer() && this.GetSectionVer()
                    && this.GetConsentVer() && this.GetEnrlCapVer() && this.GetTopicDescrVer()
                    && this.GetMeetingStartDtVer() && this.GetMeetingEndDtVer() && this.GetFacilityIdVer()
                    && this.GetMeetingTimeStartVer() && this.GetMeetingTimeEndVer() && this.GetMonVer() && this.GetTuesVer()
                    && this.GetWedVer() && this.GetThursVer() && this.GetFriVer() && this.GetSatVer() && this.GetSunVer()
                    && this.GetInstructorVer() && this.GetUnitsMinVer() && this.GetUnitsMaxVer()
                    && this.GetClassAssnComponentVer();
        }

        public bool HasBeenChanged()
        {
            return !(SubjectVer && GetCatalogNbrVer() && GetClassDescrVer() && GetSectionVer()
                    && GetConsentVer() && GetEnrlCapVer() && GetTopicDescrVer()
                    && GetMeetingStartDtVer() && GetMeetingEndDtVer() && GetFacilityIdVer()
                    && GetMeetingTimeStartVer() && GetMeetingTimeEndVer() && GetMonVer() && GetTuesVer()
                    && GetWedVer() && GetThursVer() && GetFriVer() && GetSatVer() && GetSunVer()
                    && GetInstructorVer() && GetUnitsMinVer() && GetUnitsMaxVer()
                    && GetClassAssnComponentVer());
        }

        public override string ToString()
        {
            return "Section \n     Subject= [" + Subject + "] - " + SubjectVer
                    + "\n    CatalogNbr= [" + CatalogNbr + "] - " + CatalogNbrVer
                    + "\n    Section= [" + SectionName + "] - " + SectionVer
                    + "\n    ClassDescr= [" + ClassDescr + "] - " + ClassDescrVer
                    + "\n    TopicDescr= [" + TopicDescr + "] - " + TopicDescrVer
                    + "\n    ClassAssnComponent= [" + ClassAssnComponent + "] - " + ClassAssnComponentVer
                    + "\n    Instructor= [" + Instructor + "] - " + InstructorVer
                    + "\n    Time = [" + MeetingTimeStart + "-" + MeetingTimeEnd + "]"
                    + "\n    Room= [" + FacilityId + "] - " + FacilityIdVer
                    + "\n    myNotes=" + myNotes;
        }

        public string GetClassDescr()
        {
            return ClassDescr;
        }

        public void setClassDescr(string classDescr)
        {
            ClassDescr = classDescr;
        }

        public string GetSection()
        {
            return SectionName;
        }

        public void setSection(string section)
        {
            SectionName = section;
        }

        public string GetConsent()
        {
            return Consent;
        }

        public void setConsent(string consent)
        {
            Consent = consent;
        }

        public string GetEnrlCap()
        {
            return EnrlCap;
        }

        public void setEnrlCap(string enrlCap)
        {
            EnrlCap = enrlCap;
        }

        public string GetTopicDescr()
        {
            return TopicDescr;
        }

        public void setTopicDescr(string topicDescr)
        {
            TopicDescr = topicDescr;
        }

        public string GetMeetingStartDt()
        {
            return MeetingStartDt;
        }

        public void setMeetingStartDt(string meetingStartDt)
        {
            MeetingStartDt = meetingStartDt;
        }

        public string GetMeetingEndDt()
        {
            return MeetingEndDt;
        }

        public void setMeetingEndDt(string meetingEndDt)
        {
            MeetingEndDt = meetingEndDt;
        }

        public string GetMeetingTimeStart()
        {
            return MeetingTimeStart;
        }

        public void setMeetingTimeStart(string meetingTimeStart)
        {
            MeetingTimeStart = meetingTimeStart;
        }

        public string GetMeetingTimeEnd()
        {
            return MeetingTimeEnd;
        }

        public void setMeetingTimeEnd(string meetingTimeEnd)
        {
            MeetingTimeEnd = meetingTimeEnd;
        }

        public string GetFacilityId()
        {
            return FacilityId;
        }

        public void setFacilityId(string facilityId)
        {
            FacilityId = facilityId;
        }

        public string GetMon()
        {
            return Mon;
        }

        public void setMon(string mon)
        {
            Mon = mon;
        }

        public string GetTues()
        {
            return Tues;
        }

        public void setTues(string tues)
        {
            Tues = tues;
        }

        public string GetWed()
        {
            return Wed;
        }

        public void setWed(string wed)
        {
            Wed = wed;
        }

        public string GetThurs()
        {
            return Thurs;
        }

        public void setThurs(string thurs)
        {
            Thurs = thurs;
        }

        public string GetFri()
        {
            return Fri;
        }

        public void setFri(string fri)
        {
            Fri = fri;
        }

        public string GetSat()
        {
            return Sat;
        }

        public void setSat(string sat)
        {
            Sat = sat;
        }

        public string GetSun()
        {
            return Sun;
        }

        public void setSun(string sun)
        {
            Sun = sun;
        }

        public string GetInstructor()
        {
            return Instructor;
        }

        public void setInstructor(string instructor)
        {
            Instructor = instructor;
        }

        public string GetUnitsMin()
        {
            return UnitsMin;
        }

        public void setUnitsMin(string unitsMin)
        {
            UnitsMin = unitsMin;
        }

        public string GetUnitsMax()
        {
            return UnitsMax;
        }

        public void setUnitsMax(string unitsMax)
        {
            UnitsMax = unitsMax;
        }

        public string GetClassAssnComponent()
        {
            return ClassAssnComponent;
        }

        public void setClassAssnComponent(string classAssnComponent)
        {
            ClassAssnComponent = classAssnComponent;
        }

        public string GetMyNotes()
        {
            return myNotes;
        }

        public void GetMyNotes(string mynotes)
        {
            myNotes = mynotes;
        }

        public bool IsHidden()
        {
            return GetHidden().ToLower().Equals("true");
        }

        public string GetHidden()
        {
            return Hidden;
        }

        public void setHidden(string hidden)
        {
            if (hidden.Equals("") || hidden.ToLower().Equals("false"))
                Hidden = "FALSE";
            else
                Hidden = "TRUE";
        }

        public bool GetHasBeenDeleted()
        {
            return this.HasBeenDeleted;
        }

        public void SetHasBeenDeleted(bool kSISVerified)
        {
            HasBeenDeleted = kSISVerified;
        }

        public bool GetSTRMVer()
        {
            return STRMVer;
        }

        public void setSTRMVer(bool sTRMVer)
        {
            STRMVer = sTRMVer;
        }

        public bool GetSubjectVer()
        {
            return SubjectVer;
        }

        public void setSubjectVer(bool subjectVer)
        {
            SubjectVer = subjectVer;
        }

        public bool GetCatalogNbrVer()
        {
            return CatalogNbrVer;
        }

        public void setCatalogNbrVer(bool catalogNbrVer)
        {
            CatalogNbrVer = catalogNbrVer;
        }

        public bool GetClassDescrVer()
        {
            return ClassDescrVer;
        }

        public void setClassDescrVer(bool classDescrVer)
        {
            ClassDescrVer = classDescrVer;
        }

        public bool GetSectionVer()
        {
            return SectionVer;
        }

        public void setSectionVer(bool sectionVer)
        {
            SectionVer = sectionVer;
        }

        public bool GetConsentVer()
        {
            return ConsentVer;
        }

        public void setConsentVer(bool consentVer)
        {
            ConsentVer = consentVer;
        }

        public bool GetEnrlCapVer()
        {
            return EnrlCapVer;
        }

        public void setEnrlCapVer(bool enrlCapVer)
        {
            EnrlCapVer = enrlCapVer;
        }

        public bool GetTopicDescrVer()
        {
            return TopicDescrVer;
        }

        public void setTopicDescrVer(bool topicDescrVer)
        {
            TopicDescrVer = topicDescrVer;
        }

        public bool GetMeetingStartDtVer()
        {
            return MeetingStartDtVer;
        }

        public void setMeetingStartDtVer(bool meetingStartDtVer)
        {
            MeetingStartDtVer = meetingStartDtVer;
        }

        public bool GetMeetingEndDtVer()
        {
            return MeetingEndDtVer;
        }

        public void setMeetingEndDtVer(bool meetingEndDtVer)
        {
            MeetingEndDtVer = meetingEndDtVer;
        }

        public bool GetFacilityIdVer()
        {
            return FacilityIdVer;
        }

        public void setFacilityIdVer(bool facilityIdVer)
        {
            FacilityIdVer = facilityIdVer;
        }

        public bool GetMeetingTimeStartVer()
        {
            return MeetingTimeStartVer;
        }

        public void setMeetingTimeStartVer(bool meetingTimeStartVer)
        {
            MeetingTimeStartVer = meetingTimeStartVer;
        }

        public bool GetMeetingTimeEndVer()
        {
            return MeetingTimeEndVer;
        }

        public void setMeetingTimeEndVer(bool meetingTimeEndVer)
        {
            MeetingTimeEndVer = meetingTimeEndVer;
        }

        public bool GetMonVer()
        {
            return MonVer;
        }

        public void setMonVer(bool monVer)
        {
            MonVer = monVer;
        }

        public bool GetTuesVer()
        {
            return TuesVer;
        }

        public void setTuesVer(bool tuesVer)
        {
            TuesVer = tuesVer;
        }

        public bool GetWedVer()
        {
            return WedVer;
        }

        public void setWedVer(bool wedVer)
        {
            WedVer = wedVer;
        }

        public bool GetThursVer()
        {
            return ThursVer;
        }

        public void setThursVer(bool thursVer)
        {
            ThursVer = thursVer;
        }

        public bool GetFriVer()
        {
            return FriVer;
        }

        public void setFriVer(bool friVer)
        {
            FriVer = friVer;
        }

        public bool GetSatVer()
        {
            return SatVer;
        }

        public void setSatVer(bool satVer)
        {
            SatVer = satVer;
        }

        public bool GetSunVer()
        {
            return SunVer;
        }

        public void setSunVer(bool sunVer)
        {
            SunVer = sunVer;
        }

        public bool GetInstructorVer()
        {
            return InstructorVer;
        }

        public void setInstructorVer(bool instructorVer)
        {
            InstructorVer = instructorVer;
        }

        public bool GetUnitsMinVer()
        {
            return UnitsMinVer;
        }

        public void setUnitsMinVer(bool unitsMinVer)
        {
            UnitsMinVer = unitsMinVer;
        }

        public bool GetUnitsMaxVer()
        {
            return UnitsMaxVer;
        }

        public void setUnitsMaxVer(bool unitsMaxVer)
        {
            UnitsMaxVer = unitsMaxVer;
        }

        public bool GetClassAssnComponentVer()
        {
            return ClassAssnComponentVer;
        }

        public void setClassAssnComponentVer(bool classAssnComponentVer)
        {
            ClassAssnComponentVer = classAssnComponentVer;
        }
    }
}