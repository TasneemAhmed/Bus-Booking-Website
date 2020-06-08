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
        public ActionResult Index(string searchBy, string search)
        {
            if (searchBy == "Start")
            {
                return View(db.Trips.Where(x => x.tripStart.StartsWith(search) || search == null).ToList());
            }
            else if(searchBy == "Destination")
            {
                return View(db.Trips.Where(x => x.tripDestination.StartsWith(search) || search == null).ToList());
            }else if (searchBy == "Price")
            {
                var castedPrice = int.Parse(search);
                return View(db.Trips.Where(x => x.price == castedPrice || search == null).ToList());
            }else if (searchBy == "Time")
            {
                return View(db.Trips.Where(x => x.time.StartsWith(search) || search == null).ToList());
            }else //searchBy == "Date"
            {
                return View(db.Trips.Where(x => x.date.StartsWith(search) || search == null).ToList());
            }
        }

        //This function retrieve the data of the trip from the database.
        public IEnumerable<Trip> getTrips()
        {
            var trips = db.Trips.ToList();
            return trips;
        }

        //This function shows the details of the trip after retrieving the data from the database.
        public ActionResult Details(int id)
        {
            var trip = getTrips().SingleOrDefault(c => c.Id == id);
            if (trip == null)
            {
                return HttpNotFound();
            }
            return View(trip);
        }

        //This function starts the adding functionality of trips to database.
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        //This function adds a new trip to the database.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Trip newTrip)
        {
            if (ModelState.IsValid)
            {
                db.Trips.Add(newTrip);
                db.SaveChanges();

                return RedirectToAction("Index");
                
            }
            else
            {
                return View(newTrip);
            }
        }

        //This fuction starts the editing functionality by retrieving the data of the chosen trip from the database and filling the appropriate fields with the corresponding data.
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var tripFromDB = db.Trips.SingleOrDefault(d => d.Id == id);

            if (tripFromDB == null)
            {
                return HttpNotFound();
            }

            return View(tripFromDB);
        }

        //This function edits the trip's information by overwriting the existing data in the database by the new data from the POST request.
        [HttpPost]
        public ActionResult Edit(Trip trip)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit", "trip");
            }

            var tripFromDB = db.Trips.SingleOrDefault(d => d.Id == trip.Id);
            tripFromDB.date = trip.date;
            tripFromDB.time = trip.time;
            tripFromDB.price = trip.price;
            tripFromDB.tripDestination = trip.tripDestination;
            tripFromDB.tripStart = trip.tripStart;
            db.SaveChanges();

            return RedirectToAction("Index", "trip");
        }

        //This function deletes the chosen trip from the database.
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var trip = db.Trips.SingleOrDefault(d => d.Id == id);
            db.Trips.Remove(trip);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}