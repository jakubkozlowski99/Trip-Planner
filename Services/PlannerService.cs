using Test_web_app.Models;
using Test_web_app.Services.Interfaces;

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
            _context.Trips.Remove(trip);
            _context.SaveChanges();
        }

        public Trip Get(int id)
        {
            var trip = _context.Trips.Find(id);
            return trip;
        }

        public List<Trip> GetAll()
        {
            var trips = _context.Trips.ToList();
            return trips;
        }

        public int Save(Trip trip)
        {
            _context.Add(trip);
            return _context.SaveChanges();
        }
    }
}
