using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MyProject.Models.Items
{
    public class RealEstateDetailAppendixItem
    {
        public int Id { get; set; }
        public int RealEstateDetailId { get; set; }

        [Display(Name = "附件名稱")]
        public string? Name { get; set; }

        [Display(Name = "附件種類")]
        public AppendixType? AppendixType { get; set; }

        [Display(Name = "格式")]
        public string? Format { get; set; }
        public string? Base64 { get; set; }
        public RealEstateDetail? RealEstateDetail { get; set; }
    }
}
