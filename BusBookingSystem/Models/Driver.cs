using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BusBookingSystem.Models
{
    public class Driver : Person
    {
        [Required(ErrorMessage = "You have enter Age")]
        [Display(Name = "Age")]
        public byte Age { get; set; }  //0 to 255
        public string Gender { get; set; } //want to make check list (male , female).

        public float Salary { get; set; }
    }
}
