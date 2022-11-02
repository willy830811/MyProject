using MyProject.Models;
using System.ComponentModel.DataAnnotations;

namespace MyProject.ViewModels
{
    public class CaseSourceViewModel : CaseSource
    {
        [Display(Name = "創建者")]
        public string? CreateName { get; set; }

        [Display(Name = "更新者")]
        public string? UpdateName { get; set; }

        public CaseSourceViewModel(CaseSource parent, List<ApplicationUser> users)
        {
            Id = parent.Id;
            CaseName = parent.CaseName;
            TotalPrice = parent.TotalPrice;
            UnitPrice = parent.UnitPrice;
            Section = parent.Section;
            Subsection = parent.Subsection;
            LandCount = parent.LandCount;
            Agent = parent.Agent;
            Phone = parent.Phone;
            CreateTime = parent.CreateTime;
            UpdateTime = parent.UpdateTime;

            CreateName = users.FirstOrDefault(x => x.Id == parent.CreateId)?.CnName;
            UpdateName = users.FirstOrDefault(x => x.Id == parent.UpdateId)?.CnName;
        }
    }
}
