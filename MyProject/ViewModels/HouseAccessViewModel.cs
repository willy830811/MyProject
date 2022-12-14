using MyProject.Models;
using System.ComponentModel.DataAnnotations;

namespace MyProject.ViewModels
{
    public class HouseAccessViewModel
    {
        public string UserId { get; set; }
        [Display(Name = "帳號")]
        public string? UserName { get; set; }
        [Display(Name = "姓名")]
        public string? CnName { get; set; }
        [Display(Name = "英文名")]
        public string? EngName { get; set; }
        [Display(Name = "部門")]
        public string? DepartmentName { get; set; }
        public bool Checked { get; set; }
    }
}
