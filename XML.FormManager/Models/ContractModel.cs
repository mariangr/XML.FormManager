using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace XML.FormManager.Models
{
    public class ContractModel
    {
        public int contractNumber { get; set; }
        public DateTime contractDate { get; set; }
        public DateTime contractDate2 { get; set; }
        public string community { get; set; }
        public string contractEmployer { get; set; }
        public string contractAddress { get; set; }
        public int agencyNumber { get; set; }
        public string contractEmployee { get; set; }
        public string employeeCity { get; set; }
        public string employeeIDN { get; set; }
        public string identityCardNumber { get; set; }
        public DateTime identityCardCreateDate { get; set; }
        public string firstSpecialty { get; set; }
        public int firstDiplomaNumber { get; set; }
        public DateTime firstDiplomaDate { get; set; }
        public string firstDiplomaCreator { get; set; }
        public string secondSpecialty { get; set; }
        public int secondDiplomaNumber { get; set; }
        public DateTime secondDiplomaDate { get; set; }
        public string secondDiplomaCreator { get; set; }
        public int workExperienceYears { get; set; }
        public short workExperienceMonths { get; set; }
        public short workExperienceDays { get; set; }
        public string workExperienceYearsWords { get; set; }
        public string workExperienceMonthsWords { get; set; }
        public string workExperienceDaysWords { get; set; }
        public string workPosition { get; set; }
        public string positionCode { get; set; }
        public string workPlace { get; set; }
        public short workTime { get; set; }
        public string testTerm { get; set; }
        public int payment { get; set; }
        public string paymentWords { get; set; }
        public DateTime dateStartJob { get; set; }
    }
}