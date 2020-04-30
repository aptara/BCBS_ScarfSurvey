using System;
using System.Collections.Generic;
using System.Linq;
using BCBS_Api.Common;
using BCBS_Api.Models;
using System.Web.Providers.Entities;
using System.Configuration;

namespace BCBS_Api.DataAccess
{
    public class BCBSDataAccess
    {

        #region Log In Page

        public static List<UserMst> GetUserInfoById(UserMst model)
        {
            List<UserMst> UserMstDataList = null;
            try
            {

                using (BCBSEntities dbObject = new BCBSEntities())
                {

                    var UserMstDBList = dbObject.UserMasters.Where(s => s.UserName == model.LoginUserName && s.Password == model.LoginPassword).ToList();

                    // var UserMstDBList = dbObject.UserMasters.OrderByDescending(x => x.UserId).Where(x => x.UserName =model.UserName).ToList();
                    if (UserMstDBList != null && UserMstDBList.Count > 0)
                    {
                        UserMstDataList = new List<UserMst>();
                        UserMstDBList.ForEach(x =>
                        {
                            UserMstDataList.Add(new UserMst
                            {
                                LoginUserId = x.UserId,
                                LoginFirstName = x.FirstName,
                                LoginLastName = x.LastName,
                                LoginUserName = x.UserName,
                                LoginPassword = x.Password,
                                LoginEmail = x.Email,
                                LoginIsActive = x.IsActive

                            });
                        });
                    }
                    else
                    {
                        UserMstDataList = new List<UserMst>();
                        UserMstDBList.ForEach(x =>
                        {
                            UserMstDataList.Add(new UserMst
                            {
                                LoginUserId = x.UserId,
                                LoginFirstName = x.FirstName,
                                LoginLastName = x.LastName,
                                LoginUserName = x.UserName,
                                LoginPassword = x.Password,
                                LoginEmail = x.Email,
                                LoginIsActive = x.IsActive

                            });
                        });

                    }
                }
            }
            catch (Exception ex)
            {
                string DetailsMessageError = null;
                if (ex.InnerException != null)
                    DetailsMessageError = ex.InnerException.Message + " " + ex.StackTrace;
                else
                {
                    DetailsMessageError = ex.StackTrace;
                }
                Util.LoggError(new System.Diagnostics.StackFrame(0).GetMethod().Name,
                    ex.Message, DetailsMessageError);
                throw ex;
            }
            return UserMstDataList;
        }

        #endregion

