using System;
using System.Net;
using System.Net.Mail;

namespace EmailSending.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var message = new MailMessage
            {
                Subject = "Test subject",
                Body = "Test body",
                From = new MailAddress("elmenjardaqui@gmail.com", "El Menjar d'Aqui")
            };
            message.To.Add("franck.quintana@gmail.com");
            try
            {
                using (var sender = new SmtpClient("smtp.gmail.com", 587))
                {
                    sender.UseDefaultCredentials = false;
                    sender.Credentials = new NetworkCredential("elmenjardaqui@gmail.com", "password");
                    sender.EnableSsl = true;
                    sender.Send(message);
                }

                System.Console.WriteLine("Message sent successfully!");
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Error: " + ex.Message);
                throw;
            }
        }
    }
}
