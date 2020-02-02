using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Mail
    {
        public void GuiMail(string emailKhach, string tieuDe, string noiDung){
            var fromEmailAddress = ConfigurationManager.AppSettings["FromEmailAddress"].ToString();
            var fromEmailDisplayName = ConfigurationManager.AppSettings["FromEmailDisplayName"].ToString();
            var fromEmailPassword = ConfigurationManager.AppSettings["FromEmailPassword"].ToString();
            var smptHost = ConfigurationManager.AppSettings["SMTPHost"].ToString();
            var smptPort = ConfigurationManager.AppSettings["SMTPPort"].ToString();

            bool enableSSL = bool.Parse(ConfigurationManager.AppSettings["EnabledSSL"].ToString());

            string nd = noiDung;

            MailMessage mail = new MailMessage(new MailAddress(fromEmailAddress, fromEmailDisplayName),
                                                  new MailAddress(emailKhach));
            mail.Subject = tieuDe;
            mail.IsBodyHtml = true;
            mail.Body = noiDung;

            var client = new SmtpClient();
            client.Credentials = new NetworkCredential(fromEmailAddress, fromEmailPassword);
            client.Host = smptHost;
            client.EnableSsl = enableSSL;
            client.Port = !string.IsNullOrEmpty(smptPort) ? Convert.ToInt32(smptPort) : 0;
            try
            {
                client.Send(mail);
            }
            catch(Exception ex)
            {
                throw ex;
            }

        }
    }
}
