using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace StudentCalendar.Class
{   
        public class AppUser : IdentityUser// Зміни тут
        {
            [NotNull]
            public string? FirstName { get; set; }
            [NotNull]
            public string? LastName { get; set; }
            public int IdGroup { get; set; }
            public DateTime LoginTime { get; set; }
            [NotMapped]
            public string? RoleId { get; set; }
            [NotMapped]
            public string? Role { get; set; }
            [NotMapped]
            public IEnumerable<SelectListItem>? RoleList { get; set; }
        }
 
}
