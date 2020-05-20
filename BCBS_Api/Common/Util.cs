using System;
using System.Configuration;
using System.IO;
using System.Net;
using System.Net.Mail;

using log4net;

namespace BCBS_Api.Common
{
    public class Util
    {
        public static ILog GetLogger()
        {
            return LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        }

        public static void LogInfo(string methodName, string info)
        {
            ILog logger = GetLogger();
            if (logger != null)
                logger.Info(methodName + ":" + info);
        }

        public static void LogError(string methodName, string error)
        {
            ILog logger = GetLogger();
            if (logger != null)
                logger.Error(methodName + ":" + error);
        }

        public static void LoggError(string methodName, string title, string detailMsg)
        {
            ILog logger = GetLogger();
            if (logger != null)
                logger.Error(methodName + ":" + title + ":" + detailMsg);
        }

        public static bool SendMail(string reciepient, string subject, string content, Attachment AttachmentPath) //string AttachmentPath
        {
            bool result = false;
            string SMTP_HostName = ConfigurationManager.AppSettings["SMTP_HostName"];
            string SMTP_PORT = ConfigurationManager.AppSettings["SMTP_PORT"];
            string SMTP_UserName = ConfigurationManager.AppSettings["SMTP_UserName"];
            string SMTP_Password = ConfigurationManager.AppSettings["SMTP_Password"];
            string SMTP_FromEmailId = ConfigurationManager.AppSettings["SMTP_FromEmailId"];
            Util.LogInfo("Post", "SMTP_HostName :" + SMTP_HostName);
            Util.LogInfo("Post", "SMTP_PORT :" + SMTP_PORT);
            Util.LogInfo("Post", "SMTP_UserName :" + SMTP_UserName);
            Util.LogInfo("Post", "SMTP_Password :" + SMTP_Password);
            Util.LogInfo("Post", "SMTP_FromEmailId :" + SMTP_FromEmailId);
            Util.LogInfo("Post", "reciepient :" + reciepient);
            Util.LogInfo("Post", "subject :" + subject);

            if (AttachmentPath.ContentStream != null)
            {
                Util.LogInfo("Post", "AttachmentPath :" + "Generate Attachment Success");
            }            


            try
            {
                int port = 0;
                int.TryParse(SMTP_PORT, out port);
                var client = new SmtpClient(SMTP_HostName, port)
                {
                    Credentials = new NetworkCredential(SMTP_UserName, SMTP_Password),
                    //  EnableSsl = true
                };
                MailMessage mailMessage = new MailMessage(SMTP_FromEmailId, reciepient, subject, content);              
                mailMessage.IsBodyHtml = true;
                mailMessage.Priority = MailPriority.High;
                
                //if (AttachmentPath != "")
                //{
                //mailMessage.Attachments.Add(new Attachment(AttachmentPath));
                mailMessage.Attachments.Add(AttachmentPath);
                //}
                client.Send(mailMessage);
                result = true;
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
            return result;
        }

        public static string ResolveFileName(string relativePath)
        {
            relativePath = string.IsNullOrEmpty(relativePath) ? relativePath : relativePath.Trim();
            if (File.Exists(relativePath))
                return relativePath;

            string tempRelativePath = string.Empty;
            if (null != System.Web.HttpContext.Current)
            {
                tempRelativePath = System.Web.HttpContext.Current.Server.MapPath(relativePath);
                if (File.Exists(tempRelativePath))
                    return tempRelativePath;
            }

            tempRelativePath = relativePath.TrimStart(new char[] { '~' });
            tempRelativePath = AppDomain.CurrentDomain.BaseDirectory + "bin\\" + tempRelativePath;
            if (File.Exists(tempRelativePath))
                return tempRelativePath;

            return relativePath;
        }


    }

    public static class ExtentionMethod
    {
        public static string UppercaseFirst(this string s)
        {
            // Check for empty string.
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            // Return char and concat substring.
            return char.ToUpper(s[0]) + s.Substring(1);
        }

        public static string LowercaseFirst(this string s)
        {
            // Check for empty string.
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            // Return char and concat substring.
            return char.ToLower(s[0]) + s.Substring(1);
        }
    }

}