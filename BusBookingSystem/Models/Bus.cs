using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace BusBookingSystem.Models
{
    public class Bus
    {
        

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
        
        public string MBusType { get; set; }
        public virtual Driver Driverid { get; set; }
        [ForeignKey("Driverid")]
        public int? Did { get; set; }

    }
}