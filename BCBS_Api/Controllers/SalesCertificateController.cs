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

namespace BCBS_Api.Controllers
{
    public class SalesCertificateController : ApiController
    {
        //[HttpPost]
        //public SalesCertificate SalesPost([FromBody] SalesCertificate SalesCertificateModel)
        //{
        //    SalesCertificate OnjSalesCertificate = new SalesCertificate();
        //    try
        //    {
        //        var PreAns = SalesCertificateModel.PreAnsArr.Split(',');
        //        string[] PostAns = { };
        //        if (!String.IsNullOrEmpty(SalesCertificateModel.PostAnsArr))
        //        {
        //            PostAns = SalesCertificateModel.PostAnsArr.Split(',');
        //        }
             
        //        int SalesPreArray = Convert.ToInt32(ConfigurationManager.AppSettings["SalesPreArray"]);
        //        int SalesPostArray = Convert.ToInt32(ConfigurationManager.AppSettings["SalesPostArray"]);

        //        if (String.IsNullOrEmpty(SalesCertificateModel.WorkDayId.Trim()))
        //        {
        //            SalesCertificateModel.IsErrrorMsg = true;
        //            SalesCertificateModel.Message = "WorkDay Id is Required";
        //        }
        //        else if (String.IsNullOrEmpty(SalesCertificateModel.LearnerName.Trim()))
        //        {
        //            SalesCertificateModel.IsErrrorMsg = true;
        //            SalesCertificateModel.Message = "Learner Name is Required";
        //        }
        //        else if (String.IsNullOrEmpty(SalesCertificateModel.PreAnsArr.Trim()))
        //        {
        //            SalesCertificateModel.IsErrrorMsg = true;
        //            SalesCertificateModel.Message = "PreAnsArr is Required";
        //        }
        //        if (SalesPreArray != PreAns.Length)
        //        {
        //            SalesCertificateModel.IsErrrorMsg = true;
        //            SalesCertificateModel.Message = string.Format("PreAnsArr length is (" + PreAns.Length + ") mismatch. In API, configured array length is " + SalesPreArray);
        //        }
        //        if (PostAns.Length != 0 && SalesPostArray != PostAns.Length)
        //        {
        //            SalesCertificateModel.IsErrrorMsg = true;
        //            SalesCertificateModel.Message = string.Format("PostAnsArr length is (" + PostAns.Length + ") mismatch. In API configured length is " + SalesPostArray);
        //        }
        //        if (SalesCertificateModel.IsErrrorMsg == false)
        //        {
        //            OnjSalesCertificate.SalesId = 0;
        //            OnjSalesCertificate.WorkDayId = SalesCertificateModel.WorkDayId;
        //            OnjSalesCertificate.LearnerName = SalesCertificateModel.LearnerName;
        //            OnjSalesCertificate.PreAssmResult = SalesCertificateModel.PreAssmResult;
        //            OnjSalesCertificate.PreAssmScore = SalesCertificateModel.PreAssmScore;
        //            OnjSalesCertificate.PostAssmAttempt = SalesCertificateModel.PostAssmAttempt;
        //            OnjSalesCertificate.PostAssmResult = SalesCertificateModel.PostAssmResult;
        //            OnjSalesCertificate.PostAssmScore = SalesCertificateModel.PostAssmScore;
        //            OnjSalesCertificate.CompletionStatus = SalesCertificateModel.CompletionStatus;
        //            #region PreAns
        //            for (int i = 0; i < PreAns.Length; i++)
        //            {
        //                if (!String.IsNullOrEmpty(PreAns[i].Trim()))
        //                {
        //                    if (i == 0)
        //                    {
        //                        OnjSalesCertificate.Pre_Q01 = PreAns[i].ToString();
        //                    }
        //                    if (i == 1)
        //                    {
        //                        OnjSalesCertificate.Pre_Q02 = PreAns[i].ToString();
        //                    }
        //                    if (i == 2)
        //                    {
        //                        OnjSalesCertificate.Pre_Q03 = PreAns[i].ToString();
        //                    }
        //                    if (i == 3)
        //                    {
        //                        OnjSalesCertificate.Pre_Q04 = PreAns[i].ToString();
        //                    }
        //                    if (i == 4)
        //                    {
        //                        OnjSalesCertificate.Pre_Q05 = PreAns[i].ToString();
        //                    }
        //                    if (i == 5)
        //                    {
        //                        OnjSalesCertificate.Pre_Q06 = PreAns[i].ToString();
        //                    }
        //                    if (i == 6)
        //                    {
        //                        OnjSalesCertificate.Pre_Q07 = PreAns[i].ToString();
        //                    }
        //                    if (i == 7)
        //                    {
        //                        OnjSalesCertificate.Pre_Q08 = PreAns[i].ToString();
        //                    }
        //                    if (i == 8)
        //                    {
        //                        OnjSalesCertificate.Pre_Q09 = PreAns[i].ToString();
        //                    }
        //                    if (i == 9)
        //                    {
        //                        OnjSalesCertificate.Pre_Q10 = PreAns[i].ToString();
        //                    }                           
        //                    if (i == 10)
        //                    {
        //                        OnjSalesCertificate.Pre_Q11 = PreAns[i].ToString();
        //                    }
        //                    if (i == 11)
        //                    {
        //                        OnjSalesCertificate.Pre_Q12 = PreAns[i].ToString();
        //                    }
        //                    if (i == 12)
        //                    {
        //                        OnjSalesCertificate.Pre_Q13 = PreAns[i].ToString();
        //                    }
        //                    if (i == 13)
        //                    {
        //                        OnjSalesCertificate.Pre_Q14 = PreAns[i].ToString();
        //                    }
        //                    if (i == 14)
        //                    {
        //                        OnjSalesCertificate.Pre_Q15 = PreAns[i].ToString();
        //                    }
        //                    if (i == 15)
        //                    {
        //                        OnjSalesCertificate.Pre_Q16 = PreAns[i].ToString();
        //                    }
        //                    if (i == 16)
        //                    {
        //                        OnjSalesCertificate.Pre_Q17 = PreAns[i].ToString();
        //                    }
        //                    if (i == 17)
        //                    {
        //                        OnjSalesCertificate.Pre_Q18 = PreAns[i].ToString();
        //                    }
        //                    if (i == 18)
        //                    {
        //                        OnjSalesCertificate.Pre_Q19 = PreAns[i].ToString();
        //                    }
        //                    if (i == 19)
        //                    {
        //                        OnjSalesCertificate.Pre_Q20 = PreAns[i].ToString();
        //                    }
        //                    if (i == 20)
        //                    {
        //                        OnjSalesCertificate.Pre_Q21 = PreAns[i].ToString();
        //                    }
        //                    if (i == 21)
        //                    {
        //                        OnjSalesCertificate.Pre_Q22 = PreAns[i].ToString();
        //                    }
        //                    if (i == 22)
        //                    {
        //                        OnjSalesCertificate.Pre_Q23 = PreAns[i].ToString();
        //                    }
        //                    if (i == 23)
        //                    {
        //                        OnjSalesCertificate.Pre_Q24 = PreAns[i].ToString();
        //                    }
        //                    if (i == 24)
        //                    {
        //                        OnjSalesCertificate.Pre_Q25 = PreAns[i].ToString();
        //                    }
        //                }
        //            }

