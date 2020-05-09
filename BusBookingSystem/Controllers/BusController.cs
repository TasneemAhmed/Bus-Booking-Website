using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusBookingSystem.Models;
using BusBookingSystem.ViewModels;
using Microsoft.Ajax.Utilities;

namespace BusBookingSystem.Controllers
{
    public class BusController : Controller
    { ApplicationDbContext db = new ApplicationDbContext();
       public ActionResult Index()
        {
            var Driverid = db.Drivers.ToList();
            var Bus = db.Bus.ToList();
            BusDriver BD = new BusDriver
            {
                Buses=Bus,
                Drivers = Driverid

     
             };
            return View(BD);
        }
        public ActionResult New()
        {


            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult New(Bus Buses)
        {
            if (!ModelState.IsValid)
            {

                return View("New");
            }

            db.Bus.Add(Buses);
            db.SaveChanges();

            return RedirectToAction("Index");
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

           
            var Dbus = db.Bus.Single(B => B.id ==  BD.Bus.id);

            Dbus.MBusCapacity = BD.Bus.MBusCapacity;
            Dbus.MBusType = BD.Bus.MBusType;
            Dbus.MLicensePlateNo = BD.Bus.MLicensePlateNo;
            Dbus.Did = BD.Bus.Did;
            db.SaveChanges();



            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(int id)

        {
            var buses = db.Bus.Single(B => B.id ==id);
            db.Bus.Remove(buses);
            db.SaveChanges();


            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            BusDriver BD = new BusDriver();
            BD.Bus = db.Bus.SingleOrDefault(B => B.id == id);
          



            return View(BD);
        }
        [HttpGet]
        public ActionResult Back()
        {




            return RedirectToAction("Index");
        }
    }
}