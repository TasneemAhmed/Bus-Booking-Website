using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusBookingSystem.Models;
using BusBookingSystem.ViewModels;

namespace BusBookingSystem.Controllers
{
    public class BusController : Controller
    {
        // GET: Bus
        ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            var Driverid = db.Drivers.ToList();
            var Bus = db.Bus.ToList();
            BusDriver BD = new BusDriver
            {
                Buses = Bus,
                Drivers = Driverid


            };
            return View(BD);
        }

        [HttpGet]
        public ActionResult New()
        {


            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult New(BusDriver Buses)
        {

            if (!ModelState.IsValid)
            {

                return View(Buses);

            }
            else
            {

                db.Bus.Add(Buses.Bus);
                db.SaveChanges();

                return RedirectToAction("Index");
            }


        }
        [HttpGet]
        public ActionResult Edit(int id)
        {



            BusDriver BD = new BusDriver();
            BD.Bus = db.Bus.Single(B => B.id == id);



            return View(BD);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Edit(BusDriver BD)
        {
            if (!ModelState.IsValid)
            {

                return View("Edit", BD);
            }


            var Dbus = db.Bus.Single(B => B.id == BD.Bus.id);

            Dbus.MBusCapacity = BD.Bus.MBusCapacity;
            Dbus.MBusType = BD.Bus.MBusType;
            Dbus.MLicensePlateNo = BD.Bus.MLicensePlateNo;
            Dbus.Did = BD.Bus.Did;
            db.SaveChanges();



            return RedirectToAction("Index");
        }



        public ActionResult Details(int id)
        {
            BusDriver BD = new BusDriver();
            BD.Bus = db.Bus.SingleOrDefault(B => B.id == id);




            return View(BD);
        }









    }


}