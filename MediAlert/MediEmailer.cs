using MediEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;

namespace MediAlert
{
    public class MediEmailer
    {
        public void sendMail(ServerData smtpData,string Message)
        {
            char[] delimeter = { ',' };
            String[] recieverMails = (smtpData.Reciever).Split(delimeter);
            foreach (var emailadd in recieverMails)
            {
                string txtMessage = "<html><body> <div style='margin:0 auto;width:600px' align='center'><div align='center' style='background-color: #0066FF; font-weight: 700; text-decoration: underline; font-size: xx-large;'>hello Sir/Mam</div><br /><div style='border-style: outset; border-color: #C0C0C0;width:500px; font-weight: 700;'><br />Message is : " + Message + "</div></div></body></html>";
                MailMessage mail = new MailMessage();
                mail.To.Add(emailadd);
                mail.From = new MailAddress(smtpData.Sender);
                mail.Subject = "MediAlert Notification";
                mail.Body = txtMessage;
                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = smtpData.Host;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential(smtpData.Email, smtpData.Password);
                smtp.EnableSsl = true;
                smtp.Port = 587;
                smtp.Send(mail);

            }
        }

        public void sendMailWithoutPWD(ServerData smtpData, string Message)
        {
            char[] delimeter = { ',' };
            String[] recieverMails = (smtpData.Reciever).Split(delimeter);
            foreach (var emailadd in recieverMails)
            {
                string txtMessage = "<html><body> <div style='margin:0 auto;width:600px' align='center'><div align='center' style='background-color: #0066FF; font-weight: 700; text-decoration: underline; font-size: xx-large;'>hello Sir/Mam</div><br /><div style='border-style: outset; border-color: #C0C0C0;width:500px; font-weight: 700;'><br />Message is : " + Message + "</div></div></body></html>";
                MailMessage mail = new MailMessage();
                mail.To.Add(emailadd);
                mail.From = new MailAddress(smtpData.Sender);
                mail.Subject = "MediAlert Notification";
                mail.Body = txtMessage;
                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient("192.168.20.90");
                smtp.UseDefaultCredentials = false;
                smtp.Send(mail);

            }
        }
    }
}
