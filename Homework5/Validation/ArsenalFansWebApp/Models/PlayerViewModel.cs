namespace ArsenalFansWebApp.Models
{
    public class PlayerViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
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

        public string Position { get; set; }
        public string Nationality { get; set; }
    }
}