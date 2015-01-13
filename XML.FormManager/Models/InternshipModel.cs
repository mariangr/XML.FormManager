using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XML.FormManager.Models
{
    public class InternshipModel
    {
        public int internshipNumber { get; set; }
        public string internshipDate { get; set; }
        public string internshipCompany { get; set; }
        public string internshipCompanyTown { get; set; }
        public int internshipCompanyNumber { get; set; }
        public int internshipCompanyBulstat { get; set; }
        public string internshipCompanyLeaderName { get; set; }
        public int internshipCompanyLeaderEgn { get; set; }
        public string internshipStudentName { get; set; }
        public int internshipStudentEgn { get; set; }
        public int internshipStudentLK { get; set; }
        public string internshipStudentLKMVR { get; set; }
        public string internshipStudentLKDate { get; set; }
        public string internshipStudentAddressTown { get; set; }
        public string internshipStudentAddressStreet { get; set; }
        public int internshipStudentAddressStreetNumber { get; set; }
        public int internshipStudentTelephoneNumber { get; set; }
        public string internshipStudentUniversity { get; set; }
        public string internshipStudentUniversityTown { get; set; }
        public int internshipStudentCourse { get; set; }
        public string internshipStudentGrade { get; set; }
        public string internshipStudentFaculty { get; set; }
        public int internshipStudentNumber { get; set; }
        public string internshipName { get; set; }
        public string internshipTasks { get; set; }
        public string internshipMentorName { get; set; }
        public string internshipMentorPosition { get; set; }
        public string internshipAcquiredSkills { get; set; }
        public string internshipRecommendations { get; set; }
        public string internshipAppraisalWord { get; set; } 
        public int internshipAppraisal { get; set; }
        public string internshipCurrentDate { get; set; }
        public string internshipCurrentTown { get; set; } 
    }
}