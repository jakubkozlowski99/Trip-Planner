using System.ComponentModel.DataAnnotations;

namespace Test_web_app.Models
{
    public class Trip :IValidatableObject
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(15)]
        public string Title { get; set; }

        public string? Description { get; set; }
        public string? User { get; set; }

        [Required(ErrorMessage ="Wybierz datę")]
        [DataType(DataType.Date)]
        public DateTime? StartDate { get; set; }

        [Required(ErrorMessage ="Wybierz datę")]
        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if(EndDate.Value <= StartDate.Value)
            {
                yield return new ValidationResult("Data końcowa musi być późniejsza od początkowej");
            }
        }
    }
}
