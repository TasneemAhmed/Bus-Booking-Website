﻿using System;
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
    }


}