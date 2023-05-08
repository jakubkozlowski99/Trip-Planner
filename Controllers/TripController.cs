using Microsoft.AspNetCore.Mvc;
using Test_web_app.Services.Interfaces;

namespace Test_web_app.Controllers
{
    public class TripController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
