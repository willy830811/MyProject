using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace MyProject.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Display(Name = "姓名")]
        public string? CnName { get; set; }

        [Display(Name = "英文名")]
        public string? EngName { get; set; }

        [Display(Name = "部門")]
        public int? DepartmentId { get; set; }

        [Display(Name = "創建時間")]
        public DateTime? CreateTime { get; set; }

        public string? CreateId { get; set; }

        [Display(Name = "更新時間")]
        public DateTime? UpdateTime { get; set; }

        public string? UpdateId { get; set; }

        [Display(Name = "帳號")]
        public override string? UserName { get; set; }

        [Display(Name = "手機")]
        public override string? PhoneNumber { get; set; }
    }
}
