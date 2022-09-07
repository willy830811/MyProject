using System.ComponentModel.DataAnnotations;

namespace MyProject.ViewModels
{
    public class UserIndexViewModel
    {
        public string UserId { get; set; }
        [Display(Name = "帳號")]
        public string? UserName { get; set; }
        public string? Email { get; set; }
        [Display(Name = "姓名")]
        public string? CnName { get; set; }
        [Display(Name = "英文名")]
        public string? EngName { get; set; }
        [Display(Name = "部門")]
        public string? DepartmentName { get; set; }
        [Display(Name = "角色")]
        public string? RoleName { get; set; }
    }
}
