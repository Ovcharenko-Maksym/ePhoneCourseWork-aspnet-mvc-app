using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ePhoneCourseWork.Models
{
    public class BlacklistedCustomer
    {
        [Key]
        public int Id { get; set; }
        public DateTime BlacklistedDateTime { get; set; }

    }
}