        //            #endregion
        //            #region PostAns
        //            for (int j = 0; j < PostAns.Length; j++)
        //            {
        //                if (!String.IsNullOrEmpty(PostAns[j].Trim()))
        //                {
        //                    if (j == 0)
        //                    {
        //                        OnjSalesCertificate.Post_Q01 = PostAns[j].ToString();
        //                    }
        //                    if (j == 1)
        //                    {
        //                        OnjSalesCertificate.Post_Q02 = PostAns[j].ToString();
        //                    }
        //                    if (j == 2)
        //                    {
        //                        OnjSalesCertificate.Post_Q03 = PostAns[j].ToString();
        //                    }
        //                    if (j == 3)
        //                    {
        //                        OnjSalesCertificate.Post_Q04 = PostAns[j].ToString();
        //                    }
        //                    if (j == 4)
        //                    {
        //                        OnjSalesCertificate.Post_Q05 = PostAns[j].ToString();
        //                    }
        //                    if (j == 5)
        //                    {
        //                        OnjSalesCertificate.Post_Q06 = PostAns[j].ToString();
        //                    }
        //                    if (j == 6)
        //                    {
        //                        OnjSalesCertificate.Post_Q07 = PostAns[j].ToString();
        //                    }
        //                    if (j == 7)
        //                    {
        //                        OnjSalesCertificate.Post_Q08 = PostAns[j].ToString();
        //                    }
        //                    if (j == 8)
        //                    {
        //                        OnjSalesCertificate.Post_Q09 = PostAns[j].ToString();
        //                    }
        //                    if (j == 9)
        //                    {
        //                        OnjSalesCertificate.Post_Q10 = PostAns[j].ToString();
        //                    }
        //                    if (j == 10)
        //                    {
        //                        OnjSalesCertificate.Post_Q11 = PostAns[j].ToString();
        //                    }
        //                    if (j == 11)
        //                    {
        //                        OnjSalesCertificate.Post_Q12 = PostAns[j].ToString();
        //                    }
        //                    if (j == 12)
        //                    {
        //                        OnjSalesCertificate.Post_Q13 = PostAns[j].ToString();
        //                    }
        //                    if (j == 13)
        //                    {
        //                        OnjSalesCertificate.Post_Q14 = PostAns[j].ToString();
        //                    }
        //                    if (j == 14)
        //                    {
        //                        OnjSalesCertificate.Post_Q15 = PostAns[j].ToString();
        //                    }
        //                    if (j == 15)
        //                    {
        //                        OnjSalesCertificate.Post_Q16 = PostAns[j].ToString();
        //                    }
        //                    if (j == 16)
        //                    {
        //                        OnjSalesCertificate.Post_Q17 = PostAns[j].ToString();
        //                    }
        //                    if (j == 17)
        //                    {
        //                        OnjSalesCertificate.Post_Q18 = PostAns[j].ToString();
        //                    }
        //                    if (j == 18)
        //                    {
        //                        OnjSalesCertificate.Post_Q19 = PostAns[j].ToString();
        //                    }
        //                    if (j == 19)
        //                    {
        //                        OnjSalesCertificate.Post_Q20 = PostAns[j].ToString();
        //                    }
        //                    if (j == 20)
        //                    {
        //                        OnjSalesCertificate.Post_Q21 = PostAns[j].ToString();
        //                    }
        //                    if (j == 21)
        //                    {
        //                        OnjSalesCertificate.Post_Q22 = PostAns[j].ToString();
        //                    }
        //                    if (j == 22)
        //                    {
        //                        OnjSalesCertificate.Post_Q23 = PostAns[j].ToString();
        //                    }
        //                    if (j == 23)
        //                    {
        //                        OnjSalesCertificate.Post_Q24 = PostAns[j].ToString();
        //                    }
        //                    if (j == 24)
        //                    {
        //                        OnjSalesCertificate.Post_Q25 = PostAns[j].ToString();
        //                    }
        //                }
        //            }
        //            SetDefultValues(PreAns.Length, PostAns.Length,OnjSalesCertificate);

        //            #endregion

        //            int result = BCBSDataAccess.SaveDataSales(OnjSalesCertificate);
        //            Util.LogInfo("Post", "After dsave call :" + result);
        //            if (result > 0)
        //            {
        //                SalesCertificateModel.SalesId = result;
        //                SalesCertificateModel.IsErrrorMsg = false;
        //                SalesCertificateModel.Message = "Sucess";

        //                if (result > 0)
        //                {
        //                    string XmlFileName = "";

        //                    string[] fileNames = XmlFileName.Split('|');
        //                    string directoryName = Path.GetDirectoryName(fileNames[0]);
                     


                       

                          

        //                    //<List>SalesCertificate OnjSalesCertificate = OnjSalesCertificate;
        //                    //List<Data> regLibraryRecord = DataList;

        //                    //CsvFileDescription csvFileDescription = new CsvFileDescription
        //                    //{
        //                    //    SeparatorChar = '\t',
        //                    //    FirstLineHasColumnNames = true,
        //                    //    IgnoreUnknownColumns = true,
        //                    //    EnforceCsvColumnAttribute = true
        //                    //};
        //                    //CsvContext csvContext = new CsvContext();
        //                    //csvContext.Write<Data>(regLibraryRecord, fileNames[0], csvFileDescription);

        //                    var subject = ConfigurationManager.AppSettings["MailSubject"];
        //                    var physicalPath = Util.ResolveFileName(@"Template\EmailTemplate.txt");
        //                    var content = File.ReadAllText(physicalPath);
        //                    var emailContent = string.Format(content, "SCARF Survey Tool", "http://localhost:52844/");                           

        //                    Util.SendMail("Pushpraj.Jagadale@aptaracorp.com", subject, emailContent);
        //                }
        //            }
        //            else if (result == -1)
        //            {                   
        //                SalesCertificateModel.SalesId = 0;
        //                SalesCertificateModel.IsErrrorMsg = true;                        
        //                SalesCertificateModel.Message = "Duplicate WorkDayId";
        //            }
        //            else 
        //            {
        //                SalesCertificateModel.SalesId = 0;
        //                SalesCertificateModel.IsErrrorMsg = true;
        //                SalesCertificateModel.Message = "Fail";
        //            }
        //            SalesCertificateModel.WorkDayId = OnjSalesCertificate.WorkDayId;
        //            SalesCertificateModel.LearnerName = OnjSalesCertificate.LearnerName;
        //            SalesCertificateModel.PreAssmResult = OnjSalesCertificate.PreAssmResult;
        //            if (String.IsNullOrEmpty(OnjSalesCertificate.PreAssmResultString))
        //            {
        //                SalesCertificateModel.PreAssmResultString = "";
        //            }
        //            else
        //            {
        //                SalesCertificateModel.PreAssmResultString = OnjSalesCertificate.PreAssmResultString;
        //            }
        //            SalesCertificateModel.PreAssmScore = OnjSalesCertificate.PreAssmScore;
        //            SalesCertificateModel.PostAssmAttempt = OnjSalesCertificate.PostAssmAttempt;
        //            SalesCertificateModel.PostAssmResult = OnjSalesCertificate.PostAssmResult;
        //            SalesCertificateModel.PostAssmResultString = OnjSalesCertificate.PostAssmResultString;
        //            if (String.IsNullOrEmpty(OnjSalesCertificate.PostAssmResultString))
        //            {
        //                SalesCertificateModel.PostAssmResultString = "";
        //            }
        //            else
        //            {
        //                SalesCertificateModel.PostAssmResultString = OnjSalesCertificate.PostAssmResultString;
        //            }
        //            if (OnjSalesCertificate.CompletionStatus == 0)
        //            {
        //                SalesCertificateModel.CompletionStatusString = "In-Complete";
        //            }
        //            else
        //            {
        //                SalesCertificateModel.CompletionStatusString = "Complete";
        //            }
        //            SalesCertificateModel.PostAssmScore = OnjSalesCertificate.PostAssmScore;
        //            SalesCertificateModel.Pre_Q01 = OnjSalesCertificate.Pre_Q01;
        //            SalesCertificateModel.Pre_Q02 = OnjSalesCertificate.Pre_Q02;
        //            SalesCertificateModel.Pre_Q03 = OnjSalesCertificate.Pre_Q03;
        //            SalesCertificateModel.Pre_Q04 = OnjSalesCertificate.Pre_Q04;
        //            SalesCertificateModel.Pre_Q05 = OnjSalesCertificate.Pre_Q05;
        //            SalesCertificateModel.Pre_Q06 = OnjSalesCertificate.Pre_Q06;
        //            SalesCertificateModel.Pre_Q07 = OnjSalesCertificate.Pre_Q07;
        //            SalesCertificateModel.Pre_Q08 = OnjSalesCertificate.Pre_Q08;
        //            SalesCertificateModel.Pre_Q09 = OnjSalesCertificate.Pre_Q09;
        //            SalesCertificateModel.Pre_Q10 = OnjSalesCertificate.Pre_Q10;
        //            SalesCertificateModel.Pre_Q11 = OnjSalesCertificate.Pre_Q11;
        //            SalesCertificateModel.Pre_Q12 = OnjSalesCertificate.Pre_Q12;
        //            SalesCertificateModel.Pre_Q13 = OnjSalesCertificate.Pre_Q13;
        //            SalesCertificateModel.Pre_Q14 = OnjSalesCertificate.Pre_Q14;
        //            SalesCertificateModel.Pre_Q15 = OnjSalesCertificate.Pre_Q15;
        //            SalesCertificateModel.Pre_Q16 = OnjSalesCertificate.Pre_Q16;
        //            SalesCertificateModel.Pre_Q17 = OnjSalesCertificate.Pre_Q17;
        //            SalesCertificateModel.Pre_Q18 = OnjSalesCertificate.Pre_Q18;
        //            SalesCertificateModel.Pre_Q19 = OnjSalesCertificate.Pre_Q19;
        //            SalesCertificateModel.Pre_Q20 = OnjSalesCertificate.Pre_Q20;
        //            SalesCertificateModel.Pre_Q21 = OnjSalesCertificate.Pre_Q21;
        //            SalesCertificateModel.Pre_Q22 = OnjSalesCertificate.Pre_Q22;
        //            SalesCertificateModel.Pre_Q23 = OnjSalesCertificate.Pre_Q23;
        //            SalesCertificateModel.Pre_Q24 = OnjSalesCertificate.Pre_Q24;
        //            SalesCertificateModel.Pre_Q25 = OnjSalesCertificate.Pre_Q25;

