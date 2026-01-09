using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace APP_DOAN
{
    public static class EmailHelper
    {
        public static async Task SendEmailAsync(
            string toEmail,
            string subject,
            string body)
        {
            var fromEmail = "codeptraiskycuatung@gmail.com";       // 🔥 Gmail gửi
            var fromPassword = "reqtizijmmnuhiac";      // 🔥 App Password

            var client = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential(fromEmail, fromPassword),
                EnableSsl = true
            };

            var mail = new MailMessage
            {
                From = new MailAddress(fromEmail, "Hệ thống nộp bài"),
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            };

            mail.To.Add(toEmail);

            await client.SendMailAsync(mail);
        }
    }
}
