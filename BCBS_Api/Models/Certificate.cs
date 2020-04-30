using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace BCBS_Api.Models
{
    public class Certificate
    {
        public string CourseTitle { get; set; }
        public string DeliveryMethod { get; set; }
        public string TotalContactHours { get; set; } //Chnage 13/05/2019
        public string TypeofCredits { get; set; }
        
        public DateTime CompletionDate { get; set; }
        public string CompletionDateString { get; set; }
        public string PracticeName { get; set; }
        public string ProviderType { get; set; }
        public string OfficialProviderName { get; set; }
        public string MedicalLicenseNo { get; set; }
        public int Score { get; set; }
        public string EmailAddress { get; set; }
        public string UserName { get; set; }
        public string NPI { get; set; }

        public Guid UserCourseId { get; set; }

    }
}