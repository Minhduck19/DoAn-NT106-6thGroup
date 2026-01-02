using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace APP_DOAN
{
    public class EmailService
    {
        private readonly string _fromEmail = "tdruucc20056@gmail.com";
        private readonly string _password = "pfkg pibq eopu dvhu";

        public async Task<bool> SendVerificationCodeAsync(string toEmail, string verificationCode)
        {
            try
            {
                var message = new MailMessage();
                message.From = new MailAddress(_fromEmail);
                message.To.Add(new MailAddress(toEmail));
                message.Subject = "Mã xác minh đăng ký tài khoản";
                message.Body = $@"
                    <html>
                    <body>
                        <h2>Xin chào!</h2>
                        <p>Cảm ơn bạn đã đăng ký. Đây là mã xác minh của bạn:</p>
                        <h1 style='color:blue'>{verificationCode}</h1>
                        <p>Vui lòng không chia sẻ mã này cho ai.</p>
                    </body>
                    </html>";
                message.IsBodyHtml = true;

                using (var smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.EnableSsl = true;
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential(_fromEmail, _password);

                    await smtp.SendMailAsync(message);
                }

                return true; // Gửi thành công
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Lỗi gửi mail: " + ex.Message);
                return false; // Gửi thất bại
            }
        }
    }
}