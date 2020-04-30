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
    public class CertificateController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public string Post(Certificate model)
        {
            var certificateLink = string.Empty;
         //   BCBSDataAccess.AddDumCourse("entry");
            try
            {
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
            return certificateLink;
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}