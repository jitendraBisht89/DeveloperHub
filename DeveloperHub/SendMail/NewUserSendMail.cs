using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Net;
using ShareBook.Models;
namespace ShareBook.Models
{
    public class NewUserSendMail
    {

        public static int SendMail(string email,string pass)
        {
            int res = 1;
            try
            {

                MailMessage mM = new MailMessage();
                //Mail Address
                mM.From = new MailAddress("rituBishtDDun@outlook.com");
                //receiver email id
                mM.To.Add(email);
                //subject of the email
                mM.Subject = "Memeber of ShareBook";
                //deciding for the attachment
                // mM.Attachments.Add(new Attachment(@"C:\\attachedfile.jpg"));
                //add the body of the email
                string crypto = EncryptionDecryption.Encrypt(email, pass);
                mM.Body = "Click here for Login:<br><a href='" +
                    @"http://localhost:4650/account/UnblockUser?cypertext=" + crypto + "'>Login</a>";
                mM.IsBodyHtml = true;
                //SMTP client
                SmtpClient sC = new SmtpClient("smtp.live.com");
                //port number for Hot mail
                sC.Port = 25;
                //credentials to login in to hotmail account
                sC.Credentials = new NetworkCredential("rituBishtDDun@outlook.com", "ritu@123");
                //enabled SSL
                sC.EnableSsl = true;
                sC.Timeout = 10000000;
                //Send an email
                sC.Send(mM);
            }

            catch
            {
                res = 0;
            }
              return res;

        }

        
    }
}