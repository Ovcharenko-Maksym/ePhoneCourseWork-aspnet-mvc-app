using ePhoneCourseWork.Data.Base;
using ePhoneCourseWork.Models;
using System.Linq;

namespace ePhoneCourseWork.Data.Services
{
    public class ProductsService : EntityBaseRepository<Product>, IProductsService
    {
        private readonly AppDbContext _context;
        public ProductsService(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public Product GetProductById(int id)
        {
            var movieDetails = _context.Products.FirstOrDefault(n=>n.Id==id);
            return movieDetails;
        }
    }
}
