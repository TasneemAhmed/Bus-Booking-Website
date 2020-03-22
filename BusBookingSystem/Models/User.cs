using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BusBookingSystem.Models
{
    public class User : Person
    {
        [Required(ErrorMessage = "You have enter a Password")]
        [Display(Name = "Password")]
        public string UserPassword { get; set; }
    }
}