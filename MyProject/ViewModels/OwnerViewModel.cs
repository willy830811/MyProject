using MyProject.Models;
using System.ComponentModel.DataAnnotations;
using System.Security.Policy;
using System.Xml.Linq;

namespace MyProject.ViewModels
{
    public class OwnerViewModel : Owner
    {
        [Display(Name = "創建者")]
        public string? CreateName { get; set; }

        [Display(Name = "更新者")]
        public string? UpdateName { get; set; }

        public string? ErrMsg { get; set; }

        public OwnerViewModel(Owner parent, List<ApplicationUser> users, string? errMsg)
        {
            Id = parent.Id;
            Name = parent.Name;
            Relationship = parent.Relationship;
            IdNumber = parent.IdNumber;
            Telephone = parent.Telephone;
            Phone = parent.Phone;
            Residence = parent.Residence;
            CreateTime = parent.CreateTime;
            UpdateTime = parent.UpdateTime;

            CreateName = users.FirstOrDefault(x => x.Id == parent.CreateId)?.CnName;
            UpdateName = users.FirstOrDefault(x => x.Id == parent.UpdateId)?.CnName;

            ErrMsg = errMsg;
        }
    }
}
