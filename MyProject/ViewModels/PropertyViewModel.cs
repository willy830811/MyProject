using MyProject.Models;
using MyProject.Models.Items;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MyProject.ViewModels
{
    public class PropertyViewModel : Property
    {
        [Display(Name = "創建者")]
        public string? CreateName { get; set; }

        [Display(Name = "更新者")]
        public string? UpdateName { get; set; }

        public PropertyViewModel()
        {
        }

        public PropertyViewModel(Property parent, List<ApplicationUser> users)
        {
            Id = parent.Id;
            LetterNumber = parent.LetterNumber;
            SellingPrice = parent.SellingPrice;
            CaseName = parent.CaseName;
            Address = parent.Address;
            PropertyType = parent.PropertyType;
            OtherPropertyType = parent.OtherPropertyType;
            Use = parent.Use;
            OtherUse = parent.OtherUse;
            TotalArea = parent.TotalArea;
            MainArea = parent.MainArea;
            AttachedArea = parent.AttachedArea;
            SharedArea = parent.SharedArea;
            OtherArea = parent.OtherArea;
            OtherAreaDefine = parent.OtherAreaDefine;
            SettingPrice = parent.SettingPrice;
            HoldArea = parent.HoldArea;
            LandSection = parent.LandSection;
            BuildingFinishedDate = parent.BuildingFinishedDate;
            UnitPrice = parent.UnitPrice;
            Decorate = parent.Decorate;
            GasFacility = parent.GasFacility;
            Balcony = parent.Balcony;
            BuildingName = parent.BuildingName;
            UpperGroundFloors = parent.UpperGroundFloors;
            UnderGroundFloors = parent.UnderGroundFloors;
            SitDirection = parent.SitDirection;
            FaceDirection = parent.FaceDirection;
            RoadWidth = parent.RoadWidth;
            LightingFace = parent.LightingFace;
            RoomCounts = parent.RoomCounts;
            HallCounts = parent.HallCounts;
            ToliteCounts = parent.ToliteCounts;
            NeiborCounts = parent.NeiborCounts;
            ElevatorCounts = parent.ElevatorCounts;
            ElementarySchool = parent.ElementarySchool;
            JuniorHighSchool = parent.JuniorHighSchool;
            Park = parent.Park;
            Market = parent.Market;
            BusStation = parent.BusStation;
            MRTStation = parent.MRTStation;
            Status = parent.Status;
            Rent = parent.Rent;
            RentPeriodFrom = parent.RentPeriodFrom;
            RentPeriodTo = parent.RentPeriodTo;
            MainMaterial = parent.MainMaterial;
            OtherMainMaterial = parent.OtherMainMaterial;
            OutsideMaterial = parent.OutsideMaterial;
            OtherOutsideMaterial = parent.OtherOutsideMaterial;
            Courtyard = parent.Courtyard;
            Guard = parent.Guard;
            ManagementFee = parent.ManagementFee;
            Parking = parent.Parking;
            ParkingArea = parent.ParkingArea;
            Floor = parent.Floor;
            Number = parent.Number;
            ParkingFee = parent.ParkingFee;
            ParkingPrice = parent.ParkingPrice;
            ParkingEntrance = parent.ParkingEntrance;
            ParkingType = parent.ParkingType;
            BringingType = parent.BringingType;
            GiftPillar = parent.GiftPillar;
            GiftWallCabinet = parent.GiftWallCabinet;
            GiftLiquorCabinet = parent.GiftLiquorCabinet;
            GiftPhone = parent.GiftPhone;
            GiftSofa = parent.GiftSofa;
            GiftHeater = parent.GiftHeater;
            GiftBedding = parent.GiftBedding;
            GiftCooker = parent.GiftCooker;
            GiftGas = parent.GiftGas;
            GiftTV = parent.GiftTV;
            GiftFridge = parent.GiftFridge;
            GiftAirCon = parent.GiftAirCon;
            GiftOther = parent.GiftOther;
            Feature = parent.Feature;
            Note = parent.Note;
            Leader = parent.Leader;
            Manager = parent.Manager;
            Sales = parent.Sales;
            Phone = parent.Phone;
            CaseNumber = parent.CaseNumber;

            CreateTime = parent.CreateTime;
            CreateId = parent.CreateId;
            UpdateTime = parent.UpdateTime;
            CreateName = users.FirstOrDefault(x => x.Id == parent.CreateId)?.CnName;
            UpdateName = users.FirstOrDefault(x => x.Id == parent.UpdateId)?.CnName;
        }
    }
}
