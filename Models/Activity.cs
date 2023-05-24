using System.ComponentModel.DataAnnotations;

namespace Test_web_app.Models
{
    public class Activity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Cost { get; set; }
        public int DayId { get; set; }
    }
}
