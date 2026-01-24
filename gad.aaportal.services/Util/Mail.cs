using gad.aaportal.commons.Base;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace gad.aaportal.services.Util
{
    public class Mail
    {
        public static string RenderTemplate(string templateHtml, IDictionary<string, string> values)
        {
            if (string.IsNullOrWhiteSpace(templateHtml))
                throw new ArgumentException("La plantilla HTML está vacía.");

            if (values == null || values.Count == 0)
                return templateHtml;

            // Reemplazo directo {{KEY}} -> value
            foreach (var kv in values)
            {
                var token = "{{" + kv.Key + "}}";
                templateHtml = templateHtml.Replace(token, kv.Value ?? string.Empty);
            }

            return templateHtml;
        }
        public static bool SendEmail(string subject, string mail, string fromAddress, string dominio, string user, string pwd, string puerto)
        {
            bool result = false;
            try
            {
                ServicePointManager.ServerCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) =>
                {
                    return true;
                };

                SmtpClient smtpClient = new SmtpClient(dominio)
                {
                    Port = int.Parse(puerto),
                    Credentials = new NetworkCredential(user, pwd),
                    EnableSsl = true
                };

                MailMessage mailMessage = new MailMessage
                {
                    From = new MailAddress(user),
                    Subject = subject,
                    IsBodyHtml = true, // Importante para permitir contenido HTML
                    Body = mail
                };

                mailMessage.To.Add(fromAddress);
                smtpClient.Send(mailMessage);
            }
            catch (SmtpException)
            {
                throw;
            }
            return result;
        }
    }
}
