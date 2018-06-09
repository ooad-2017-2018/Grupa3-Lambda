using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Web.Http;
using AmbasadaAPI.NET.Models;


namespace AmbasadaAPI.NET.Controllers
{
    public class EmailController : ApiController
    {
        public HttpResponseMessage PostEmail(Email email)
        {
            try
            {
                SmtpClient smtpClient = new SmtpClient("elektrotehna.tk", 587)
                {
                    UseDefaultCredentials = false,
                    Credentials = new System.Net.NetworkCredential("ambasada.elektrotehna", "[Password]"),
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    EnableSsl = true
                };

                MailMessage mail = new MailMessage
                {
                    From = new MailAddress("ambasada@elektrotehna.tk", "Ambasada Elektrotehne"),
                    Subject = email.Subject,
                    Body = email.Body
                };
                mail.To.Add(new MailAddress(email.Address));

                smtpClient.Send(mail);
            }
            catch (Exception e)
            {
                Console.Out.Write(e);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
            return Request.CreateResponse(HttpStatusCode.OK, "poslano");
        }

    }

}