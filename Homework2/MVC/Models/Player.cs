using System.ComponentModel.DataAnnotations;

namespace ArsenalFans.Models
{
    public class Player
    {
        public int Id { get; set; }
        [Display(Name = "First name")]
        public string FirstName { get; set; }
        [Display(Name = "Last name")]
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Position { get; set; }
        public string Nationality { get; set; }
    }
}
