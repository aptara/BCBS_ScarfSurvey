using LINQtoCSV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BCBS_Api.Models
{
    public class SCARFSurveyAnswerModels
    {
        public int SCARFSurveyId { get; set; }
        public string WorkDayId { get; set; }
        public string LearnerName { get; set; }
        public string managerName { get; set; }
        public string managerEmailID { get; set; }
        public string Status { get; set; }
        public string StatusText { get; set; }
        public string Certainty { get; set; }
        public string CertaintyText { get; set; }
        public string Autonomy { get; set; }
        public string AutonomyText { get; set; }
        public string Relatedness { get; set; }
        public string RelatednessText { get; set; }
        public string Fairness { get; set; }
        public string FairnessText { get; set; }
        public DateTime ReportDate { get; set; }
        public string ReportDateString { get; set; }
        public bool IsErrrorMsg { get; set; }
        public string Message { get; set; }

    }

}