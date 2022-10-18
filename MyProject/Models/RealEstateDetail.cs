﻿using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;
using System.Xml.Linq;

namespace MyProject.Models
{
    public class RealEstateDetail
    {
        public int Id { get; set; }

        [Display(Name = "物件名稱")]
        public string? ObjectName { get; set; }

        [Display(Name = "縣市")]
        public string? City { get; set; }

        [Display(Name = "區域")]
        public string? Region { get; set; }

        [Display(Name = "大地段")]
        public string? Section { get; set; }

        [Display(Name = "小地段")]
        public string? Subsection { get; set; }

        [Display(Name = "地號")]
        public string? PlaceNumber { get; set; }

        [Display(Name = "面積")]
        public float? Area { get; set; }

        [Display(Name = "權利範圍")]
        public int? RightsScope { get; set; }

        [Display(Name = "附件名稱")]
        public string? AppendicesNames { get; set; }

        [Display(Name = "(Y/N)土地所有權人")]
        public bool? IsLandOwner { get; set; }

        [Display(Name = "土地所有權人")]
        public string? LandOwner { get; set; }

        [Display(Name = "(Y/N)他項權利人")]
        public bool? IsOtherObligee { get; set; }

        [Display(Name = "他項權利人")]
        public string? OtherObligee { get; set; }

        [Display(Name = "(Y/N)登記簿上記載之管理人")]
        public bool? IsRegisteredManager { get; set; }

        [Display(Name = "登記簿上記載之管理人")]
        public string? RegisteredManager { get; set; }

        [Display(Name = "(Y/N)所有權")]
        public bool? IsOwnership { get; set; }

        [Display(Name = "所有權種類")]
        public OwnershipType? OwnershipType { get; set; }

        [Display(Name = "(Y/N)他項權利")]
        public bool? IsOtherRights { get; set; }

        [Display(Name = "他項權利種類")]
        public string? OtherRightsType { get; set; }

        [Display(Name = "(Y/N)信託登記")]
        public bool? IsTrust { get; set; }

        [Display(Name = "信託契約之主要條款內容")]
        public string? TrustContent { get; set; }

        [Display(Name = "(Y/N)基地權利設定負擔")]
        public bool? IsBaseRightsSettingBurden { get; set; }

        [Display(Name = "設定負擔情形")]
        public string? BaseRightsSettingBurdenStatus { get; set; }

        [Display(Name = "(Y/N)他項權利設定")]
        public bool? IsSettingOtherRights { get; set; }

        [Display(Name = "他項權利設定種類")]
        public string? SettingOtherRightsType { get; set; }

        [Display(Name = "(Y/N)限制登記")]
        public bool? IsRestrictingRegistration { get; set; }

        [Display(Name = "限制登記種類")]
        public string? RestrictingRegistrationType { get; set; }

        [Display(Name = "其他限制登記禁止處分")]
        public string? OtherRestrictingRegistration { get; set; }

        [Display(Name = "(Y/N)其他基地權利事項(依民事訴訟法第254條規定註記)")]
        public bool? IsOtherBaseRightsItemBy254 { get; set; }

        [Display(Name = "其他基地權利事項(依民事訴訟法第254條規定註記)")]
        public string? OtherBaseRightsItemBy254 { get; set; }

        [Display(Name = "(Y/N)其他基地權利事項(其他相關註記)")]
        public bool? IsOtherBaseRightsItemRelated { get; set; }

        [Display(Name = "其他基地權利事項(其他相關註記)")]
        public string? OtherBaseRightsItemRelated { get; set; }

        [Display(Name = "(Y/N)依慣例使用之現況")]
        public bool? IsUseByConvention { get; set; }

        [Display(Name = "依慣例使用之現況內容")]
        public string? UseByConventionContent { get; set; }

        [Display(Name = "(Y/N)共有人分管協議")]
        public bool? IsRespectivelyManage { get; set; }

        [Display(Name = "(Y/N)共有人分管協議(依民法第826條之1)")]
        public bool? IsRespectivelyManageBy826 { get; set; }

        [Display(Name = "共有人分管協議(依民法第826條之1)種類")]
        public string? RespectivelyManageBy826Type { get; set; }

        [Display(Name = "共有人分管協議(依民法第826條之1)內容")]
        public string? RespectivelyManageBy826Content { get; set; }

        [Display(Name = "(Y/N)出租")]
        public bool? IsRent { get; set; }

        [Display(Name = "(Y/N)出借")]
        public bool? IsLend { get; set; }

        [Display(Name = "出租/出借情形")]
        public string? RentLendStatus { get; set; }

