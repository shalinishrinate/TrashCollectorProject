using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TrashCollectorFinal.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public DateTime PickupDay { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ExtraPickupDate { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zipcode { get; set; }
        public double Balance { get; set; }
        public DateTime SuspendedStart { get; set; }
        public DateTime SuspendedEnd { get; set; }
        public bool PickupConfirmation { get; set; }

        [ForeignKey("ApplicationUser")]
        public string ApplicationId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}