        #region Sales
        public static List<SalesCertificate> GetDataForSales()
        {
            List<SalesCertificate> SalesCertificateList = null;
            try
            {
                using (BCBSEntities dbObject = new BCBSEntities())
                {
                    int DataCount = 0;
                    var ProjectName = (ConfigurationManager.AppSettings["ProjectName"]);

                    var ClaimsList = new List<Claim>();


                    if (ProjectName.ToString() == "SCARF Survey".ToString())
                    {
                        ClaimsList = dbObject.Claims.OrderByDescending(x => x.SalesId).ToList();
                        DataCount = ClaimsList.Count();
                    }


                    if (DataCount > 0)
                    {
                        SalesCertificateList = new List<SalesCertificate>();

                        #region Claims
                        if (ProjectName.ToString() == "SCARF Survey".ToString())
                        {
                            ClaimsList.ForEach(x =>
                            {
                                SalesCertificateList.Add(new SalesCertificate
                                {
                                    SalesId = x.SalesId,
                                    WorkDayId = x.WorkDayId,
                                    LearnerName = x.LearnerName,
                                    PreAssmResult = Convert.ToBoolean(x.Pre_Assm_Result),
                                    PreAssmResultString = Convert.ToBoolean(x.Pre_Assm_Result) ? "PASS" : "FAIL",
                                    PreAssmScore = x.Pre_Assm_Score_Percentage,
                                    PostAssmAttempt = Convert.ToInt32(x.Post_Assm_Attempt),
                                    PostAssmResult = Convert.ToBoolean(x.Post_Assm_Result),
                                    PostAssmResultString = Convert.ToBoolean(x.Post_Assm_Result) ? "PASS" : "FAIL",
                                    PostAssmScore = x.Post_Assm_Score_Percentage,
                                    CompletionStatus = Convert.ToInt32(x.CompletionStatus),
                                    CompletionStatusString = Convert.ToBoolean(x.CompletionStatus) ? "Complete" : "In-Complete",
                                    ReportDate = Convert.ToDateTime(x.ReportDate),
                                    Pre_Q01 = x.Pre_Q01.ToString(),
                                    Pre_Q02 = x.Pre_Q02.ToString(),
                                    Pre_Q03 = x.Pre_Q03.ToString(),
                                    Pre_Q04 = x.Pre_Q04.ToString(),
                                    Pre_Q05 = x.Pre_Q05.ToString(),
                                    Pre_Q06 = x.Pre_Q06.ToString(),
                                    Pre_Q07 = x.Pre_Q07.ToString(),
                                    Pre_Q08 = x.Pre_Q08.ToString(),
                                    Pre_Q09 = x.Pre_Q09.ToString(),
                                    Pre_Q10 = x.Pre_Q10.ToString(),
                                    Pre_Q11 = x.Pre_Q11.ToString(),
                                    Pre_Q12 = x.Pre_Q12.ToString(),
                                    Pre_Q13 = x.Pre_Q13.ToString(),
                                    Pre_Q14 = x.Pre_Q14.ToString(),
                                    Pre_Q15 = x.Pre_Q15.ToString(),
                                    Pre_Q16 = x.Pre_Q16.ToString(),
                                    Pre_Q17 = x.Pre_Q17.ToString(),
                                    Pre_Q18 = x.Pre_Q18.ToString(),
                                    Pre_Q19 = x.Pre_Q19.ToString(),
                                    Pre_Q20 = x.Pre_Q20.ToString(),
                                    Pre_Q21 = x.Pre_Q21.ToString(),
                                    Pre_Q22 = x.Pre_Q22.ToString(),
                                    Pre_Q23 = x.Pre_Q23.ToString(),
                                    Pre_Q24 = x.Pre_Q24.ToString(),
                                    Pre_Q25 = x.Pre_Q25.ToString(),

                                    Post_Q01 = x.Post_Q01.ToString(),
                                    Post_Q02 = x.Post_Q02.ToString(),
                                    Post_Q03 = x.Post_Q03.ToString(),
                                    Post_Q04 = x.Post_Q04.ToString(),
                                    Post_Q05 = x.Post_Q05.ToString(),
                                    Post_Q06 = x.Post_Q06.ToString(),
                                    Post_Q07 = x.Post_Q07.ToString(),
                                    Post_Q08 = x.Post_Q08.ToString(),
                                    Post_Q09 = x.Post_Q09.ToString(),
                                    Post_Q10 = x.Post_Q10.ToString(),
                                    Post_Q11 = x.Post_Q11.ToString(),
                                    Post_Q12 = x.Post_Q12.ToString(),
                                    Post_Q13 = x.Post_Q13.ToString(),
                                    Post_Q14 = x.Post_Q14.ToString(),
                                    Post_Q15 = x.Post_Q15.ToString(),
                                    Post_Q16 = x.Post_Q16.ToString(),
                                    Post_Q17 = x.Post_Q17.ToString(),
                                    Post_Q18 = x.Post_Q18.ToString(),
                                    Post_Q19 = x.Post_Q19.ToString(),
                                    Post_Q20 = x.Post_Q20.ToString(),
                                    Post_Q21 = x.Post_Q21.ToString(),
                                    Post_Q22 = x.Post_Q22.ToString(),
                                    Post_Q23 = x.Post_Q23.ToString(),
                                    Post_Q24 = x.Post_Q24.ToString(),
                                    Post_Q25 = x.Post_Q25.ToString(),

                                });
                            });
                        }
                        #endregion

                    }
                }
            }
            catch (Exception ex)
            {
                string DetailsMessageError = null;
                if (ex.InnerException != null)
                    DetailsMessageError = ex.InnerException.Message + " " + ex.StackTrace;
                else
                {
                    DetailsMessageError = ex.StackTrace;
                }
                Util.LoggError(new System.Diagnostics.StackFrame(0).GetMethod().Name,
                    ex.Message, DetailsMessageError);
                throw ex;
            }
            return SalesCertificateList;
        }

