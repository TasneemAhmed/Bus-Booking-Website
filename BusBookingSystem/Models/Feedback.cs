using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace BusBookingSystem.Models
{
    public class Feedback
    {
        public int id { get; set; }
        [Required(ErrorMessage = "You have to enter your name")]
        [Display(Name = "name")]
        public string name { get; set; }
        [Required(ErrorMessage = "You have to enter your email to contact with you if you have any problem")]
        [Display(Name = "Email")]
        public string EMail { get; set; }
        [Required(ErrorMessage = "please enter your feedback")]
        [Display(Name = "Feedback")]
        [MaxLength(200, ErrorMessage = "Your maximlength is 200 word Only")]
        public string text { get; set; }
        [MaxLength(20, ErrorMessage = "Your maximlength is 20 word Only")]
        public string Subject { get; set; }
    }
}