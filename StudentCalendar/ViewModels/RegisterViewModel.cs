﻿using Microsoft.AspNetCore.Mvc.Rendering;
using StudentCalendar.Models;
using System.ComponentModel.DataAnnotations;

namespace StudentCalendar.ViewModels
{
    public class RegisterViewModel
    {
        
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public Group Group { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string? ReturnUrl { get; set; }
        public IEnumerable<SelectListItem> Groups { get; set; }
        public string GroupSelected { get; set; }
    }
}
