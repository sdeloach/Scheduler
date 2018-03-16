namespace Scheduler
{
    public class Section
    {

        public string Name { get; set; } = "";
        public string Subject { get; set; } = "";
        public string CatalogNbr { get; set; } = "";
        public string ClassDescr { get; set; } = "";
        public string SectionName { get; set; } = "";
        public string Consent { get; set; } = "";
        public string EnrlCap { get; set; } = "";
        public string TopicDescr { get; set; } = "";
        public string MeetingStartDt { get; set; } = "";
        public string MeetingEndDt { get; set; } = "";
        public string FacilityId { get; set; } = "";
        public string MeetingTimeStart { get; set; } = "";
        public string MeetingTimeEnd { get; set; } = "";
        public string Mon { get; set; } = "";
        public string Tues { get; set; } = "";
        public string Wed { get; set; } = "";
        public string Thurs { get; set; } = "";
        public string Fri { get; set; } = "";
        public string Sat { get; set; } = "";
        public string Sun { get; set; } = "";
        public string Instructor { get; set; } = "";
        public string UnitsMin { get; set; } = "";
        public string UnitsMax { get; set; } = "";
        public string ClassAssnComponent { get; set; } = "";
        public string MyNotes { get; set; } = ""; // holds local notes only
        public string Hidden { get; set; } = ""; // determines if we should hide section - local only

        public bool HasBeenDeleted { get; set; } = false;
        public bool HasBeenChanged { get; set; } = false;
        public bool IsHidden { get; set; } = false;
        public bool STRMVer { get; set; } = true;
        private bool SubjectVer { get; set; } = true;
        public bool CatalogNbrVer { get; set; } = true;
        public bool ClassDescrVer { get; set; } = true;
        public bool SectionVer { get; set; } = true;
        public bool ConsentVer { get; set; } = true;
        public bool EnrlCapVer { get; set; } = true;
        public bool TopicDescrVer { get; set; } = true;
        public bool MeetingStartDtVer { get; set; } = true;
        public bool MeetingEndDtVer { get; set; } = true;
        public bool FacilityIdVer { get; set; } = true;
        public bool MeetingTimeStartVer { get; set; } = true;
        public bool MeetingTimeEndVer { get; set; } = true;
        public bool MonVer { get; set; } = true;
        public bool TuesVer { get; set; } = true;
        public bool WedVer { get; set; } = true;
        public bool ThursVer { get; set; } = true;
        public bool FriVer { get; set; } = true;
        public bool SatVer { get; set; } = true;
        public bool SunVer { get; set; } = true;
        public bool InstructorVer { get; set; } = true;
        public bool UnitsMinVer { get; set; } = true;
        public bool UnitsMaxVer { get; set; } = true;
        public bool ClassAssnComponentVer { get; set; } = true;

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
            SetupParameters(subject, catalogNbr, classDescr, section, instructor, consent, enrlCap, topicDescr, meetingStartDt, meetingEndDt,
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
            SetupParameters(subject, catalogNbr, classDescr, section, instructor, consent, enrlCap, topicDescr, meetingStartDt, meetingEndDt,
                   facilityId, meetingTimeStart, meetingTimeEnd, mon, tues, wed, thurs, fri, sat, sun, unitsMin, unitsMax,
                   classAssnComponent, hidden, mynotes);
        }

        private void SetupParameters(string subject, string catalogNbr, string classDescr, string section, string instructor,
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
            MyNotes = mynotes;
            Hidden = hidden;
            IsHidden = Hidden.Trim().ToLower().Equals("true");
        }

        public bool FlagChangesFromSection(Section verSec)
        {
            SubjectVer = Subject.Equals(verSec.Subject);
            CatalogNbrVer = CatalogNbr.Equals(verSec.CatalogNbr);
            ClassDescrVer = ClassDescr.Equals(verSec.ClassDescr);
            SectionVer = SectionName.Equals(verSec.SectionName);
            ConsentVer = Consent.Equals(verSec.Consent);
            EnrlCapVer = EnrlCap.Equals(verSec.EnrlCap);
            TopicDescrVer = TopicDescr.Equals(verSec.TopicDescr);
            MeetingStartDtVer = MeetingStartDt.Equals(verSec.MeetingStartDt);
            MeetingEndDtVer = MeetingEndDt.Equals(verSec.MeetingEndDt);
            FacilityIdVer = FacilityId.Equals(verSec.FacilityId);
            MeetingTimeStartVer = MeetingTimeStart.Equals(verSec.MeetingTimeStart);
            MeetingTimeEndVer = MeetingTimeEnd.Equals(verSec.MeetingTimeEnd);
            MonVer = Mon.Equals(verSec.Mon);
            TuesVer = Tues.Equals(verSec.Tues);
            WedVer = Wed.Equals(verSec.Wed);
            ThursVer = Thurs.Equals(verSec.Thurs);
            FriVer = Fri.Equals(verSec.Fri);
            SatVer = Sat.Equals(verSec.Sat);
            SunVer = Sun.Equals(verSec.Sun);
            InstructorVer = Instructor.Equals(verSec.Instructor);
            UnitsMinVer = UnitsMin.Equals(verSec.UnitsMin);
            UnitsMaxVer = UnitsMax.Equals(verSec.UnitsMax);
            ClassAssnComponentVer = ClassAssnComponent.Equals(verSec.ClassAssnComponent);

            HasBeenChanged = SubjectVer && CatalogNbrVer && ClassDescrVer && SectionVer && ConsentVer && EnrlCapVer && TopicDescrVer
                                && MeetingStartDtVer && MeetingEndDtVer && FacilityIdVer && MeetingTimeStartVer && MeetingTimeEndVer && MonVer && TuesVer
                                && WedVer && ThursVer && FriVer && SatVer && SunVer && InstructorVer && UnitsMinVer && UnitsMaxVer && ClassAssnComponentVer;
            return HasBeenChanged;
        }
    }
}