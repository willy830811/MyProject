using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace MyProject.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? CnName { get; set; }
        public string? EngName { get; set; }
        public int? DepartmentId { get; set; }
    }
}
