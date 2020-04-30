using BCBS_Api.DataAccess;
using Kendo.Mvc.UI;
using System.Collections.Generic;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using iTextSharp.text;
using System.IO;
using System.Configuration;
using System;
using MvcRazorToPdf;
using iTextSharp.text.pdf;
using BCBS_Api.Models;
using BCBS_Api.Common;

namespace BCBS_Api.Controllers
{
    public class SalesReportController : Controller
    {
        //
        // GET: /Assessment/

        public ActionResult Index()
        {
            try
            {

                if (Session["LoginUserId"] != null)
                {
                    Util.LogInfo("Sales Index", "SalesReport Controller");
                    return View();
                }
                else
                {
                    Session["LoginUserId"] = null;
                    Session.Abandon();
                    Util.LogInfo("Sales Index", "Session Abandon");
                }
            }
            catch (Exception ex)
            {

                string DetailsMessageError = null;
                if (ex.InnerException != null)
                {
                    DetailsMessageError = ex.InnerException.Message + " " + ex.StackTrace;
                }
                else
                {
                    DetailsMessageError = ex.StackTrace;
                }
                Util.LoggError(new System.Diagnostics.StackFrame(0).GetMethod().Name, ex.Message, DetailsMessageError);
            }

            return RedirectToAction("Login", "Account");
        }


