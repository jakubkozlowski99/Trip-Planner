using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Test_web_app.Models;
using Test_web_app.Services.Interfaces;

namespace Test_web_app.Controllers
{
    [Authorize]
    public class PlannerController : Controller
    {
        private readonly IPlannerService _plannerService;

        public PlannerController(IPlannerService plannerService)
        {
            _plannerService = plannerService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult List()
        {
            var trips = _plannerService.GetAll();
            return View(trips);
        }

        [HttpGet]
        public IActionResult Add() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Trip body)
        {
            body.User = User.Identity.Name;
            if (body.Description == null) body.Description = "";
            if (!ModelState.IsValid)
            {
                return View(body);
            }
            _plannerService.Save(body);
            return RedirectToAction("List");
        }

        public IActionResult Delete(string id)
        {
            _plannerService.Delete(Int32.Parse(id));
            return RedirectToAction("List");
        }
    }
}
