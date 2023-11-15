using System.Diagnostics.CodeAnalysis;

namespace Models
{
    public class Group
    {
        [NotNull]
        public int Id { get; set; }
        [NotNull]
        public string? Name { get; set; }
    }
}
