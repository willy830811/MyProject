using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyProject.Data;
using MyProject.Models;
using MyProject.ViewModels;

namespace MyProject.Controllers
{
    [Authorize]
    public class RealEstateDetailsController : Controller
    {
        private readonly MyProjectContext _context;
        private readonly ApplicationDbContext _userContext;

        public RealEstateDetailsController(MyProjectContext context, ApplicationDbContext userContext)
        {
            _context = context;
            _userContext = userContext;
        }

        // GET: RealEstateDetails
        public async Task<IActionResult> Index()
        {
            var realEstateDetail = await _context.RealEstateDetail.ToListAsync();

            var users = await _userContext.User.ToListAsync();
            var realEstateDetailViewModels = realEstateDetail.Select(item => new RealEstateDetailViewModel(item, users));

            return View(realEstateDetailViewModels);
        }

        // GET: RealEstateDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.RealEstateDetail == null)
            {
                return NotFound();
            }

            var realEstateDetail = await _context.RealEstateDetail
                .FirstOrDefaultAsync(m => m.Id == id);
            if (realEstateDetail == null)
            {
                return NotFound();
            }

            var users = await _userContext.User.ToListAsync();
            var realEstateDetailViewModel = new RealEstateDetailViewModel(realEstateDetail, users);

            return View(realEstateDetailViewModel);
        }

        // GET: RealEstateDetails/Create
        public IActionResult Create()
        {
            var realEstateDetailViewModel = new RealEstateDetailViewModel();
            return View(realEstateDetailViewModel);
        }

