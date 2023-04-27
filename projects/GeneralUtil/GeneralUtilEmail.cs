using System;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;


namespace GeneralUtil
{
    public class GeneralUtilEmail
    {


        public static void sendMailll(string toEmail ,
               string subject = "Subject",
         string body = "Body"
            )
        {

            var fromAddress = new MailAddress("eng.tarek83@gmail.com", "From Name");
            var toAddress = new MailAddress(toEmail/*, "To Name"*/);
            const string fromPassword = "adbsjfrafmqthxwe";
          

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }
        }



        public static void sendMailllTest()
        {

            var fromAddress = new MailAddress("eng.tarek83@gmail.com", "From Name");
            var toAddress = new MailAddress("eng.tarek83@gmail.com", "To Name");
            const string fromPassword = "adbsjfrafmqthxwe";
            const string subject = "Subject";
            const string body = "Body";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }
        }










        public static string htmlBody = @"

<!DOCTYPE html>
<html>
<head>
    <meta charset=""utf-8"" />
    <title>XXsubjectXX</title>
</head>
<body>
    <br />
XXbodyXX
    <br />
    <br />

<img style ="""" src=""https://www.tasawuq.org/images/logo.png"" />

</body>
</html>
";
        //   GeneralUtil.GeneralUtilEmail.do1()

        public static async Task SendEmailWithLogoAsync(string subject, string body, string toEmail = "eng.tarek83@gmail.com")
        {
            if (toEmail.Length < 8) return;
            string[] restrectedEmails = { "ryd@gmail.com", "eng.tarek831@gmail.com", "jed@gmail.com" };
            if (restrectedEmails.Contains(toEmail)) return;

            var fromAddress = new MailAddress("info@tasawuq.org", "Tasawuq.org");
            //   var fromAddress = new MailAddress("eng.tarek83@gmail.com", "Tarek ");
            //var toAddress = new MailAddress(toEmail);
            const string fromPassword = "wxdusbnfczcnxazh";// "tARIQ123";
                                                           //  const string fromPassword = "870ZanketRoad0";
                                                           //const string subject = "Subject";
                                                           //  const string body = "Body";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                //  Port = 465,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,///this one fixed issue
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };

            using (var mailMessage = new MailMessage(/*fromAddress, toAddress*/)
            {
                Subject = subject,
                Body = htmlBody.Replace("XXbodyXX", body).Replace("XXsubjectXX", subject)// body
                ,
                IsBodyHtml = true
            })
            {
                mailMessage.From = fromAddress;
                mailMessage.To.Clear();

                foreach (var address in toEmail.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries))
                {
                    mailMessage.To.Add(address);
                }
                smtp.Send(mailMessage);
            }
        }
    }
}