        //            SalesCertificateModel.Post_Q01 = OnjSalesCertificate.Post_Q01;
        //            SalesCertificateModel.Post_Q02 = OnjSalesCertificate.Post_Q02;
        //            SalesCertificateModel.Post_Q03 = OnjSalesCertificate.Post_Q03;
        //            SalesCertificateModel.Post_Q04 = OnjSalesCertificate.Post_Q04;
        //            SalesCertificateModel.Post_Q05 = OnjSalesCertificate.Post_Q05;
        //            SalesCertificateModel.Post_Q06 = OnjSalesCertificate.Post_Q06;
        //            SalesCertificateModel.Post_Q07 = OnjSalesCertificate.Post_Q07;
        //            SalesCertificateModel.Post_Q08 = OnjSalesCertificate.Post_Q08;
        //            SalesCertificateModel.Post_Q09 = OnjSalesCertificate.Post_Q09;
        //            SalesCertificateModel.Post_Q10 = OnjSalesCertificate.Post_Q10;
        //            SalesCertificateModel.Post_Q11 = OnjSalesCertificate.Post_Q11;
        //            SalesCertificateModel.Post_Q12 = OnjSalesCertificate.Post_Q12;
        //            SalesCertificateModel.Post_Q13 = OnjSalesCertificate.Post_Q13;
        //            SalesCertificateModel.Post_Q14 = OnjSalesCertificate.Post_Q14;
        //            SalesCertificateModel.Post_Q15 = OnjSalesCertificate.Post_Q15;
        //            SalesCertificateModel.Post_Q16 = OnjSalesCertificate.Post_Q16;
        //            SalesCertificateModel.Post_Q17 = OnjSalesCertificate.Post_Q17;
        //            SalesCertificateModel.Post_Q18 = OnjSalesCertificate.Post_Q18;
        //            SalesCertificateModel.Post_Q19 = OnjSalesCertificate.Post_Q19;
        //            SalesCertificateModel.Post_Q20 = OnjSalesCertificate.Post_Q20;
        //            SalesCertificateModel.Post_Q21 = OnjSalesCertificate.Post_Q21;
        //            SalesCertificateModel.Post_Q22 = OnjSalesCertificate.Post_Q22;
        //            SalesCertificateModel.Post_Q23 = OnjSalesCertificate.Post_Q23;
        //            SalesCertificateModel.Post_Q24 = OnjSalesCertificate.Post_Q24;
        //            SalesCertificateModel.Post_Q25 = OnjSalesCertificate.Post_Q25;

        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        string DetailsMessageError = null;
        //        if (ex.InnerException != null)
        //        {
        //            DetailsMessageError = ex.InnerException.Message + " " + ex.StackTrace;
        //        }
        //        else
        //        {
        //            DetailsMessageError = ex.StackTrace;
        //        }
        //        Util.LoggError(new System.Diagnostics.StackFrame(0).GetMethod().Name,
        //            ex.Message, DetailsMessageError);
        //        SalesCertificateModel.IsErrrorMsg = true;
        //        SalesCertificateModel.Message = "Exception block: " + DetailsMessageError;
        //    }
        //    return SalesCertificateModel;
        //}

        //public void SetDefultValues(int PreValuesCount, int PostValuesCount, SalesCertificate SalesCertificate)
        //{
        //    if (PreValuesCount == 0)
        //    {
        //        SalesCertificate.Pre_Q01 = "NA";
        //        SalesCertificate.Pre_Q02 = "NA";
        //        SalesCertificate.Pre_Q03 = "NA";
        //        SalesCertificate.Pre_Q04 = "NA";
        //        SalesCertificate.Pre_Q05 = "NA";
        //        SalesCertificate.Pre_Q06 = "NA";
        //        SalesCertificate.Pre_Q07 = "NA";
        //        SalesCertificate.Pre_Q08 = "NA";
        //        SalesCertificate.Pre_Q09 = "NA";
        //        SalesCertificate.Pre_Q10 = "NA";
        //        SalesCertificate.Pre_Q11 = "NA";
        //        SalesCertificate.Pre_Q12 = "NA";
        //        SalesCertificate.Pre_Q13 = "NA";
        //        SalesCertificate.Pre_Q14 = "NA";
        //        SalesCertificate.Pre_Q15 = "NA";
        //        SalesCertificate.Pre_Q16 = "NA";
        //        SalesCertificate.Pre_Q17 = "NA";
        //        SalesCertificate.Pre_Q18 = "NA";
        //        SalesCertificate.Pre_Q19 = "NA";
        //        SalesCertificate.Pre_Q20 = "NA";
        //        SalesCertificate.Pre_Q21 = "NA";
        //        SalesCertificate.Pre_Q22 = "NA";
        //        SalesCertificate.Pre_Q23 = "NA";
        //        SalesCertificate.Pre_Q24 = "NA";
        //        SalesCertificate.Pre_Q25 = "NA";
        //    }
        //    if (PreValuesCount == 1)
        //    {
        //        SalesCertificate.Pre_Q02 = "NA";
        //        SalesCertificate.Pre_Q03 = "NA";
        //        SalesCertificate.Pre_Q04 = "NA";
        //        SalesCertificate.Pre_Q05 = "NA";
        //        SalesCertificate.Pre_Q06 = "NA";
        //        SalesCertificate.Pre_Q07 = "NA";
        //        SalesCertificate.Pre_Q08 = "NA";
        //        SalesCertificate.Pre_Q09 = "NA";
        //        SalesCertificate.Pre_Q10 = "NA";
        //        SalesCertificate.Pre_Q11 = "NA";
        //        SalesCertificate.Pre_Q12 = "NA";
        //        SalesCertificate.Pre_Q13 = "NA";
        //        SalesCertificate.Pre_Q14 = "NA";
        //        SalesCertificate.Pre_Q15 = "NA";
        //        SalesCertificate.Pre_Q16 = "NA";
        //        SalesCertificate.Pre_Q17 = "NA";
        //        SalesCertificate.Pre_Q18 = "NA";
        //        SalesCertificate.Pre_Q19 = "NA";
        //        SalesCertificate.Pre_Q20 = "NA";
        //        SalesCertificate.Pre_Q21 = "NA";
        //        SalesCertificate.Pre_Q22 = "NA";
        //        SalesCertificate.Pre_Q23 = "NA";
        //        SalesCertificate.Pre_Q24 = "NA";
        //        SalesCertificate.Pre_Q25 = "NA";
        //    }
        //    if (PreValuesCount == 2)
        //    {
        //        SalesCertificate.Pre_Q03 = "NA";
        //        SalesCertificate.Pre_Q04 = "NA";
        //        SalesCertificate.Pre_Q05 = "NA";
        //        SalesCertificate.Pre_Q06 = "NA";
        //        SalesCertificate.Pre_Q07 = "NA";
        //        SalesCertificate.Pre_Q08 = "NA";
        //        SalesCertificate.Pre_Q09 = "NA";
        //        SalesCertificate.Pre_Q10 = "NA";
        //        SalesCertificate.Pre_Q11 = "NA";
        //        SalesCertificate.Pre_Q12 = "NA";
        //        SalesCertificate.Pre_Q13 = "NA";
        //        SalesCertificate.Pre_Q14 = "NA";
        //        SalesCertificate.Pre_Q15 = "NA";
        //        SalesCertificate.Pre_Q16 = "NA";
        //        SalesCertificate.Pre_Q17 = "NA";
        //        SalesCertificate.Pre_Q18 = "NA";
        //        SalesCertificate.Pre_Q19 = "NA";
        //        SalesCertificate.Pre_Q20 = "NA";
        //        SalesCertificate.Pre_Q21 = "NA";
        //        SalesCertificate.Pre_Q22 = "NA";
        //        SalesCertificate.Pre_Q23 = "NA";
        //        SalesCertificate.Pre_Q24 = "NA";
        //        SalesCertificate.Pre_Q25 = "NA";
        //    }
        //    if (PreValuesCount == 3)
        //    {
        //        SalesCertificate.Pre_Q04 = "NA";
        //        SalesCertificate.Pre_Q05 = "NA";
        //        SalesCertificate.Pre_Q06 = "NA";
        //        SalesCertificate.Pre_Q07 = "NA";
        //        SalesCertificate.Pre_Q08 = "NA";
        //        SalesCertificate.Pre_Q09 = "NA";
        //        SalesCertificate.Pre_Q10 = "NA";
        //        SalesCertificate.Pre_Q11 = "NA";
        //        SalesCertificate.Pre_Q12 = "NA";
        //        SalesCertificate.Pre_Q13 = "NA";
        //        SalesCertificate.Pre_Q14 = "NA";
        //        SalesCertificate.Pre_Q15 = "NA";
        //        SalesCertificate.Pre_Q16 = "NA";
        //        SalesCertificate.Pre_Q17 = "NA";
        //        SalesCertificate.Pre_Q18 = "NA";
        //        SalesCertificate.Pre_Q19 = "NA";
        //        SalesCertificate.Pre_Q20 = "NA";
        //        SalesCertificate.Pre_Q21 = "NA";
        //        SalesCertificate.Pre_Q22 = "NA";
        //        SalesCertificate.Pre_Q23 = "NA";
        //        SalesCertificate.Pre_Q24 = "NA";
        //        SalesCertificate.Pre_Q25 = "NA";

