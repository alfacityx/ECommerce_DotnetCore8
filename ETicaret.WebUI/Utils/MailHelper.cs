using ETicaret.Core.Entities;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace ETicaret.WebUI.Utils
{
    public class MailHelper
    {
        public static async Task<bool> SendMailAsync(Contact contact)
        {
            return await SendMailAsync(contact.Email, "Siteden mesaj geldi",
                $"İsim: {contact.Name} <br> Soyisim: {contact.Surname} <br> Email: {contact.Email} <br> Telefon: {contact.Phone} <br> Mesaj: {contact.Message}");
        }

        public static async Task<bool> SendMailAsync(string email, string subject, string mailBody)
        {
            try
            {
                using (SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtpClient.Credentials = new NetworkCredential("shopiverse34@gmail.com", "oamf ncbh onmm fvjk");
                    smtpClient.EnableSsl = true;
                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtpClient.UseDefaultCredentials = false;

                    using (MailMessage message = new MailMessage())
                    {
                        message.From = new MailAddress("shopiverse34@gmail.com");
                        message.To.Add(email);
                        message.Subject = subject;
                        message.Body = mailBody;
                        message.IsBodyHtml = true;

                        await smtpClient.SendMailAsync(message);
                    }
                }
                return true;
            }
            catch (SmtpException smtpEx)
            {
                Console.WriteLine($"SMTP Hatası: {smtpEx.Message}");
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Genel Hata: {ex.Message}");
                return false;
            }
        }
    }
}
