using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scheduler
{
    public class Section
    {

        private string Name = "";
        private string CourseID = "";
        private string ClassNbr = "";
        private string OfferNbr = "";
        private string STRM = "";
        private string Session = "";
        private string AcadGroup = "";
        private string Subject = "";
        private string CatalogNbr = "";
        private string ClassDescr = "";
        private string AcadCareer = "";
        private string Component = "";
        private string EnrlStatus = "";
        private string ClassStatus = "";
        private string ClassType = "";
        private string SectionName = "";
        private string AssociatedClass = "";
        private string AutoEnroll1 = "";
        private string AutoEnroll2 = "";
        private string SchedulePrint = "";
        private string Consent = "";
        private string RoomCapRequest = "";
        private string EnrlCap = "";
        private string EnrlTotal = "";
        private string WaitCap = "";
        private string WaitTotal = "";
        private string MinEnrl = "";
        private string TopicId = "";
        private string TopicDescr = "";
        private string PrintTopic = "";
        private string AcadOrg = "";
        private string NextStdntPosition = "";
        private string Location = "";
        private string RoomEventNbr = "";
        private string InstructionMode = "";
        private string StartDt = "";
        private string EndDt = "";
        private string MeetingStartDt = "";
        private string MeetingEndDt = "";
        private string CancelDt = "";
        private string CombinedSection = "";
        private string ClassMtgNbr1 = "";
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
        private string InstreID = "";
        private string ClassMtgNbr2 = "";
        private string InstrRole = "";
        private string SchedPrintInstr = "";
        private string RoomChrstc1 = "";
        private string RoomChrstc2 = "";
        private string ClassNotesSeq = "";
        private string PrintAt = "";
        private string ClassNoteNbr = "";
        private string PrintNoteWOCls = "";
        private string ClassNoteLong = "";
        private string ClassNote = "";
        private string RsrvCapNbr = "";
        private string ResCapEnrlCap = "";
        private string ResCapEnrlTot = "";
        private string RqrmntGroup1 = "";
        private string RqrmntGroupDesc = "";
        private string RoomChrstcQty = "";
        private string UnitsMin = "";
        private string UnitsMax = "";
        private string UnitsAcadProg = "";
        private string GradingBasis = "";
        private string GradeRosterPrint = "";
        private string ClassAssnComponent = "";
        private string RqrmntGroup2 = "";
        private string UseCatlgRqs = "";
        private string SctnCombinedId = "";
        private string CombSecClassNbr = "";
        private string CombSecDescription = "";
        private string ClassTableDescr = "";
        private string CmbndSubject = "";
        private string CmbndCatNbr = "";
        private string RqmntDesigntn = "";
        private string RqmntDesigDescr = "";
        private string RqmntDesigDescrformal = "";
        private string ClassAttr = "";
        private string ClassAttrDescr = "";
        private string AttrValue = "";
        private string AttrValueDescr = "";
        private string ReportDate = "";
        private string myNotes = ""; // holds local notes only
        private string Hidden = ""; // determines if we should hide section - local only

        private Boolean HasBeenDeleted = false;
        private Boolean CourseIDVer = true;
        private Boolean ClassNbrVer = true;
        private Boolean OfferNbrVer = true;
        private Boolean STRMVer = true;
        private Boolean SessionVer = true;
        private Boolean AcadGroupVer = true;
        private Boolean SubjectVer = true;
        private Boolean CatalogNbrVer = true;
        private Boolean ClassDescrVer = true;
        private Boolean AcadCareerVer = true;
        private Boolean ComponentVer = true;
        private Boolean EnrlStatusVer = true;
        private Boolean ClassStatusVer = true;
        private Boolean ClassTypeVer = true;
        private Boolean SectionVer = true;
        private Boolean AssociatedClassVer = true;
        private Boolean AutoEnroll1Ver = true;
        private Boolean AutoEnroll2Ver = true;
        private Boolean SchedulePrintVer = true;
        private Boolean ConsentVer = true;
        private Boolean RoomCapRequestVer = true;
        private Boolean EnrlCapVer = true;
        private Boolean EnrlTotalVer = true;
        private Boolean WaitCapVer = true;
        private Boolean WaitTotalVer = true;
        private Boolean MinEnrlVer = true;
        private Boolean TopicIdVer = true;
        private Boolean TopicDescrVer = true;
        private Boolean PrintTopicVer = true;
        private Boolean AcadOrgVer = true;
        private Boolean NextStdntPositionVer = true;
        private Boolean LocationVer = true;
        private Boolean RoomEventNbrVer = true;
        private Boolean InstructionModeVer = true;
        private Boolean StartDtVer = true;
        private Boolean EndDtVer = true;
        private Boolean MeetingStartDtVer = true;
        private Boolean MeetingEndDtVer = true;
        private Boolean CancelDtVer = true;
        private Boolean CombinedSectionVer = true;
        private Boolean ClassMtgNbr1Ver = true;
        private Boolean FacilityIdVer = true;
        private Boolean MeetingTimeStartVer = true;
        private Boolean MeetingTimeEndVer = true;
        private Boolean MonVer = true;
        private Boolean TuesVer = true;
        private Boolean WedVer = true;
        private Boolean ThursVer = true;
        private Boolean FriVer = true;
        private Boolean SatVer = true;
        private Boolean SunVer = true;
        private Boolean InstructorVer = true;
        private Boolean InstreIDVer = true;
        private Boolean ClassMtgNbr2Ver = true;
        private Boolean InstrRoleVer = true;
        private Boolean SchedPrintInstrVer = true;
        private Boolean RoomChrstc1Ver = true;
        private Boolean RoomChrstc2Ver = true;
        private Boolean ClassNotesSeqVer = true;
        private Boolean PrintAtVer = true;
        private Boolean ClassNoteNbrVer = true;
        private Boolean PrintNoteWOClsVer = true;
        private Boolean ClassNoteLongVer = true;
        private Boolean ClassNoteVer = true;
        private Boolean RsrvCapNbrVer = true;
        private Boolean ResCapEnrlCapVer = true;
        private Boolean ResCapEnrlTotVer = true;
        private Boolean RqrmntGroup1Ver = true;
        private Boolean RqrmntGroupDescVer = true;
        private Boolean RoomChrstcQtyVer = true;
        private Boolean UnitsMinVer = true;
        private Boolean UnitsMaxVer = true;
        private Boolean UnitsAcadProgVer = true;
        private Boolean GradingBasisVer = true;
        private Boolean GradeRosterPrintVer = true;
        private Boolean ClassAssnComponentVer = true;
        private Boolean RqrmntGroup2Ver = true;
        private Boolean UseCatlgRqsVer = true;
        private Boolean SctnCombinedIdVer = true;
        private Boolean CombSecClassNbrVer = true;
        private Boolean CombSecDescriptionVer = true;
        private Boolean ClassTableDescrVer = true;
        private Boolean CmbndSubjectVer = true;
        private Boolean CmbndCatNbrVer = true;
        private Boolean RqmntDesigntnVer = true;
        private Boolean RqmntDesigDescrVer = true;
        private Boolean RqmntDesigDescrformalVer = true;
        private Boolean ClassAttrVer = true;
        private Boolean ClassAttrDescrVer = true;
        private Boolean AttrValueVer = true;
        private Boolean AttrValueDescrVer = true;
        private Boolean ReportDateVer = true;

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
            setName(sTRM);
            CourseID = courseID;
            ClassNbr = classNbr;
            OfferNbr = offerNbr;
            STRM = sTRM;
            Session = session;
            AcadGroup = acadGroup;
            Subject = subject;
            while (catalogNbr.Length < 3)
                catalogNbr = "0" + catalogNbr;
            CatalogNbr = catalogNbr;
            ClassDescr = classDescr;
            AcadCareer = acadCareer;
            Component = component;
            EnrlStatus = enrlStatus;
            ClassStatus = classStatus;
            ClassType = classType;
            SectionName = section;
            AssociatedClass = associatedClass;
            AutoEnroll1 = autoEnroll1;
            AutoEnroll2 = autoEnroll2;
            SchedulePrint = schedulePrint;
            Consent = consent;
            RoomCapRequest = roomCapRequest;
            EnrlCap = enrlCap;
            EnrlTotal = enrlTotal;
            WaitCap = waitCap;
            WaitTotal = waitTotal;
            MinEnrl = minEnrl;
            TopicId = topicId;
            TopicDescr = topicDescr;
            PrintTopic = printTopic;
            AcadOrg = acadOrg;
            NextStdntPosition = nextStdntPosition;
            Location = location;
            RoomEventNbr = roomEventNbr;
            InstructionMode = instructionMode;
            StartDt = startDt;
            EndDt = endDt;
            MeetingStartDt = meetingStartDt;
            MeetingEndDt = meetingEndDt;
            CancelDt = cancelDt;
            CombinedSection = combinedSection;
            ClassMtgNbr1 = classMtgNbr1;
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
            InstreID = instreID;
            ClassMtgNbr2 = classMtgNbr2;
            InstrRole = instrRole;
            SchedPrintInstr = schedPrintInstr;
            RoomChrstc1 = roomChrstc1;
            RoomChrstc2 = roomChrstc2;
            ClassNotesSeq = classNotesSeq;
            PrintAt = printAt;
            ClassNoteNbr = classNoteNbr;
            PrintNoteWOCls = printNoteWOCls;
            ClassNoteLong = classNoteLong;
            ClassNote = classNote;
            RsrvCapNbr = rsrvCapNbr;
            ResCapEnrlCap = resCapEnrlCap;
            ResCapEnrlTot = resCapEnrlTot;
            RqrmntGroup1 = rqrmntGroup1;
            RqrmntGroupDesc = rqrmntGroupDesc;
            RoomChrstcQty = roomChrstcQty;
            UnitsMin = unitsMin;
            UnitsMax = unitsMax;
            UnitsAcadProg = unitsAcadProg;
            GradingBasis = gradingBasis;
            GradeRosterPrint = gradeRosterPrint;
            ClassAssnComponent = classAssnComponent;
            RqrmntGroup2 = rqrmntGroup2;
            UseCatlgRqs = useCatlgRqs;
            SctnCombinedId = sctnCombinedId;
            CombSecClassNbr = combSecClassNbr;
            CombSecDescription = combSecDescription;
            ClassTableDescr = classTableDescr;
            CmbndSubject = cmbndSubject;
            CmbndCatNbr = cmbndCatNbr;
            RqmntDesigntn = rqmntDesigntn;
            RqmntDesigDescr = rqmntDesigDescr;
            RqmntDesigDescrformal = rqmntDesigDescrformal;
            ClassAttr = classAttr;
            ClassAttrDescr = classAttrDescr;
            AttrValue = attrValue;
            AttrValueDescr = attrValueDescr;
            ReportDate = reportDate;
            myNotes = "";
        }

        // constructor for creating local version of section that do not include values
        // for all attributes
        public Section(string subject, string catalogNbr, string classDescr, string section, string instructor,
                string consent, string enrlCap, string topicDescr, string meetingStartDt, string meetingEndDt,
                string facilityId, string meetingTimeStart, string meetingTimeEnd, string mon, string tues, string wed,
                string thurs, string fri, string sat, string sun, string unitsMin, string unitsMax,
                string classAssnComponent, string hidden, string mynotes)
        {
            Subject = subject;
            while (catalogNbr.Length < 3)
                catalogNbr = "0" + catalogNbr;
            CatalogNbr = catalogNbr;
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

            this.setSubjectVer(this.GetSubject().Equals(verSec.GetSubject()));
            this.setCatalogNbrVer(this.GetCatalogNbr().Equals(verSec.GetCatalogNbr()));
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
            return !(GetSubjectVer() && GetCatalogNbrVer() && GetClassDescrVer() && GetSectionVer()
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

        public string GetCourseID()
        {
            return CourseID;
        }

        public void setCourseID(string courseID)
        {
            CourseID = courseID;
        }

        public string GetClassNbr()
        {
            return ClassNbr;
        }

        public void setClassNbr(string classNbr)
        {
            ClassNbr = classNbr;
        }

        public string GetOfferNbr()
        {
            return OfferNbr;
        }

        public void setOfferNbr(string offerNbr)
        {
            OfferNbr = offerNbr;
        }

        public string GetSTRM()
        {
            return STRM;
        }

        public void setSTRM(string sTRM)
        {
            STRM = sTRM;
        }

        public string GetSession()
        {
            return Session;
        }

        public void setSession(string session)
        {
            Session = session;
        }

        public string GetAcadGroup()
        {
            return AcadGroup;
        }

        public void setAcadGroup(string acadGroup)
        {
            AcadGroup = acadGroup;
        }

        public string GetSubject()
        {
            return Subject;
        }

        public void setSubject(string subject)
        {
            Subject = subject;
        }

        public string GetCatalogNbr()
        {
            return CatalogNbr;
        }

        public void setCatalogNbr(string catalogNbr)
        {
            CatalogNbr = catalogNbr;
        }

        public string GetClassDescr()
        {
            return ClassDescr;
        }

        public void setClassDescr(string classDescr)
        {
            ClassDescr = classDescr;
        }

        public string GetAcadCareer()
        {
            return AcadCareer;
        }

        public void setAcadCareer(string acadCareer)
        {
            AcadCareer = acadCareer;
        }

        public string GetComponent()
        {
            return Component;
        }

        public void setComponent(string component)
        {
            Component = component;
        }

        public string GetEnrlStatus()
        {
            return EnrlStatus;
        }

        public void setEnrlStatus(string enrlStatus)
        {
            EnrlStatus = enrlStatus;
        }

        public string GetClassStatus()
        {
            return ClassStatus;
        }

        public void setClassStatus(string classStatus)
        {
            ClassStatus = classStatus;
        }

        public string GetClassType()
        {
            return ClassType;
        }

        public void setClassType(string classType)
        {
            ClassType = classType;
        }

        public string GetSection()
        {
            return SectionName;
        }

        public void setSection(string section)
        {
            SectionName = section;
        }

        public string GetAssociatedClass()
        {
            return AssociatedClass;
        }

        public void setAssociatedClass(string associatedClass)
        {
            AssociatedClass = associatedClass;
        }

        public string GetAutoEnroll1()
        {
            return AutoEnroll1;
        }

        public void setAutoEnroll1(string autoEnroll1)
        {
            AutoEnroll1 = autoEnroll1;
        }

        public string GetAutoEnroll2()
        {
            return AutoEnroll2;
        }

        public void setAutoEnroll2(string autoEnroll2)
        {
            AutoEnroll2 = autoEnroll2;
        }

        public string GetSchedulePrint()
        {
            return SchedulePrint;
        }

        public void setSchedulePrint(string schedulePrint)
        {
            SchedulePrint = schedulePrint;
        }

        public string GetConsent()
        {
            return Consent;
        }

        public void setConsent(string consent)
        {
            Consent = consent;
        }

        public string GetRoomCapRequest()
        {
            return RoomCapRequest;
        }

        public void setRoomCapRequest(string roomCapRequest)
        {
            RoomCapRequest = roomCapRequest;
        }

        public string GetEnrlCap()
        {
            return EnrlCap;
        }

        public void setEnrlCap(string enrlCap)
        {
            EnrlCap = enrlCap;
        }

        public string GetEnrlTotal()
        {
            return EnrlTotal;
        }

        public void setEnrlTotal(string enrlTotal)
        {
            EnrlTotal = enrlTotal;
        }

        public string GetWaitCap()
        {
            return WaitCap;
        }

        public void setWaitCap(string waitCap)
        {
            WaitCap = waitCap;
        }

        public string GetWaitTotal()
        {
            return WaitTotal;
        }

        public void setWaitTotal(string waitTotal)
        {
            WaitTotal = waitTotal;
        }

        public string GetMinEnrl()
        {
            return MinEnrl;
        }

        public void setMinEnrl(string minEnrl)
        {
            MinEnrl = minEnrl;
        }

        public string GetTopicId()
        {
            return TopicId;
        }

        public void setTopicId(string topicId)
        {
            TopicId = topicId;
        }

        public string GetTopicDescr()
        {
            return TopicDescr;
        }

        public void setTopicDescr(string topicDescr)
        {
            TopicDescr = topicDescr;
        }

        public string GetPrintTopic()
        {
            return PrintTopic;
        }

        public void setPrintTopic(string printTopic)
        {
            PrintTopic = printTopic;
        }

        public string GetAcadOrg()
        {
            return AcadOrg;
        }

        public void setAcadOrg(string acadOrg)
        {
            AcadOrg = acadOrg;
        }

        public string GetNextStdntPosition()
        {
            return NextStdntPosition;
        }

        public void setNextStdntPosition(string nextStdntPosition)
        {
            NextStdntPosition = nextStdntPosition;
        }

        public string GetLocation()
        {
            return Location;
        }

        public void setLocation(string location)
        {
            Location = location;
        }

        public string GetRoomEventNbr()
        {
            return RoomEventNbr;
        }

        public void setRoomEventNbr(string roomEventNbr)
        {
            RoomEventNbr = roomEventNbr;
        }

        public string GetInstructionMode()
        {
            return InstructionMode;
        }

        public void setInstructionMode(string instructionMode)
        {
            InstructionMode = instructionMode;
        }

        public string GetStartDt()
        {
            return StartDt;
        }

        public void setStartDt(string startDt)
        {
            StartDt = startDt;
        }

        public string GetEndDt()
        {
            return EndDt;
        }

        public void setEndDt(string endDt)
        {
            EndDt = endDt;
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

        public string GetCancelDt()
        {
            return CancelDt;
        }

        public void setCancelDt(string cancelDt)
        {
            CancelDt = cancelDt;
        }

        public string GetCombinedSection()
        {
            return CombinedSection;
        }

        public void setCombinedSection(string combinedSection)
        {
            CombinedSection = combinedSection;
        }

        public string GetClassMtgNbr1()
        {
            return ClassMtgNbr1;
        }

        public void setClassMtgNbr1(string classMtgNbr1)
        {
            ClassMtgNbr1 = classMtgNbr1;
        }

        public string GetFacilityId()
        {
            return FacilityId;
        }

        public void setFacilityId(string facilityId)
        {
            FacilityId = facilityId;
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

        public string GetInstreID()
        {
            return InstreID;
        }

        public void setInstreID(string instreID)
        {
            InstreID = instreID;
        }

        public string GetClassMtgNbr2()
        {
            return ClassMtgNbr2;
        }

        public void setClassMtgNbr2(string classMtgNbr2)
        {
            ClassMtgNbr2 = classMtgNbr2;
        }

        public string GetInstrRole()
        {
            return InstrRole;
        }

        public void setInstrRole(string instrRole)
        {
            InstrRole = instrRole;
        }

        public string GetSchedPrintInstr()
        {
            return SchedPrintInstr;
        }

        public void setSchedPrintInstr(string schedPrintInstr)
        {
            SchedPrintInstr = schedPrintInstr;
        }

        public string GetRoomChrstc1()
        {
            return RoomChrstc1;
        }

        public void setRoomChrstc1(string roomChrstc1)
        {
            RoomChrstc1 = roomChrstc1;
        }

        public string GetRoomChrstc2()
        {
            return RoomChrstc2;
        }

        public void setRoomChrstc2(string roomChrstc2)
        {
            RoomChrstc2 = roomChrstc2;
        }

        public string GetClassNotesSeq()
        {
            return ClassNotesSeq;
        }

        public void setClassNotesSeq(string classNotesSeq)
        {
            ClassNotesSeq = classNotesSeq;
        }

        public string GetPrintAt()
        {
            return PrintAt;
        }

        public void setPrintAt(string printAt)
        {
            PrintAt = printAt;
        }

        public string GetClassNoteNbr()
        {
            return ClassNoteNbr;
        }

        public void setClassNoteNbr(string classNoteNbr)
        {
            ClassNoteNbr = classNoteNbr;
        }

        public string GetPrintNoteWOCls()
        {
            return PrintNoteWOCls;
        }

        public void setPrintNoteWOCls(string printNoteWOCls)
        {
            PrintNoteWOCls = printNoteWOCls;
        }

        public string GetClassNoteLong()
        {
            return ClassNoteLong;
        }

        public void setClassNoteLong(string classNoteLong)
        {
            ClassNoteLong = classNoteLong;
        }

        public string GetClassNote()
        {
            return ClassNote;
        }

        public void setClassNote(string classNote)
        {
            ClassNote = classNote;
        }

        public string GetRsrvCapNbr()
        {
            return RsrvCapNbr;
        }

        public void setRsrvCapNbr(string rsrvCapNbr)
        {
            RsrvCapNbr = rsrvCapNbr;
        }

        public string GetResCapEnrlCap()
        {
            return ResCapEnrlCap;
        }

        public void setResCapEnrlCap(string resCapEnrlCap)
        {
            ResCapEnrlCap = resCapEnrlCap;
        }

        public string GetResCapEnrlTot()
        {
            return ResCapEnrlTot;
        }

        public void setResCapEnrlTot(string resCapEnrlTot)
        {
            ResCapEnrlTot = resCapEnrlTot;
        }

        public string GetRqrmntGroup1()
        {
            return RqrmntGroup1;
        }

        public void setRqrmntGroup1(string rqrmntGroup1)
        {
            RqrmntGroup1 = rqrmntGroup1;
        }

        public string GetRqrmntGroupDesc()
        {
            return RqrmntGroupDesc;
        }

        public void setRqrmntGroupDesc(string rqrmntGroupDesc)
        {
            RqrmntGroupDesc = rqrmntGroupDesc;
        }

        public string GetRoomChrstcQty()
        {
            return RoomChrstcQty;
        }

        public void setRoomChrstcQty(string roomChrstcQty)
        {
            RoomChrstcQty = roomChrstcQty;
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

        public string GetUnitsAcadProg()
        {
            return UnitsAcadProg;
        }

        public void setUnitsAcadProg(string unitsAcadProg)
        {
            UnitsAcadProg = unitsAcadProg;
        }

        public string GetGradingBasis()
        {
            return GradingBasis;
        }

        public void setGradingBasis(string gradingBasis)
        {
            GradingBasis = gradingBasis;
        }

        public string GetGradeRosterPrint()
        {
            return GradeRosterPrint;
        }

        public void setGradeRosterPrint(string gradeRosterPrint)
        {
            GradeRosterPrint = gradeRosterPrint;
        }

        public string GetClassAssnComponent()
        {
            return ClassAssnComponent;
        }

        public void setClassAssnComponent(string classAssnComponent)
        {
            ClassAssnComponent = classAssnComponent;
        }

        public string GetRqrmntGroup2()
        {
            return RqrmntGroup2;
        }

        public void setRqrmntGroup2(string rqrmntGroup2)
        {
            RqrmntGroup2 = rqrmntGroup2;
        }

        public string GetUseCatlgRqs()
        {
            return UseCatlgRqs;
        }

        public void setUseCatlgRqs(string useCatlgRqs)
        {
            UseCatlgRqs = useCatlgRqs;
        }

        public string GetSctnCombinedId()
        {
            return SctnCombinedId;
        }

        public void setSctnCombinedId(string sctnCombinedId)
        {
            SctnCombinedId = sctnCombinedId;
        }

        public string GetCombSecClassNbr()
        {
            return CombSecClassNbr;
        }

        public void setCombSecClassNbr(string combSecClassNbr)
        {
            CombSecClassNbr = combSecClassNbr;
        }

        public string GetCombSecDescription()
        {
            return CombSecDescription;
        }

        public void setCombSecDescription(string combSecDescription)
        {
            CombSecDescription = combSecDescription;
        }

        public string GetClassTableDescr()
        {
            return ClassTableDescr;
        }

        public void setClassTableDescr(string classTableDescr)
        {
            ClassTableDescr = classTableDescr;
        }

        public string GetCmbndSubject()
        {
            return CmbndSubject;
        }

        public void setCmbndSubject(string cmbndSubject)
        {
            CmbndSubject = cmbndSubject;
        }

        public string GetCmbndCatNbr()
        {
            return CmbndCatNbr;
        }

        public void setCmbndCatNbr(string cmbndCatNbr)
        {
            CmbndCatNbr = cmbndCatNbr;
        }

        public string GetRqmntDesigntn()
        {
            return RqmntDesigntn;
        }

        public void setRqmntDesigntn(string rqmntDesigntn)
        {
            RqmntDesigntn = rqmntDesigntn;
        }

        public string GetRqmntDesigDescr()
        {
            return RqmntDesigDescr;
        }

        public void setRqmntDesigDescr(string rqmntDesigDescr)
        {
            RqmntDesigDescr = rqmntDesigDescr;
        }

        public string GetRqmntDesigDescrformal()
        {
            return RqmntDesigDescrformal;
        }

        public void setRqmntDesigDescrformal(string rqmntDesigDescrformal)
        {
            RqmntDesigDescrformal = rqmntDesigDescrformal;
        }

        public string GetClassAttr()
        {
            return ClassAttr;
        }

        public void setClassAttr(string classAttr)
        {
            ClassAttr = classAttr;
        }

        public string GetClassAttrDescr()
        {
            return ClassAttrDescr;
        }

        public void setClassAttrDescr(string classAttrDescr)
        {
            ClassAttrDescr = classAttrDescr;
        }

        public string GetAttrValue()
        {
            return AttrValue;
        }

        public void setAttrValue(string attrValue)
        {
            AttrValue = attrValue;
        }

        public string GetAttrValueDescr()
        {
            return AttrValueDescr;
        }

        public void setAttrValueDescr(string attrValueDescr)
        {
            AttrValueDescr = attrValueDescr;
        }

        public string GetMyNotes()
        {
            return myNotes;
        }

        public void GetMyNotes(string mynotes)
        {
            myNotes = mynotes;
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

        public string GetReportDate()
        {
            return ReportDate;
        }

        public void setReportDate(string reportDate)
        {
            ReportDate = reportDate;
        }

        public Boolean GetHasBeenDeleted()
        {
            return this.HasBeenDeleted;
        }

        public void SetHasBeenDeleted(Boolean kSISVerified)
        {
            HasBeenDeleted = kSISVerified;
        }

        public Boolean GetCourseIDVer()
        {
            return CourseIDVer;
        }

        public void setCourseIDVer(Boolean courseIDVer)
        {
            CourseIDVer = courseIDVer;
        }

        public Boolean GetClassNbrVer()
        {
            return ClassNbrVer;
        }

        public void setClassNbrVer(Boolean classNbrVer)
        {
            ClassNbrVer = classNbrVer;
        }

        public Boolean GetOfferNbrVer()
        {
            return OfferNbrVer;
        }

        public void setOfferNbrVer(Boolean offerNbrVer)
        {
            OfferNbrVer = offerNbrVer;
        }

        public Boolean GetSTRMVer()
        {
            return STRMVer;
        }

        public void setSTRMVer(Boolean sTRMVer)
        {
            STRMVer = sTRMVer;
        }

        public Boolean GetSessionVer()
        {
            return SessionVer;
        }

        public void setSessionVer(Boolean sessionVer)
        {
            SessionVer = sessionVer;
        }

        public Boolean GetAcadGroupVer()
        {
            return AcadGroupVer;
        }

        public void setAcadGroupVer(Boolean acadGroupVer)
        {
            AcadGroupVer = acadGroupVer;
        }

        public Boolean GetSubjectVer()
        {
            return SubjectVer;
        }

        public void setSubjectVer(Boolean subjectVer)
        {
            SubjectVer = subjectVer;
        }

        public Boolean GetCatalogNbrVer()
        {
            return CatalogNbrVer;
        }

        public void setCatalogNbrVer(Boolean catalogNbrVer)
        {
            CatalogNbrVer = catalogNbrVer;
        }

        public Boolean GetClassDescrVer()
        {
            return ClassDescrVer;
        }

        public void setClassDescrVer(Boolean classDescrVer)
        {
            ClassDescrVer = classDescrVer;
        }

        public Boolean GetAcadCareerVer()
        {
            return AcadCareerVer;
        }

        public void setAcadCareerVer(Boolean acadCareerVer)
        {
            AcadCareerVer = acadCareerVer;
        }

        public Boolean GetComponentVer()
        {
            return ComponentVer;
        }

        public void setComponentVer(Boolean componentVer)
        {
            ComponentVer = componentVer;
        }

        public Boolean GetEnrlStatusVer()
        {
            return EnrlStatusVer;
        }

        public void setEnrlStatusVer(Boolean enrlStatusVer)
        {
            EnrlStatusVer = enrlStatusVer;
        }

        public Boolean GetClassStatusVer()
        {
            return ClassStatusVer;
        }

        public void setClassStatusVer(Boolean classStatusVer)
        {
            ClassStatusVer = classStatusVer;
        }

        public Boolean GetClassTypeVer()
        {
            return ClassTypeVer;
        }

        public void setClassTypeVer(Boolean classTypeVer)
        {
            ClassTypeVer = classTypeVer;
        }

        public Boolean GetSectionVer()
        {
            return SectionVer;
        }

        public void setSectionVer(Boolean sectionVer)
        {
            SectionVer = sectionVer;
        }

        public Boolean GetAssociatedClassVer()
        {
            return AssociatedClassVer;
        }

        public void setAssociatedClassVer(Boolean associatedClassVer)
        {
            AssociatedClassVer = associatedClassVer;
        }

        public Boolean GetAutoEnroll1Ver()
        {
            return AutoEnroll1Ver;
        }

        public void setAutoEnroll1Ver(Boolean autoEnroll1Ver)
        {
            AutoEnroll1Ver = autoEnroll1Ver;
        }

        public Boolean GetAutoEnroll2Ver()
        {
            return AutoEnroll2Ver;
        }

        public void setAutoEnroll2Ver(Boolean autoEnroll2Ver)
        {
            AutoEnroll2Ver = autoEnroll2Ver;
        }

        public Boolean GetSchedulePrintVer()
        {
            return SchedulePrintVer;
        }

        public void setSchedulePrintVer(Boolean schedulePrintVer)
        {
            SchedulePrintVer = schedulePrintVer;
        }

        public Boolean GetConsentVer()
        {
            return ConsentVer;
        }

        public void setConsentVer(Boolean consentVer)
        {
            ConsentVer = consentVer;
        }

        public Boolean GetRoomCapRequestVer()
        {
            return RoomCapRequestVer;
        }

        public void setRoomCapRequestVer(Boolean roomCapRequestVer)
        {
            RoomCapRequestVer = roomCapRequestVer;
        }

        public Boolean GetEnrlCapVer()
        {
            return EnrlCapVer;
        }

        public void setEnrlCapVer(Boolean enrlCapVer)
        {
            EnrlCapVer = enrlCapVer;
        }

        public Boolean GetEnrlTotalVer()
        {
            return EnrlTotalVer;
        }

        public void setEnrlTotalVer(Boolean enrlTotalVer)
        {
            EnrlTotalVer = enrlTotalVer;
        }

        public Boolean GetWaitCapVer()
        {
            return WaitCapVer;
        }

        public void setWaitCapVer(Boolean waitCapVer)
        {
            WaitCapVer = waitCapVer;
        }

        public Boolean GetWaitTotalVer()
        {
            return WaitTotalVer;
        }

        public void setWaitTotalVer(Boolean waitTotalVer)
        {
            WaitTotalVer = waitTotalVer;
        }

        public Boolean GetMinEnrlVer()
        {
            return MinEnrlVer;
        }

        public void setMinEnrlVer(Boolean minEnrlVer)
        {
            MinEnrlVer = minEnrlVer;
        }

        public Boolean GetTopicIdVer()
        {
            return TopicIdVer;
        }

        public void setTopicIdVer(Boolean topicIdVer)
        {
            TopicIdVer = topicIdVer;
        }

        public Boolean GetTopicDescrVer()
        {
            return TopicDescrVer;
        }

        public void setTopicDescrVer(Boolean topicDescrVer)
        {
            TopicDescrVer = topicDescrVer;
        }

        public Boolean GetPrintTopicVer()
        {
            return PrintTopicVer;
        }

        public void setPrintTopicVer(Boolean printTopicVer)
        {
            PrintTopicVer = printTopicVer;
        }

        public Boolean GetAcadOrgVer()
        {
            return AcadOrgVer;
        }

        public void setAcadOrgVer(Boolean acadOrgVer)
        {
            AcadOrgVer = acadOrgVer;
        }

        public Boolean GetNextStdntPositionVer()
        {
            return NextStdntPositionVer;
        }

        public void setNextStdntPositionVer(Boolean nextStdntPositionVer)
        {
            NextStdntPositionVer = nextStdntPositionVer;
        }

        public Boolean GetLocationVer()
        {
            return LocationVer;
        }

        public void setLocationVer(Boolean locationVer)
        {
            LocationVer = locationVer;
        }

        public Boolean GetRoomEventNbrVer()
        {
            return RoomEventNbrVer;
        }

        public void setRoomEventNbrVer(Boolean roomEventNbrVer)
        {
            RoomEventNbrVer = roomEventNbrVer;
        }

        public Boolean GetInstructionModeVer()
        {
            return InstructionModeVer;
        }

        public void setInstructionModeVer(Boolean instructionModeVer)
        {
            InstructionModeVer = instructionModeVer;
        }

        public Boolean GetStartDtVer()
        {
            return StartDtVer;
        }

        public void setStartDtVer(Boolean startDtVer)
        {
            StartDtVer = startDtVer;
        }

        public Boolean GetEndDtVer()
        {
            return EndDtVer;
        }

        public void setEndDtVer(Boolean endDtVer)
        {
            EndDtVer = endDtVer;
        }

        public Boolean GetMeetingStartDtVer()
        {
            return MeetingStartDtVer;
        }

        public void setMeetingStartDtVer(Boolean meetingStartDtVer)
        {
            MeetingStartDtVer = meetingStartDtVer;
        }

        public Boolean GetMeetingEndDtVer()
        {
            return MeetingEndDtVer;
        }

        public void setMeetingEndDtVer(Boolean meetingEndDtVer)
        {
            MeetingEndDtVer = meetingEndDtVer;
        }

        public Boolean GetCancelDtVer()
        {
            return CancelDtVer;
        }

        public void setCancelDtVer(Boolean cancelDtVer)
        {
            CancelDtVer = cancelDtVer;
        }

        public Boolean GetCombinedSectionVer()
        {
            return CombinedSectionVer;
        }

        public void setCombinedSectionVer(Boolean combinedSectionVer)
        {
            CombinedSectionVer = combinedSectionVer;
        }

        public Boolean GetClassMtgNbr1Ver()
        {
            return ClassMtgNbr1Ver;
        }

        public void setClassMtgNbr1Ver(Boolean classMtgNbr1Ver)
        {
            ClassMtgNbr1Ver = classMtgNbr1Ver;
        }

        public Boolean GetFacilityIdVer()
        {
            return FacilityIdVer;
        }

        public void setFacilityIdVer(Boolean facilityIdVer)
        {
            FacilityIdVer = facilityIdVer;
        }

        public Boolean GetMeetingTimeStartVer()
        {
            return MeetingTimeStartVer;
        }

        public void setMeetingTimeStartVer(Boolean meetingTimeStartVer)
        {
            MeetingTimeStartVer = meetingTimeStartVer;
        }

        public Boolean GetMeetingTimeEndVer()
        {
            return MeetingTimeEndVer;
        }

        public void setMeetingTimeEndVer(Boolean meetingTimeEndVer)
        {
            MeetingTimeEndVer = meetingTimeEndVer;
        }

        public Boolean GetMonVer()
        {
            return MonVer;
        }

        public void setMonVer(Boolean monVer)
        {
            MonVer = monVer;
        }

        public Boolean GetTuesVer()
        {
            return TuesVer;
        }

        public void setTuesVer(Boolean tuesVer)
        {
            TuesVer = tuesVer;
        }

        public Boolean GetWedVer()
        {
            return WedVer;
        }

        public void setWedVer(Boolean wedVer)
        {
            WedVer = wedVer;
        }

        public Boolean GetThursVer()
        {
            return ThursVer;
        }

        public void setThursVer(Boolean thursVer)
        {
            ThursVer = thursVer;
        }

        public Boolean GetFriVer()
        {
            return FriVer;
        }

        public void setFriVer(Boolean friVer)
        {
            FriVer = friVer;
        }

        public Boolean GetSatVer()
        {
            return SatVer;
        }

        public void setSatVer(Boolean satVer)
        {
            SatVer = satVer;
        }

        public Boolean GetSunVer()
        {
            return SunVer;
        }

        public void setSunVer(Boolean sunVer)
        {
            SunVer = sunVer;
        }

        public Boolean GetInstructorVer()
        {
            return InstructorVer;
        }

        public void setInstructorVer(Boolean instructorVer)
        {
            InstructorVer = instructorVer;
        }

        public Boolean GetInstreIDVer()
        {
            return InstreIDVer;
        }

        public void setInstreIDVer(Boolean instreIDVer)
        {
            InstreIDVer = instreIDVer;
        }

        public Boolean GetClassMtgNbr2Ver()
        {
            return ClassMtgNbr2Ver;
        }

        public void setClassMtgNbr2Ver(Boolean classMtgNbr2Ver)
        {
            ClassMtgNbr2Ver = classMtgNbr2Ver;
        }

        public Boolean GetInstrRoleVer()
        {
            return InstrRoleVer;
        }

        public void setInstrRoleVer(Boolean instrRoleVer)
        {
            InstrRoleVer = instrRoleVer;
        }

        public Boolean GetSchedPrintInstrVer()
        {
            return SchedPrintInstrVer;
        }

        public void setSchedPrintInstrVer(Boolean schedPrintInstrVer)
        {
            SchedPrintInstrVer = schedPrintInstrVer;
        }

        public Boolean GetRoomChrstc1Ver()
        {
            return RoomChrstc1Ver;
        }

        public void setRoomChrstc1Ver(Boolean roomChrstc1Ver)
        {
            RoomChrstc1Ver = roomChrstc1Ver;
        }

        public Boolean GetRoomChrstc2Ver()
        {
            return RoomChrstc2Ver;
        }

        public void setRoomChrstc2Ver(Boolean roomChrstc2Ver)
        {
            RoomChrstc2Ver = roomChrstc2Ver;
        }

        public Boolean GetClassNotesSeqVer()
        {
            return ClassNotesSeqVer;
        }

        public void setClassNotesSeqVer(Boolean classNotesSeqVer)
        {
            ClassNotesSeqVer = classNotesSeqVer;
        }

        public Boolean GetPrintAtVer()
        {
            return PrintAtVer;
        }

        public void setPrintAtVer(Boolean printAtVer)
        {
            PrintAtVer = printAtVer;
        }

        public Boolean GetClassNoteNbrVer()
        {
            return ClassNoteNbrVer;
        }

        public void setClassNoteNbrVer(Boolean classNoteNbrVer)
        {
            ClassNoteNbrVer = classNoteNbrVer;
        }

        public Boolean GetPrintNoteWOClsVer()
        {
            return PrintNoteWOClsVer;
        }

        public void setPrintNoteWOClsVer(Boolean printNoteWOClsVer)
        {
            PrintNoteWOClsVer = printNoteWOClsVer;
        }

        public Boolean GetClassNoteLongVer()
        {
            return ClassNoteLongVer;
        }

        public void setClassNoteLongVer(Boolean classNoteLongVer)
        {
            ClassNoteLongVer = classNoteLongVer;
        }

        public Boolean GetClassNoteVer()
        {
            return ClassNoteVer;
        }

        public void setClassNoteVer(Boolean classNoteVer)
        {
            ClassNoteVer = classNoteVer;
        }

        public Boolean GetRsrvCapNbrVer()
        {
            return RsrvCapNbrVer;
        }

        public void setRsrvCapNbrVer(Boolean rsrvCapNbrVer)
        {
            RsrvCapNbrVer = rsrvCapNbrVer;
        }

        public Boolean GetResCapEnrlCapVer()
        {
            return ResCapEnrlCapVer;
        }

        public void setResCapEnrlCapVer(Boolean resCapEnrlCapVer)
        {
            ResCapEnrlCapVer = resCapEnrlCapVer;
        }

        public Boolean GetResCapEnrlTotVer()
        {
            return ResCapEnrlTotVer;
        }

        public void setResCapEnrlTotVer(Boolean resCapEnrlTotVer)
        {
            ResCapEnrlTotVer = resCapEnrlTotVer;
        }

        public Boolean GetRqrmntGroup1Ver()
        {
            return RqrmntGroup1Ver;
        }

        public void setRqrmntGroup1Ver(Boolean rqrmntGroup1Ver)
        {
            RqrmntGroup1Ver = rqrmntGroup1Ver;
        }

        public Boolean GetRqrmntGroupDescVer()
        {
            return RqrmntGroupDescVer;
        }

        public void setRqrmntGroupDescVer(Boolean rqrmntGroupDescVer)
        {
            RqrmntGroupDescVer = rqrmntGroupDescVer;
        }

        public Boolean GetRoomChrstcQtyVer()
        {
            return RoomChrstcQtyVer;
        }

        public void setRoomChrstcQtyVer(Boolean roomChrstcQtyVer)
        {
            RoomChrstcQtyVer = roomChrstcQtyVer;
        }

        public Boolean GetUnitsMinVer()
        {
            return UnitsMinVer;
        }

        public void setUnitsMinVer(Boolean unitsMinVer)
        {
            UnitsMinVer = unitsMinVer;
        }

        public Boolean GetUnitsMaxVer()
        {
            return UnitsMaxVer;
        }

        public void setUnitsMaxVer(Boolean unitsMaxVer)
        {
            UnitsMaxVer = unitsMaxVer;
        }

        public Boolean GetUnitsAcadProgVer()
        {
            return UnitsAcadProgVer;
        }

        public void setUnitsAcadProgVer(Boolean unitsAcadProgVer)
        {
            UnitsAcadProgVer = unitsAcadProgVer;
        }

        public Boolean GetGradingBasisVer()
        {
            return GradingBasisVer;
        }

        public void setGradingBasisVer(Boolean gradingBasisVer)
        {
            GradingBasisVer = gradingBasisVer;
        }

        public Boolean GetGradeRosterPrintVer()
        {
            return GradeRosterPrintVer;
        }

        public void setGradeRosterPrintVer(Boolean gradeRosterPrintVer)
        {
            GradeRosterPrintVer = gradeRosterPrintVer;
        }

        public Boolean GetClassAssnComponentVer()
        {
            return ClassAssnComponentVer;
        }

        public void setClassAssnComponentVer(Boolean classAssnComponentVer)
        {
            ClassAssnComponentVer = classAssnComponentVer;
        }

        public Boolean GetRqrmntGroup2Ver()
        {
            return RqrmntGroup2Ver;
        }

        public void setRqrmntGroup2Ver(Boolean rqrmntGroup2Ver)
        {
            RqrmntGroup2Ver = rqrmntGroup2Ver;
        }

        public Boolean GetUseCatlgRqsVer()
        {
            return UseCatlgRqsVer;
        }

        public void setUseCatlgRqsVer(Boolean useCatlgRqsVer)
        {
            UseCatlgRqsVer = useCatlgRqsVer;
        }

        public Boolean GetSctnCombinedIdVer()
        {
            return SctnCombinedIdVer;
        }

        public void setSctnCombinedIdVer(Boolean sctnCombinedIdVer)
        {
            SctnCombinedIdVer = sctnCombinedIdVer;
        }

        public Boolean GetCombSecClassNbrVer()
        {
            return CombSecClassNbrVer;
        }

        public void setCombSecClassNbrVer(Boolean combSecClassNbrVer)
        {
            CombSecClassNbrVer = combSecClassNbrVer;
        }

        public Boolean GetCombSecDescriptionVer()
        {
            return CombSecDescriptionVer;
        }

        public void setCombSecDescriptionVer(Boolean combSecDescriptionVer)
        {
            CombSecDescriptionVer = combSecDescriptionVer;
        }

        public Boolean GetClassTableDescrVer()
        {
            return ClassTableDescrVer;
        }

        public void setClassTableDescrVer(Boolean classTableDescrVer)
        {
            ClassTableDescrVer = classTableDescrVer;
        }

        public Boolean GetCmbndSubjectVer()
        {
            return CmbndSubjectVer;
        }

        public void setCmbndSubjectVer(Boolean cmbndSubjectVer)
        {
            CmbndSubjectVer = cmbndSubjectVer;
        }

        public Boolean GetCmbndCatNbrVer()
        {
            return CmbndCatNbrVer;
        }

        public void setCmbndCatNbrVer(Boolean cmbndCatNbrVer)
        {
            CmbndCatNbrVer = cmbndCatNbrVer;
        }

        public Boolean GetRqmntDesigntnVer()
        {
            return RqmntDesigntnVer;
        }

        public void setRqmntDesigntnVer(Boolean rqmntDesigntnVer)
        {
            RqmntDesigntnVer = rqmntDesigntnVer;
        }

        public Boolean GetRqmntDesigDescrVer()
        {
            return RqmntDesigDescrVer;
        }

        public void setRqmntDesigDescrVer(Boolean rqmntDesigDescrVer)
        {
            RqmntDesigDescrVer = rqmntDesigDescrVer;
        }

        public Boolean GetRqmntDesigDescrformalVer()
        {
            return RqmntDesigDescrformalVer;
        }

        public void setRqmntDesigDescrformalVer(Boolean rqmntDesigDescrformalVer)
        {
            RqmntDesigDescrformalVer = rqmntDesigDescrformalVer;
        }

        public Boolean GetClassAttrVer()
        {
            return ClassAttrVer;
        }

        public void setClassAttrVer(Boolean classAttrVer)
        {
            ClassAttrVer = classAttrVer;
        }

        public Boolean GetClassAttrDescrVer()
        {
            return ClassAttrDescrVer;
        }

        public void setClassAttrDescrVer(Boolean classAttrDescrVer)
        {
            ClassAttrDescrVer = classAttrDescrVer;
        }

        public Boolean GetAttrValueVer()
        {
            return AttrValueVer;
        }

        public void setAttrValueVer(Boolean attrValueVer)
        {
            AttrValueVer = attrValueVer;
        }

        public Boolean GetAttrValueDescrVer()
        {
            return AttrValueDescrVer;
        }

        public void setAttrValueDescrVer(Boolean attrValueDescrVer)
        {
            AttrValueDescrVer = attrValueDescrVer;
        }

        public Boolean GetReportDateVer()
        {
            return ReportDateVer;
        }

        public void setReportDateVer(Boolean reportDateVer)
        {
            ReportDateVer = reportDateVer;
        }

        public string GetName()
        {
            return Name;
        }

        public void setName(string name)
        {
            Name = name;
        }


    }
}