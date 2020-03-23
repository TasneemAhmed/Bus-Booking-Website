using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BusBookingSystem.Models
{
    public class Bus
    {
        [Required(ErrorMessage = "this field is required")]
        [Display(Name = "Bus Number")]
        
        public int id { get; set; }

        [Required(ErrorMessage = "this field is required")]
        [Display(Name = "License Plate Number")]

        [StringLength(5, ErrorMessage = "you must enter 5 characters")]
        public string MLicensePlateNo { get; set; }

        [Required(ErrorMessage = "this field is required")]
        [Display(Name = "Bus Capacity")]
        [Range(20, 150)]
        public int MBusCapacity { get; set; }
        [Required(ErrorMessage = "this field is required")]
        [Display(Name = "Bus Type")]
        [Range(3, 5)]
        public string MBusType { get; set; }
    }
}