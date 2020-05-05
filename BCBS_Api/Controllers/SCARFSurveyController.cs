using BCBS_Api.Common;
using BCBS_Api.DataAccess;
using BCBS_Api.Models;
using System;
using System.Configuration;
using System.Reflection;
using System.Web.Http;
using System.Collections.Generic;
using System.IO;
using System.Data.SqlClient;
using LINQtoCSV;
using System.Collections;
using Kendo.Mvc.Extensions;
using System.Globalization;
using MvcRazorToPdf;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
//using System.Web.Mvc;
//using System.Web.Mvc;
using System.Web;
using System.Net;
using iTextSharp.text.html.simpleparser;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using System.Web.Routing;
using System.Web.UI;
using System.Net.Mail;
//using System.Web.Mvc;
//using System.Web.Routing;


//using Kendo.Mvc.UI;


namespace BCBS_Api.Controllers
{
    public class SCARFSurveyController : ApiController
    {
        [HttpPost]
        public SCARFSurveyAnswerModels SCARFSurveyPost([FromBody] SCARFSurveyAnswerModels SCARFSurveyModel)
        {
            SCARFSurveyAnswerModels OnjSCARFSurvey = new SCARFSurveyAnswerModels();
            try
            {
                if (String.IsNullOrEmpty(SCARFSurveyModel.WorkDayId.Trim()))
                {
                    SCARFSurveyModel.IsErrrorMsg = true;
                    SCARFSurveyModel.Message = "WorkDay Id is Required";
                }
                else if (String.IsNullOrEmpty(SCARFSurveyModel.LearnerName.Trim()))
                {
                    SCARFSurveyModel.IsErrrorMsg = true;
                    SCARFSurveyModel.Message = "Learner Name is Required";
                }
                else if (String.IsNullOrEmpty(SCARFSurveyModel.managerName.Trim()))
                {
                    SCARFSurveyModel.IsErrrorMsg = true;
                    SCARFSurveyModel.Message = "Manager Name is Required";
                }
                else if (String.IsNullOrEmpty(SCARFSurveyModel.managerEmailID.Trim()))
                {
                    SCARFSurveyModel.IsErrrorMsg = true;
                    SCARFSurveyModel.Message = "Manager Email Address is Required";
                }
                else if (SCARFSurveyModel.StatusText.Length > 300)
                {
                    SCARFSurveyModel.IsErrrorMsg = true;
                    SCARFSurveyModel.Message = "StatusText length exceeded.";
                }
                else if (SCARFSurveyModel.CertaintyText.Length > 300)
                {
                    SCARFSurveyModel.IsErrrorMsg = true;
                    SCARFSurveyModel.Message = "CertaintyText length exceeded.";
                }
                else if (SCARFSurveyModel.AutonomyText.Length > 300)
                {
                    SCARFSurveyModel.IsErrrorMsg = true;
                    SCARFSurveyModel.Message = "AutonomyText length exceeded.";
                }
                else if (SCARFSurveyModel.RelatednessText.Length > 300)
                {
                    SCARFSurveyModel.IsErrrorMsg = true;
                    SCARFSurveyModel.Message = "RelatednessText length exceeded.";
                }
                else if (SCARFSurveyModel.FairnessText.Length > 300)
                {
                    SCARFSurveyModel.IsErrrorMsg = true;
                    SCARFSurveyModel.Message = "FairnessText length exceeded.";
                }
                if (SCARFSurveyModel.IsErrrorMsg == false)
                {
                    SCARFSurveyModel.SCARFSurveyId = 0;
                    OnjSCARFSurvey.WorkDayId = SCARFSurveyModel.WorkDayId;
                    OnjSCARFSurvey.LearnerName = SCARFSurveyModel.LearnerName;
                    OnjSCARFSurvey.managerName = SCARFSurveyModel.managerName;                    
                    OnjSCARFSurvey.managerEmailID = SCARFSurveyModel.managerEmailID;
                    OnjSCARFSurvey.Status = SCARFSurveyModel.Status;
                    OnjSCARFSurvey.StatusText = SCARFSurveyModel.StatusText;
                    OnjSCARFSurvey.Certainty = SCARFSurveyModel.Certainty;
                    OnjSCARFSurvey.CertaintyText = SCARFSurveyModel.CertaintyText;
                    OnjSCARFSurvey.Autonomy = SCARFSurveyModel.Autonomy;
                    OnjSCARFSurvey.AutonomyText = SCARFSurveyModel.AutonomyText;
                    OnjSCARFSurvey.Relatedness = SCARFSurveyModel.Relatedness;
                    OnjSCARFSurvey.RelatednessText = SCARFSurveyModel.RelatednessText;
                    OnjSCARFSurvey.Fairness = SCARFSurveyModel.Fairness;
                    OnjSCARFSurvey.FairnessText = SCARFSurveyModel.FairnessText;

                    int result = BCBSDataAccess.SaveDataSCARFSurvey(OnjSCARFSurvey);

                    Util.LogInfo("Post", "After dsave call :" + result);
                    if (result > 0)
                    {

                        SCARFSurveyModel.SCARFSurveyId = result;
                        SCARFSurveyModel.IsErrrorMsg = false;
                        SCARFSurveyModel.Message = "Sucess";

                        var model = BCBSDataAccess.GetSCARFSurveyDataForPDF(SCARFSurveyModel.SCARFSurveyId);
                        if (model != null)
                        {
                            model.managerName = OnjSCARFSurvey.managerName;
                            string html = RenderViewToString("SCARFSurveyAnswer", "~/views/Shared/_SCARFSurveyAnswerPDF.cshtml", model);
                          
                            model.ReportDate = model.ReportDate;                            
                            byte[] buffer = Render(html);                            
                            using (MemoryStream stream = new System.IO.MemoryStream())
                            {                               
                                Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 100f, 0f);                                
                                PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                                writer.CloseStream = false;
                                pdfDoc.Open();                                
                                StringReader sr = new StringReader(html);                               
                                XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                                pdfDoc.Close();
                                buffer = stream.ToArray();
                               
                                Attachment AttachmentMemoryStream = new Attachment(new MemoryStream(buffer), "SCARFSurveyAnswer" + SCARFSurveyModel.SCARFSurveyId + ".PDF");
                               
                                //File Write in Folder With Out Mail 
                                //string FilePathandName = @"C:\Logs\" + "SCARFSurveyAnswer" + SCARFSurveyModel.SCARFSurveyId + ".PDF";
                                //File.WriteAllBytes(FilePathandName, buffer);

                                #region Mail Sending
                                    var subject = ConfigurationManager.AppSettings["MailSubject"] + model.LearnerName;
                                    var physicalPath = Util.ResolveFileName(@"Template\EmailTemplate.txt");
                                    var content = File.ReadAllText(physicalPath);
                                    string emailContent = content.Replace("@LearnerName", model.LearnerName).Replace("@ManagerName", model.managerName);
                                    Util.SendMail(OnjSCARFSurvey.managerEmailID, subject, emailContent, AttachmentMemoryStream);
                            }
                                #endregion

                        }
                        SCARFSurveyModel.WorkDayId = "";
                        SCARFSurveyModel.LearnerName = "";
                        SCARFSurveyModel.managerName = "";
                        SCARFSurveyModel.managerEmailID = "";
                        SCARFSurveyModel.Status = "";
                        SCARFSurveyModel.StatusText = "";
                        SCARFSurveyModel.Certainty = "";
                        SCARFSurveyModel.CertaintyText = "";
                        SCARFSurveyModel.Autonomy = "";
                        SCARFSurveyModel.AutonomyText = "";
                        SCARFSurveyModel.Relatedness = "";
                        SCARFSurveyModel.RelatednessText = "";
                        SCARFSurveyModel.Fairness = "";
                        SCARFSurveyModel.FairnessText = "";

                    }
                    else if (result == -1)
                    {
                        SCARFSurveyModel.SCARFSurveyId = 0;
                        SCARFSurveyModel.IsErrrorMsg = true;
                        SCARFSurveyModel.Message = "Duplicate WorkDayId";
                        SCARFSurveyModel.WorkDayId = "";
                        SCARFSurveyModel.LearnerName = "";
                        SCARFSurveyModel.managerName = "";
                        SCARFSurveyModel.managerEmailID = "";
                        SCARFSurveyModel.Status = "";
                        SCARFSurveyModel.StatusText = "";
                        SCARFSurveyModel.Certainty = "";
                        SCARFSurveyModel.CertaintyText = "";
                        SCARFSurveyModel.Autonomy = "";
                        SCARFSurveyModel.AutonomyText = "";
                        SCARFSurveyModel.Relatedness = "";
                        SCARFSurveyModel.RelatednessText = "";
                        SCARFSurveyModel.Fairness = "";

                    }
                    else
                    {
                        SCARFSurveyModel.SCARFSurveyId = 0;
                        SCARFSurveyModel.IsErrrorMsg = true;
                        SCARFSurveyModel.Message = "Fail";
                    }
                    SCARFSurveyModel.WorkDayId = OnjSCARFSurvey.WorkDayId;
                    SCARFSurveyModel.managerName = OnjSCARFSurvey.managerName;
                    SCARFSurveyModel.LearnerName = OnjSCARFSurvey.LearnerName;
                    SCARFSurveyModel.managerEmailID = OnjSCARFSurvey.managerEmailID;
                    SCARFSurveyModel.Status = OnjSCARFSurvey.Status;
                    SCARFSurveyModel.StatusText = OnjSCARFSurvey.StatusText;
                    SCARFSurveyModel.Certainty = OnjSCARFSurvey.Certainty;
                    SCARFSurveyModel.CertaintyText = OnjSCARFSurvey.CertaintyText;
                    SCARFSurveyModel.Autonomy = OnjSCARFSurvey.Autonomy;
                    SCARFSurveyModel.AutonomyText = OnjSCARFSurvey.AutonomyText;
                    SCARFSurveyModel.Relatedness = OnjSCARFSurvey.Relatedness;
                    SCARFSurveyModel.RelatednessText = OnjSCARFSurvey.RelatednessText;
                    SCARFSurveyModel.Fairness = OnjSCARFSurvey.Fairness;
                    SCARFSurveyModel.FairnessText = OnjSCARFSurvey.FairnessText;
                    SCARFSurveyModel.ReportDate = OnjSCARFSurvey.ReportDate;
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
                Util.LoggError(new System.Diagnostics.StackFrame(0).GetMethod().Name,
                    ex.Message, DetailsMessageError);
                SCARFSurveyModel.IsErrrorMsg = true;
                SCARFSurveyModel.Message = "Exception block: " + DetailsMessageError;
            }
            return SCARFSurveyModel;
        }

