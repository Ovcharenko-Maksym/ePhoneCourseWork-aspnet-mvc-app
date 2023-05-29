using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ePhoneCourseWork.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        //Relationships
        public List<Order> Orders { get; set; }
        public List<BlacklistedCustomer> BlacklistedCustomers { get; set; }
    }
}
