namespace MyProject.Models.Items
{
    public class LandInventoryItem
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? PlaceNumber { get; set; }
        public float? AreaInSquareMeter { get; set; }
        public float? AreaInPing { get; set; }
        public string? Hold { get; set; }
        public float? PresentValue { get; set; }
        public string? UseSection { get; set; }
        public string? Note { get; set; }
    }
}
