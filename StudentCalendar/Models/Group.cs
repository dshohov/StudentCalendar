using System.Diagnostics.CodeAnalysis;

namespace StudentCalendar.Models
{
    public class Group
    {
        [NotNull]
        public int Id { get; set; }
        [NotNull]
        public string? Name { get; set; }
    }
}
