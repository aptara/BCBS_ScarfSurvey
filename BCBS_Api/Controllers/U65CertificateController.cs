using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Web.Http;
using BCBS_Api.Common;
using BCBS_Api.DataAccess;
using BCBS_Api.Models;

namespace BCBS.Controllers
{
    public class U65CertificateController : ApiController
    {
        public string Post(U65Certificate model)
        {
            var U65CertificateLink = string.Empty;
            try
            {
               

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
            return U65CertificateLink;
        }
    }
}