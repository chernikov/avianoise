using avianoise.SL.Options;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace avianoise.SL
{
    public class EmailSenderSL : IEmailSenderSL
    {
        private readonly EmailOptions options;

        public EmailSenderSL(IOptions<EmailOptions> options)
        {
            this.options = options.Value;
        }

        public bool SendEmail(string email, string subject, string body)
        {
            try
            {
                var mailAddress = new MailAddress(options.Reply, options.User);
                var message = new MailMessage(
                    mailAddress,
                    new MailAddress(email))
                {
                    Subject = subject,
                    BodyEncoding = Encoding.UTF8,
                    Body = body,
                    IsBodyHtml = true,
                    SubjectEncoding = Encoding.UTF8
                };
                var client = new SmtpClient
                {
                    Host = options.Server,
                    Port = options.Port,
                    UseDefaultCredentials = false,
                    EnableSsl = options.EnableSsl,
                    Credentials =
                        new NetworkCredential(options.UserName,
                                                options.Password),
                    DeliveryMethod = SmtpDeliveryMethod.Network
                };
                client.Send(message);
                return true;
            }
            catch (SmtpException)
            {
                throw;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
