using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MyProject.Models.Items
{
    public class LandInventoryItem
    {
        [Display(Name = "地段名")]
        public string? SectionName { get; set; }

        [Display(Name = "地號")]
        public string? PlaceNumber { get; set; }

        [Display(Name = "總面積（平方公尺）")]
        public float? AreaInSquareMeter { get; set; }

        [Display(Name = "總面積（坪）")]
        public float? AreaInPing { get; set; }

        [Display(Name = "持分")]
        public string? Hold { get; set; }

        [Display(Name = "持分（平方公尺）")]
        public float? HoldAreaInSquareMeter { get; set; }

        [Display(Name = "持分（坪）")]
        public float? HoldAreaInPing { get; set; }

        [Display(Name = "公告現值（平方公尺）")]
        public float? PresentValue { get; set; }

        [Display(Name = "使用分區")]
        public string? UseSection { get; set; }

        [Display(Name = "備註")]
        public string? Note { get; set; }
        public CaseSource? CaseSource { get; set; }
    }
}