        #region Sales
        [OutputCache(NoStore = true, Duration = 0)]
        public ActionResult GetSalesData([DataSourceRequest] DataSourceRequest request)
        {
            List<SalesCertificate> SalesCertificateModelList = null;

            SalesCertificateModelList = BCBSDataAccess.GetDataForSales();
            if (SalesCertificateModelList == null)
            {
                return Json(new List<SalesCertificate>(), JsonRequestBehavior.AllowGet);
            }
            return Json(SalesCertificateModelList.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }
        public ActionResult SalesExportData()
        {
            MemoryStream memoryStream = null;
            List<SalesCertificate> SalessModelList = null;
            const string header = "Workday ID, Learner Name,Completion Status,Report Date,Pre-Assm Result,Pre-Assm Score %, Post-Assm Attempt,Post-Assm Result,Post-Assm Score %,Pre-Q01, Pre-Q02, Pre-Q03, Pre-Q04, Pre-Q05, Pre-Q06, Pre-Q07, Pre-Q08, Pre-Q09, Pre-Q10, Pre-Q11, Pre-Q12, Pre-Q13, Pre-Q14, Pre-Q15, Pre-Q16, Pre-Q17, Pre-Q18, Pre-Q19, Pre-Q20, Pre-Q21, Pre-Q22, Pre-Q23, Pre-Q24, Pre-Q25, Post-Q01, Post-Q02, Post-Q03, Post-Q04, Post-Q05, Post-Q06, Post-Q07, Post-Q08, Post-Q09, Post-Q10, Post-Q11, Post-Q12, Post-Q13, Post-Q14, Post-Q15, Post-Q16, Post-Q17, Post-Q18, Post-Q19, Post-Q20, Post-Q21, Post-Q22, Post-Q23, Post-Q24, Post-Q25";
            const string format = "{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20},{21},{22},{23},{24},{25},{26},{27},{28},{29},{30},{31},{32},{33},{34},{35},{36},{37},{38},{39},{40},{41},{42},{43},{44},{45},{46},{47},{48},{49},{50},{51},{52},{53},{54},{55},{56},{57},{58}";
            string content = string.Empty;
            SalessModelList = BCBSDataAccess.GetDataForSales();
            memoryStream = new MemoryStream();
            if (SalessModelList != null && SalessModelList.Count > 0)
            {
                TextWriter tw = new StreamWriter(memoryStream);
                tw.WriteLine(header);
                foreach (var item in SalessModelList)
                {
                    item.WorkDayId = !String.IsNullOrEmpty(item.WorkDayId) ? (item.WorkDayId.Contains(",") ? item.WorkDayId.Replace(',', '|') : item.WorkDayId) : string.Empty;
                    item.LearnerName = !String.IsNullOrEmpty(item.LearnerName) ? (item.LearnerName.Contains(",") ? item.LearnerName.Replace(',', '|') : item.LearnerName) : string.Empty;
                    item.CompletionStatusString = !String.IsNullOrEmpty(item.CompletionStatusString) ? (item.CompletionStatusString.Contains(",") ? item.CompletionStatusString.Replace(',', '|') : item.CompletionStatusString) : string.Empty;
                    item.ReportDateString = item.ReportDate.ToString("MM/dd/yyyy");

                    item.PreAssmResultString = !String.IsNullOrEmpty(item.PreAssmResultString) ? (item.PreAssmResultString.Contains(",") ? item.PreAssmResultString.Replace(',', '|') : item.PreAssmResultString) : string.Empty;
                    item.PreAssmScore = item.PreAssmScore;
                    //item.PostAssmAttempt = item.PostAssmAttempt;
                    item.PostAssmResult = item.PostAssmResult;
                    if (item.PostAssmAttempt == 0)
                    {
                        item.PostAssmAttemptString = "NA";
                    }
                    else
                    {
                        item.PostAssmAttemptString = item.PostAssmAttempt.ToString();
                    }
                    if (item.PostAssmAttempt == 0)
                    {
                        item.PostAssmResultString = "NA";
                    }
                    else
                    {
                        item.PostAssmResultString = !String.IsNullOrEmpty(item.PostAssmResultString) ? (item.PostAssmResultString.Contains(",") ? item.PostAssmResultString.Replace(',', '|') : item.PostAssmResultString) : string.Empty;
                    }
                    item.PostAssmScore = item.PostAssmScore;                    
                    item.Pre_Q01 = item.Pre_Q01;
                    item.Pre_Q02 = item.Pre_Q02;
                    item.Pre_Q03 = item.Pre_Q03;
                    item.Pre_Q03 = item.Pre_Q03;
                    item.Pre_Q04 = item.Pre_Q04;
                    item.Pre_Q05 = item.Pre_Q05;
                    item.Pre_Q06 = item.Pre_Q06;
                    item.Pre_Q07 = item.Pre_Q07;
                    item.Pre_Q08 = item.Pre_Q08;
                    item.Pre_Q09 = item.Pre_Q09;
                    item.Pre_Q10 = item.Pre_Q10;
                    item.Pre_Q11 = item.Pre_Q11;
                    item.Pre_Q12 = item.Pre_Q12;
                    item.Pre_Q13 = item.Pre_Q13;
                    item.Pre_Q14 = item.Pre_Q14;
                    item.Pre_Q15 = item.Pre_Q15;
                    item.Pre_Q16 = item.Pre_Q16;
                    item.Pre_Q17 = item.Pre_Q17;
                    item.Pre_Q18 = item.Pre_Q18;
                    item.Pre_Q19 = item.Pre_Q19;
                    item.Pre_Q20 = item.Pre_Q20;
                    item.Pre_Q21 = item.Pre_Q21;
                    item.Pre_Q22 = item.Pre_Q22;
                    item.Pre_Q23 = item.Pre_Q23;
                    item.Pre_Q24 = item.Pre_Q24;
                    item.Pre_Q25 = item.Pre_Q25;
                    item.Post_Q01 = item.Post_Q01;
                    item.Post_Q02 = item.Post_Q02;
                    item.Post_Q03 = item.Post_Q03;
                    item.Post_Q04 = item.Post_Q04;
                    item.Post_Q05 = item.Post_Q05;
                    item.Post_Q06 = item.Post_Q06;
                    item.Post_Q07 = item.Post_Q07;
                    item.Post_Q08 = item.Post_Q08;
                    item.Post_Q09 = item.Post_Q09;
                    item.Post_Q10 = item.Post_Q10;
                    item.Post_Q11 = item.Post_Q11;
                    item.Post_Q12 = item.Post_Q12;
                    item.Post_Q13 = item.Post_Q13;
                    item.Post_Q14 = item.Post_Q14;
                    item.Post_Q15 = item.Post_Q15;
                    item.Post_Q16 = item.Post_Q16;
                    item.Post_Q17 = item.Post_Q17;
                    item.Post_Q18 = item.Post_Q18;
                    item.Post_Q19 = item.Post_Q19;
                    item.Post_Q20 = item.Post_Q20;
                    item.Post_Q21 = item.Post_Q21;
                    item.Post_Q22 = item.Post_Q22;
                    item.Post_Q23 = item.Post_Q23;
                    item.Post_Q24 = item.Post_Q24;
                    item.Post_Q25 = item.Post_Q25;
                    content = string.Format(format, item.WorkDayId, item.LearnerName, item.CompletionStatusString, item.ReportDateString, item.PreAssmResultString, item.PreAssmScore, item.PostAssmAttemptString, item.PostAssmResultString, item.PostAssmScore, item.Pre_Q01, item.Pre_Q02, item.Pre_Q03, item.Pre_Q04, item.Pre_Q05, item.Pre_Q06, item.Pre_Q07, item.Pre_Q08, item.Pre_Q09, item.Pre_Q10, item.Pre_Q11, item.Pre_Q12, item.Pre_Q13, item.Pre_Q14, item.Pre_Q15, item.Pre_Q16, item.Pre_Q17, item.Pre_Q18, item.Pre_Q19, item.Pre_Q20, item.Pre_Q21, item.Pre_Q22, item.Pre_Q23, item.Pre_Q24, item.Pre_Q25, item.Post_Q01, item.Post_Q02, item.Post_Q03, item.Post_Q04, item.Post_Q05, item.Post_Q06, item.Post_Q07, item.Post_Q08, item.Post_Q09, item.Post_Q10, item.Post_Q11, item.Post_Q12, item.Post_Q13, item.Post_Q14, item.Post_Q15, item.Post_Q16, item.Post_Q17, item.Post_Q18, item.Post_Q19, item.Post_Q20, item.Post_Q21, item.Post_Q22, item.Post_Q23, item.Post_Q24, item.Post_Q25);
                    tw.WriteLine(content);
                }
                tw.Flush();
            }

            string contentType = "application/octet-stream";
            byte[] pdfdata = null;
            pdfdata = memoryStream.ToArray();
            var filaName = (ConfigurationManager.AppSettings["ProjectName"]);
            var Datetime = "";
            Datetime = DateTime.Now.ToString("dd_MM_yyyy_T_HH:mm");

            return File(pdfdata, contentType, filaName + "_ExportData_" + Datetime + ".csv");
        }

        #endregion
    }
}
