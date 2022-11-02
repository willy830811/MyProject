using MyProject.Models;
using System.ComponentModel.DataAnnotations;

namespace MyProject.ViewModels
{
    public class HouseViewModel : House
    {
        [Display(Name = "所有權人")]
        public string? OwnerName { get; set; }

        [Display(Name = "關係")]
        public string? OwnerRelationship { get; set; }

        [Display(Name = "身分證字號")]
        public string? OwnerIdNumber { get; set; }

        [Display(Name = "電話")]
        public string? OwnerTelephone { get; set; }

        [Display(Name = "手機")]
        public string? OwnerPhone { get; set; }

        [Display(Name = "戶籍地址")]
        public string? OwnerResidence { get; set; }
        
        [Display(Name = "創建者")]
        public string? CreateName { get; set; }

        [Display(Name = "更新者")]
        public string? UpdateName { get; set; }

        public HouseViewModel(House parent, List<ApplicationUser> users, Owner? owner)
        {
            Id = parent.Id;
            City = parent.City;
            Region = parent.Region;
            Section = parent.Section;
            Subsection = parent.Subsection;
            Number = parent.Number;
            RegisterReason = parent.RegisterReason;
            Order = parent.Order;
            Area = parent.Area;
            ShareNumerator = parent.ShareNumerator;
            ShareDenominator = parent.ShareDenominator;
            OwnerId = parent.OwnerId;
            OwnerName = owner?.Name;
            OwnerRelationship = owner?.Relationship;
            OwnerIdNumber = owner?.IdNumber;
            OwnerTelephone = owner?.Telephone;
            OwnerPhone = owner?.Phone;
            OwnerResidence = owner?.Residence;
            RegisterTime = parent.RegisterTime;
            CreateTime = parent.CreateTime;
            UpdateTime = parent.UpdateTime;

            CreateName = users.FirstOrDefault(x => x.Id == parent.CreateId)?.CnName;
            UpdateName = users.FirstOrDefault(x => x.Id == parent.UpdateId)?.CnName;
        }
    }
}
