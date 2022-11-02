using MyProject.Models;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;

namespace MyProject.ViewModels
{
    //public class MultipleChoiceItem
    //{
    //    public int Index { get; set; }
    //    public string Name { get; set; }
    //    public bool Selected { get; set; }
    //}

    public class RealEstateDetailViewModel : RealEstateDetail
    {
        [Display(Name = "創建者")]
        public string? CreateName { get; set; }

        [Display(Name = "更新者")]
        public string? UpdateName { get; set; }

        //public List<MultipleChoiceItem> OtherRightsTypeMulti { get; set; }
        //public string[] OtherRightsTypeArr { get; set; }

        //public string OtherRightsTypeStr
        //{
        //    get { return String.Join(',', OtherRightsTypeArr); }
        //    set { OtherRightsTypeArr = null; }
        //}

        public OtherRightsType[]? OtherRightsTypes { get; set; }
        public OtherRightsType[]? SettingOtherRightsTypes { get; set; }
        public RestrictingRegistrationType[]? RestrictingRegistrationTypes { get; set; }
        public RespectivelyManageBy826Type[]? RespectivelyManageBy826Types { get; set; }
        public DevelopMethodRestrictionsType[]? DevelopMethodRestrictionsTypes { get; set; }
        public BuildFarmhouseType[]? BuildFarmhouseTypes { get; set; }
        public NationalParkType[]? NationalParkTypes { get; set; }
        public DrinkingWaterSourceType[]? DrinkingWaterSourceTypes { get; set; }
        public PolutedAreaType[]? PolutedAreaTypes { get; set; }
        public ChooseManageType[]? ChooseManageTypes { get; set; }
        public SurroundingsAppendiceType[]? SurroundingsAppendiceTypes { get; set; }
        public Surroundings[]? Surroundingss { get; set; }

        public RealEstateDetailViewModel()
        {
        }

