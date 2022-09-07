using System.ComponentModel.DataAnnotations;

namespace MyProject.ViewModels
{
    public class UserEditViewModel
    {
        public string UserId { get; set; }
        [Display(Name = "帳號")]
        public string? UserName { get; set; }
        [Display(Name = "姓名")]
        public string? CnName { get; set; }
        [Display(Name = "部門")]
        public int? DepartmentId { get; set; }
        [Display(Name = "角色")]
        public string? RoleName { get; set; }
    }
}
