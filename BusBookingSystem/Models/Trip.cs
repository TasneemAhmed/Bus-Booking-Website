using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BusBookingSystem.Models
{
    public class Trip
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "You have enter the trip start")]
        [Display(Name = "Start")]
        public string tripStart { get; set; }

        [Required(ErrorMessage = "You have enter the trip destination")]
        [Display(Name = "Destination")]
        public string tripDestination { get; set; }

        [Required(ErrorMessage = "You have enter the trip price")]
        [Display(Name = "Price")]
        public int price { get; set; }

        [Required(ErrorMessage = "You have enter the trip time")]
        [Display(Name = "Time")]
        public string time { get; set; }

        [Required(ErrorMessage = "You have enter the trip date")]
        [Display(Name = "Date")]
        public string date { get; set; }
    }
}
