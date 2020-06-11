using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusBookingSystem.Models;
using BusBookingSystem.ViewModels;

namespace BusBookingSystem.Controllers
{
    public class TripController : Controller
    {
        //Instance of the database to access it.
        ApplicationDbContext db = new ApplicationDbContext();

        /*This function shows a list of all saved trips in the database and shows it on the home screen of
         * maintaining the trips, it also works as a search function with different search filters*/
        [Authorize(Roles = "Admin")]
        public ActionResult Index(string searchBy, string search)
        {
            if (searchBy == "Start")
            {
                return View(db.Trips.Where(x => x.tripStart.StartsWith(search) || search == null).ToList());
            }
            else if (searchBy == "Destination")
            {
                return View(db.Trips.Where(x => x.tripDestination.StartsWith(search) || search == null).ToList());
            }else if (searchBy == "Price")
            {
                var castedPrice = int.Parse(search);
                return View(db.Trips.Where(x => x.price == castedPrice || search == null).ToList());
            }else if (searchBy == "Time")
            {
                return View(db.Trips.Where(x => x.time.StartsWith(search) || search == null).ToList());
            }else if (searchBy == "Date")
            {
                return View(db.Trips.Where(x => x.date.StartsWith(search) || search == null).ToList());
            }
            else //if (searchBy == "License Plate Number")
            {
                return View(db.Trips.Where(x => x.licensePlateNo.StartsWith(search) || search == null).ToList());
            }
        }

        //This function retrieve the data of the trip from the database.
        [Authorize(Roles = "Admin")]
        public IEnumerable<Trip> getTrips()
        {
            var trips = db.Trips.ToList();
            return trips;
        }

        //This function shows the details of the trip after retrieving the data from the database.
        [Authorize(Roles = "Admin")]
        public ActionResult Details(int id)
        {
            var trip = getTrips().SingleOrDefault(c => c.Id == id);
            if (trip == null)
            {
                return HttpNotFound();
            }
            TripBus tripBus = new TripBus { Trip = trip };
            return View(tripBus);
        }

        //This function starts the adding functionality of trips to database.
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult Add()
        {
            var buses = db.Bus.ToList();
            TripBus tripBus = new TripBus
            {
                Buses = buses
            };
            return View(tripBus);
        }

        //This function adds a new trip to the database.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Add(TripBus newTrip)
        {
            if (ModelState.IsValid)
            {
                db.Trips.Add(newTrip.Trip);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(newTrip);
        }

        //This fuction starts the editing functionality by retrieving the data of the chosen trip from the database and filling the appropriate fields with the corresponding data.
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            var tripFromDB = db.Trips.SingleOrDefault(d => d.Id == id);
            var buses = db.Bus.ToList();
            TripBus tripBus = new TripBus
            {
                Trip = tripFromDB,
                Buses = buses
            };
            if (tripFromDB == null)
            {
                return HttpNotFound();
            }

            return View(tripBus);
        }

        //This function edits the trip's information by overwriting the existing data in the database by the new data from the POST request.
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(TripBus editTrip)
        {
            if (!ModelState.IsValid)
            {
                var buses = db.Bus.ToList();
                editTrip.Buses = buses;
                return View("Edit", "editTrip");
            }

            var tripFromDB = db.Trips.SingleOrDefault(d => d.Id == editTrip.Trip.Id);
            tripFromDB.date = editTrip.Trip.date;
            tripFromDB.time = editTrip.Trip.time;
            tripFromDB.price = editTrip.Trip.price;
            tripFromDB.tripDestination = editTrip.Trip.tripDestination;
            tripFromDB.tripStart = editTrip.Trip.tripStart;
            tripFromDB.licensePlateNo = editTrip.Trip.licensePlateNo;
            db.SaveChanges();

            return RedirectToAction("Index", "trip");
        }

        //This function deletes the chosen trip from the database.
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            var trip = db.Trips.SingleOrDefault(d => d.Id == id);
            db.Trips.Remove(trip);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}