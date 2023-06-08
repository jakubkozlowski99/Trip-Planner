using Test_web_app.Models;
using Test_web_app.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Test_web_app.Services
{
    public class PlannerService : IPlannerService
    {
        private readonly DbTestContext _context;
        public PlannerService(DbTestContext context)
        {
            _context = context;
        }

        public void Delete(int id)
        {
            var trip = _context.Trips.Find(id);
            var days = _context.Days.Where(d => d.TripId == id).ToList();

            foreach (Day day in days)
            {
                _context.Activities.RemoveRange(_context.Activities.Where(a => a.DayId == day.Id));
            }

            _context.Days.RemoveRange(_context.Days.Where(d => d.TripId == id));
            _context.Trips.Remove(trip);
            _context.SaveChanges();
        }

        public Trip Get(int id)
        {
            var trip = _context.Trips.Find(id);
            return trip;
        }

        public List<Trip> GetAll(string userName)
        {
            var trips = _context.Trips.Where(t => t.User == userName).ToList();
            return trips;
        }

        public int Save(Trip trip)
        {
            _context.Add(trip);
            return _context.SaveChanges();
        }

        public void SaveDay(Day day) 
        {
            _context.Add(day);
            _context.SaveChanges();
        }

        public void SaveActivity(Activity activity)
        {
            _context.Add(activity);
            _context.SaveChanges();
        }

        public void Edit(Trip newTrip, int id)
        {
            var trip = _context.Trips.Find(id);
            trip.Title = newTrip.Title;
            trip.StartDate = newTrip.StartDate;
            trip.EndDate = newTrip.EndDate;
            trip.Description = newTrip.Description;

            var days = _context.Days.Where(d => d.TripId == id).ToList();
            foreach(Day day in days)
            {

            }

            _context.SaveChanges();
        }

        public List<Day> GetTripDays(int id)
        {
            var days = _context.Days.Where(d => d.TripId == id).ToList();

            return days;
        }

        public void DeleteDay(int id)
        {
            var day = _context.Days.Find(id);
            _context.Days.Remove(day);
            _context.SaveChanges();
        }
    }
}