        //    }
        //    if (PreValuesCount == 4)
        //    {
        //        SalesCertificate.Pre_Q05 = "NA";
        //        SalesCertificate.Pre_Q06 = "NA";
        //        SalesCertificate.Pre_Q07 = "NA";
        //        SalesCertificate.Pre_Q08 = "NA";
        //        SalesCertificate.Pre_Q09 = "NA";
        //        SalesCertificate.Pre_Q10 = "NA";
        //        SalesCertificate.Pre_Q11 = "NA";
        //        SalesCertificate.Pre_Q12 = "NA";
        //        SalesCertificate.Pre_Q13 = "NA";
        //        SalesCertificate.Pre_Q14 = "NA";
        //        SalesCertificate.Pre_Q15 = "NA";
        //        SalesCertificate.Pre_Q16 = "NA";
        //        SalesCertificate.Pre_Q17 = "NA";
        //        SalesCertificate.Pre_Q18 = "NA";
        //        SalesCertificate.Pre_Q19 = "NA";
        //        SalesCertificate.Pre_Q20 = "NA";
        //        SalesCertificate.Pre_Q21 = "NA";
        //        SalesCertificate.Pre_Q22 = "NA";
        //        SalesCertificate.Pre_Q23 = "NA";
        //        SalesCertificate.Pre_Q24 = "NA";
        //        SalesCertificate.Pre_Q25 = "NA";
        //    }
        //    if (PreValuesCount == 5)
        //    {
        //        SalesCertificate.Pre_Q05 = "NA";
        //        SalesCertificate.Pre_Q06 = "NA";
        //        SalesCertificate.Pre_Q07 = "NA";
        //        SalesCertificate.Pre_Q08 = "NA";
        //        SalesCertificate.Pre_Q09 = "NA";
        //        SalesCertificate.Pre_Q10 = "NA";
        //        SalesCertificate.Pre_Q11 = "NA";
        //        SalesCertificate.Pre_Q12 = "NA";
        //        SalesCertificate.Pre_Q13 = "NA";
        //        SalesCertificate.Pre_Q14 = "NA";
        //        SalesCertificate.Pre_Q15 = "NA";
        //        SalesCertificate.Pre_Q16 = "NA";
        //        SalesCertificate.Pre_Q17 = "NA";
        //        SalesCertificate.Pre_Q18 = "NA";
        //        SalesCertificate.Pre_Q19 = "NA";
        //        SalesCertificate.Pre_Q20 = "NA";
        //        SalesCertificate.Pre_Q21 = "NA";
        //        SalesCertificate.Pre_Q22 = "NA";
        //        SalesCertificate.Pre_Q23 = "NA";
        //        SalesCertificate.Pre_Q24 = "NA";
        //        SalesCertificate.Pre_Q25 = "NA";
        //    }
        //    if (PreValuesCount == 6)
        //    {
        //        SalesCertificate.Pre_Q07 = "NA";
        //        SalesCertificate.Pre_Q08 = "NA";
        //        SalesCertificate.Pre_Q09 = "NA";
        //        SalesCertificate.Pre_Q10 = "NA";
        //        SalesCertificate.Pre_Q11 = "NA";
        //        SalesCertificate.Pre_Q12 = "NA";
        //        SalesCertificate.Pre_Q13 = "NA";
        //        SalesCertificate.Pre_Q14 = "NA";
        //        SalesCertificate.Pre_Q15 = "NA";
        //        SalesCertificate.Pre_Q16 = "NA";
        //        SalesCertificate.Pre_Q17 = "NA";
        //        SalesCertificate.Pre_Q18 = "NA";
        //        SalesCertificate.Pre_Q19 = "NA";
        //        SalesCertificate.Pre_Q20 = "NA";
        //        SalesCertificate.Pre_Q21 = "NA";
        //        SalesCertificate.Pre_Q22 = "NA";
        //        SalesCertificate.Pre_Q23 = "NA";
        //        SalesCertificate.Pre_Q24 = "NA";
        //        SalesCertificate.Pre_Q25 = "NA";
        //    }
        //    if (PreValuesCount == 7)
        //    {
        //        SalesCertificate.Pre_Q08 = "NA";
        //        SalesCertificate.Pre_Q09 = "NA";
        //        SalesCertificate.Pre_Q10 = "NA";
        //        SalesCertificate.Pre_Q11 = "NA";
        //        SalesCertificate.Pre_Q12 = "NA";
        //        SalesCertificate.Pre_Q13 = "NA";
        //        SalesCertificate.Pre_Q14 = "NA";
        //        SalesCertificate.Pre_Q15 = "NA";
        //        SalesCertificate.Pre_Q16 = "NA";
        //        SalesCertificate.Pre_Q17 = "NA";
        //        SalesCertificate.Pre_Q18 = "NA";
        //        SalesCertificate.Pre_Q19 = "NA";
        //        SalesCertificate.Pre_Q20 = "NA";
        //        SalesCertificate.Pre_Q21 = "NA";
        //        SalesCertificate.Pre_Q22 = "NA";
        //        SalesCertificate.Pre_Q23 = "NA";
        //        SalesCertificate.Pre_Q24 = "NA";
        //        SalesCertificate.Pre_Q25 = "NA";
        //    }
        //    if (PreValuesCount == 8)
        //    {

