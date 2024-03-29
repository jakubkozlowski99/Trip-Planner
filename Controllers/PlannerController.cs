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

            return RedirectToAction("EditDay", "Planner", new { @tripId = body.Id, @dayNumber = 1 });
        }

        public IActionResult Delete(string id)
        {
            _plannerService.Delete(Int32.Parse(id));
            return RedirectToAction("List");
        }

        [HttpGet]
        public IActionResult Edit(string id)
        {
            var trip = _plannerService.Get(Int32.Parse(id));
            return View(trip);
        }

        [HttpPost]
        public IActionResult Edit(Trip body, string id, DateTime startDate, DateTime endDate)
        {
            int daysAmount = (endDate - startDate).Days;

            body.User = User.Identity.Name;
            body.StartDate = startDate;
            body.EndDate = endDate;

            var days = _plannerService.GetTripDays(Int32.Parse(id));

            if (daysAmount > days.Count) 
            {
                for (int i = 0; i <= daysAmount - days.Count; i++)
                {
                    Day day = new Day();
                    day.TripId = Int32.Parse(id);
                    day.DayNumber = daysAmount + i;
                    _plannerService.SaveDay(day);
                }
            }
            else
            {
                foreach (var day in days)
                {
                    if (day.DayNumber > daysAmount + 1) _plannerService.DeleteDay(day.Id);
                }
            }

            if (body.Description == null) body.Description = "";
            if (!ModelState.IsValid)
            {
                return View(body);
            }
            _plannerService.Edit(body, Int32.Parse(id));

            return RedirectToAction("EditDay", "Planner", new {@tripId = id, @dayNumber = "1"});
        }

        public IActionResult EditDay(string tripId, string dayNumber)
        {
            var trip = _plannerService.Get(Int32.Parse(tripId));
            var day = _plannerService.GetDay(trip, Int32.Parse(dayNumber));
            if(day != null)
            {
                ViewData["Activities"] = _plannerService.GetActivities(day.Id);
                return View(day);
            }
            return RedirectToAction("List");
        }

        [HttpPost]
        public IActionResult AddActivity(string tripId, string dayId, string dayNumber, string activityName, string activityCost)
        {
            var activity = new Activity();
            activity.Cost = Int32.Parse(activityCost);
            activity.Name = activityName;
            activity.DayId = Int32.Parse(dayId);
            _plannerService.SaveActivity(activity);
            return RedirectToAction("EditDay", "Planner", new { @tripId = tripId, @dayNumber = dayNumber });
        }

        [HttpPost]
        public IActionResult DeleteActivity(string id)
        {
            var activity = _plannerService.GetActivity(Int32.Parse(id));
            var day = _plannerService.GetDayById(activity.DayId);
            _plannerService.DeleteActivity(Int32.Parse(id));
            return RedirectToAction("EditDay", "Planner", new { @tripId = day.TripId.ToString(), @dayNumber = day.DayNumber.ToString() });
        }
    }
}
