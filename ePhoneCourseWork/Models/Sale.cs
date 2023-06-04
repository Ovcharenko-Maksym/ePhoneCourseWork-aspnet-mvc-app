using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ePhoneCourseWork.Models
{
    public class Sale
    {
        [Key]
        public int Id { get; set; }
        public DateTime SaleDateTime { get; set; }

        //Order
        public int OrderId { get; set; }
        [ForeignKey("OrderId")]
        public Order Order { get; set; }
    }
}
