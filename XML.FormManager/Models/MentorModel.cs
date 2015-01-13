using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XML.FormManager.Models
{
    public class MentorModel
    {
        public int mentorNumber { get; set; }
        public int mentorDay { get; set; }
        public int mentorMonth { get; set; }
        public int mentorYear { get; set; }
        public string mentorFirstName { get; set; }
        public string mentorMiddleName { get; set; }
        public string mentorLastName { get; set; }
        public string mentorOrganization { get; set; }
        public string mentorFirstNameStudent { get; set; }
        public string mentorMiddleNameStudent { get; set; }
        public string mentorLastNameStudent { get; set; }
        public int mentorStudentDay { get; set; }
        public int mentorStudentMonth { get; set; }
        public int mentorStudentYear { get; set; }
        public int mentorStudentArrivalHour { get; set; }
        public int mentorStudentArrivalMinutes { get; set; }
        public int mentorStudentLeavingHour { get; set; }
        public int mentorStudentLeavingMinutes { get; set; }
        public string mentorStudentDescription { get; set; }
        public int mentorStudentRating { get; set; }
    }
}