        //        SalesCertificate.Pre_Q09 = "NA";
        //        SalesCertificate.Pre_Q10 = "NA";
        //        SalesCertificate.Pre_Q11 = "NA";
        //        SalesCertificate.Pre_Q12 = "NA";
        //        SalesCertificate.Pre_Q13 = "NA";
        //        SalesCertificate.Pre_Q14 = "NA";
        //        SalesCertificate.Pre_Q15 = "NA";
        //        SalesCertificate.Pre_Q16 = "NA";
        //        SalesCertificate.Pre_Q17 = "NA";
        //        SalesCertificate.Pre_Q18 = "NA";
        //        SalesCertificate.Pre_Q19 = "NA";
        //        SalesCertificate.Pre_Q20 = "NA";
        //        SalesCertificate.Pre_Q21 = "NA";
        //        SalesCertificate.Pre_Q22 = "NA";
        //        SalesCertificate.Pre_Q23 = "NA";
        //        SalesCertificate.Pre_Q24 = "NA";
        //        SalesCertificate.Pre_Q25 = "NA";
        //    }
        //    if (PreValuesCount == 9)
        //    {

        //        SalesCertificate.Pre_Q10 = "NA";
        //        SalesCertificate.Pre_Q11 = "NA";
        //        SalesCertificate.Pre_Q12 = "NA";
        //        SalesCertificate.Pre_Q13 = "NA";
        //        SalesCertificate.Pre_Q14 = "NA";
        //        SalesCertificate.Pre_Q15 = "NA";
        //        SalesCertificate.Pre_Q16 = "NA";
        //        SalesCertificate.Pre_Q17 = "NA";
        //        SalesCertificate.Pre_Q18 = "NA";
        //        SalesCertificate.Pre_Q19 = "NA";
        //        SalesCertificate.Pre_Q20 = "NA";
        //        SalesCertificate.Pre_Q21 = "NA";
        //        SalesCertificate.Pre_Q22 = "NA";
        //        SalesCertificate.Pre_Q23 = "NA";
        //        SalesCertificate.Pre_Q24 = "NA";
        //        SalesCertificate.Pre_Q25 = "NA";
        //    }
        //    if (PreValuesCount == 10)
        //    {


        //        SalesCertificate.Pre_Q11 = "NA";
        //        SalesCertificate.Pre_Q12 = "NA";
        //        SalesCertificate.Pre_Q13 = "NA";
        //        SalesCertificate.Pre_Q14 = "NA";
        //        SalesCertificate.Pre_Q15 = "NA";
        //        SalesCertificate.Pre_Q16 = "NA";
        //        SalesCertificate.Pre_Q17 = "NA";
        //        SalesCertificate.Pre_Q18 = "NA";
        //        SalesCertificate.Pre_Q19 = "NA";
        //        SalesCertificate.Pre_Q20 = "NA";
        //        SalesCertificate.Pre_Q21 = "NA";
        //        SalesCertificate.Pre_Q22 = "NA";
        //        SalesCertificate.Pre_Q23 = "NA";
        //        SalesCertificate.Pre_Q24 = "NA";
        //        SalesCertificate.Pre_Q25 = "NA";
        //    }
        //    if (PreValuesCount == 11)
        //    {


        //        SalesCertificate.Pre_Q12 = "NA";
        //        SalesCertificate.Pre_Q13 = "NA";
        //        SalesCertificate.Pre_Q14 = "NA";
        //        SalesCertificate.Pre_Q15 = "NA";
        //        SalesCertificate.Pre_Q16 = "NA";
        //        SalesCertificate.Pre_Q17 = "NA";
        //        SalesCertificate.Pre_Q18 = "NA";
        //        SalesCertificate.Pre_Q19 = "NA";
        //        SalesCertificate.Pre_Q20 = "NA";
        //        SalesCertificate.Pre_Q21 = "NA";
        //        SalesCertificate.Pre_Q22 = "NA";
        //        SalesCertificate.Pre_Q23 = "NA";
        //        SalesCertificate.Pre_Q24 = "NA";
        //        SalesCertificate.Pre_Q25 = "NA";
        //    }
        //    if (PreValuesCount == 12)
        //    {


        //        SalesCertificate.Pre_Q13 = "NA";
        //        SalesCertificate.Pre_Q14 = "NA";
        //        SalesCertificate.Pre_Q15 = "NA";
        //        SalesCertificate.Pre_Q16 = "NA";
        //        SalesCertificate.Pre_Q17 = "NA";
        //        SalesCertificate.Pre_Q18 = "NA";
        //        SalesCertificate.Pre_Q19 = "NA";
        //        SalesCertificate.Pre_Q20 = "NA";
        //        SalesCertificate.Pre_Q21 = "NA";
        //        SalesCertificate.Pre_Q22 = "NA";
        //        SalesCertificate.Pre_Q23 = "NA";
        //        SalesCertificate.Pre_Q24 = "NA";
        //        SalesCertificate.Pre_Q25 = "NA";
        //    }
        //    if (PreValuesCount == 13)
        //    {

        //        SalesCertificate.Pre_Q14 = "NA";
        //        SalesCertificate.Pre_Q15 = "NA";
        //        SalesCertificate.Pre_Q16 = "NA";
        //        SalesCertificate.Pre_Q17 = "NA";
        //        SalesCertificate.Pre_Q18 = "NA";
        //        SalesCertificate.Pre_Q19 = "NA";
        //        SalesCertificate.Pre_Q20 = "NA";
        //        SalesCertificate.Pre_Q21 = "NA";
        //        SalesCertificate.Pre_Q22 = "NA";
        //        SalesCertificate.Pre_Q23 = "NA";
        //        SalesCertificate.Pre_Q24 = "NA";
        //        SalesCertificate.Pre_Q25 = "NA";
        //    }
        //    if (PreValuesCount == 14)
        //    {

        //        SalesCertificate.Pre_Q14 = "NA";
        //        SalesCertificate.Pre_Q15 = "NA";
        //        SalesCertificate.Pre_Q16 = "NA";
        //        SalesCertificate.Pre_Q17 = "NA";
        //        SalesCertificate.Pre_Q18 = "NA";
        //        SalesCertificate.Pre_Q19 = "NA";
        //        SalesCertificate.Pre_Q20 = "NA";
        //        SalesCertificate.Pre_Q21 = "NA";
        //        SalesCertificate.Pre_Q22 = "NA";
        //        SalesCertificate.Pre_Q23 = "NA";
        //        SalesCertificate.Pre_Q24 = "NA";
        //        SalesCertificate.Pre_Q25 = "NA";
        //    }
        //    if (PreValuesCount == 15)
        //    {

        //        SalesCertificate.Pre_Q16 = "NA";
        //        SalesCertificate.Pre_Q17 = "NA";
        //        SalesCertificate.Pre_Q18 = "NA";
        //        SalesCertificate.Pre_Q19 = "NA";
        //        SalesCertificate.Pre_Q20 = "NA";
        //        SalesCertificate.Pre_Q21 = "NA";
        //        SalesCertificate.Pre_Q22 = "NA";
        //        SalesCertificate.Pre_Q23 = "NA";
        //        SalesCertificate.Pre_Q24 = "NA";
        //        SalesCertificate.Pre_Q25 = "NA";
        //    }
        //    if (PreValuesCount == 16)
        //    {

        //        SalesCertificate.Pre_Q17 = "NA";
        //        SalesCertificate.Pre_Q18 = "NA";
        //        SalesCertificate.Pre_Q19 = "NA";
        //        SalesCertificate.Pre_Q20 = "NA";
        //        SalesCertificate.Pre_Q21 = "NA";
        //        SalesCertificate.Pre_Q22 = "NA";
        //        SalesCertificate.Pre_Q23 = "NA";
        //        SalesCertificate.Pre_Q24 = "NA";
        //        SalesCertificate.Pre_Q25 = "NA";
        //    }
        //    if (PreValuesCount == 17)
        //    {

