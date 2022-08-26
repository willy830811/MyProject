using MyProject.Models.Enum;
using System.ComponentModel.DataAnnotations;

namespace MyProject.Models
{
    public class House
    {
        public int Id { get; set; }
        public string? City { get; set; }
        public string? Region { get; set; }
        public string? Section { get; set; }
        public string? Subsection { get; set; }
        public string? Number { get; set; }
        public int RegisterReason { get; set; }
        public int Order { get; set; }
        public float Area { get; set; }
        public int ShareNumerator { get; set; }
        public int ShareDenominator { get; set; }
        public string? OwnerId { get; set; }
        public DateTime RegisterTime { get; set; }
        public DateTime CreateTime { get; set; }
        public string? CreateId { get; set; }
        public DateTime UpdateTime { get; set; }
        public string? UpdateId { get; set; }
    }
}
