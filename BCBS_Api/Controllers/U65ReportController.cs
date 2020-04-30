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
using BCBS_Api.Common;

namespace BCBS_Api.Controllers
{
    public class U65ReportController : Controller
    {
        public ActionResult Index()
        {
            try
            {

                if (Session["LoginUserId"] != null)
                {
                    Util.LogInfo("U65 Index", "Report Controller");
                    return View();
                }
                else
                {
                    Session["LoginUserId"] = null;
                    Session.Abandon();
                    Util.LogInfo("U65 Index", "Session Abandon");
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
                Util.LoggError(new System.Diagnostics.StackFrame(0).GetMethod().Name,ex.Message, DetailsMessageError);
            }

            return RedirectToAction("Login", "Account");
        }
    }
}