        [Display(Name = "(Y/N)被他人無權占用")]
        public bool? IsOccupiedWithoutRights { get; set; }

        [Display(Name = "被他人無權占用情形")]
        public string? OccupiedWithoutRightsStatus { get; set; }

        [Display(Name = "(Y/N)供公眾通行之私有道路")]
        public bool? IsPublicWay { get; set; }

        [Display(Name = "供公眾通行之私有道路位置附件")]
        public string? PublicWayPlaceAppendice { get; set; }

        [Display(Name = "供公眾通行之私有道路面積")]
        public float? PublicWayArea { get; set; }

        [Display(Name = "都市土地使用分區")]
        public string? UrbanLandSection { get; set; }

        [Display(Name = "非都市土地使用分區")]
        public string? NonUrbanLandSection { get; set; }

        [Display(Name = "非都市土地使用分區用地編定類別")]
        public string? NonUrbanLandType { get; set; }

        [Display(Name = "未記載土地管制情形")]
        public string? UnKnownLandRegulationStatus { get; set; }

        [Display(Name = "法定建蔽率")]
        public float? BuildRate { get; set; }

        [Display(Name = "法定容積率")]
        public float? VolumeRate { get; set; }

        [Display(Name = "(Y/N)都市計畫說明書")]
        public bool? IsUrbanPlanningManual { get; set; }

        [Display(Name = "開發方式限制")]
        public string? DevelopMethodRestrictionsType { get; set; }

        [Display(Name = "其他開發方式限制")]
        public string? OtherDevelopMethodRestriction { get; set; }

        [Display(Name = "(Y/N)屬都市計畫法規定之禁限建地區")]
        public bool? IsBuildingRestrictedRegion { get; set; }

        [Display(Name = "(Y/N)農業用地")]
        public bool? IsFarmLand { get; set; }

        [Display(Name = "興建農舍")]
        public string? BuildFarmhouseType { get; set; }

        [Display(Name = "農業用地使用管制情形")]
        public string? FarmLandRegulation { get; set; }

        [Display(Name = "(Y/N)山坡地範圍")]
        public bool? IsMountLand { get; set; }

        [Display(Name = "山坡地範圍限制重點")]
        public string? MountLandRestrictions { get; set; }

        [Display(Name = "(Y/N)依水土保持法公告禁止開發之特定水土保持區範圍")]
        public bool? IsBanningBuildByKeepSoilLaw { get; set; }

        [Display(Name = "依水土保持法公告禁止開發之特定水土保持區範圍其限制重點")]
        public string? BanningBuildByKeepSoilLawRestrictions { get; set; }

        [Display(Name = "(Y/N)依水利法劃設公告之河川區域範圍")]
        public bool? IsRiverRegion { get; set; }

        [Display(Name = "依水利法劃設公告之河川區域範圍限制重點")]
        public string? RiverRegionRestrictions { get; set; }

        [Display(Name = "(Y/N)依水利法劃設公告之排水設施範圍")]
        public bool? IsDrainFacilityRegion { get; set; }

        [Display(Name = "依水利法劃設公告之排水設施範圍限制重點")]
        public string? DrainFacilityRegionRestrictions { get; set; }

        [Display(Name = "(Y/N)國家公園區")]
        public bool? IsNationalPark { get; set; }

        [Display(Name = "國家公園區種類")]
        public string? NationalParkType { get; set; }

        [Display(Name = "國家公園區限制重點")]
        public string? NationalParkRestrictions { get; set; }

        [Display(Name = "(Y/N)飲用水管理條例公告區")]
        public bool? IsDrinkingWaterSource { get; set; }

        [Display(Name = "飲用水管理條例公告區")]
        public string? DrinkingWaterSourceType { get; set; }

        [Display(Name = "飲用水管理條例公告區限制重點")]
        public string? DrinkingWaterSourceRestrictions { get; set; }

        [Display(Name = "(Y/N)自來水法規定之水質水量保護區")]
        public bool? IsWaterProtectionAreaByLaw { get; set; }

        [Display(Name = "自來水法規定之水質水量保護區限制重點")]
        public string? WaterProtectionAreaByLawRestrictions { get; set; }

        [Display(Name = "(Y/N)污染場址")]
        public bool? IsPolutedArea { get; set; }

        [Display(Name = "污染場址")]
        public string? PolutedAreaType { get; set; }

        [Display(Name = "污染場址限制重點")]
        public string? PolutedAreaRestrictions { get; set; }

        [Display(Name = "交易種類")]
        public TransactionType? TransactionType { get; set; }

