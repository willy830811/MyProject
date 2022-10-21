using MyProject.Models.Items;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MyProject.Models
{
    public class CaseSource
    {
        public int Id { get; set; }

        [Display(Name = "案名")]
        public string? CaseName { get; set; }

        [Display(Name = "總價")]
        public float? TotalPrice { get; set; }

        [Display(Name = "單價")]
        public float? UnitPrice { get; set; }

        [Display(Name = "大地段")]
        public string? Section { get; set; }

        [Display(Name = "小地段")]
        public string? Subsection { get; set; }

        [Display(Name = "地號")]
        public string? PlaceNumber { get; set; }

        [Display(Name = "土地筆數")]
        public int? LandCount { get; set; }

        [Display(Name = "總面積(平方公尺)")]
        public float? TotalAreaInSquareMeter { get; set; }

        [Display(Name = "總面積(坪)")]
        public float? TotalAreaInPing { get; set; }

        [Display(Name = "建蔽率")]
        public float? BuildRate { get; set; }

        [Display(Name = "容積率")]
        public float? VolumeRate { get; set; }

        [Display(Name = "持分")]
        public string? Hold { get; set; }

        [Display(Name = "出售面積(平方公尺)")]
        public float? SellingAreaInSquareMeter { get; set; }

        [Display(Name = "出售面積(坪)")]
        public float? SellingAreaInPing { get; set; }

        [Display(Name = "使用分區")]
        public string? UseSection { get; set; }

        [Display(Name = "使用狀況")]
        public string? UseStatus { get; set; }

        [Display(Name = "環境介紹")]
        public string? Environment { get; set; }

        [Display(Name = "物件特色／優勢")]
        public string? Feature { get; set; }

        [Display(Name = "地籍圖(Y/N)")]
        public bool IsCadastralMap { get; set; } = false;

        [Display(Name = "空照圖(Y/N)")]
        public bool IsAerialPhoto { get; set; } = false;

        [Display(Name = "謄本(Y/N)")]
        public bool IsTranscript { get; set; } = false;

        [Display(Name = "使用分區(Y/N)")]
        public bool IsUseSection { get; set; } = false;

        [Display(Name = "都市計畫圖(Y/N)")]
        public bool IsUrbanPlanningManual { get; set; } = false;

        [Display(Name = "現況照片(Y/N)")]
        public bool IsCurrentPhotos { get; set; } = false;

        [Display(Name = "增值稅概算")]
        public float? ValueAddedTax { get; set; }

        [Display(Name = "其他")]
        public string? Other { get; set; }

        [Display(Name = "經紀人姓名")]
        public string? Agent { get; set; }

        [Display(Name = "經紀人電話")]
        public string? Phone { get; set; }

        [Display(Name = "創建時間")]
        public DateTime? CreateTime { get; set; }

        [Display(Name = "創建者")]
        public string? CreateId { get; set; }

        [Display(Name = "更新時間")]
        public DateTime? UpdateTime { get; set; }

        [Display(Name = "更新者")]
        public string? UpdateId { get; set; }

        [Display(Name = "土地清冊")]
        public string? LandInventories { get; set; }

        [Display(Name = "附件")]
        public List<AppendixItem>? AppendixItems { get; set; }
    }
}
