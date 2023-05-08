using Microsoft.AspNetCore.Mvc;
using Test_web_app.Models;
using Test_web_app.Services.Interfaces;

namespace Test_web_app.Controllers
{
    public class ProductController : Controller
    {
        private readonly IWarehouseService _warehouseService;
        private readonly IPlannerService _plannerService;

        public ProductController(IWarehouseService warehouseService, IPlannerService plannerService)
        {
            _warehouseService = warehouseService;
            _plannerService = plannerService;
        }

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
            var productList = _warehouseService.GetAll();
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
