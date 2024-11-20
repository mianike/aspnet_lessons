using ArsenalFansModel.Contracts;

namespace ArsenalFansModel.Entities
{
    public class Player : EntityBase<int>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly BirthDate { get; set; }
        public string Position { get; set; }
        public string Nationality { get; set; }
        public DateTime LastUpdatedUtc { get; set; }
    }
}