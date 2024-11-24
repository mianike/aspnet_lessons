using System.ComponentModel.DataAnnotations;

namespace ArsenalFansWebApp.Validation
{
    public class FootballPositionAttribute : ValidationAttribute
    {
        private readonly string[] _existingPositions = new[]
        {
            "Goalkeeper",
            "Defender",
            "Midfielder",
            "Forward"
        };

        public override bool IsValid(object? value)
        {
            if (value != null && value is string position)
            {
                return _existingPositions.Contains(position, StringComparer.OrdinalIgnoreCase);
            }

            return false;
        }
    }
}