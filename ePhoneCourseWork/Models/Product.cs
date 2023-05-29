using ePhoneCourseWork.Data.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ePhoneCourseWork.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public Color Color { get; set; }
        public double Price { get; set; }

        //Reletionships
        public List<OrderItem> OrderItems { get; set; }
    }
}
