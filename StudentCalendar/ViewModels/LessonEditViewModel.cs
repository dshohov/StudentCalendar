using System.Diagnostics.CodeAnalysis;

namespace StudentCalendar.ViewModels
{
    public class LessonEditViewModel
    {
        public int Id { get; set; }
        [NotNull]
        public string? Name { get; set; }
        public int IdGrouop { get; set; }
    }
}