        [Display(Name = "交易價金")]
        public float? TransactionPrice { get; set; }

        [Display(Name = "付款方式")]
        public string? PaymentMethod { get; set; }

        [Display(Name = "(Y/N)土地增值稅")]
        public bool? IsLandValueAddedTax { get; set; }

        [Display(Name = "土地增值稅")]
        public float? LandValueAddedTax { get; set; }

        [Display(Name = "(Y/N)地價稅")]
        public bool? IsLandTax { get; set; }

        [Display(Name = "地價稅")]
        public float? LandTax { get; set; }

        [Display(Name = "(Y/N)印花稅")]
        public bool? IsStampDuty { get; set; }

        [Display(Name = "印花稅")]
        public float? StampDuty { get; set; }

        [Display(Name = "(Y/N)其他稅費")]
        public bool? IsOtherTax { get; set; }

        [Display(Name = "其他稅費")]
        public string? OtherTax { get; set; }

        [Display(Name = "(Y/N)工程受益費")]
        public bool? IsConstructionBenefitFee { get; set; }

        [Display(Name = "工程受益費")]
        public float? ConstructionBenefitFee { get; set; }

        [Display(Name = "(Y/N)登記規費")]
        public bool? IsRegistrationFee { get; set; }

        [Display(Name = "登記規費")]
        public float? RegistrationFee { get; set; }

        [Display(Name = "(Y/N)公證費")]
        public bool? IsSurveyFee { get; set; }

        [Display(Name = "公證費")]
        public float? SurveyFee { get; set; }

        [Display(Name = "(Y/N)其他規費")]
        public bool? IsOtherProcessingFee { get; set; }

        [Display(Name = "其他規費")]
        public string? OtherProcessingFee { get; set; }

        [Display(Name = "(Y/N)簽約費")]
        public bool? IsContractFee { get; set; }

        [Display(Name = "簽約費")]
        public float? ContractFee { get; set; }

        [Display(Name = "(Y/N)所有權移轉代辦費")]
        public bool? IsOwnershipTransferAgencyFee { get; set; }

        [Display(Name = "所有權移轉代辦費")]
        public float? OwnershipTransferAgencyFee { get; set; }

        [Display(Name = "(Y/N)其他其他費用")]
        public bool? IsOtherFee { get; set; }

        [Display(Name = "其他其他費用")]
        public string? OtherFee { get; set; }

        [Display(Name = "選擇他項權利/限制登記")]
        public string? ChooseManageType { get; set; }

        [Display(Name = "他項權利/限制登記處理方式")]
        public string? ManageMethod { get; set; }

        [Display(Name = "(Y/N)解約、違約之處罰")]
        public bool? IsBreachOfContractPunishment { get; set; }

        [Display(Name = "解約、違約之處罰")]
        public string? BreachOfContractPunishment { get; set; }

        [Display(Name = "其他交易事項")]
        public string? OtherTransactionItem { get; set; }

        [Display(Name = "周邊環境附件種類")]
        public string? SurroundingsAppendiceType { get; set; }

        [Display(Name = "周邊環境")]
        public string? Surroundings { get; set; }

        [Display(Name = "(Y/N)已辦理地籍圖重測")]
        public bool? IsCadastralMapRetest { get; set; }

        [Display(Name = "(Y/N)地籍圖重測已公告辦理")]
        public bool? IsCadastralMapRetestAnnouced { get; set; }

        [Display(Name = "(Y/N)有被越界建築")]
        public bool? IsOutOfBoundsBuilding { get; set; }

        [Display(Name = "被越界建築情形")]
        public string? OutOfBoundsBuildingStatus { get; set; }

        [Display(Name = "(Y/N)公告徵收")]
        public bool? IsCompulsoryAcquisition { get; set; }

        [Display(Name = "徵收範圍")]
        public string? CompulsoryAcquisitionArea { get; set; }

        [Display(Name = "(Y/N)電力")]
        public bool? IsElectricityPower { get; set; }

        [Display(Name = "(Y/N)自來水")]
        public bool? IsTapWater { get; set; }

        [Display(Name = "(Y/N)天然瓦斯")]
        public bool? IsGas { get; set; }

        [Display(Name = "(Y/N)排水設施")]
        public bool? IsDrainer { get; set; }

        [Display(Name = "公共基礎設施理由")]
        public string? NonInfrastructureReason { get; set; }

        [Display(Name = "不動產經紀業名稱")]
        public string? RealEstateBroker { get; set; }

        [Display(Name = "簽約日期")]
        public DateTime? ContractDate { get; set; }

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