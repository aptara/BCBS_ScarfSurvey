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
using System.Reflection;
using System.Web.Http;
using System.IO;
using System.Data.SqlClient;
using LINQtoCSV;
using System.Collections;
using System.Web;
using System.Web.Routing;



namespace BCBS_Api.Controllers
{
    public class SCARFSurveyAnswerController : Controller
    {
        //
        // GET: /Assessment/

        public ActionResult Index()
        {
            try
            {

                if (Session["LoginUserId"] != null)
                {
                    Util.LogInfo("SCARFSurveyAnswer Index", "SCARFSurveyAnswer Controller");
                    return View();
                }
                else
                {
                    Session["LoginUserId"] = null;
                    Session.Abandon();
                    Util.LogInfo("SCARFSurveyAnswer Index", "Session Abandon");
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

        #region SCARFSurveyAnswer

        [OutputCache(NoStore = true, Duration = 0)]
        public ActionResult GetSCARFSurveyAnswerData([DataSourceRequest] DataSourceRequest request)
        {
            List<SCARFSurveyAnswerModels> SCARFSurveyAnswerModelsList = null;

            SCARFSurveyAnswerModelsList = BCBSDataAccess.GetDataForSCARFSurveyAnswer();
            if (SCARFSurveyAnswerModelsList == null)
            {
                return Json(new List<SCARFSurveyAnswerModels>(), JsonRequestBehavior.AllowGet);
            }
            return Json(SCARFSurveyAnswerModelsList.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetExporttoSCARFSurveyAnswerData()
        {
            MemoryStream memoryStream = null;
            List<SCARFSurveyAnswerModels> SCARFSurveyAnswerModelsList = null;
            const string header = "Workday ID,Learner Name,Manager Name,Manager Email Address,Report Date,Status,Status Text,Certainty,Certainty Text,Autonomy,Autonomy Text,Relatedness,Relatedness Text,Fairness,Fairness Text";
            const string format = "{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14}";
            string content = string.Empty;
            SCARFSurveyAnswerModelsList = BCBSDataAccess.GetDataForSCARFSurveyAnswer();
            memoryStream = new MemoryStream();
            if (SCARFSurveyAnswerModelsList != null && SCARFSurveyAnswerModelsList.Count > 0)
            {
                TextWriter tw = new StreamWriter(memoryStream);
                tw.WriteLine(header);
                foreach (var item in SCARFSurveyAnswerModelsList)
                {
                    item.WorkDayId = item.WorkDayId;
                    item.LearnerName = item.LearnerName;
                    item.managerName = item.managerName;
                    item.managerEmailID = item.managerEmailID;
                    item.ReportDateString = item.ReportDate.ToString("MM/dd/yyyy").Trim();
                    item.Status = item.Status;
                    item.StatusText = item.StatusText;
                    item.Certainty = item.Certainty;
                    item.CertaintyText = item.CertaintyText;
                    item.Autonomy = item.Autonomy;
                    item.AutonomyText = item.AutonomyText;
                    item.Relatedness = item.Relatedness;
                    item.RelatednessText = item.RelatednessText;
                    item.Fairness = item.Fairness;
                    item.FairnessText = item.FairnessText;
                    content = string.Format(format, item.WorkDayId, item.LearnerName, item.managerName, item.managerEmailID, item.ReportDateString, item.Status, item.StatusText, item.Certainty, item.CertaintyText, item.Autonomy, item.AutonomyText, item.Relatedness, item.RelatednessText, item.Fairness, item.FairnessText);
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
