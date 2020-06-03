using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Web.UI.WebControls;
using BusBookingSystem.Models;
using System.Text;

using System.Net;
using System.Net.Mail;


namespace BusBookingSystem.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpGet]
        public ActionResult Feedback()
        {


            return View();
        }
        [HttpPost]
        public ActionResult Feedback(Feedback fb)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    MailMessage mail = new MailMessage();
                    mail.To.Add("busbookinga@gmail.com");
                    mail.From = new MailAddress(fb.EMail);
                    mail.Subject = fb.Subject;

                    StringBuilder Body = new StringBuilder();
                    Body.Append("Name   :   " + fb.name);
                    Body.Append(" \n Email  :   " + fb.EMail);
                    Body.Append(" \n Message :   " + fb.text);

                    mail.Body = Body.ToString();
                    mail.IsBodyHtml = true;
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new System.Net.NetworkCredential
                    ("busbookinga@gmail.com", "BusBookingSystem2020");// Enter seders User name and password
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                    ViewBag.Message = "Thank you for your feedback";
                    return View();

                }
                else
                {
                    return View();
                }
            }
            catch (Exception e)
            {
                ViewBag.Message = "There is an error !! please resend your feedback";
                return View();
            }
        }

    }
}