        //        SalesCertificate.Pre_Q18 = "NA";
        //        SalesCertificate.Pre_Q19 = "NA";
        //        SalesCertificate.Pre_Q20 = "NA";
        //        SalesCertificate.Pre_Q21 = "NA";
        //        SalesCertificate.Pre_Q22 = "NA";
        //        SalesCertificate.Pre_Q23 = "NA";
        //        SalesCertificate.Pre_Q24 = "NA";
        //        SalesCertificate.Pre_Q25 = "NA";
        //    }
        //    if (PreValuesCount == 18)
        //    {

        //        SalesCertificate.Pre_Q19 = "NA";
        //        SalesCertificate.Pre_Q20 = "NA";
        //        SalesCertificate.Pre_Q21 = "NA";
        //        SalesCertificate.Pre_Q22 = "NA";
        //        SalesCertificate.Pre_Q23 = "NA";
        //        SalesCertificate.Pre_Q24 = "NA";
        //        SalesCertificate.Pre_Q25 = "NA";
        //    }
        //    if (PreValuesCount == 19)
        //    {

        //        SalesCertificate.Pre_Q20 = "NA";
        //        SalesCertificate.Pre_Q21 = "NA";
        //        SalesCertificate.Pre_Q22 = "NA";
        //        SalesCertificate.Pre_Q23 = "NA";
        //        SalesCertificate.Pre_Q24 = "NA";
        //        SalesCertificate.Pre_Q25 = "NA";
        //    }
        //    if (PreValuesCount == 20)
        //    {

        //        SalesCertificate.Pre_Q21 = "NA";
        //        SalesCertificate.Pre_Q22 = "NA";
        //        SalesCertificate.Pre_Q23 = "NA";
        //        SalesCertificate.Pre_Q24 = "NA";
        //        SalesCertificate.Pre_Q25 = "NA";
        //    }
        //    if (PreValuesCount == 21)
        //    {

        //        SalesCertificate.Pre_Q22 = "NA";
        //        SalesCertificate.Pre_Q23 = "NA";
        //        SalesCertificate.Pre_Q24 = "NA";
        //        SalesCertificate.Pre_Q25 = "NA";
        //    }
        //    if (PreValuesCount == 22)
        //    {

        //        SalesCertificate.Pre_Q23 = "NA";
        //        SalesCertificate.Pre_Q24 = "NA";
        //        SalesCertificate.Pre_Q25 = "NA";
        //    }
        //    if (PreValuesCount == 23)
        //    {
        //        SalesCertificate.Pre_Q24 = "NA";
        //        SalesCertificate.Pre_Q25 = "NA";
        //    }
        //    if (PreValuesCount == 24)
        //    {

        //        SalesCertificate.Pre_Q25 = "NA";
        //    }


        //    if (PostValuesCount == 0)
        //    {
        //        SalesCertificate.Post_Q01 = "NA";
        //        SalesCertificate.Post_Q02 = "NA";
        //        SalesCertificate.Post_Q03 = "NA";
        //        SalesCertificate.Post_Q04 = "NA";
        //        SalesCertificate.Post_Q05 = "NA";
        //        SalesCertificate.Post_Q06 = "NA";
        //        SalesCertificate.Post_Q07 = "NA";
        //        SalesCertificate.Post_Q08 = "NA";
        //        SalesCertificate.Post_Q09 = "NA";
        //        SalesCertificate.Post_Q10 = "NA";
        //        SalesCertificate.Post_Q11 = "NA";
        //        SalesCertificate.Post_Q12 = "NA";
        //        SalesCertificate.Post_Q13 = "NA";
        //        SalesCertificate.Post_Q14 = "NA";
        //        SalesCertificate.Post_Q15 = "NA";
        //        SalesCertificate.Post_Q16 = "NA";
        //        SalesCertificate.Post_Q17 = "NA";
        //        SalesCertificate.Post_Q18 = "NA";
        //        SalesCertificate.Post_Q19 = "NA";
        //        SalesCertificate.Post_Q20 = "NA";
        //        SalesCertificate.Post_Q21 = "NA";
        //        SalesCertificate.Post_Q22 = "NA";
        //        SalesCertificate.Post_Q23 = "NA";
        //        SalesCertificate.Post_Q24 = "NA";
        //        SalesCertificate.Post_Q25 = "NA";
        //    }
        //    if (PostValuesCount == 1)
        //    {
        //        SalesCertificate.Post_Q02 = "NA";
        //        SalesCertificate.Post_Q03 = "NA";
        //        SalesCertificate.Post_Q04 = "NA";
        //        SalesCertificate.Post_Q05 = "NA";
        //        SalesCertificate.Post_Q06 = "NA";
        //        SalesCertificate.Post_Q07 = "NA";
        //        SalesCertificate.Post_Q08 = "NA";
        //        SalesCertificate.Post_Q09 = "NA";
        //        SalesCertificate.Post_Q10 = "NA";
        //        SalesCertificate.Post_Q11 = "NA";
        //        SalesCertificate.Post_Q12 = "NA";
        //        SalesCertificate.Post_Q13 = "NA";
        //        SalesCertificate.Post_Q14 = "NA";
        //        SalesCertificate.Post_Q15 = "NA";
        //        SalesCertificate.Post_Q16 = "NA";
        //        SalesCertificate.Post_Q17 = "NA";
        //        SalesCertificate.Post_Q18 = "NA";
        //        SalesCertificate.Post_Q19 = "NA";
        //        SalesCertificate.Post_Q20 = "NA";
        //        SalesCertificate.Post_Q21 = "NA";
        //        SalesCertificate.Post_Q22 = "NA";
        //        SalesCertificate.Post_Q23 = "NA";
        //        SalesCertificate.Post_Q24 = "NA";
        //        SalesCertificate.Post_Q25 = "NA";
        //    }
        //    if (PostValuesCount == 2)
        //    {
        //        SalesCertificate.Post_Q03 = "NA";
        //        SalesCertificate.Post_Q04 = "NA";
        //        SalesCertificate.Post_Q05 = "NA";
        //        SalesCertificate.Post_Q06 = "NA";
        //        SalesCertificate.Post_Q07 = "NA";
        //        SalesCertificate.Post_Q08 = "NA";
        //        SalesCertificate.Post_Q09 = "NA";
        //        SalesCertificate.Post_Q10 = "NA";
        //        SalesCertificate.Post_Q11 = "NA";
        //        SalesCertificate.Post_Q12 = "NA";
        //        SalesCertificate.Post_Q13 = "NA";
        //        SalesCertificate.Post_Q14 = "NA";
        //        SalesCertificate.Post_Q15 = "NA";
        //        SalesCertificate.Post_Q16 = "NA";
        //        SalesCertificate.Post_Q17 = "NA";
        //        SalesCertificate.Post_Q18 = "NA";
        //        SalesCertificate.Post_Q19 = "NA";
        //        SalesCertificate.Post_Q20 = "NA";
        //        SalesCertificate.Post_Q21 = "NA";
        //        SalesCertificate.Post_Q22 = "NA";
        //        SalesCertificate.Post_Q23 = "NA";
        //        SalesCertificate.Post_Q24 = "NA";
        //        SalesCertificate.Post_Q25 = "NA";
        //    }
        //    if (PostValuesCount == 3)
        //    {
        //        SalesCertificate.Post_Q04 = "NA";
        //        SalesCertificate.Post_Q05 = "NA";
        //        SalesCertificate.Post_Q06 = "NA";
        //        SalesCertificate.Post_Q07 = "NA";
        //        SalesCertificate.Post_Q08 = "NA";
        //        SalesCertificate.Post_Q09 = "NA";
        //        SalesCertificate.Post_Q10 = "NA";
        //        SalesCertificate.Post_Q11 = "NA";
        //        SalesCertificate.Post_Q12 = "NA";
        //        SalesCertificate.Post_Q13 = "NA";
        //        SalesCertificate.Post_Q14 = "NA";
        //        SalesCertificate.Post_Q15 = "NA";
        //        SalesCertificate.Post_Q16 = "NA";
        //        SalesCertificate.Post_Q17 = "NA";
        //        SalesCertificate.Post_Q18 = "NA";
        //        SalesCertificate.Post_Q19 = "NA";
        //        SalesCertificate.Post_Q20 = "NA";
        //        SalesCertificate.Post_Q21 = "NA";
        //        SalesCertificate.Post_Q22 = "NA";
        //        SalesCertificate.Post_Q23 = "NA";
        //        SalesCertificate.Post_Q24 = "NA";
        //        SalesCertificate.Post_Q25 = "NA";

