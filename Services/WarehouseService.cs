using Test_web_app.Models;
using Test_web_app.Services.Interfaces;

namespace Test_web_app.Services
{
    public class WarehouseService : IWarehouseService
    {
        private readonly DbTestContext _context;

        public WarehouseService(DbTestContext context)
        {
            _context = context;
        }

        public List<Product> GetAll()
        {
            var products = _context.Products.ToList();

            return products;
        }

        public int Save(Product product)
        {
            _context.Add(product);

            if(_context.SaveChanges() > 0)
            {
                System.Console.WriteLine("SUKCES");
            }

            return product.Id; 
        }
    }
}
