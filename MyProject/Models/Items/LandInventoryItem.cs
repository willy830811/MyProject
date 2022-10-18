namespace MyProject.Models.Items
{
    public class LandInventoryItem
    {
        public string? SectionName { get; set; }
        public string? PlaceNumber { get; set; }
        public float? AreaInSquareMeter { get; set; }
        public float? AreaInPing { get; set; }
        public string? Hold { get; set; }
        public float? HoldAreaInSquareMeter { get; set; }
        public float? HoldAreaInPing { get; set; }
        public float? PresentValue { get; set; }
        public string? UseSection { get; set; }
        public string? Note { get; set; }
        public CaseSource? CaseSource { get; set; }
    }
}
