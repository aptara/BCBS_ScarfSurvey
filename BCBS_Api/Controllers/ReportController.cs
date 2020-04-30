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

namespace BCBS_Api.Controllers
{
    public class ReportController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        
    }
}
