using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MyProject.Models.Items
{
    public class AppendixItem
    {
        public int Id { get; set; }
        public int CaseSourceId { get; set; }

        [Display(Name = "附件名稱")]
        public string? Name { get; set; }

        [Display(Name = "格式")]
        public string? Format { get; set; }
        public string? Base64 { get; set; }
        public CaseSource? CaseSource { get; set; }
    }
}
