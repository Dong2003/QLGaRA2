using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Net.Mail;
using System.IO;
using TestG.Models;

namespace TestG.Controllers
{
    public class SendGmailController : Controller
    {
        // GET: SendGmail
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SendGmail()
        {

            return View();
        }

        [HttpPost]
        public ActionResult SendGmail(Gmail model)
        {
            using (MailMessage mm = new MailMessage(model.Email, model.To))
            {
                mm.Subject = model.Subject;
                mm.Body = model.Body;

                mm.IsBodyHtml = false;

                using (SmtpClient smtp = new SmtpClient())
                {
                    smtp.Host = "smtp.gmail.com";
                    smtp.EnableSsl = true;

                    NetworkCredential nc = new NetworkCredential(model.Email, model.Password);
                    smtp.UseDefaultCredentials = true;
                    smtp.Credentials = nc;
                    smtp.Port = 587;

                    smtp.Send(mm);

                    ViewBag.Message = "Gửi thành công";
                }
            }
            return View();
        }
    }
}