        // POST: RealEstateDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ObjectName,City,Region,Section,Subsection,PlaceNumber,Area,RightsScope,AppendicesNames,IsLandOwner,LandOwner,IsOtherObligee,OtherObligee,IsRegisteredManager,RegisteredManager,IsOwnership,OwnershipType,IsOtherRights,OtherRightsType,IsTrust,TrustContent,IsBaseRightsSettingBurden,BaseRightsSettingBurdenStatus,IsSettingOtherRights,SettingOtherRightsType,IsRestrictingRegistration,RestrictingRegistrationType,OtherRestrictingRegistration,IsOtherBaseRightsItemBy254,OtherBaseRightsItemBy254,IsOtherBaseRightsItemRelated,OtherBaseRightsItemRelated,IsUseByConvention,UseByConventionContent,IsRespectivelyManage,IsRespectivelyManageBy826,RespectivelyManageBy826Type,RespectivelyManageBy826Content,IsRent,IsLend,RentLendStatus,IsOccupiedWithoutRights,OccupiedWithoutRightsStatus,IsPublicWay,PublicWayPlaceAppendice,PublicWayArea,UrbanLandSection,NonUrbanLandSection,NonUrbanLandType,UnKnownLandRegulationStatus,BuildRate,VolumeRate,IsUrbanPlanningManual,DevelopMethodRestrictionsType,OtherDevelopMethodRestriction,IsBuildingRestrictedRegion,IsFarmLand,BuildFarmhouseType,FarmLandRegulation,IsMountLand,MountLandRestrictions,IsBanningBuildByKeepSoilLaw,BanningBuildByKeepSoilLawRestrictions,IsRiverRegion,RiverRegionRestrictions,IsDrainFacilityRegion,DrainFacilityRegionRestrictions,IsNationalPark,NationalParkType,NationalParkRestrictions,IsDrinkingWaterSource,DrinkingWaterSourceType,DrinkingWaterSourceRestrictions,IsWaterProtectionAreaByLaw,WaterProtectionAreaByLawRestrictions,IsPolutedArea,PolutedAreaType,PolutedAreaRestrictions,TransactionType,TransactionPrice,PaymentMethod,IsLandValueAddedTax,LandValueAddedTax,IsLandTax,LandTax,IsStampDuty,StampDuty,IsOtherTax,OtherTax,IsConstructionBenefitFee,ConstructionBenefitFee,IsRegistrationFee,RegistrationFee,IsSurveyFee,SurveyFee,IsOtherProcessingFee,OtherProcessingFee,IsContractFee,ContractFee,IsOwnershipTransferAgencyFee,OwnershipTransferAgencyFee,IsOtherFee,OtherFee,ChooseManageType,ManageMethod,IsBreachOfContractPunishment,BreachOfContractPunishment,OtherTransactionItem,SurroundingsAppendiceType,Surroundings,IsCadastralMapRetest,IsCadastralMapRetestAnnouced,IsOutOfBoundsBuilding,OutOfBoundsBuildingStatus,IsCompulsoryAcquisition,CompulsoryAcquisitionArea,IsElectricityPower,IsTapWater,IsGas,IsDrainer,NonInfrastructureReason,RealEstateBroker,ContractDate")] RealEstateDetail realEstateDetail, 
            string[] otherRightsType, string[] settingOtherRightsType, string[] restrictingRegistrationType, string[] respectivelyManageBy826Type, string[] developMethodRestrictionsType, string[] buildFarmhouseType, string[] nationalParkType, string[] drinkingWaterSourceType, string[] polutedAreaType, string[] chooseManageType, string[] surroundingsAppendiceType, string[] surroundings)
        {
            if (ModelState.IsValid)
            {
                realEstateDetail.OtherRightsType = String.Join(',', otherRightsType);
                realEstateDetail.SettingOtherRightsType = String.Join(',', settingOtherRightsType);
                realEstateDetail.RestrictingRegistrationType = String.Join(',', restrictingRegistrationType);
                realEstateDetail.RespectivelyManageBy826Type = String.Join(',', respectivelyManageBy826Type);
                realEstateDetail.DevelopMethodRestrictionsType = String.Join(',', developMethodRestrictionsType);
                realEstateDetail.BuildFarmhouseType = String.Join(',', buildFarmhouseType);
                realEstateDetail.NationalParkType = String.Join(',', nationalParkType);
                realEstateDetail.DrinkingWaterSourceType = String.Join(',', drinkingWaterSourceType);
                realEstateDetail.PolutedAreaType = String.Join(',', polutedAreaType);
                realEstateDetail.ChooseManageType = String.Join(',', chooseManageType);
                realEstateDetail.SurroundingsAppendiceType = String.Join(',', surroundingsAppendiceType);
                realEstateDetail.Surroundings = String.Join(',', surroundings);

                realEstateDetail.CreateId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                realEstateDetail.CreateTime = DateTime.Now;
                _context.Add(realEstateDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(realEstateDetail);
        }

        // GET: RealEstateDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.RealEstateDetail == null)
            {
                return NotFound();
            }

            var realEstateDetail = await _context.RealEstateDetail.FindAsync(id);
            if (realEstateDetail == null)
            {
                return NotFound();
            }

            var users = await _userContext.User.ToListAsync();
            var realEstateDetailViewModel = new RealEstateDetailViewModel(realEstateDetail, users);

            return View(realEstateDetailViewModel);
        }

        // POST: RealEstateDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ObjectName,City,Region,Section,Subsection,PlaceNumber,Area,RightsScope,AppendicesNames,IsLandOwner,LandOwner,IsOtherObligee,OtherObligee,IsRegisteredManager,RegisteredManager,IsOwnership,OwnershipType,IsOtherRights,OtherRightsType,IsTrust,TrustContent,IsBaseRightsSettingBurden,BaseRightsSettingBurdenStatus,IsSettingOtherRights,SettingOtherRightsType,IsRestrictingRegistration,RestrictingRegistrationType,OtherRestrictingRegistration,IsOtherBaseRightsItemBy254,OtherBaseRightsItemBy254,IsOtherBaseRightsItemRelated,OtherBaseRightsItemRelated,IsUseByConvention,UseByConventionContent,IsRespectivelyManage,IsRespectivelyManageBy826,RespectivelyManageBy826Type,RespectivelyManageBy826Content,IsRent,IsLend,RentLendStatus,IsOccupiedWithoutRights,OccupiedWithoutRightsStatus,IsPublicWay,PublicWayPlaceAppendice,PublicWayArea,UrbanLandSection,NonUrbanLandSection,NonUrbanLandType,UnKnownLandRegulationStatus,BuildRate,VolumeRate,IsUrbanPlanningManual,DevelopMethodRestrictionsType,OtherDevelopMethodRestriction,IsBuildingRestrictedRegion,IsFarmLand,BuildFarmhouseType,FarmLandRegulation,IsMountLand,MountLandRestrictions,IsBanningBuildByKeepSoilLaw,BanningBuildByKeepSoilLawRestrictions,IsRiverRegion,RiverRegionRestrictions,IsDrainFacilityRegion,DrainFacilityRegionRestrictions,IsNationalPark,NationalParkType,NationalParkRestrictions,IsDrinkingWaterSource,DrinkingWaterSourceType,DrinkingWaterSourceRestrictions,IsWaterProtectionAreaByLaw,WaterProtectionAreaByLawRestrictions,IsPolutedArea,PolutedAreaType,PolutedAreaRestrictions,TransactionType,TransactionPrice,PaymentMethod,IsLandValueAddedTax,LandValueAddedTax,IsLandTax,LandTax,IsStampDuty,StampDuty,IsOtherTax,OtherTax,IsConstructionBenefitFee,ConstructionBenefitFee,IsRegistrationFee,RegistrationFee,IsSurveyFee,SurveyFee,IsOtherProcessingFee,OtherProcessingFee,IsContractFee,ContractFee,IsOwnershipTransferAgencyFee,OwnershipTransferAgencyFee,IsOtherFee,OtherFee,ChooseManageType,ManageMethod,IsBreachOfContractPunishment,BreachOfContractPunishment,OtherTransactionItem,SurroundingsAppendiceType,Surroundings,IsCadastralMapRetest,IsCadastralMapRetestAnnouced,IsOutOfBoundsBuilding,OutOfBoundsBuildingStatus,IsCompulsoryAcquisition,CompulsoryAcquisitionArea,IsElectricityPower,IsTapWater,IsGas,IsDrainer,NonInfrastructureReason,RealEstateBroker,ContractDate,CreateTime,CreateId")] RealEstateDetailViewModel realEstateDetail,
            string[] otherRightsType, string[] settingOtherRightsType, string[] restrictingRegistrationType, string[] respectivelyManageBy826Type, string[] developMethodRestrictionsType, string[] buildFarmhouseType, string[] nationalParkType, string[] drinkingWaterSourceType, string[] polutedAreaType, string[] chooseManageType, string[] surroundingsAppendiceType, string[] surroundings)
        {
            if (id != realEstateDetail.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    realEstateDetail.OtherRightsType = String.Join(',', otherRightsType);
                    realEstateDetail.SettingOtherRightsType = String.Join(',', settingOtherRightsType);
                    realEstateDetail.RestrictingRegistrationType = String.Join(',', restrictingRegistrationType);
                    realEstateDetail.RespectivelyManageBy826Type = String.Join(',', respectivelyManageBy826Type);
                    realEstateDetail.DevelopMethodRestrictionsType = String.Join(',', developMethodRestrictionsType);
                    realEstateDetail.BuildFarmhouseType = String.Join(',', buildFarmhouseType);
                    realEstateDetail.NationalParkType = String.Join(',', nationalParkType);
                    realEstateDetail.DrinkingWaterSourceType = String.Join(',', drinkingWaterSourceType);
                    realEstateDetail.PolutedAreaType = String.Join(',', polutedAreaType);
                    realEstateDetail.ChooseManageType = String.Join(',', chooseManageType);
                    realEstateDetail.SurroundingsAppendiceType = String.Join(',', surroundingsAppendiceType);
                    realEstateDetail.Surroundings = String.Join(',', surroundings);

                    realEstateDetail.UpdateId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                    realEstateDetail.UpdateTime = DateTime.Now;
                    _context.Update(realEstateDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RealEstateDetailExists(realEstateDetail.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(realEstateDetail);
        }

        // GET: RealEstateDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.RealEstateDetail == null)
            {
                return NotFound();
            }

            var realEstateDetail = await _context.RealEstateDetail
                .FirstOrDefaultAsync(m => m.Id == id);
            if (realEstateDetail == null)
            {
                return NotFound();
            }

            var users = await _userContext.User.ToListAsync();
            var realEstateDetailViewModel = new RealEstateDetailViewModel(realEstateDetail, users);

            return View(realEstateDetailViewModel);
        }

        // POST: RealEstateDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.RealEstateDetail == null)
            {
                return Problem("Entity set 'MyProjectContext.RealEstateDetail'  is null.");
            }
            var realEstateDetail = await _context.RealEstateDetail.FindAsync(id);
            if (realEstateDetail != null)
            {
                _context.RealEstateDetail.Remove(realEstateDetail);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<ContentResult?> CreatePdf(int? id)
        {
            if (id == null || _context.RealEstateDetail == null)
            {
                return null;
            }

            var realEstateDetail = await _context.RealEstateDetail.FindAsync(id);
            if (realEstateDetail == null)
            {
                return null;
            }

            var html = System.IO.File.ReadAllText(@"D:\table2.html");
            var multipleChoiceItems = new List<string>()
            {
                //"OwnershipType",
                "OtherRightsType",
                "SettingOtherRightsType",
                "RestrictingRegistrationType",
                "RespectivelyManageBy826Type",
                "DevelopMethodRestrictionsType",
                "BuildFarmhouseType",
                "NationalParkType",
                "DrinkingWaterSourceType",
                "PolutedAreaType",
                //"TransactionType",
                "ChooseManageType",
                "SurroundingsAppendiceType",
                "Surroundings"
            };

            foreach (var propertyInfo in realEstateDetail.GetType().GetProperties())
            {
                if (
                    (propertyInfo.PropertyType == typeof(string) && !multipleChoiceItems.Contains(propertyInfo.Name))
                    || propertyInfo.PropertyType == typeof(int)
                    || propertyInfo.PropertyType == typeof(float)
                    || Nullable.GetUnderlyingType(propertyInfo.PropertyType) == typeof(string)
                    || Nullable.GetUnderlyingType(propertyInfo.PropertyType) == typeof(int)
                    || Nullable.GetUnderlyingType(propertyInfo.PropertyType) == typeof(float)
                )
                {
                    html = html.Replace($"${propertyInfo.Name}$", propertyInfo.GetValue(realEstateDetail, null)?.ToString());
                    continue;
                }

                if (propertyInfo.PropertyType == typeof(bool) || Nullable.GetUnderlyingType(propertyInfo.PropertyType) == typeof(bool))
                {
                    var boolValue = (bool)propertyInfo.GetValue(realEstateDetail, null);

                    html = html.Replace($"${propertyInfo.Name}$", (bool)boolValue ? "&#x25A0;" : "&#x25A1;");
                    html = html.Replace($"$!{propertyInfo.Name}$", (bool)boolValue ? "&#x25A1;" : "&#x25A0;");
                }

                if (propertyInfo.PropertyType == typeof(DateTime) || Nullable.GetUnderlyingType(propertyInfo.PropertyType) == typeof(DateTime))
                {
                    var date = (DateTime?)propertyInfo.GetValue(realEstateDetail, null);
                    html = html.Replace($"${propertyInfo.Name}$", date is not null ? $"{date.Value.Year}年{date.Value.Month}月{date.Value.Day}日" : "__年__月__日");
                }

                if (propertyInfo.PropertyType.IsEnum || Nullable.GetUnderlyingType(propertyInfo.PropertyType) is not null && Nullable.GetUnderlyingType(propertyInfo.PropertyType).IsEnum)
                {
                    var enumValue = propertyInfo.GetValue(realEstateDetail, null);
                    var enumInt = enumValue is not null ? (int)enumValue : 0;
                    var enumConut = 1;

                    while (html.Contains($"${propertyInfo.Name}{enumConut}$"))
                    {
                        if (enumInt == enumConut)
                            html = html.Replace($"${propertyInfo.Name}{enumConut}$", "&#x25A0;");
                        else
                            html = html.Replace($"${propertyInfo.Name}{enumConut}$", "&#x25A1;");

                        enumConut++;
                    }
                }

                if (propertyInfo.PropertyType == typeof(string) && multipleChoiceItems.Contains(propertyInfo.Name))
                {
                    var enumArrayString = (string?)propertyInfo.GetValue(realEstateDetail, null);
                    var enumConut = 1;

                    if (enumArrayString is not null && enumArrayString.Length > 0)
                    {
                        var enumArray = enumArrayString.Split(',').Select(int.Parse).Select(x => x + 1).ToArray();

                        while (html.Contains($"${propertyInfo.Name}{enumConut}$"))
                        {
                            if (Array.Exists(enumArray, x => x == enumConut))
                                html = html.Replace($"${propertyInfo.Name}{enumConut}$", "&#x25A0;");
                            else
                                html = html.Replace($"${propertyInfo.Name}{enumConut}$", "&#x25A1;");

                            enumConut++;
                        }
                    }
                    else
                    {
                        while (html.Contains($"${propertyInfo.Name}{enumConut}$"))
                        {
                            html = html.Replace($"${propertyInfo.Name}{enumConut}$", "&#x25A1;");
                            enumConut++;
                        }
                    }
                }
            }

            return new ContentResult
            {
                Content = html,
                ContentType = "text/html"
            };
        }

        private bool RealEstateDetailExists(int id)
        {
          return _context.RealEstateDetail.Any(e => e.Id == id);
        }
    }
}
