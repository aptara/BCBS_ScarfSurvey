using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BCBS_Api.DataAccess;
using BCBS_Api.Models;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using System.IO;
using System.Configuration;
using System.Globalization;
using MvcRazorToPdf;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using BCBS_Api.Common;
using System.Web.Script.Serialization;

namespace BCBS_Api.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Login()
        {
            UserMst user = new UserMst();
            try
            {
                Session["LoginUserId"] = null;
                Session.Abandon();
                ViewBag.ErrorMessage = null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return View(user);
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(UserMst model, string returnUrl)
        {
            List<UserMst> courseModelList = null;

            try
            {
                courseModelList = BCBSDataAccess.GetUserInfoById(model);
                if (courseModelList != null && courseModelList.Count > 0)
                {
                    foreach (var item in courseModelList)
                    {
                        if (item.LoginIsActive == true)
                        {

                            UserMst TempLocation = new UserMst();
                            Session["LoginUserId"] = item.LoginUserId;
                            TempLocation.LoginUserId = item.LoginUserId;
                            TempLocation.LoginUserName = item.LoginUserName;
                            TempLocation.LoginPassword = item.LoginPassword;
                            TempLocation.LoginEmail = item.LoginEmail;
                            TempLocation.LoginFirstName = item.LoginFirstName;
                            TempLocation.LoginLastName = item.LoginLastName;
                            TempLocation.LoginIsActive = item.LoginIsActive;
                            courseModelList.Add(TempLocation);
                            Util.LogInfo("Login", "Successfully Login : " + item.LoginUserName);
                            return RedirectToAction("Index", "SCARFSurveyAnswer");
                        }
                        else
                        {
                            Session["LoginUserId"] = null;
                            Session.Abandon();
                            Util.LogInfo("Login", "User is In-Active. Please contact Administrator : " + item.LoginUserName);
                            ViewBag.ErrorMessage = "User is In-Active. Please contact Administrator";
                        }
                    }

                }
                else
                {
                    Session["LoginUserId"] = null;
                    Session.Abandon();
                    ViewBag.ErrorMessage = "Incorrect user name/password.";
                    return View();
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
            }

            return View();
        }

        public ActionResult LogOff()
        {
            Session.Abandon();
            Session["LoginUserId"] = null;
            return RedirectToAction("Login", "Account");
        }
    }
}
