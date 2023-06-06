using Test_web_app.Models;

namespace Test_web_app.Services.Interfaces
{
    public interface IPlannerService
    {
        int Save(Trip trip);
        List<Trip> GetAll(string userName);
        Trip Get(int id);
        void Delete(int id);
        public void SaveDay(Day day);
        public void SaveActivity(Activity activity);
        public void Edit(Trip trip, int id);
    }
}
