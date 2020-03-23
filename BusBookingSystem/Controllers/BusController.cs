using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusBookingSystem.Models;

namespace BusBookingSystem.Controllers
{
    public class BusController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public IEnumerable<Bus> getBuses()
        {

            var CBuses = db.Buses.ToList();
            return CBuses;
        }

        // GET: Bus

        public ActionResult Index()
        {

            var Buses = getBuses();
            return View(Buses);
        }
        [HttpGet]
        public ActionResult New()
        {


            return View();
        }
        [HttpPost]
      
        public ActionResult New(Bus Buses)
        {
            if (!ModelState.IsValid)
            {

                return View("New");
            }
            db.Buses.Add(Buses);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var buses = db.Buses.Single(B => B.id == id);


            return View(buses);
        }
      
        [HttpPost]
        public ActionResult Edit(Bus buses)
        {
            if (!ModelState.IsValid)
            {

                return View("Edit", buses);
            }
            var BusDB = db.Buses.Single(B => B.id == buses.id);
            BusDB.MBusCapacity = buses.MBusCapacity;
            BusDB.MBusType = buses.MBusType;
            BusDB.MLicensePlateNo = buses.MLicensePlateNo;
            db.SaveChanges();



            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(int id)

        {
            var buses = db.Buses.Single(B => B.id == id);
            db.Buses.Remove(buses);
            db.SaveChanges();


            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            var buses = getBuses().Where(B => B.id == id);



            return View(buses);
        }
        [HttpGet]
        public ActionResult Back()
        {




            return RedirectToAction("Index");
        }
    }
}