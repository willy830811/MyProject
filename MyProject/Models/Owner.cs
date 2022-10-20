using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MyProject.Models
{
    public class Owner
    {
        public int Id { get; set; }

        [Display(Name = "所有權人")]
        public string? Name { get; set; }

        [Display(Name = "關係")]
        public string? Relationship { get; set; }

        [Display(Name = "身分證字號")]
        public string? IdNumber { get; set; }

        [Display(Name = "電話")]
        public string? Telephone { get; set; }

        [Display(Name = "手機")]
        public string? Phone { get; set; }

        [Display(Name = "戶籍地址")]
        public string? Residence { get; set; }

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
