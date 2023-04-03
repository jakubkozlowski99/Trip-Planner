using System.ComponentModel.DataAnnotations;

namespace Test_web_app.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Pole nazwa jest wymagane")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Pole opis jest wymagane")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Pole kategoria jest wymagane")]
        public string Category { get; set; }
    }
}
