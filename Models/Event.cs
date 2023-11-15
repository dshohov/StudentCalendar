using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Models
{
    public class Event
    {
        [NotNull]
        public int Id { get; set; }
        [NotNull]
        public string? Name { get; set; }
        [NotNull]
        public string? Description { get; set; }
        [NotNull]
        public DateTime DateTime { get; set; }
        [NotNull]
        public string? Location { get; set; }
        [NotNull]
        public DateTime DateCreate { get; set; }
        
    }
}
