using Microsoft.AspNetCore.Identity;
using MyProject.Models;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace MyProject.ViewModels
{
    public class UserViewModel : ApplicationUser
    {
        [Display(Name = "部門")]
        public string? DepartmentName { get; set; }

        [Display(Name = "角色")]
        public string? RoleName { get; set; }

        [Display(Name = "創建者")]
        public string? CreateName { get; set; }

        [Display(Name = "更新者")]
        public string? UpdateName { get; set; }

        public UserViewModel(ApplicationUser parent, List<ApplicationUser> users, string? departmentName, string? roleName)
        {
            Id = parent.Id;
            UserName = parent.UserName;
            CnName = parent.CnName;
            EngName = parent.EngName;
            PhoneNumber = parent.PhoneNumber;
            Email = parent.Email;
            DepartmentId = parent.DepartmentId;
            DepartmentName = departmentName;
            RoleName = roleName;
            CreateTime = parent.CreateTime;
            CreateId = parent.CreateId;
            UpdateTime = parent.UpdateTime;
            UpdateId = parent.UpdateId;

            CreateName = users.FirstOrDefault(x => x.Id == parent.CreateId)?.CnName;
            UpdateName = users.FirstOrDefault(x => x.Id == parent.UpdateId)?.CnName;
        }
    }
}
