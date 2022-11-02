using MyProject.Models;
using MyProject.Models.Items;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MyProject.ViewModels
{
    public class CaseSourceLandInventoryItemsViewModel : CaseSource
    {
        [Display(Name = "創建者")]
        public string? CreateName { get; set; }

        [Display(Name = "更新者")]
        public string? UpdateName { get; set; }

        public List<LandInventoryItem>? LandInventoryItems { get; set; }

        public CaseSourceLandInventoryItemsViewModel()
        {
        }

        public CaseSourceLandInventoryItemsViewModel(CaseSource parent, List<ApplicationUser> users)
        {
            Id = parent.Id;
            CaseName = parent.CaseName;
            TotalPrice = parent.TotalPrice;
            UnitPrice = parent.UnitPrice;
            Section = parent.Section;
            Subsection = parent.Subsection;
            PlaceNumber = parent.PlaceNumber;
            LandCount = parent.LandCount;
            TotalAreaInSquareMeter = parent.TotalAreaInSquareMeter;
            TotalAreaInPing = parent.TotalAreaInPing;
            BuildRate = parent.BuildRate;
            VolumeRate = parent.VolumeRate;
            Hold = parent.Hold;
            SellingAreaInSquareMeter = parent.SellingAreaInSquareMeter;
            SellingAreaInPing = parent.SellingAreaInPing;
            UseSection = parent.UseSection;
            UseStatus = parent.UseStatus;
            Environment = parent.Environment;
            Feature = parent.Feature;
            IsCadastralMap = parent.IsCadastralMap;
            IsAerialPhoto = parent.IsAerialPhoto;
            IsTranscript = parent.IsTranscript;
            IsUseSection = parent.IsUseSection;
            IsUrbanPlanningManual = parent.IsUrbanPlanningManual;
            IsCurrentPhotos = parent.IsCurrentPhotos;
            ValueAddedTax = parent.ValueAddedTax;
            Other = parent.Other;
            Agent = parent.Agent;
            Phone = parent.Phone;
            LandInventoryItems = parent.LandInventories is not null ? JsonConvert.DeserializeObject<List<LandInventoryItem>>(parent.LandInventories) : null;
            AppendixItems = parent.AppendixItems;

            CreateTime = parent.CreateTime;
            CreateId = parent.CreateId;
            UpdateTime = parent.UpdateTime;
            CreateName = users.FirstOrDefault(x => x.Id == parent.CreateId)?.CnName;
            UpdateName = users.FirstOrDefault(x => x.Id == parent.UpdateId)?.CnName;
        }
    }
}