        public static int SaveDataSales(SalesCertificate model)
        {
            var ProjectName = (ConfigurationManager.AppSettings["ProjectName"]);
            int result = 0;
            Claim ClaimsEntity = null;
            try
            {
                using (BCBSEntities dbObject = new BCBSEntities())
                {

                    #region SCARF Survey
                    if (ProjectName.ToString() == "SCARF Survey".ToString())
                    {
                        ClaimsEntity = new Claim
                         {
                             SalesId = 0,
                             WorkDayId = model.WorkDayId,
                             LearnerName = model.LearnerName,
                             Pre_Assm_Result = model.PreAssmResult,
                             Pre_Assm_Score_Percentage = model.PreAssmScore,
                             Post_Assm_Attempt = model.PostAssmAttempt,
                             Post_Assm_Result = model.PostAssmResult,
                             Post_Assm_Score_Percentage = model.PostAssmScore,
                             CompletionStatus = model.CompletionStatus,
                             Pre_Q01 = model.Pre_Q01.ToString(),
                             Pre_Q02 = model.Pre_Q02.ToString(),
                             Pre_Q03 = model.Pre_Q03.ToString(),
                             Pre_Q04 = model.Pre_Q04.ToString(),
                             Pre_Q05 = model.Pre_Q05.ToString(),
                             Pre_Q06 = model.Pre_Q06.ToString(),
                             Pre_Q07 = model.Pre_Q07.ToString(),
                             Pre_Q08 = model.Pre_Q08.ToString(),
                             Pre_Q09 = model.Pre_Q09.ToString(),
                             Pre_Q10 = model.Pre_Q10.ToString(),
                             Pre_Q11 = model.Pre_Q11.ToString(),
                             Pre_Q12 = model.Pre_Q12.ToString(),
                             Pre_Q13 = model.Pre_Q13.ToString(),
                             Pre_Q14 = model.Pre_Q14.ToString(),
                             Pre_Q15 = model.Pre_Q15.ToString(),
                             Pre_Q16 = model.Pre_Q16.ToString(),
                             Pre_Q17 = model.Pre_Q17.ToString(),
                             Pre_Q18 = model.Pre_Q18.ToString(),
                             Pre_Q19 = model.Pre_Q19.ToString(),
                             Pre_Q20 = model.Pre_Q20.ToString(),
                             Pre_Q21 = model.Pre_Q21.ToString(),
                             Pre_Q22 = model.Pre_Q22.ToString(),
                             Pre_Q23 = model.Pre_Q23.ToString(),
                             Pre_Q24 = model.Pre_Q24.ToString(),
                             Pre_Q25 = model.Pre_Q25.ToString(),
                             Post_Q01 = model.Post_Q01.ToString(),
                             Post_Q02 = model.Post_Q02.ToString(),
                             Post_Q03 = model.Post_Q03.ToString(),
                             Post_Q04 = model.Post_Q04.ToString(),
                             Post_Q05 = model.Post_Q05.ToString(),
                             Post_Q06 = model.Post_Q06.ToString(),
                             Post_Q07 = model.Post_Q07.ToString(),
                             Post_Q08 = model.Post_Q08.ToString(),
                             Post_Q09 = model.Post_Q09.ToString(),
                             Post_Q10 = model.Post_Q10.ToString(),
                             Post_Q11 = model.Post_Q11.ToString(),
                             Post_Q12 = model.Post_Q12.ToString(),
                             Post_Q13 = model.Post_Q13.ToString(),
                             Post_Q14 = model.Post_Q14.ToString(),
                             Post_Q15 = model.Post_Q15.ToString(),
                             Post_Q16 = model.Post_Q16.ToString(),
                             Post_Q17 = model.Post_Q17.ToString(),
                             Post_Q18 = model.Post_Q18.ToString(),
                             Post_Q19 = model.Post_Q19.ToString(),
                             Post_Q20 = model.Post_Q20.ToString(),
                             Post_Q21 = model.Post_Q21.ToString(),
                             Post_Q22 = model.Post_Q22.ToString(),
                             Post_Q23 = model.Post_Q23.ToString(),
                             Post_Q24 = model.Post_Q24.ToString(),
                             Post_Q25 = model.Post_Q25.ToString(),
                             ReportDate = Convert.ToDateTime(DateTime.Now.ToLongDateString())
                         };

                        var response = dbObject.Claims.Where(b => b.WorkDayId == ClaimsEntity.WorkDayId).FirstOrDefault();
                        if (response == null)
                        {
                            dbObject.Claims.Add(ClaimsEntity);
                            Util.LogInfo("Post", "before calling db :" + dbObject.Database.Connection.ConnectionString);
                            result = dbObject.SaveChanges();
                            result = ClaimsEntity.SalesId;
                        }
                        else
                        {
                            Util.LogInfo("Post", "Duplicate WorkDayId : " + ClaimsEntity.WorkDayId);
                            model.Message = "Duplicate WorkDayId";
                            model.IsErrrorMsg = true;
                            result = -1;
                        }
                        Util.LogInfo("Post", "after calling db");
                    }
                    #endregion

                }

            }
            catch (Exception ex)
            {
                string DetailsMessageError = null;
                if (ex.InnerException != null)
                    DetailsMessageError = ex.InnerException.Message + " " + ex.StackTrace;
                else
                {
                    DetailsMessageError = ex.StackTrace;
                }
                Util.LoggError(new System.Diagnostics.StackFrame(0).GetMethod().Name,
                    ex.Message, DetailsMessageError);
                var test = ex.Message + DetailsMessageError;
                throw ex;
            }

            return result;
        }
        #endregion

