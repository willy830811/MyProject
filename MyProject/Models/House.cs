using MyProject.Models.Enum;
using System.ComponentModel.DataAnnotations;

namespace MyProject.Models
{
    public class House
    {
        public int Id { get; set; }
        [Display(Name = "縣市")]
        public string? City { get; set; }
        [Display(Name = "區域")]
        public string? Region { get; set; }
        [Display(Name = "大地段")]
        public string? Section { get; set; }
        [Display(Name = "小地段")]
        public string? Subsection { get; set; }
        [Display(Name = "地號")]
        public string? Number { get; set; }
        [Display(Name = "登記原因")]
        public int? RegisterReason { get; set; }
        [Display(Name = "次序")]
        public int? Order { get; set; }
        [Display(Name = "面積")]
        public float? Area { get; set; }
        [Display(Name = "權力範圍")]
        public int? ShareNumerator { get; set; }
        [Display(Name = "權力範圍")]
        public int? ShareDenominator { get; set; }
        [Display(Name = "所有權人")]
        public string? OwnerId { get; set; }
        [Display(Name = "登記日期")]
        public DateTime? RegisterTime { get; set; }
        [Display(Name = "創建時間")]
        public DateTime? CreateTime { get; set; }
        [Display(Name = "創建者")]
        public string? CreateId { get; set; }
        [Display(Name = "更新時間")]
        public DateTime? UpdateTime { get; set; }
        [Display(Name = "更新者")]
        public string? UpdateId { get; set; }
    }
}
