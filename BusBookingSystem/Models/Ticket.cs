using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BusBookingSystem.Models
{
    public class Ticket
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name ="From")]
        public string Source { get; set; }

        [Display(Name = "Where to?")]
        public string Desination { get; set; }

        [Display(Name = "Trip Price")]
        public int TripPrice { get; set; }

        [Display(Name = "Date")]
        public string TripDate { get; set; }

        [Display(Name = "Time")]
        public string TripTime { get; set; }

        [Required(ErrorMessage = "this field is required")]
        [Display(Name ="Number of Seats")]
        [Range(1, 150)]
        public int  NumberOfSeats { get; set; }

        [Display(Name = "Licence Plate Number")]
        public string BusType { get; set; }

        [Display(Name = "Total Price")]
        public int TotalPrice { get; set; }

   

    }
}