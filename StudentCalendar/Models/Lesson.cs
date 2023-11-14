using System.Diagnostics.CodeAnalysis;

namespace StudentCalendar.Models
{
    public class Lesson
    {
        public int Id { get; set; }
        [NotNull]
        public string? Name { get; set; }
        public int IdGroup { get; set; }
        public byte DayOfWeek { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
    }
}
