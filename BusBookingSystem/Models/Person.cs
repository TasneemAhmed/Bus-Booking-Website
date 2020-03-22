using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BusBookingSystem.Models
{
    public class Person
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } 

        [Required(ErrorMessage = "You have enter an Email")]
        [Display(Name = "Email")]
        public string EMail { get; set; }

        [Required(ErrorMessage = "You have enter  User Name")]
        [Display(Name = "Name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "You have enter  Phone Number")]
        [Display(Name = "Phone Number")]
        public long PhoneNumber { get; set; } //-18,446,744,,073,709,551,615 to 0 & 0 to 18,446,744,,073,709,551,615

        [Required(ErrorMessage = "You have enter Adress")]
        [Display(Name = "Adress")]
        public string Address { get; set; }
    }
}