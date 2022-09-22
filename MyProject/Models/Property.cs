using System.ComponentModel.DataAnnotations;

namespace MyProject.Models
{
    public class Property
    {
        public int Id { get; set; }
        public string? LetterNumber { get; set; }
        public float? SellingPrice { get; set; }
        public string? CaseName { get; set; }
        public string? Address { get; set; }
        public PropertyType? PropertyType { get; set; }
        public string? OtherPropertyType { get; set; }
        public Use? Use { get; set; }
        public string? OtherUse { get; set; }
        public float? TotalArea { get; set; }
        public float? MainArea { get; set; }
        public float? AttachedArea { get; set; }
        public float? SharedArea { get; set; }
        public float? OtherArea { get; set; }
        public string? OtherAreaDefine { get; set; }
        public float? SettingPrice { get; set; }
        public float? HoldArea { get; set; }
        public string? LandSection { get; set; }
        public DateTime? BuildingFinishedDate { get; set; }
        public float? UnitPrice { get; set; }
        public string? Decorate { get; set; }
        public string? GasFacility { get; set; }
        public string? Balcony { get; set; }
        public string? BuildingName { get; set; }
        public int? UpperGroundFloors { get; set; }
        public int? UnderGroundFloors { get; set; }
        public string? SitDirection { get; set; }
        public string? FaceDirection { get; set; }
        public string? RoadWidth { get; set; }
        public string? LightingFace { get; set; }
        public int? RoomCounts { get; set; }
        public int? HallCounts { get; set; }
        public int? ToliteCounts { get; set; }
        public int? NeiborCounts { get; set; }
        public int? ElevatorCounts  { get; set; }
        public string? ElementarySchool { get; set; }
        public string? JuniorHighSchool { get; set; }
        public string? Park { get; set; }
        public string? Market { get; set; }
        public string? BusStation { get; set; }
        public string? MRTStation { get; set; }
        public Status? Status { get; set; }
        public float? Rent { get; set; }
        public DateTime? RentPeriodFrom { get; set; }
        public DateTime? RentPeriodTo { get; set; }
        public MainMaterial? MainMaterial { get; set; }
        public string? OtherMainMaterial { get; set; }
        public OutsideMaterial? OutsideMaterial { get; set; }
        public string? OtherOutsideMaterial { get; set; }
        public bool? Courtyard { get; set; }
        public bool? Guard { get; set; }
        public float? ManagementFee { get; set; }
        public bool? Parking { get; set; }
        public float? ParkingArea { get; set; }
        public string? Floor { get; set; }
        public string? Number { get; set; }
        public float? ParkingFee { get; set; }
        public float? ParkingPrice { get; set; }
        public ParkingEntrance? ParkingEntrance { get; set; }
        public ParkingType? ParkingType { get; set; }
        public BringingType? BringingType { get; set; }
        public bool? GiftPillar { get; set; }
        public bool? GiftWallCabinet { get; set; }
        public bool? GiftLiquorCabinet { get; set; }
        public bool? GiftPhone { get; set; }
        public bool? GiftSofa { get; set; }
        public bool? GiftHeater { get; set; }
        public bool? GiftBedding { get; set; }
        public bool? GiftCooker { get; set; }
        public bool? GiftGas { get; set; }
        public int? GiftTV { get; set; }
        public int? GiftFridge { get; set; }
        public int? GiftAirCon { get; set; }
        public string? GiftOther { get; set; }
        public string? Feature { get; set; }
        public string? Note { get; set; }
        public string? Leader { get; set; }
        public string? Manager { get; set; }
        public string? Sales { get; set; }
        public string? Phone { get; set; }
        public string? CaseNumber { get; set; }

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
