using MyProject.Models.Items;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MyProject.Models
{
    public class CaseSource
    {
        public int Id { get; set; }
        public string? CaseName { get; set; }
        public float? TotalPrice { get; set; }
        public float? UnitPrice { get; set; }
        public string? Section { get; set; }
        public string? Subsection { get; set; }
        public string? PlaceNumber { get; set; }
        public int? LandCount { get; set; }
        public float? TotalAreaInSquareMeter { get; set; }
        public float? TotalAreaInPing { get; set; }
        public float? BuildRate { get; set; }
        public float? VolumeRate { get; set; }
        public string? Hold { get; set; }
        public float? SellingAreaInSquareMeter { get; set; }
        public float? SellingAreaInPing { get; set; }
        public string? UseSection { get; set; }
        public string? UseStatus { get; set; }
        public string? Environment { get; set; }
        public string? Feature { get; set; }
        public bool? IsCadastralMap { get; set; }
        public bool? IsAerialPhoto { get; set; }
        public bool? IsTranscript { get; set; }
        public bool? IsUseSection { get; set; }
        public bool? IsUrbanPlanningManual { get; set; }
        public bool? IsCurrentPhotos { get; set; }
        public float? ValueAddedTax { get; set; }
        public string? Other { get; set; }
        public string? Agent { get; set; }
        public string? Phone { get; set; }

        [Display(Name = "創建時間")]
        public DateTime? CreateTime { get; set; }

        [Display(Name = "創建者")]
        public string? CreateId { get; set; }

        [Display(Name = "更新時間")]
        public DateTime? UpdateTime { get; set; }

        [Display(Name = "更新者")]
        public string? UpdateId { get; set; }
        public string? LandInventories { get; set; }
        public List<AppendixItem>? AppendixItems { get; set; }
    }
}
