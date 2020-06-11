using BusBookingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BusBookingSystem.Controllers
{
    public class TicketController : Controller
    {
        //Instance of the database to access it.
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            var trips = getTrips();
            return View(trips);
        }
        //This function retrieve the data of the trip from the database.
        public IEnumerable<Trip> getTrips()
        {
            var trips = db.Trips.ToList();
            return trips;
        }

        //to calculate Total Price by (Number of Seats * Trip Price)
        public int getTotalPrice(int numberOfSeats, int tripPrice)
        {
            var totalPrice = numberOfSeats * tripPrice;
            return totalPrice;
        }

        [Authorize(Roles = "User")]

        [HttpGet] //this action triggered when click Button "Book" in "Index" view.
        public ActionResult Booking(int Id)
        {
            var trip = getTrips().SingleOrDefault(t => t.Id == Id);
            Ticket bookingTrip = new Ticket
            {

                Source = trip.tripStart,
                Desination = trip.tripDestination,
                TripPrice = trip.price,
                BusType = trip.licensePlateNo,
                TripDate = trip.date, // want to change date from string to DateTime in Trip & BookingTrip
                TripTime = trip.time,
            };
            return View(bookingTrip);
        }

        [HttpPost]
        //this will view when press "Confirm Book" button in "Booking" view..
        public ActionResult Booking(Ticket bookingTrip)
        {
            ViewBag.Message = string.Format("Total Price: {0}. \\n Are you sure you want to Book this trip? ", getTotalPrice(bookingTrip.NumberOfSeats, bookingTrip.TripPrice));

            db.Tickets.Add(bookingTrip);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}