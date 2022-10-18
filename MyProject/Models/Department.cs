using System.ComponentModel.DataAnnotations;

namespace MyProject.Models
{
    public class Department
    {
        public int Id { get; set; }

        [Display(Name = "部門名稱")]
        public string? Name { get; set; }

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
