using System.Diagnostics.CodeAnalysis;

namespace StudentCalendar.Models
{
    public class UserInEvent
    {
        [NotNull]
        public int Id { get; set; }
        [NotNull]
        public int IdEvent { get; set; }
        [NotNull]
        public string? IdUser { get; set; }
        [NotNull]
        public bool Join { get; set; }
    }
}
