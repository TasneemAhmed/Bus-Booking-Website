using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusBookingSystem.Models;

namespace BusBookingSystem.ViewModels
{
    public class BusDriver
    {
        public IEnumerable<Driver> Drivers { get; set; }
        public IEnumerable<Bus> Buses { get; set; }
        public Driver Driver { get; set; }
        public Bus Bus { get; set; }
    }
}