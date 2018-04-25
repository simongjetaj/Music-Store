using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicStore.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }

        //[Remote("CheckUserName", "Account")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Your {0} is required.")]
        [StringLength(160, MinimumLength = 3)]
        [Display(Name="First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(160)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }

        //[Range(35, 44)]
        //public int Age { get; set; }

        //[Range(typeof(decimal), "0.00", "49.99")]
        //public decimal Price { get; set; }

        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Please, enter a valid email address")]
        public string Email { get; set; }

        //[Required]
        //[DataType(DataType.Password)]
        //[Display(Name = "Password")]
        //public string Password { get; set; }

        public decimal Total { get; set; }
    }
}