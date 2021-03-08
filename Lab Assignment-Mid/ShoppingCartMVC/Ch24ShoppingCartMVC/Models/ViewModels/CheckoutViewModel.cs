using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ch24ShoppingCartMVC.Models.ViewModels
{
    public class CheckoutViewModel
    {
        [Required(ErrorMessage="First Name required")]
        [Display(Name="First Name")]
        public string fName;

        [Required(ErrorMessage = "Last Name required")]
        [Display(Name = "Last Name")]
        public string lName;

        [Required(ErrorMessage = "Email is required")]
        public string email;

        [Required(ErrorMessage = "Address is required")]
        public string address;

        [Required(ErrorMessage = "City is required")]
        public string city;

        [Required(ErrorMessage = "State is required")]
        public string state;

        [Required(ErrorMessage = "Zip Code is required")]
        public int zipCode;

        [Required(ErrorMessage = "Contact information is required")]
        public string contact;
    }
}