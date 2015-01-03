using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XML.FormManager.Models
{
    public class ContractModel
    {
        public int contractNumber { get; set; }
        public string contractDate { get; set; }
        public string contractDate2 { get; set; }
        public string community { get; set; }
        public string contractEmployer { get; set; }
        public string contractAddress { get; set; }
        public string agencyNumber { get; set; }
        public string contractEmployee { get; set; }
        public string employeeCity { get; set; }
        public string employeeIDN { get; set; }
        public string identityCardNumber { get; set; }
        public string identityCardCreateDate { get; set; }
        public string firstSpecialty { get; set; }
        public int firstDiplomaNumber { get; set; }
        public string firstDiplomaDate { get; set; }
        public string firstDiplomaCreator { get; set; }
        public string secondSpecialty { get; set; }
        public int secondDiplomaNumber { get; set; }
        public string secondDiplomaDate { get; set; }
        public string secondDiplomaCreator { get; set; }
        public string workExperienceYears { get; set; }
        public string workExperienceMonths { get; set; }
        public string workExperienceDays { get; set; }
        public string workExperienceYearsWords { get; set; }
        public string workExperienceMonthsWords { get; set; }
        public string workExperienceDaysWords { get; set; }
        public string workPosition { get; set; }
        public string positionCode { get; set; }
        public string workPlace { get; set; }
        public string workTime { get; set; }
        public string testTerm { get; set; }
        public string payment { get; set; }
        public string paymentWords { get; set; }
        public string dateStartJob { get; set; }
    }
}