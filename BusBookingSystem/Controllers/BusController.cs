using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
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
        [Authorize(Roles ="Admin")]
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
        [Authorize(Roles = "Admin")]
        public ActionResult New()
        {


            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult New(BusDriver Buses, HttpPostedFileBase Upload)
        {
            if (Upload != null)
            {
                string path = Path.Combine(Server.MapPath("~/Uploads"), Upload.FileName);
                Upload.SaveAs(path);
                Buses.Bus.image = Upload.FileName;
            }

            try
            {
                db.Bus.Add(Buses.Bus);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                ViewBag.Message = "There is an error!! Maybe the driver id is wrong";
                return View(Buses);
            }
                return RedirectToAction("Index");
            


        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {



            BusDriver BD = new BusDriver();
            BD.Bus = db.Bus.Single(B => B.id == id);



            return View(BD);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(BusDriver BD, HttpPostedFileBase Upload)
        {
           


            var Dbus = db.Bus.Single(B => B.id == BD.Bus.id);

            Dbus.MBusCapacity = BD.Bus.MBusCapacity;
            Dbus.MBusType = BD.Bus.MBusType;
            Dbus.MLicensePlateNo = BD.Bus.MLicensePlateNo;
            Dbus.Did = BD.Bus.Did;
            if (Upload != null)
            {
                string path = Path.Combine(Server.MapPath("~/Uploads"), Upload.FileName);
                Upload.SaveAs(path);
                Dbus.image = Upload.FileName;

            }
            try
            {
                db.Entry(Dbus).State = EntityState.Modified;
                db.SaveChanges();
            }
            catch(Exception e)
            {
                ViewBag.Message = "There is Antlr error !! Maybe the driver id is wrong ";
                return View("Edit ", BD);
            }

            return RedirectToAction("Index");
        }


        [Authorize(Roles = "Admin")]
        public ActionResult Details(int id)
        {
            BusDriver BD = new BusDriver();
            BD.Bus = db.Bus.SingleOrDefault(B => B.id == id);




            return View(BD);
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult Back()
        {




            return RedirectToAction("Index");
        }
        [Authorize(Roles = "Admin")]
        public ActionResult SearchBus(string MLicensePlateNo)
        {

            BusDriver BD = new BusDriver();
            BD.Bus = db.Bus.SingleOrDefault(s => s.MLicensePlateNo.Contains(MLicensePlateNo));


            return View(BD);

        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)

        {
            var buses = db.Bus.Single(B => B.id == id);
            db.Bus.Remove(buses);
            db.SaveChanges();


            return RedirectToAction("Index");
        }
       









    }


}