        public static string RenderViewToString(string controllerName, string viewName, object viewData)
        {
            var context = HttpContext.Current;
            var contextBase = new HttpContextWrapper(context);
            var routeData = new RouteData();
            routeData.Values.Add("controller", controllerName);

            var controllerContext = new System.Web.Mvc.ControllerContext(contextBase,
            routeData,
            new EmptyController());

            var razorViewEngine = new System.Web.Mvc.RazorViewEngine();
            var razorViewResult = razorViewEngine.FindView(controllerContext,
            viewName,
            "",
            false);

            var writer = new StringWriter();
            var viewContext = new System.Web.Mvc.ViewContext(controllerContext,
            razorViewResult.View,
            new System.Web.Mvc.ViewDataDictionary(viewData),
            new System.Web.Mvc.TempDataDictionary(),
            writer);
            razorViewResult.View.Render(viewContext, writer);

            return writer.ToString();
        }

        public byte[] Render(string contentHtml)
        {
            byte[] data;

            using (MemoryStream ms = new MemoryStream())
            {
                using (Document doc = new Document())
                {
                     PdfWriter writer = PdfWriter.GetInstance(doc, ms);
                     writer.CloseStream = false;
                     doc.Open();

                     using (var srHtml = new StringReader(contentHtml))
                     {
                         XMLWorkerHelper.GetInstance().ParseXHtml(writer, doc, srHtml);
                     }
                     doc.Close();
                     data = ms.ToArray();          
                }

                return data;
            }
        }
    }

   
    public class EmptyController : System.Web.Mvc.ControllerBase
    {
        protected override void ExecuteCore() { }
    }
}
