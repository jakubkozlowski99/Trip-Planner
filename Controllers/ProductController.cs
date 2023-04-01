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

        public IActionResult ProductList()
        {
            var productList = new List<Product>
            {
                new Product
                {
                    Id = 1,
                    Name = "BMW M5",
                    Category = "Samochód",
                    Description = "Super samochód"
                },
                new Product
                {
                    Id = 2,
                    Name = "PEPSI",
                    Category = "Napoje",
                    Description = "To jest opis napoju"
                },
                new Product
                {
                    Id = 3,
                    Name = "Storczyk",
                    Category = "Rośliny",
                    Description = "To jest opis rośliny"
                }
            };
            return View(productList);
        }

        public IActionResult Data()
        {
            ViewBag.Name = "Jakub";
            ViewData["Surname"] = "Kozłowski";
            TempData["SecondName"] = "Brak";
            return View();
        }
    }
}