        #region SCARF Survey Answer

        public static int SaveDataSCARFSurvey(SCARFSurveyAnswerModels OnjSCARFSurvey)
        {
            var ProjectName = (ConfigurationManager.AppSettings["ProjectName"]);
            int result = 0;
            SCARFSurveyAnswer SCARFSurveyAnswerEntity = null;
            try
            {
                using (BCBSEntities dbObject = new BCBSEntities())
                {

                    #region SCARF Survey
                    if (ProjectName.ToString() == "SCARF Survey".ToString())
                    {
                        SCARFSurveyAnswerEntity = new SCARFSurveyAnswer
                        {
                            SCARFSurveyId = 0,
                            WorkDayId = OnjSCARFSurvey.WorkDayId,
                            LearnerName = OnjSCARFSurvey.LearnerName,
                            managerName = OnjSCARFSurvey.managerName,
                            managerEmailID = OnjSCARFSurvey.managerEmailID,
                            Status = OnjSCARFSurvey.Status,
                            StatusText = OnjSCARFSurvey.StatusText,
                            Certainty = OnjSCARFSurvey.Certainty,
                            CertaintyText = OnjSCARFSurvey.CertaintyText,
                            Autonomy = OnjSCARFSurvey.Autonomy,
                            AutonomyText = OnjSCARFSurvey.AutonomyText,
                            Relatedness = OnjSCARFSurvey.Relatedness,
                            RelatednessText = OnjSCARFSurvey.RelatednessText,
                            Fairness = OnjSCARFSurvey.Fairness,
                            FairnessText = OnjSCARFSurvey.FairnessText,
                            ReportDate = Convert.ToDateTime(DateTime.Now.ToLongDateString())
                        };

                        var response = dbObject.SCARFSurveyAnswers.Where(b => b.WorkDayId == SCARFSurveyAnswerEntity.WorkDayId).FirstOrDefault();
                        if (response == null)
                        {
                            dbObject.SCARFSurveyAnswers.Add(SCARFSurveyAnswerEntity);
                            Util.LogInfo("Post", "before calling db :" + dbObject.Database.Connection.ConnectionString);
                            result = dbObject.SaveChanges();
                            result = SCARFSurveyAnswerEntity.SCARFSurveyId;
                        }
                        else
                        {
                            Util.LogInfo("Post", "Duplicate WorkDayId : " + SCARFSurveyAnswerEntity.WorkDayId);
                            OnjSCARFSurvey.Message = "Duplicate WorkDayId";
                            OnjSCARFSurvey.IsErrrorMsg = true;
                            result = -1;
                        }
                        Util.LogInfo("Post", "after calling db");
                    }
                    #endregion

                }

            }
            catch (Exception ex)
            {
                string DetailsMessageError = null;
                if (ex.InnerException != null)
                    DetailsMessageError = ex.InnerException.Message + " " + ex.StackTrace;
                else
                {
                    DetailsMessageError = ex.StackTrace;
                }
                Util.LoggError(new System.Diagnostics.StackFrame(0).GetMethod().Name,
                    ex.Message, DetailsMessageError);
                var test = ex.Message + DetailsMessageError;
                throw ex;
            }

            return result;
        }
        public static List<SCARFSurveyAnswerModels> GetDataForSCARFSurveyAnswer()
        {
            List<SCARFSurveyAnswerModels> SCARFSurveyAnswerList = null;
            try
            {
                using (BCBSEntities dbObject = new BCBSEntities())
                {
                    int DataCount = 0;
                    var ProjectName = (ConfigurationManager.AppSettings["ProjectName"]);

                    var SCARFSurveyAnswerTableList = new List<SCARFSurveyAnswer>();


                    if (ProjectName.ToString() == "SCARF Survey".ToString())
                    {
                        SCARFSurveyAnswerTableList = dbObject.SCARFSurveyAnswers.OrderByDescending(x => x.SCARFSurveyId).ToList();
                        DataCount = SCARFSurveyAnswerTableList.Count();
                    }


                    if (DataCount > 0)
                    {
                        SCARFSurveyAnswerList = new List<SCARFSurveyAnswerModels>();

                        #region Claims
                        if (ProjectName.ToString() == "SCARF Survey".ToString())
                        {
                            SCARFSurveyAnswerTableList.ForEach(x =>
                            {
                                SCARFSurveyAnswerList.Add(new SCARFSurveyAnswerModels
                                {
                                    SCARFSurveyId = x.SCARFSurveyId,
                                    WorkDayId = x.WorkDayId,
                                    LearnerName = x.LearnerName,
                                    managerName = x.managerName,
                                    ReportDate = Convert.ToDateTime(x.ReportDate),                                    
                                    managerEmailID = x.managerEmailID,
                                    Status = x.Status,
                                    StatusText = x.StatusText,
                                    Certainty = x.Certainty,
                                    CertaintyText = x.CertaintyText,
                                    Autonomy = x.Autonomy,
                                    AutonomyText = x.AutonomyText,
                                    Relatedness = x.Relatedness,
                                    RelatednessText = x.RelatednessText,
                                    Fairness = x.Fairness,
                                    FairnessText = x.FairnessText,


                                });
                            });
                        }
                        #endregion

                    }
                }
            }
            catch (Exception ex)
            {
                string DetailsMessageError = null;
                if (ex.InnerException != null)
                    DetailsMessageError = ex.InnerException.Message + " " + ex.StackTrace;
                else
                {
                    DetailsMessageError = ex.StackTrace;
                }
                Util.LoggError(new System.Diagnostics.StackFrame(0).GetMethod().Name,
                    ex.Message, DetailsMessageError);
                throw ex;
            }
            return SCARFSurveyAnswerList;
        }