        //    }
        //    if (PostValuesCount == 4)
        //    {
        //        SalesCertificate.Post_Q05 = "NA";
        //        SalesCertificate.Post_Q06 = "NA";
        //        SalesCertificate.Post_Q07 = "NA";
        //        SalesCertificate.Post_Q08 = "NA";
        //        SalesCertificate.Post_Q09 = "NA";
        //        SalesCertificate.Post_Q10 = "NA";
        //        SalesCertificate.Post_Q11 = "NA";
        //        SalesCertificate.Post_Q12 = "NA";
        //        SalesCertificate.Post_Q13 = "NA";
        //        SalesCertificate.Post_Q14 = "NA";
        //        SalesCertificate.Post_Q15 = "NA";
        //        SalesCertificate.Post_Q16 = "NA";
        //        SalesCertificate.Post_Q17 = "NA";
        //        SalesCertificate.Post_Q18 = "NA";
        //        SalesCertificate.Post_Q19 = "NA";
        //        SalesCertificate.Post_Q20 = "NA";
        //        SalesCertificate.Post_Q21 = "NA";
        //        SalesCertificate.Post_Q22 = "NA";
        //        SalesCertificate.Post_Q23 = "NA";
        //        SalesCertificate.Post_Q24 = "NA";
        //        SalesCertificate.Post_Q25 = "NA";
        //    }
        //    if (PostValuesCount == 5)
        //    {
        //        SalesCertificate.Post_Q05 = "NA";
        //        SalesCertificate.Post_Q06 = "NA";
        //        SalesCertificate.Post_Q07 = "NA";
        //        SalesCertificate.Post_Q08 = "NA";
        //        SalesCertificate.Post_Q09 = "NA";
        //        SalesCertificate.Post_Q10 = "NA";
        //        SalesCertificate.Post_Q11 = "NA";
        //        SalesCertificate.Post_Q12 = "NA";
        //        SalesCertificate.Post_Q13 = "NA";
        //        SalesCertificate.Post_Q14 = "NA";
        //        SalesCertificate.Post_Q15 = "NA";
        //        SalesCertificate.Post_Q16 = "NA";
        //        SalesCertificate.Post_Q17 = "NA";
        //        SalesCertificate.Post_Q18 = "NA";
        //        SalesCertificate.Post_Q19 = "NA";
        //        SalesCertificate.Post_Q20 = "NA";
        //        SalesCertificate.Post_Q21 = "NA";
        //        SalesCertificate.Post_Q22 = "NA";
        //        SalesCertificate.Post_Q23 = "NA";
        //        SalesCertificate.Post_Q24 = "NA";
        //        SalesCertificate.Post_Q25 = "NA";
        //    }
        //    if (PostValuesCount == 6)
        //    {
        //        SalesCertificate.Post_Q07 = "NA";
        //        SalesCertificate.Post_Q08 = "NA";
        //        SalesCertificate.Post_Q09 = "NA";
        //        SalesCertificate.Post_Q10 = "NA";
        //        SalesCertificate.Post_Q11 = "NA";
        //        SalesCertificate.Post_Q12 = "NA";
        //        SalesCertificate.Post_Q13 = "NA";
        //        SalesCertificate.Post_Q14 = "NA";
        //        SalesCertificate.Post_Q15 = "NA";
        //        SalesCertificate.Post_Q16 = "NA";
        //        SalesCertificate.Post_Q17 = "NA";
        //        SalesCertificate.Post_Q18 = "NA";
        //        SalesCertificate.Post_Q19 = "NA";
        //        SalesCertificate.Post_Q20 = "NA";
        //        SalesCertificate.Post_Q21 = "NA";
        //        SalesCertificate.Post_Q22 = "NA";
        //        SalesCertificate.Post_Q23 = "NA";
        //        SalesCertificate.Post_Q24 = "NA";
        //        SalesCertificate.Post_Q25 = "NA";
        //    }
        //    if (PostValuesCount == 7)
        //    {
        //        SalesCertificate.Post_Q08 = "NA";
        //        SalesCertificate.Post_Q09 = "NA";
        //        SalesCertificate.Post_Q10 = "NA";
        //        SalesCertificate.Post_Q11 = "NA";
        //        SalesCertificate.Post_Q12 = "NA";
        //        SalesCertificate.Post_Q13 = "NA";
        //        SalesCertificate.Post_Q14 = "NA";
        //        SalesCertificate.Post_Q15 = "NA";
        //        SalesCertificate.Post_Q16 = "NA";
        //        SalesCertificate.Post_Q17 = "NA";
        //        SalesCertificate.Post_Q18 = "NA";
        //        SalesCertificate.Post_Q19 = "NA";
        //        SalesCertificate.Post_Q20 = "NA";
        //        SalesCertificate.Post_Q21 = "NA";
        //        SalesCertificate.Post_Q22 = "NA";
        //        SalesCertificate.Post_Q23 = "NA";
        //        SalesCertificate.Post_Q24 = "NA";
        //        SalesCertificate.Post_Q25 = "NA";
        //    }
        //    if (PostValuesCount == 8)
        //    {

        //        SalesCertificate.Post_Q09 = "NA";
        //        SalesCertificate.Post_Q10 = "NA";
        //        SalesCertificate.Post_Q11 = "NA";
        //        SalesCertificate.Post_Q12 = "NA";
        //        SalesCertificate.Post_Q13 = "NA";
        //        SalesCertificate.Post_Q14 = "NA";
        //        SalesCertificate.Post_Q15 = "NA";
        //        SalesCertificate.Post_Q16 = "NA";
        //        SalesCertificate.Post_Q17 = "NA";
        //        SalesCertificate.Post_Q18 = "NA";
        //        SalesCertificate.Post_Q19 = "NA";
        //        SalesCertificate.Post_Q20 = "NA";
        //        SalesCertificate.Post_Q21 = "NA";
        //        SalesCertificate.Post_Q22 = "NA";
        //        SalesCertificate.Post_Q23 = "NA";
        //        SalesCertificate.Post_Q24 = "NA";
        //        SalesCertificate.Post_Q25 = "NA";
        //    }
        //    if (PostValuesCount == 9)
        //    {

        //        SalesCertificate.Post_Q10 = "NA";
        //        SalesCertificate.Post_Q11 = "NA";
        //        SalesCertificate.Post_Q12 = "NA";
        //        SalesCertificate.Post_Q13 = "NA";
        //        SalesCertificate.Post_Q14 = "NA";
        //        SalesCertificate.Post_Q15 = "NA";
        //        SalesCertificate.Post_Q16 = "NA";
        //        SalesCertificate.Post_Q17 = "NA";
        //        SalesCertificate.Post_Q18 = "NA";
        //        SalesCertificate.Post_Q19 = "NA";
        //        SalesCertificate.Post_Q20 = "NA";
        //        SalesCertificate.Post_Q21 = "NA";
        //        SalesCertificate.Post_Q22 = "NA";
        //        SalesCertificate.Post_Q23 = "NA";
        //        SalesCertificate.Post_Q24 = "NA";
        //        SalesCertificate.Post_Q25 = "NA";
        //    }
        //    if (PostValuesCount == 10)
        //    {


