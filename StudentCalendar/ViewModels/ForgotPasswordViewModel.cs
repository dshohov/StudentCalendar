using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace StudentCalendar.ViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [NotNull]
        public string? Email { get; set; }
    }
}
