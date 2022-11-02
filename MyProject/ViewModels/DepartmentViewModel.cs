using MyProject.Models;
using static System.Collections.Specialized.BitVector32;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Xml.Linq;
using System;

namespace MyProject.ViewModels
{
    public class DepartmentViewModel : Department
    {
        [Display(Name = "創建者")]
        public string? CreateName { get; set; }

        [Display(Name = "更新者")]
        public string? UpdateName { get; set; }

        public DepartmentViewModel(Department parent, List<ApplicationUser> users)
        {
            Id = parent.Id;
            Name = parent.Name;
            CreateTime = parent.CreateTime;
            UpdateTime = parent.UpdateTime;

            CreateName = users.FirstOrDefault(x => x.Id == parent.CreateId)?.CnName;
            UpdateName = users.FirstOrDefault(x => x.Id == parent.UpdateId)?.CnName;
        }
    }
}
