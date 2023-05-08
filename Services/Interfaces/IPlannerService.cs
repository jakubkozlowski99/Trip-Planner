using Test_web_app.Models;

namespace Test_web_app.Services.Interfaces
{
    public interface IPlannerService
    {
        int Save(Trip trip);
        List<Trip> GetAll();
        Trip Get(int id);
        void Delete(int id);
    }
}
