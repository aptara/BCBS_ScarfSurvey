using LINQtoCSV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BCBS_Api.Models
{
    public class SalesCertificate
    {
        public int SalesId { get; set; }

        public string WorkDayId { get; set; }

        public string LearnerName { get; set; }

        public bool PreAssmResult { get; set; }

        public string PreAssmResultString { get; set; }

        public decimal? PreAssmScore { get; set; }

        public int PostAssmAttempt { get; set; }
        public string PostAssmAttemptString { get; set; }

        public bool PostAssmResult { get; set; }
        public string PostAssmResultString { get; set; }

        public decimal? PostAssmScore { get; set; }

        public string PreAnsArr { get; set; }

        public string PostAnsArr { get; set; }

        public string Pre_Q01 { get; set; }
        public string Pre_Q02 { get; set; }
        public string Pre_Q03 { get; set; }
        public string Pre_Q04 { get; set; }
        public string Pre_Q05 { get; set; }
        public string Pre_Q06 { get; set; }
        public string Pre_Q07 { get; set; }
        public string Pre_Q08 { get; set; }
        public string Pre_Q09 { get; set; }
        public string Pre_Q10 { get; set; }
        public string Pre_Q11 { get; set; }
        public string Pre_Q12 { get; set; }
        public string Pre_Q13 { get; set; }
        public string Pre_Q14 { get; set; }
        public string Pre_Q15 { get; set; }
        public string Pre_Q16 { get; set; }
        public string Pre_Q17 { get; set; }
        public string Pre_Q18 { get; set; }
        public string Pre_Q19 { get; set; }
        public string Pre_Q20 { get; set; }
        public string Pre_Q21 { get; set; }
        public string Pre_Q22 { get; set; }
        public string Pre_Q23 { get; set; }
        public string Pre_Q24 { get; set; }
        public string Pre_Q25 { get; set; }
               
        public string Post_Q01 { get; set; }
        public string Post_Q02 { get; set; }
        public string Post_Q03 { get; set; }
        public string Post_Q04 { get; set; }
        public string Post_Q05 { get; set; }
        public string Post_Q06 { get; set; }
        public string Post_Q07 { get; set; }
        public string Post_Q08 { get; set; }
        public string Post_Q09 { get; set; }
        public string Post_Q10 { get; set; }
        public string Post_Q11 { get; set; }
        public string Post_Q12 { get; set; }
        public string Post_Q13 { get; set; }
        public string Post_Q14 { get; set; }
        public string Post_Q15 { get; set; }
        public string Post_Q16 { get; set; }
        public string Post_Q17 { get; set; }
        public string Post_Q18 { get; set; }
        public string Post_Q19 { get; set; }
        public string Post_Q20 { get; set; }
        public string Post_Q21 { get; set; }
        public string Post_Q22 { get; set; }
        public string Post_Q23 { get; set; }
        public string Post_Q24 { get; set; }
        public string Post_Q25 { get; set; }
        public bool IsErrrorMsg { get; set; }
        public string Message { get; set; }
        public int CompletionStatus { get; set; }
        public string CompletionStatusString { get; set; }
        public DateTime ReportDate { get; set; }
        public string ReportDateString { get; set; }

    }

    [Serializable]
    public class Data
    {
        [CsvColumn(FieldIndex = 1)]
        public int SalesId { get; set; }

        [CsvColumn(FieldIndex = 2)]
        public string WorkDayId { get; set; }

        [CsvColumn(FieldIndex = 3)]
        public string LearnerName { get; set; }

        [CsvColumn(FieldIndex = 4)]
        public string Pre_Q01 { get; set; }       

    }
}