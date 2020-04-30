using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace BCBS_Api.Models
{
    public class U65Certificate
    {
        public int U65_Id { get; set; }
        public string AgentName { get; set; }
        public string AgencyName { get; set; }
        public string AgencyAddress { get; set; }
        public string AgentManagingHealth { get; set; }
        public string AgentEmail { get; set; }
        public string WorkPhoneNumber { get; set; }
        public string NationalProducerNumber { get; set; }
        public string FFMID { get; set; }
        public decimal AssessmentScore { get; set; }
        public bool PassFailStatus { get; set; }
        public string PassFailStatusstring { get; set; }
        public DateTime DateofCompletion { get; set; }
        public string DateofCompletionstring { get; set; }

    }
}