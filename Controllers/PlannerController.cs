﻿using Microsoft.AspNetCore.Authorization;
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
            var trips = _plannerService.GetAll(User.Identity.Name);
            return View(trips);
        }

        [HttpGet]
        public IActionResult Add() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Trip body, DateTime startDate, DateTime endDate)
        {
            body.User = User.Identity.Name;
            body.StartDate = startDate;
            body.EndDate = endDate;

            int daysAmount = (endDate - startDate).Days;

            if (body.Description == null) body.Description = "";
            if (!ModelState.IsValid)
            {
                return View(body);
            }
            _plannerService.Save(body);
            
            for(int i=0; i<=daysAmount; i++)
            {
                Day day = new Day();
                day.TripId = body.Id;
                day.DayNumber = i + 1;
                _plannerService.SaveDay(day);
            }

            return RedirectToAction("List");
        }

        public IActionResult Delete(string id)
        {
            _plannerService.Delete(Int32.Parse(id));
            return RedirectToAction("List");
        }

        public IActionResult Edit(string id)
        {
            var trip = _plannerService.Get(Int32.Parse(id));
            return View(trip);
        }

        public IActionResult EditDay(int dayNumber)
        {
            return View();
        }
    }
}
