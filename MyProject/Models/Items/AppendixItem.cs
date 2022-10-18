namespace MyProject.Models.Items
{
    public class AppendixItem
    {
        public int Id { get; set; }
        public int CaseSourceId { get; set; }
        public string? Name { get; set; }
        public string? Format { get; set; }
        public string? Base64 { get; set; }
        public CaseSource? CaseSource { get; set; }
    }
}
