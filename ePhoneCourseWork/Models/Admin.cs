using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ePhoneCourseWork.Models
{
    public class Admin
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        //Relationships
        public List<BlacklistedCustomer> BlacklistedCustomers { get; set; }
        public List<Sale> Sales { get; set; }
    }
}