        //        SalesCertificate.Post_Q11 = "NA";
        //        SalesCertificate.Post_Q12 = "NA";
        //        SalesCertificate.Post_Q13 = "NA";
        //        SalesCertificate.Post_Q14 = "NA";
        //        SalesCertificate.Post_Q15 = "NA";
        //        SalesCertificate.Post_Q16 = "NA";
        //        SalesCertificate.Post_Q17 = "NA";
        //        SalesCertificate.Post_Q18 = "NA";
        //        SalesCertificate.Post_Q19 = "NA";
        //        SalesCertificate.Post_Q20 = "NA";
        //        SalesCertificate.Post_Q21 = "NA";
        //        SalesCertificate.Post_Q22 = "NA";
        //        SalesCertificate.Post_Q23 = "NA";
        //        SalesCertificate.Post_Q24 = "NA";
        //        SalesCertificate.Post_Q25 = "NA";
        //    }
        //    if (PostValuesCount == 11)
        //    {


        //        SalesCertificate.Post_Q12 = "NA";
        //        SalesCertificate.Post_Q13 = "NA";
        //        SalesCertificate.Post_Q14 = "NA";
        //        SalesCertificate.Post_Q15 = "NA";
        //        SalesCertificate.Post_Q16 = "NA";
        //        SalesCertificate.Post_Q17 = "NA";
        //        SalesCertificate.Post_Q18 = "NA";
        //        SalesCertificate.Post_Q19 = "NA";
        //        SalesCertificate.Post_Q20 = "NA";
        //        SalesCertificate.Post_Q21 = "NA";
        //        SalesCertificate.Post_Q22 = "NA";
        //        SalesCertificate.Post_Q23 = "NA";
        //        SalesCertificate.Post_Q24 = "NA";
        //        SalesCertificate.Post_Q25 = "NA";
        //    }
        //    if (PostValuesCount == 12)
        //    {


        //        SalesCertificate.Post_Q13 = "NA";
        //        SalesCertificate.Post_Q14 = "NA";
        //        SalesCertificate.Post_Q15 = "NA";
        //        SalesCertificate.Post_Q16 = "NA";
        //        SalesCertificate.Post_Q17 = "NA";
        //        SalesCertificate.Post_Q18 = "NA";
        //        SalesCertificate.Post_Q19 = "NA";
        //        SalesCertificate.Post_Q20 = "NA";
        //        SalesCertificate.Post_Q21 = "NA";
        //        SalesCertificate.Post_Q22 = "NA";
        //        SalesCertificate.Post_Q23 = "NA";
        //        SalesCertificate.Post_Q24 = "NA";
        //        SalesCertificate.Post_Q25 = "NA";
        //    }
        //    if (PostValuesCount == 13)
        //    {

        //        SalesCertificate.Post_Q14 = "NA";
        //        SalesCertificate.Post_Q15 = "NA";
        //        SalesCertificate.Post_Q16 = "NA";
        //        SalesCertificate.Post_Q17 = "NA";
        //        SalesCertificate.Post_Q18 = "NA";
        //        SalesCertificate.Post_Q19 = "NA";
        //        SalesCertificate.Post_Q20 = "NA";
        //        SalesCertificate.Post_Q21 = "NA";
        //        SalesCertificate.Post_Q22 = "NA";
        //        SalesCertificate.Post_Q23 = "NA";
        //        SalesCertificate.Post_Q24 = "NA";
        //        SalesCertificate.Post_Q25 = "NA";
        //    }
        //    if (PostValuesCount == 14)
        //    {

        //        SalesCertificate.Post_Q14 = "NA";
        //        SalesCertificate.Post_Q15 = "NA";
        //        SalesCertificate.Post_Q16 = "NA";
        //        SalesCertificate.Post_Q17 = "NA";
        //        SalesCertificate.Post_Q18 = "NA";
        //        SalesCertificate.Post_Q19 = "NA";
        //        SalesCertificate.Post_Q20 = "NA";
        //        SalesCertificate.Post_Q21 = "NA";
        //        SalesCertificate.Post_Q22 = "NA";
        //        SalesCertificate.Post_Q23 = "NA";
        //        SalesCertificate.Post_Q24 = "NA";
        //        SalesCertificate.Post_Q25 = "NA";
        //    }
        //    if (PostValuesCount == 15)
        //    {

        //        SalesCertificate.Post_Q16 = "NA";
        //        SalesCertificate.Post_Q17 = "NA";
        //        SalesCertificate.Post_Q18 = "NA";
        //        SalesCertificate.Post_Q19 = "NA";
        //        SalesCertificate.Post_Q20 = "NA";
        //        SalesCertificate.Post_Q21 = "NA";
        //        SalesCertificate.Post_Q22 = "NA";
        //        SalesCertificate.Post_Q23 = "NA";
        //        SalesCertificate.Post_Q24 = "NA";
        //        SalesCertificate.Post_Q25 = "NA";
        //    }
        //    if (PostValuesCount == 16)
        //    {

        //        SalesCertificate.Post_Q17 = "NA";
        //        SalesCertificate.Post_Q18 = "NA";
        //        SalesCertificate.Post_Q19 = "NA";
        //        SalesCertificate.Post_Q20 = "NA";
        //        SalesCertificate.Post_Q21 = "NA";
        //        SalesCertificate.Post_Q22 = "NA";
        //        SalesCertificate.Post_Q23 = "NA";
        //        SalesCertificate.Post_Q24 = "NA";
        //        SalesCertificate.Post_Q25 = "NA";
        //    }
        //    if (PostValuesCount == 17)
        //    {

        //        SalesCertificate.Post_Q18 = "NA";
        //        SalesCertificate.Post_Q19 = "NA";
        //        SalesCertificate.Post_Q20 = "NA";
        //        SalesCertificate.Post_Q21 = "NA";
        //        SalesCertificate.Post_Q22 = "NA";
        //        SalesCertificate.Post_Q23 = "NA";
        //        SalesCertificate.Post_Q24 = "NA";
        //        SalesCertificate.Post_Q25 = "NA";
        //    }
        //    if (PostValuesCount == 18)
        //    {

        //        SalesCertificate.Post_Q19 = "NA";
        //        SalesCertificate.Post_Q20 = "NA";
        //        SalesCertificate.Post_Q21 = "NA";
        //        SalesCertificate.Post_Q22 = "NA";
        //        SalesCertificate.Post_Q23 = "NA";
        //        SalesCertificate.Post_Q24 = "NA";
        //        SalesCertificate.Post_Q25 = "NA";
        //    }
        //    if (PostValuesCount == 19)
        //    {

        //        SalesCertificate.Pre_Q20 = "NA";
        //        SalesCertificate.Pre_Q21 = "NA";
        //        SalesCertificate.Pre_Q22 = "NA";
        //        SalesCertificate.Pre_Q23 = "NA";
        //        SalesCertificate.Pre_Q24 = "NA";
        //        SalesCertificate.Pre_Q25 = "NA";
        //    }
        //    if (PostValuesCount == 20)
        //    {

        //        SalesCertificate.Post_Q21 = "NA";
        //        SalesCertificate.Post_Q22 = "NA";
        //        SalesCertificate.Post_Q23 = "NA";
        //        SalesCertificate.Post_Q24 = "NA";
        //        SalesCertificate.Post_Q25 = "NA";
        //    }
        //    if (PostValuesCount == 21)
        //    {

        //        SalesCertificate.Post_Q22 = "NA";
        //        SalesCertificate.Post_Q23 = "NA";
        //        SalesCertificate.Post_Q24 = "NA";
        //        SalesCertificate.Post_Q25 = "NA";
        //    }
        //    if (PostValuesCount == 22)
        //    {

        //        SalesCertificate.Post_Q23 = "NA";
        //        SalesCertificate.Post_Q24 = "NA";
        //        SalesCertificate.Post_Q25 = "NA";
        //    }
        //    if (PostValuesCount == 23)
        //    {
        //        SalesCertificate.Post_Q24 = "NA";
        //        SalesCertificate.Post_Q25 = "NA";
        //    }
        //    if (PostValuesCount == 24)
        //    {

        //        SalesCertificate.Post_Q25 = "NA";
        //    }

        //}

    }
}
