using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace CourseReportEmailer.Workers
{
    class EnrollmentDetailReportEmailSender
    {
        public void Send(string fileName)
        {
            SmtpClient smtpClient = new SmtpClient("smtp-mail.outlook.com");
            smtpClient.Port = 587;
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.UseDefaultCredentials = false;

            string credentialEmail = "email";
            string credentialPassword = "password";

            NetworkCredential credentials = new NetworkCredential(credentialEmail, credentialPassword);
            smtpClient.EnableSsl = true;
            smtpClient.Credentials = credentials;

            string fromEmail = "fromEmail";
            string toEmail = "toEmail";

            MailMessage message = new MailMessage(fromEmail, toEmail);
            message.Subject = "Enrollment Details Report";
            message.IsBodyHtml = true;
            message.Body = "Hi,<br><br>Demo app message. Please find attachment attached to this mail.<br><br>Regards,<br>EnrollmentCourseReporter";

            Attachment attachment = new Attachment(fileName);
            message.Attachments.Add(attachment);

            smtpClient.Send(message);
        }
    }
}
