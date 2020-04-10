using BusBookingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BusBookingSystem.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        ApplicationDbContext db = new ApplicationDbContext();

        // GET: User
        //the first parameter is the option that we choose and the second parameter will use the textbox value  

        public ActionResult List(string searchBy, string search)
        {
            if (searchBy == "Name")
            {//searchBy == "Name"
                return View(db.Users.Where(x => x.UserName.StartsWith(search) || search == null).ToList());
            }
            else if (searchBy == "Email")
            {//searchBy == "Email"
                return View(db.Users.Where(x => x.EMail.StartsWith(search) || search == null).ToList());
            }
            var users = getUsers();
            return View(users);
        }

        public IEnumerable<User> getUsers()
        {
            //this var users is dbset in db , that get all users in db.
            var users = db.Users.ToList();
            return users;
        }

        public ActionResult Details(int id)
        {
            //SingleOrDefault() : this is for single specific customer.
            var user = getUsers().SingleOrDefault(c => c.Id == id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }
    }
}