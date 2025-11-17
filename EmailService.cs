using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APP_DOAN
{
    public class EmailService
    {
        
        private const string SMTP_SERVER = "smtp.gmail.com";
        private const int SMTP_PORT = 587;
        private const string SENDER_EMAIL = "tdruucc20056@gmail.com";
        private const string SENDER_PASSWORD = "syzgbcuzzwcwibdy"; 

        public async Task<bool> SendVerificationCodeAsync(string toEmail, string code)
        {
            try
            {
                using (SmtpClient client = new SmtpClient(SMTP_SERVER, SMTP_PORT))
                {
                    client.Credentials = new NetworkCredential(SENDER_EMAIL, SENDER_PASSWORD);
                    client.EnableSsl = true;

                    using (MailMessage mailMessage = new MailMessage(SENDER_EMAIL, toEmail))
                    {
                        mailMessage.Subject = "Mã xác minh đăng ký";
                        mailMessage.Body = $"Mã xác minh của bạn là: <h2>{code}</h2>";
                        mailMessage.IsBodyHtml = true;

                        await client.SendMailAsync(mailMessage);
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi gửi email: {ex.Message}", "Lỗi EmailService", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}