using System.ComponentModel.DataAnnotations;

namespace Test_web_app.Models
{
    public class Day
    {
        [Key]
        public int Id { get; set; }

        public int TripId { get; set; }

    }
}
