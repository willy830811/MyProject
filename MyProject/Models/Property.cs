using System.ComponentModel.DataAnnotations;

namespace MyProject.Models
{
    public class Property
    {
        public int Id { get; set; }

        [Display(Name = "委託書編號")]
        public string? LetterNumber { get; set; }

        [Display(Name = "售價")]
        public float? SellingPrice { get; set; }

        [Display(Name = "案名")]
        public string? CaseName { get; set; }

        [Display(Name = "地址/地號")]
        public string? Address { get; set; }

        [Display(Name = "屬性")]
        public PropertyType? PropertyType { get; set; }

        [Display(Name = "屬性(其他)")]
        public string? OtherPropertyType { get; set; }

        [Display(Name = "主要用途")]
        public Use? Use { get; set; }

        [Display(Name = "主要用途(其他)")]
        public string? OtherUse { get; set; }

        [Display(Name = "權狀坪數")]
        public float? TotalArea { get; set; }

        [Display(Name = "主建物坪數")]
        public float? MainArea { get; set; }

        [Display(Name = "附屬建物坪數")]
        public float? AttachedArea { get; set; }

        [Display(Name = "共有部份坪數")]
        public float? SharedArea { get; set; }

        [Display(Name = "其它坪數")]
        public float? OtherArea { get; set; }

        [Display(Name = "其它坪數定義")]
        public string? OtherAreaDefine { get; set; }

        [Display(Name = "設定金額")]
        public float? SettingPrice { get; set; }

        [Display(Name = "土地持分")]
        public float? HoldArea { get; set; }

        [Display(Name = "土地分區")]
        public string? LandSection { get; set; }

        [Display(Name = "建築完成日")]
        public DateTime? BuildingFinishedDate { get; set; }

        [Display(Name = "單價")]
        public float? UnitPrice { get; set; }

        [Display(Name = "裝潢")]
        public string? Decorate { get; set; }

        [Display(Name = "瓦斯設備")]
        public string? GasFacility { get; set; }

        [Display(Name = "陽台")]
        public string? Balcony { get; set; }

        [Display(Name = "大樓名稱")]
        public string? BuildingName { get; set; }

        [Display(Name = "地上層")]
        public int? UpperGroundFloors { get; set; }

        [Display(Name = "地下層")]
        public int? UnderGroundFloors { get; set; }

        [Display(Name = "座向(座)")]
        public string? SitDirection { get; set; }

        [Display(Name = "座向(朝)")]
        public string? FaceDirection { get; set; }

        [Display(Name = "路(巷)寬")]
        public string? RoadWidth { get; set; }

        [Display(Name = "採光面")]
        public string? LightingFace { get; set; }

        [Display(Name = "隔局(房數)")]
        public int? RoomCounts { get; set; }

        [Display(Name = "隔局(廳數)")]
        public int? HallCounts { get; set; }

        [Display(Name = "隔局(廁數)")]
        public int? ToliteCounts { get; set; }

        [Display(Name = "同層戶")]
        public int? NeiborCounts { get; set; }

        [Display(Name = "電梯數")]
        public int? ElevatorCounts  { get; set; }

        [Display(Name = "學校(國小)")]
        public string? ElementarySchool { get; set; }

        [Display(Name = "學校(國中)")]
        public string? JuniorHighSchool { get; set; }

        [Display(Name = "公園")]
        public string? Park { get; set; }

        [Display(Name = "商圈/市場")]
        public string? Market { get; set; }

        [Display(Name = "交通(公車)")]
        public string? BusStation { get; set; }

        [Display(Name = "交通(捷運)")]
        public string? MRTStation { get; set; }

        [Display(Name = "現況")]
        public Status? Status { get; set; }

        [Display(Name = "租金")]
        public float? Rent { get; set; }

        [Display(Name = "租賃期間(起)")]
        public DateTime? RentPeriodFrom { get; set; }

        [Display(Name = "租賃期間(止)")]
        public DateTime? RentPeriodTo { get; set; }

        [Display(Name = "主要建材")]
        public MainMaterial? MainMaterial { get; set; }

        [Display(Name = "主要建材(其他)")]
        public string? OtherMainMaterial { get; set; }

        [Display(Name = "外牆建材")]
        public OutsideMaterial? OutsideMaterial { get; set; }

        [Display(Name = "外牆建材(其他)")]
        public string? OtherOutsideMaterial { get; set; }

        [Display(Name = "(有/無)中庭")]
        public bool Courtyard { get; set; } = false;

        [Display(Name = "(有/無)警衛管理")]
        public bool Guard { get; set; } = false;

        [Display(Name = "管理費")]
        public float? ManagementFee { get; set; }

        [Display(Name = "(有/無)車位")]
        public bool Parking { get; set; } = false;

        [Display(Name = "車位坪數")]
        public float? ParkingArea { get; set; }

        [Display(Name = "編號(樓)")]
        public string? Floor { get; set; }

        [Display(Name = "編號(號)")]
        public string? Number { get; set; }

        [Display(Name = "車位管理費")]
        public float? ParkingFee { get; set; }

        [Display(Name = "車價約")]
        public float? ParkingPrice { get; set; }

        [Display(Name = "入口")]
        public ParkingEntrance? ParkingEntrance { get; set; }

        [Display(Name = "內部")]
        public ParkingType? ParkingType { get; set; }

        [Display(Name = "帶看方式")]
        public BringingType? BringingType { get; set; }

        [Display(Name = "附贈設備(固定物)?")]
        public bool GiftPillar { get; set; } = false;

        [Display(Name = "附贈設備(壁櫃)?")]
        public bool GiftWallCabinet { get; set; } = false;

        [Display(Name = "附贈設備(酒櫃)?")]
        public bool GiftLiquorCabinet { get; set; } = false;

        [Display(Name = "附贈設備(電話)?")]
        public bool GiftPhone { get; set; } = false;

        [Display(Name = "附贈設備(沙發組)?")]
        public bool GiftSofa { get; set; } = false;

        [Display(Name = "附贈設備(熱水器)?")]
        public bool GiftHeater { get; set; } = false;

        [Display(Name = "附贈設備(床組)?")]
        public bool GiftBedding { get; set; } = false;

        [Display(Name = "附贈設備(廚具組)?")]
        public bool GiftCooker { get; set; } = false;

        [Display(Name = "附贈設備(天然瓦斯)?")]
        public bool GiftGas { get; set; } = false;

        [Display(Name = "附贈設備(電視)(數量)")]
        public int? GiftTV { get; set; }

        [Display(Name = "附贈設備(冰箱)(數量)")]
        public int? GiftFridge { get; set; }

        [Display(Name = "附贈設備(冷氣)(數量)")]
        public int? GiftAirCon { get; set; }

        [Display(Name = "附贈設備(其他)")]
        public string? GiftOther { get; set; }

        [Display(Name = "特色說明")]
        public string? Feature { get; set; }

        [Display(Name = "備註")]
        public string? Note { get; set; }

        [Display(Name = "組長")]
        public string? Leader { get; set; }

        [Display(Name = "經紀人")]
        public string? Manager { get; set; }

        [Display(Name = "營業員")]
        public string? Sales { get; set; }

        [Display(Name = "電話")]
        public string? Phone { get; set; }

        [Display(Name = "物件編號")]
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