        public RealEstateDetailViewModel(RealEstateDetail parent, List<ApplicationUser> users)
        {
            Id = parent.Id;
            ObjectName = parent.ObjectName;
            City = parent.City;
            Region = parent.Region;
            Section = parent.Section;
            Subsection = parent.Subsection;
            PlaceNumber = parent.PlaceNumber;
            Area = parent.Area;
            RightsScope = parent.RightsScope;
            AppendicesNames = parent.AppendicesNames;
            IsLandOwner = parent.IsLandOwner;
            LandOwner = parent.LandOwner;
            IsOtherObligee = parent.IsOtherObligee;
            OtherObligee = parent.OtherObligee;
            IsRegisteredManager = parent.IsRegisteredManager;
            RegisteredManager = parent.RegisteredManager;
            IsOwnership = parent.IsOwnership;
            OwnershipType = parent.OwnershipType;
            IsOtherRights = parent.IsOtherRights;
            OtherRightsType = parent.OtherRightsType;
            IsTrust = parent.IsTrust;
            TrustContent = parent.TrustContent;
            IsBaseRightsSettingBurden = parent.IsBaseRightsSettingBurden;
            BaseRightsSettingBurdenStatus = parent.BaseRightsSettingBurdenStatus;
            IsSettingOtherRights = parent.IsSettingOtherRights;
            SettingOtherRightsType = parent.SettingOtherRightsType;
            IsRestrictingRegistration = parent.IsRestrictingRegistration;
            RestrictingRegistrationType = parent.RestrictingRegistrationType;
            OtherRestrictingRegistration = parent.OtherRestrictingRegistration;
            IsOtherBaseRightsItemBy254 = parent.IsOtherBaseRightsItemBy254;
            OtherBaseRightsItemBy254 = parent.OtherBaseRightsItemBy254;
            IsOtherBaseRightsItemRelated = parent.IsOtherBaseRightsItemRelated;
            OtherBaseRightsItemRelated = parent.OtherBaseRightsItemRelated;
            IsUseByConvention = parent.IsUseByConvention;
            UseByConventionContent = parent.UseByConventionContent;
            IsRespectivelyManage = parent.IsRespectivelyManage;
            IsRespectivelyManageBy826 = parent.IsRespectivelyManageBy826;
            RespectivelyManageBy826Type = parent.RespectivelyManageBy826Type;
            RespectivelyManageBy826Content = parent.RespectivelyManageBy826Content;
            IsRent = parent.IsRent;
            IsLend = parent.IsLend;
            RentLendStatus = parent.RentLendStatus;
            IsOccupiedWithoutRights = parent.IsOccupiedWithoutRights;
            OccupiedWithoutRightsStatus = parent.OccupiedWithoutRightsStatus;
            IsPublicWay = parent.IsPublicWay;
            PublicWayPlaceAppendice = parent.PublicWayPlaceAppendice;
            PublicWayArea = parent.PublicWayArea;
            UrbanLandSection = parent.UrbanLandSection;
            NonUrbanLandSection = parent.NonUrbanLandSection;
            NonUrbanLandType = parent.NonUrbanLandType;
            UnKnownLandRegulationStatus = parent.UnKnownLandRegulationStatus;
            BuildRate = parent.BuildRate;
            VolumeRate = parent.VolumeRate;
            IsUrbanPlanningManual = parent.IsUrbanPlanningManual;
            DevelopMethodRestrictionsType = parent.DevelopMethodRestrictionsType;
            OtherDevelopMethodRestriction = parent.OtherDevelopMethodRestriction;
            IsBuildingRestrictedRegion = parent.IsBuildingRestrictedRegion;
            IsFarmLand = parent.IsFarmLand;
            BuildFarmhouseType = parent.BuildFarmhouseType;
            FarmLandRegulation = parent.FarmLandRegulation;
            IsMountLand = parent.IsMountLand;
            MountLandRestrictions = parent.MountLandRestrictions;
            IsBanningBuildByKeepSoilLaw = parent.IsBanningBuildByKeepSoilLaw;
            BanningBuildByKeepSoilLawRestrictions = parent.BanningBuildByKeepSoilLawRestrictions;
            IsRiverRegion = parent.IsRiverRegion;
            RiverRegionRestrictions = parent.RiverRegionRestrictions;
            IsDrainFacilityRegion = parent.IsDrainFacilityRegion;
            DrainFacilityRegionRestrictions = parent.DrainFacilityRegionRestrictions;
            IsNationalPark = parent.IsNationalPark;
            NationalParkType = parent.NationalParkType;
            NationalParkRestrictions = parent.NationalParkRestrictions;
            IsDrinkingWaterSource = parent.IsDrinkingWaterSource;
            DrinkingWaterSourceType = parent.DrinkingWaterSourceType;
            DrinkingWaterSourceRestrictions = parent.DrinkingWaterSourceRestrictions;
            IsWaterProtectionAreaByLaw = parent.IsWaterProtectionAreaByLaw;
            WaterProtectionAreaByLawRestrictions = parent.WaterProtectionAreaByLawRestrictions;
            IsPolutedArea = parent.IsPolutedArea;
            PolutedAreaType = parent.PolutedAreaType;
            PolutedAreaRestrictions = parent.PolutedAreaRestrictions;
            TransactionType = parent.TransactionType;
            TransactionPrice = parent.TransactionPrice;
            PaymentMethod = parent.PaymentMethod;
            IsLandValueAddedTax = parent.IsLandValueAddedTax;
            LandValueAddedTax = parent.LandValueAddedTax;
            IsLandTax = parent.IsLandTax;
            LandTax = parent.LandTax;
            IsStampDuty = parent.IsStampDuty;
            StampDuty = parent.StampDuty;
            IsOtherTax = parent.IsOtherTax;
            OtherTax = parent.OtherTax;
            IsConstructionBenefitFee = parent.IsConstructionBenefitFee;
            ConstructionBenefitFee = parent.ConstructionBenefitFee;
            IsRegistrationFee = parent.IsRegistrationFee;
            RegistrationFee = parent.RegistrationFee;
            IsSurveyFee = parent.IsSurveyFee;
            SurveyFee = parent.SurveyFee;
            IsOtherProcessingFee = parent.IsOtherProcessingFee;
            OtherProcessingFee = parent.OtherProcessingFee;
            IsContractFee = parent.IsContractFee;
            ContractFee = parent.ContractFee;
            IsOwnershipTransferAgencyFee = parent.IsOwnershipTransferAgencyFee;
            OwnershipTransferAgencyFee = parent.OwnershipTransferAgencyFee;
            IsOtherFee = parent.IsOtherFee;
            OtherFee = parent.OtherFee;
            ChooseManageType = parent.ChooseManageType;
            ManageMethod = parent.ManageMethod;
            IsBreachOfContractPunishment = parent.IsBreachOfContractPunishment;
            BreachOfContractPunishment = parent.BreachOfContractPunishment;
            OtherTransactionItem = parent.OtherTransactionItem;
            SurroundingsAppendiceType = parent.SurroundingsAppendiceType;
            Surroundings = parent.Surroundings;
            IsCadastralMapRetest = parent.IsCadastralMapRetest;
            IsCadastralMapRetestAnnouced = parent.IsCadastralMapRetestAnnouced;
            IsOutOfBoundsBuilding = parent.IsOutOfBoundsBuilding;
            OutOfBoundsBuildingStatus = parent.OutOfBoundsBuildingStatus;
            IsCompulsoryAcquisition = parent.IsCompulsoryAcquisition;
            CompulsoryAcquisitionArea = parent.CompulsoryAcquisitionArea;
            IsElectricityPower = parent.IsElectricityPower;
            IsTapWater = parent.IsTapWater;
            IsGas = parent.IsGas;
            IsDrainer = parent.IsDrainer;
            NonInfrastructureReason = parent.NonInfrastructureReason;
            RealEstateBroker = parent.RealEstateBroker;
            ContractDate = parent.ContractDate;

            //OtherRightsTypeMulti = Enum.GetValues(typeof(OtherRightsType)).Cast<OtherRightsType>().ToList().Select(o => new MultipleChoiceItem() { Index = (int)o, Name = o.ToString(), Selected = Array.Exists(parent.OtherRightsType.Split(',', StringSplitOptions.RemoveEmptyEntries), x => x == ((int)o).ToString()) }).ToList();

            OtherRightsTypes = parent.OtherRightsType.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).Select(o => (OtherRightsType)o).ToArray();
            SettingOtherRightsTypes = parent.SettingOtherRightsType.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).Select(o => (OtherRightsType)o).ToArray();
            RestrictingRegistrationTypes = parent.RestrictingRegistrationType.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).Select(o => (RestrictingRegistrationType)o).ToArray();
            RespectivelyManageBy826Types = parent.RespectivelyManageBy826Type.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).Select(o => (RespectivelyManageBy826Type)o).ToArray();
            DevelopMethodRestrictionsTypes = parent.DevelopMethodRestrictionsType.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).Select(o => (DevelopMethodRestrictionsType)o).ToArray();
            BuildFarmhouseTypes = parent.BuildFarmhouseType.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).Select(o => (BuildFarmhouseType)o).ToArray();
            NationalParkTypes = parent.NationalParkType.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).Select(o => (NationalParkType)o).ToArray();
            DrinkingWaterSourceTypes = parent.DrinkingWaterSourceType.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).Select(o => (DrinkingWaterSourceType)o).ToArray();
            PolutedAreaTypes = parent.PolutedAreaType.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).Select(o => (PolutedAreaType)o).ToArray();
            ChooseManageTypes = parent.ChooseManageType.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).Select(o => (ChooseManageType)o).ToArray();
            SurroundingsAppendiceTypes = parent.SurroundingsAppendiceType.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).Select(o => (SurroundingsAppendiceType)o).ToArray();
            Surroundingss = parent.Surroundings.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).Select(o => (Surroundings)o).ToArray();

            CreateTime = parent.CreateTime;
            CreateId = parent.CreateId;
            UpdateTime = parent.UpdateTime;
            CreateName = users.FirstOrDefault(x => x.Id == parent.CreateId)?.CnName;
            UpdateName = users.FirstOrDefault(x => x.Id == parent.UpdateId)?.CnName;
        }
    }
}
