using System;
using System.ComponentModel.DataAnnotations;

namespace CarShowroom.Client.DTOs
{
    public class CarDTO
    {
        public int Id { get; set; }
        [Required]
        public string Make { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [CorrectYear(ErrorMessage = "Invalid year.")]
        public int Year { get; set; }
        [Required]
        [Range(1,int.MaxValue, ErrorMessage = "Invalid mileage.")]
        public int Mileage { get; set; }
        [Required]
        public string BodyStyle { get; set; }
        [Required]
        public string Color { get; set; }

        public int? ClientId { get; set; }
    }

    class CorrectYearAttribute : ValidationAttribute
    {
        public CorrectYearAttribute()
        {
        }

        public override bool IsValid(object value)
        {
            var year = (int)value;
            if(year <= DateTime.Now.Year && year >= 1883)
            {
                return true;
            }
            return false;
        }
    }
}