        public static SCARFSurveyAnswerModels GetSCARFSurveyDataForPDF(int SCARFSurveyId)
        {
            SCARFSurveyAnswerModels SCARFSurveyModel = null;
            try
            {
                using (BCBSEntities dbObject = new BCBSEntities())
                {
                    var SCARFSurveyAnswerlist = dbObject.SCARFSurveyAnswers.Where(x => x.SCARFSurveyId == SCARFSurveyId).FirstOrDefault();
                    if (SCARFSurveyAnswerlist != null)
                    {                      

                        SCARFSurveyModel = new SCARFSurveyAnswerModels();
                        SCARFSurveyModel.SCARFSurveyId = SCARFSurveyAnswerlist.SCARFSurveyId;
                        SCARFSurveyModel.WorkDayId = SCARFSurveyAnswerlist.WorkDayId;
                        SCARFSurveyModel.LearnerName = SCARFSurveyAnswerlist.LearnerName;
                        SCARFSurveyModel.managerEmailID = SCARFSurveyAnswerlist.managerEmailID;
                        SCARFSurveyModel.Status = SCARFSurveyAnswerlist.Status;
                        SCARFSurveyModel.StatusText = SCARFSurveyAnswerlist.StatusText;
                        SCARFSurveyModel.Certainty = SCARFSurveyAnswerlist.Certainty;
                        SCARFSurveyModel.CertaintyText = SCARFSurveyAnswerlist.CertaintyText;
                        SCARFSurveyModel.Autonomy = SCARFSurveyAnswerlist.Autonomy;
                        SCARFSurveyModel.AutonomyText = SCARFSurveyAnswerlist.AutonomyText;
                        SCARFSurveyModel.Relatedness = SCARFSurveyAnswerlist.Relatedness;
                        SCARFSurveyModel.RelatednessText = SCARFSurveyAnswerlist.RelatednessText;
                        SCARFSurveyModel.Fairness = SCARFSurveyAnswerlist.Fairness;
                        SCARFSurveyModel.FairnessText = SCARFSurveyAnswerlist.FairnessText;
                        SCARFSurveyModel.ReportDate =  Convert.ToDateTime(SCARFSurveyAnswerlist.ReportDate);
                        SCARFSurveyModel.ReportDateString = SCARFSurveyModel.ReportDate.ToString("MMMM-dd-yyyy");
                    }
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
            }

            return SCARFSurveyModel;
        }
        #endregion
    }
}