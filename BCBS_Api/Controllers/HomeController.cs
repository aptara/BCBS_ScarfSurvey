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

namespace BCBS_Api.Controllers
{
    public class HomeController : Controller
    {        
        public ActionResult Index()
        {
            return View();
        }     
    }
}
