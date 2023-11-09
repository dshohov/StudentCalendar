using System.ComponentModel.DataAnnotations;

namespace StudentCalendar.ViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
