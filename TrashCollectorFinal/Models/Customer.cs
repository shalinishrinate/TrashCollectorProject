using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TrashCollectorFinal.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

       [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Street Address")]
        public string StreetAddress { get; set; }

        [Display(Name = "City")]
        public string City { get; set; }

        public string State { get; set; }

        public int Zipcode { get; set; }

        [Display(Name = "Weekly Pickup Day")]
        public string PickupDay { get; set; }

        [Display(Name = "Extra Pickup Date")]
        public int ExtraPickupDate { get; set; }

        [Display(Name = "Account Balance")]
        public double Balance { get; set; }

        [Display(Name = "Suspended Start Date")]
        public DateTime SuspendedStart { get; set; }

        [Display(Name = "Suspended End Date")]
        public DateTime SuspendedEnd { get; set; }

        [Display(Name = "Pickup Confirmation")]
        public bool PickupConfirmation { get; set; }

        [ForeignKey("ApplicationUser")]
        public string ApplicationId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        public IEnumerable<Customer> Customers { get; set; }

        [NotMapped]
        public SelectList DaysOfWeek { get; set; }
    }
}