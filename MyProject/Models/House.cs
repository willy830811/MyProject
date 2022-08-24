using System.ComponentModel.DataAnnotations;

namespace MyProject.Models
{
    public class House
    {
        public int Id { get; set; }
        public string? City { get; set; }
        public string? Region { get; set; }
        public string? Section { get; set; }
        public string? Number { get; set; }
        public int RegisterReason { get; set; }
        public int Order { get; set; }
        public float Area { get; set; }
        public int Share { get; set; }
        public int OwnerId { get; set; }

        [DataType(DataType.Date)]
        public DateTime RegisterTime { get; set; }

        [DataType(DataType.Date)]
        public DateTime CreateTime { get; set; }

        public int CreateId { get; set; }
        [DataType(DataType.Date)]
        public DateTime UpdateTime { get; set; }

        public int UpdateId { get; set; }
    }
}
