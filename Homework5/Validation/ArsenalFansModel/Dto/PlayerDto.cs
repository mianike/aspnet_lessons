namespace ArsenalFansModel.Dto
{
    public class PlayerDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly BirthDate { get; set; }
        public string Position { get; set; }
        public string Nationality { get; set; }
    }
}