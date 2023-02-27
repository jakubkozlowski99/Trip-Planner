using Microsoft.AspNetCore.Mvc;
using Test_web_app.Models;

namespace Test_web_app.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Product()
        {
            var product = new Product()
            {
                Id = 1,
                Name = "BMW M5",
                Category = "car",
                Description = "Super samochód"
            };
            return View(product);
        }
    }
}
