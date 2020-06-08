using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusBookingSystem.Models;

namespace BusBookingSystem.ViewModels
{
    public class TripBus
    {
        public IEnumerable<Trip> Trips { get; set; }
        public IEnumerable<Bus> Buses { get; set; }
        public Trip Trip { get; set; }
        public Bus Bus { get; set; }
    }
}