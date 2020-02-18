using avianoise.Domain;
using avianoise.SL;
using avianoise.Web.Services.Options;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace avianoise.Web.Services
{
    public class EmailService : IEmailService
    {
        private readonly IEmailSenderSL emailSenderSL;
        private readonly IOptions<AdminOptions> options;

        public EmailService(IEmailSenderSL emailSenderSL, IOptions<AdminOptions> options)
        {
            this.emailSenderSL = emailSenderSL;
            this.options = options;
        }

        public bool SendFeedback(Feedback feedback)
        {
            var body = GenerateFeedbackBody(feedback);
            return emailSenderSL.SendEmail(this.options.Value.Email, "Restore Password", body);
        }

        private string GenerateFeedbackBody(Feedback feedback)
        {
            var sb = new StringBuilder();


            sb.AppendLine($"Новий зворотний зв'язок:");
            sb.AppendLine($"Відправник:{feedback.Name}");
            sb.AppendLine($"Email:{feedback.Email}");
            sb.AppendLine($"------------------");
            sb.AppendLine($"Текст:{feedback.Message}");
            return sb.ToString();
        }
    }
}
