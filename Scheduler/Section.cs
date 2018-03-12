using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scheduler
{
    public class Section
    {

        private String Name = "";
        private String CourseID = "";
        private String ClassNbr = "";
        private String OfferNbr = "";
        private String STRM = "";
        private String Session = "";
        private String AcadGroup = "";
        private String Subject = "";
        private String CatalogNbr = "";
        private String ClassDescr = "";
        private String AcadCareer = "";
        private String Component = "";
        private String EnrlStatus = "";
        private String ClassStatus = "";
        private String ClassType = "";
        private String SectionName = "";
        private String AssociatedClass = "";
        private String AutoEnroll1 = "";
        private String AutoEnroll2 = "";
        private String SchedulePrint = "";
        private String Consent = "";
        private String RoomCapRequest = "";
        private String EnrlCap = "";
        private String EnrlTotal = "";
        private String WaitCap = "";
        private String WaitTotal = "";
        private String MinEnrl = "";
        private String TopicId = "";
        private String TopicDescr = "";
        private String PrintTopic = "";
        private String AcadOrg = "";
        private String NextStdntPosition = "";
        private String Location = "";
        private String RoomEventNbr = "";
        private String InstructionMode = "";
        private String StartDt = "";
        private String EndDt = "";
        private String MeetingStartDt = "";
        private String MeetingEndDt = "";
        private String CancelDt = "";
        private String CombinedSection = "";
        private String ClassMtgNbr1 = "";
        private String FacilityId = "";
        private String MeetingTimeStart = "";
        private String MeetingTimeEnd = "";
        private String Mon = "";
        private String Tues = "";
        private String Wed = "";
        private String Thurs = "";
        private String Fri = "";
        private String Sat = "";
        private String Sun = "";
        private String Instructor = "";
        private String InstreID = "";
        private String ClassMtgNbr2 = "";
        private String InstrRole = "";
        private String SchedPrintInstr = "";
        private String RoomChrstc1 = "";
        private String RoomChrstc2 = "";
        private String ClassNotesSeq = "";
        private String PrintAt = "";
        private String ClassNoteNbr = "";
        private String PrintNoteWOCls = "";
        private String ClassNoteLong = "";
        private String ClassNote = "";
        private String RsrvCapNbr = "";
        private String ResCapEnrlCap = "";
        private String ResCapEnrlTot = "";
        private String RqrmntGroup1 = "";
        private String RqrmntGroupDesc = "";
        private String RoomChrstcQty = "";
        private String UnitsMin = "";
        private String UnitsMax = "";
        private String UnitsAcadProg = "";
        private String GradingBasis = "";
        private String GradeRosterPrint = "";
        private String ClassAssnComponent = "";
        private String RqrmntGroup2 = "";
        private String UseCatlgRqs = "";
        private String SctnCombinedId = "";
        private String CombSecClassNbr = "";
        private String CombSecDescription = "";
        private String ClassTableDescr = "";
        private String CmbndSubject = "";
        private String CmbndCatNbr = "";
        private String RqmntDesigntn = "";
        private String RqmntDesigDescr = "";
        private String RqmntDesigDescrformal = "";
        private String ClassAttr = "";
        private String ClassAttrDescr = "";
        private String AttrValue = "";
        private String AttrValueDescr = "";
        private String ReportDate = "";
        private String myNotes = ""; // holds local notes only
        private String Hidden = ""; // determines if we should hide section - local only

        private Boolean KSISVerified = false;
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
        public Section(String courseID, String classNbr, String offerNbr, String sTRM, String session, String acadGroup,
                String subject, String catalogNbr, String classDescr, String acadCareer, String component,
                String enrlStatus, String classStatus, String classType, String section, String associatedClass,
                String autoEnroll1, String autoEnroll2, String schedulePrint, String consent, String roomCapRequest,
                String enrlCap, String enrlTotal, String waitCap, String waitTotal, String minEnrl, String topicId,
                String topicDescr, String printTopic, String acadOrg, String nextStdntPosition, String location,
                String roomEventNbr, String instructionMode, String startDt, String endDt, String meetingStartDt,
                String meetingEndDt, String cancelDt, String combinedSection, String classMtgNbr1, String facilityId,
                String meetingTimeStart, String meetingTimeEnd, String mon, String tues, String wed, String thurs,
                String fri, String sat, String sun, String instructor, String instreID, String classMtgNbr2,
                String instrRole, String schedPrintInstr, String roomChrstc1, String roomChrstc2, String classNotesSeq,
                String printAt, String classNoteNbr, String printNoteWOCls, String classNoteLong, String classNote,
                String rsrvCapNbr, String resCapEnrlCap, String resCapEnrlTot, String rqrmntGroup1, String rqrmntGroupDesc,
                String roomChrstcQty, String unitsMin, String unitsMax, String unitsAcadProg, String gradingBasis,
                String gradeRosterPrint, String classAssnComponent, String rqrmntGroup2, String useCatlgRqs,
                String sctnCombinedId, String combSecClassNbr, String combSecDescription, String classTableDescr,
                String cmbndSubject, String cmbndCatNbr, String rqmntDesigntn, String rqmntDesigDescr,
                String rqmntDesigDescrformal, String classAttr, String classAttrDescr, String attrValue,
                String attrValueDescr, String reportDate)
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
            Instructor = instructor;
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
        public Section(String subject, String catalogNbr, String classDescr, String section, String instructor,
                String consent, String enrlCap, String topicDescr, String meetingStartDt, String meetingEndDt,
                String facilityId, String meetingTimeStart, String meetingTimeEnd, String mon, String tues, String wed,
                String thurs, String fri, String sat, String sun, String unitsMin, String unitsMax,
                String classAssnComponent, String hidden, String mynotes)
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
            Instructor = instructor;
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

        public String toString()
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

        public String GetCourseID()
        {
            return CourseID;
        }

        public void setCourseID(String courseID)
        {
            CourseID = courseID;
        }

        public String GetClassNbr()
        {
            return ClassNbr;
        }

        public void setClassNbr(String classNbr)
        {
            ClassNbr = classNbr;
        }

        public String GetOfferNbr()
        {
            return OfferNbr;
        }

        public void setOfferNbr(String offerNbr)
        {
            OfferNbr = offerNbr;
        }

        public String GetSTRM()
        {
            return STRM;
        }

        public void setSTRM(String sTRM)
        {
            STRM = sTRM;
        }

        public String GetSession()
        {
            return Session;
        }

        public void setSession(String session)
        {
            Session = session;
        }

        public String GetAcadGroup()
        {
            return AcadGroup;
        }

        public void setAcadGroup(String acadGroup)
        {
            AcadGroup = acadGroup;
        }

        public String GetSubject()
        {
            return Subject;
        }

        public void setSubject(String subject)
        {
            Subject = subject;
        }

        public String GetCatalogNbr()
        {
            return CatalogNbr;
        }

        public void setCatalogNbr(String catalogNbr)
        {
            CatalogNbr = catalogNbr;
        }

        public String GetClassDescr()
        {
            return ClassDescr;
        }

        public void setClassDescr(String classDescr)
        {
            ClassDescr = classDescr;
        }

        public String GetAcadCareer()
        {
            return AcadCareer;
        }

        public void setAcadCareer(String acadCareer)
        {
            AcadCareer = acadCareer;
        }

        public String GetComponent()
        {
            return Component;
        }

        public void setComponent(String component)
        {
            Component = component;
        }

        public String GetEnrlStatus()
        {
            return EnrlStatus;
        }

        public void setEnrlStatus(String enrlStatus)
        {
            EnrlStatus = enrlStatus;
        }

        public String GetClassStatus()
        {
            return ClassStatus;
        }

        public void setClassStatus(String classStatus)
        {
            ClassStatus = classStatus;
        }

        public String GetClassType()
        {
            return ClassType;
        }

        public void setClassType(String classType)
        {
            ClassType = classType;
        }

        public String GetSection()
        {
            return SectionName;
        }

        public void setSection(String section)
        {
            SectionName = section;
        }

        public String GetAssociatedClass()
        {
            return AssociatedClass;
        }

        public void setAssociatedClass(String associatedClass)
        {
            AssociatedClass = associatedClass;
        }

        public String GetAutoEnroll1()
        {
            return AutoEnroll1;
        }

        public void setAutoEnroll1(String autoEnroll1)
        {
            AutoEnroll1 = autoEnroll1;
        }

        public String GetAutoEnroll2()
        {
            return AutoEnroll2;
        }

        public void setAutoEnroll2(String autoEnroll2)
        {
            AutoEnroll2 = autoEnroll2;
        }

        public String GetSchedulePrint()
        {
            return SchedulePrint;
        }

        public void setSchedulePrint(String schedulePrint)
        {
            SchedulePrint = schedulePrint;
        }

        public String GetConsent()
        {
            return Consent;
        }

        public void setConsent(String consent)
        {
            Consent = consent;
        }

        public String GetRoomCapRequest()
        {
            return RoomCapRequest;
        }

        public void setRoomCapRequest(String roomCapRequest)
        {
            RoomCapRequest = roomCapRequest;
        }

        public String GetEnrlCap()
        {
            return EnrlCap;
        }

        public void setEnrlCap(String enrlCap)
        {
            EnrlCap = enrlCap;
        }

        public String GetEnrlTotal()
        {
            return EnrlTotal;
        }

        public void setEnrlTotal(String enrlTotal)
        {
            EnrlTotal = enrlTotal;
        }

        public String GetWaitCap()
        {
            return WaitCap;
        }

        public void setWaitCap(String waitCap)
        {
            WaitCap = waitCap;
        }

        public String GetWaitTotal()
        {
            return WaitTotal;
        }

        public void setWaitTotal(String waitTotal)
        {
            WaitTotal = waitTotal;
        }

        public String GetMinEnrl()
        {
            return MinEnrl;
        }

        public void setMinEnrl(String minEnrl)
        {
            MinEnrl = minEnrl;
        }

        public String GetTopicId()
        {
            return TopicId;
        }

        public void setTopicId(String topicId)
        {
            TopicId = topicId;
        }

        public String GetTopicDescr()
        {
            return TopicDescr;
        }

        public void setTopicDescr(String topicDescr)
        {
            TopicDescr = topicDescr;
        }

        public String GetPrintTopic()
        {
            return PrintTopic;
        }

        public void setPrintTopic(String printTopic)
        {
            PrintTopic = printTopic;
        }

        public String GetAcadOrg()
        {
            return AcadOrg;
        }

        public void setAcadOrg(String acadOrg)
        {
            AcadOrg = acadOrg;
        }

        public String GetNextStdntPosition()
        {
            return NextStdntPosition;
        }

        public void setNextStdntPosition(String nextStdntPosition)
        {
            NextStdntPosition = nextStdntPosition;
        }

        public String GetLocation()
        {
            return Location;
        }

        public void setLocation(String location)
        {
            Location = location;
        }

        public String GetRoomEventNbr()
        {
            return RoomEventNbr;
        }

        public void setRoomEventNbr(String roomEventNbr)
        {
            RoomEventNbr = roomEventNbr;
        }

        public String GetInstructionMode()
        {
            return InstructionMode;
        }

        public void setInstructionMode(String instructionMode)
        {
            InstructionMode = instructionMode;
        }

        public String GetStartDt()
        {
            return StartDt;
        }

        public void setStartDt(String startDt)
        {
            StartDt = startDt;
        }

        public String GetEndDt()
        {
            return EndDt;
        }

        public void setEndDt(String endDt)
        {
            EndDt = endDt;
        }

        public String GetMeetingStartDt()
        {
            return MeetingStartDt;
        }

        public void setMeetingStartDt(String meetingStartDt)
        {
            MeetingStartDt = meetingStartDt;
        }

        public String GetMeetingEndDt()
        {
            return MeetingEndDt;
        }

        public void setMeetingEndDt(String meetingEndDt)
        {
            MeetingEndDt = meetingEndDt;
        }

        public String GetCancelDt()
        {
            return CancelDt;
        }

        public void setCancelDt(String cancelDt)
        {
            CancelDt = cancelDt;
        }

        public String GetCombinedSection()
        {
            return CombinedSection;
        }

        public void setCombinedSection(String combinedSection)
        {
            CombinedSection = combinedSection;
        }

        public String GetClassMtgNbr1()
        {
            return ClassMtgNbr1;
        }

        public void setClassMtgNbr1(String classMtgNbr1)
        {
            ClassMtgNbr1 = classMtgNbr1;
        }

        public String GetFacilityId()
        {
            return FacilityId;
        }

        public void setFacilityId(String facilityId)
        {
            FacilityId = facilityId;
        }

        public String GetMeetingTimeStart()
        {
            return MeetingTimeStart;
        }

        public void setMeetingTimeStart(String meetingTimeStart)
        {
            MeetingTimeStart = meetingTimeStart;
        }

        public String GetMeetingTimeEnd()
        {
            return MeetingTimeEnd;
        }

        public void setMeetingTimeEnd(String meetingTimeEnd)
        {
            MeetingTimeEnd = meetingTimeEnd;
        }

        public String GetMon()
        {
            return Mon;
        }

        public void setMon(String mon)
        {
            Mon = mon;
        }

        public String GetTues()
        {
            return Tues;
        }

        public void setTues(String tues)
        {
            Tues = tues;
        }

        public String GetWed()
        {
            return Wed;
        }

        public void setWed(String wed)
        {
            Wed = wed;
        }

        public String GetThurs()
        {
            return Thurs;
        }

        public void setThurs(String thurs)
        {
            Thurs = thurs;
        }

        public String GetFri()
        {
            return Fri;
        }

        public void setFri(String fri)
        {
            Fri = fri;
        }

        public String GetSat()
        {
            return Sat;
        }

        public void setSat(String sat)
        {
            Sat = sat;
        }

        public String GetSun()
        {
            return Sun;
        }

        public void setSun(String sun)
        {
            Sun = sun;
        }

        public String GetInstructor()
        {
            return Instructor;
        }

        public void setInstructor(String instructor)
        {
            Instructor = instructor;
        }

        public String GetInstreID()
        {
            return InstreID;
        }

        public void setInstreID(String instreID)
        {
            InstreID = instreID;
        }

        public String GetClassMtgNbr2()
        {
            return ClassMtgNbr2;
        }

        public void setClassMtgNbr2(String classMtgNbr2)
        {
            ClassMtgNbr2 = classMtgNbr2;
        }

        public String GetInstrRole()
        {
            return InstrRole;
        }

        public void setInstrRole(String instrRole)
        {
            InstrRole = instrRole;
        }

        public String GetSchedPrintInstr()
        {
            return SchedPrintInstr;
        }

        public void setSchedPrintInstr(String schedPrintInstr)
        {
            SchedPrintInstr = schedPrintInstr;
        }

        public String GetRoomChrstc1()
        {
            return RoomChrstc1;
        }

        public void setRoomChrstc1(String roomChrstc1)
        {
            RoomChrstc1 = roomChrstc1;
        }

        public String GetRoomChrstc2()
        {
            return RoomChrstc2;
        }

        public void setRoomChrstc2(String roomChrstc2)
        {
            RoomChrstc2 = roomChrstc2;
        }

        public String GetClassNotesSeq()
        {
            return ClassNotesSeq;
        }

        public void setClassNotesSeq(String classNotesSeq)
        {
            ClassNotesSeq = classNotesSeq;
        }

        public String GetPrintAt()
        {
            return PrintAt;
        }

        public void setPrintAt(String printAt)
        {
            PrintAt = printAt;
        }

        public String GetClassNoteNbr()
        {
            return ClassNoteNbr;
        }

        public void setClassNoteNbr(String classNoteNbr)
        {
            ClassNoteNbr = classNoteNbr;
        }

        public String GetPrintNoteWOCls()
        {
            return PrintNoteWOCls;
        }

        public void setPrintNoteWOCls(String printNoteWOCls)
        {
            PrintNoteWOCls = printNoteWOCls;
        }

        public String GetClassNoteLong()
        {
            return ClassNoteLong;
        }

        public void setClassNoteLong(String classNoteLong)
        {
            ClassNoteLong = classNoteLong;
        }

        public String GetClassNote()
        {
            return ClassNote;
        }

        public void setClassNote(String classNote)
        {
            ClassNote = classNote;
        }

        public String GetRsrvCapNbr()
        {
            return RsrvCapNbr;
        }

        public void setRsrvCapNbr(String rsrvCapNbr)
        {
            RsrvCapNbr = rsrvCapNbr;
        }

        public String GetResCapEnrlCap()
        {
            return ResCapEnrlCap;
        }

        public void setResCapEnrlCap(String resCapEnrlCap)
        {
            ResCapEnrlCap = resCapEnrlCap;
        }

        public String GetResCapEnrlTot()
        {
            return ResCapEnrlTot;
        }

        public void setResCapEnrlTot(String resCapEnrlTot)
        {
            ResCapEnrlTot = resCapEnrlTot;
        }

        public String GetRqrmntGroup1()
        {
            return RqrmntGroup1;
        }

        public void setRqrmntGroup1(String rqrmntGroup1)
        {
            RqrmntGroup1 = rqrmntGroup1;
        }

        public String GetRqrmntGroupDesc()
        {
            return RqrmntGroupDesc;
        }

        public void setRqrmntGroupDesc(String rqrmntGroupDesc)
        {
            RqrmntGroupDesc = rqrmntGroupDesc;
        }

        public String GetRoomChrstcQty()
        {
            return RoomChrstcQty;
        }

        public void setRoomChrstcQty(String roomChrstcQty)
        {
            RoomChrstcQty = roomChrstcQty;
        }

        public String GetUnitsMin()
        {
            return UnitsMin;
        }

        public void setUnitsMin(String unitsMin)
        {
            UnitsMin = unitsMin;
        }

        public String GetUnitsMax()
        {
            return UnitsMax;
        }

        public void setUnitsMax(String unitsMax)
        {
            UnitsMax = unitsMax;
        }

        public String GetUnitsAcadProg()
        {
            return UnitsAcadProg;
        }

        public void setUnitsAcadProg(String unitsAcadProg)
        {
            UnitsAcadProg = unitsAcadProg;
        }

        public String GetGradingBasis()
        {
            return GradingBasis;
        }

        public void setGradingBasis(String gradingBasis)
        {
            GradingBasis = gradingBasis;
        }

        public String GetGradeRosterPrint()
        {
            return GradeRosterPrint;
        }

        public void setGradeRosterPrint(String gradeRosterPrint)
        {
            GradeRosterPrint = gradeRosterPrint;
        }

        public String GetClassAssnComponent()
        {
            return ClassAssnComponent;
        }

        public void setClassAssnComponent(String classAssnComponent)
        {
            ClassAssnComponent = classAssnComponent;
        }

        public String GetRqrmntGroup2()
        {
            return RqrmntGroup2;
        }

        public void setRqrmntGroup2(String rqrmntGroup2)
        {
            RqrmntGroup2 = rqrmntGroup2;
        }

        public String GetUseCatlgRqs()
        {
            return UseCatlgRqs;
        }

        public void setUseCatlgRqs(String useCatlgRqs)
        {
            UseCatlgRqs = useCatlgRqs;
        }

        public String GetSctnCombinedId()
        {
            return SctnCombinedId;
        }

        public void setSctnCombinedId(String sctnCombinedId)
        {
            SctnCombinedId = sctnCombinedId;
        }

        public String GetCombSecClassNbr()
        {
            return CombSecClassNbr;
        }

        public void setCombSecClassNbr(String combSecClassNbr)
        {
            CombSecClassNbr = combSecClassNbr;
        }

        public String GetCombSecDescription()
        {
            return CombSecDescription;
        }

        public void setCombSecDescription(String combSecDescription)
        {
            CombSecDescription = combSecDescription;
        }

        public String GetClassTableDescr()
        {
            return ClassTableDescr;
        }

        public void setClassTableDescr(String classTableDescr)
        {
            ClassTableDescr = classTableDescr;
        }

        public String GetCmbndSubject()
        {
            return CmbndSubject;
        }

        public void setCmbndSubject(String cmbndSubject)
        {
            CmbndSubject = cmbndSubject;
        }

        public String GetCmbndCatNbr()
        {
            return CmbndCatNbr;
        }

        public void setCmbndCatNbr(String cmbndCatNbr)
        {
            CmbndCatNbr = cmbndCatNbr;
        }

        public String GetRqmntDesigntn()
        {
            return RqmntDesigntn;
        }

        public void setRqmntDesigntn(String rqmntDesigntn)
        {
            RqmntDesigntn = rqmntDesigntn;
        }

        public String GetRqmntDesigDescr()
        {
            return RqmntDesigDescr;
        }

        public void setRqmntDesigDescr(String rqmntDesigDescr)
        {
            RqmntDesigDescr = rqmntDesigDescr;
        }

        public String GetRqmntDesigDescrformal()
        {
            return RqmntDesigDescrformal;
        }

        public void setRqmntDesigDescrformal(String rqmntDesigDescrformal)
        {
            RqmntDesigDescrformal = rqmntDesigDescrformal;
        }

        public String GetClassAttr()
        {
            return ClassAttr;
        }

        public void setClassAttr(String classAttr)
        {
            ClassAttr = classAttr;
        }

        public String GetClassAttrDescr()
        {
            return ClassAttrDescr;
        }

        public void setClassAttrDescr(String classAttrDescr)
        {
            ClassAttrDescr = classAttrDescr;
        }

        public String GetAttrValue()
        {
            return AttrValue;
        }

        public void setAttrValue(String attrValue)
        {
            AttrValue = attrValue;
        }

        public String GetAttrValueDescr()
        {
            return AttrValueDescr;
        }

        public void setAttrValueDescr(String attrValueDescr)
        {
            AttrValueDescr = attrValueDescr;
        }

        public String GetMyNotes()
        {
            return myNotes;
        }

        public void GetMyNotes(String mynotes)
        {
            myNotes = mynotes;
        }

        public String GetHidden()
        {
            return Hidden;
        }

        public void setHidden(String hidden)
        {
            if (hidden.Equals("") || hidden.ToLower().Equals("false"))
                Hidden = "FALSE";
            else
                Hidden = "TRUE";
        }

        public String GetReportDate()
        {
            return ReportDate;
        }

        public void setReportDate(String reportDate)
        {
            ReportDate = reportDate;
        }

        public Boolean GetKSISVerified()
        {
            return KSISVerified;
        }

        public void setKSISVerified(Boolean kSISVerified)
        {
            KSISVerified = kSISVerified;
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

        public String GetName()
        {
            return Name;
        }

        public void setName(String name)
        {
            Name = name;
        }


    }
}