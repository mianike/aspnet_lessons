using ArsenalFansWebApp.Validation;
using System.ComponentModel.DataAnnotations;

namespace ArsenalFansWebApp.Models
{
    public class PlayerViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "FirstName is required")]
        [MaxLength(100, ErrorMessage = "The FirstName length must not exceed 100 characters")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "LastName is required")]
        [MaxLength(100, ErrorMessage = "The LastName length must not exceed 100 characters")]
        public string LastName { get; set; }

        [DataType(DataType.Date, ErrorMessage = "Invalid date format")]
        public DateOnly BirthDate { get; set; }

        public int Age
        {
            get
            {
                DateOnly currentDate = DateOnly.FromDateTime(DateTime.Now);

                int age = currentDate.Year - BirthDate.Year;

                if (currentDate.DayOfYear < BirthDate.DayOfYear)
                {
                    age--;
                }

                return age;
            }
        }

        [Required(ErrorMessage = "Position is required")]
        [FootballPosition(ErrorMessage = "Invalid football position. Valid positions are Goalkeeper, Defender, Midfielder, Forward")]
        public string Position { get; set; }

        [Required(ErrorMessage = "Nationality is required")]
        [MaxLength(100, ErrorMessage = "The nationality length must not exceed 100 characters")]
        public string Nationality { get; set; }
    }
}