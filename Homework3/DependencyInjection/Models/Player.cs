using System.ComponentModel.DataAnnotations;

namespace ArsenalFans.Models
{
    public class Player
    {
        public int Id { get; set; }

        [Display(Name = "First name"), MaxLength(50), Required]
        public string FirstName { get; set; }

        [Display(Name = "Last name"), MaxLength(50), Required]
        public string LastName { get; set; }

        [Range(16, 40)]
        public int Age { get; set; }
        public string Position { get; set; }

        [MaxLength(30)]
        public string Nationality { get; set; }
    }
}