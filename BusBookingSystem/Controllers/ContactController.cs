
using BusBookingSystem.Models;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Web;

using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace BusBookingSystem.Controllers
{
    public class ContactController : Controller
    {
     [HttpGet]
     public ActionResult Feedback ()
        {
            return View();
        }

        
    }
}