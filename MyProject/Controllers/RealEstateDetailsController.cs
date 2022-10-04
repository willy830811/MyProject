using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyProject.Data;
using MyProject.Models;

namespace MyProject.Controllers
{
    public class RealEstateDetailsController : Controller
    {
        private readonly MyProjectContext _context;

        public RealEstateDetailsController(MyProjectContext context)
        {
            _context = context;
        }

        // GET: RealEstateDetails
        public async Task<IActionResult> Index()
        {
              return View(await _context.RealEstateDetail.ToListAsync());
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

            return View(realEstateDetail);
        }

        // GET: RealEstateDetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RealEstateDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ObjectName,City,Region,Section,Subsection,PlaceNumber,Area,RightsScope,AppendicesNames,IsLandOwner,LandOwner,IsOtherObligee,OtherObligee,IsRegisteredManager,RegisteredManager,IsOwnership,OwnershipType,IsOtherRights,OtherRightsType,IsTrust,TrustContent,IsBaseRightsSettingBurden,BaseRightsSettingBurdenStatus,IsSettingOtherRights,SettingOtherRightsType,IsRestrictingRegistration,RestrictingRegistrationType,OtherRestrictingRegistration,IsOtherBaseRightsItemBy254,OtherBaseRightsItemBy254,IsOtherBaseRightsItemRelated,OtherBaseRightsItemRelated,IsUseByConvention,UseByConventionContent,IsRespectivelyManage,IsRespectivelyManageBy826,RespectivelyManageBy826Type,RespectivelyManageBy826Content,IsRent,IsLend,RentLendStatus,IsOccupiedWithoutRights,OccupiedWithoutRightsStatus,IsPublicWay,PublicWayPlaceAppendice,PublicWayArea,UrbanLandSection,NonUrbanLandSection,NonUrbanLandType,UnKnownLandRegulationStatus,BuildRate,VolumeRate,IsUrbanPlanningManual,DevelopMethodRestrictionsType,OtherDevelopMethodRestriction,IsBuildingRestrictedRegion,IsFarmLand,BuildFarmhouseType,FarmLandRegulation,IsMountLand,MountLandRestrictions,IsBanningBuildByKeepSoilLaw,BanningBuildByKeepSoilLawRestrictions,IsRiverRegion,RiverRegionRestrictions,IsDrainFacilityRegion,DrainFacilityRegionRestrictions,IsNationalPark,NationalParkType,NationalParkRestrictions,IsDrinkingWaterSource,DrinkingWaterSourceType,DrinkingWaterSourceRestrictions,IsWaterProtectionAreaByLaw,WaterProtectionAreaByLawRestrictions,IsPolutedArea,PolutedAreaType,PolutedAreaRestrictions,TransactionType,TransactionPrice,PaymentMethod,IsLandValueAddedTax,LandValueAddedTax,IsLandTax,LandTax,IsStampDuty,StampDuty,IsOtherTax,OtherTax,IsConstructionBenefitFee,ConstructionBenefitFee,IsRegistrationFee,RegistrationFee,IsSurveyFee,SurveyFee,IsOtherProcessingFee,OtherProcessingFee,IsContractFee,ContractFee,IsOwnershipTransferAgencyFee,OwnershipTransferAgencyFee,IsOtherFee,OtherFee,ChooseManageType,ManageMethod,IsBreachOfContractPunishment,BreachOfContractPunishment,OtherTransactionItem,SurroundingsAppendiceType,Surroundings,IsCadastralMapRetest,IsCadastralMapRetestAnnouced,IsOutOfBoundsBuilding,OutOfBoundsBuildingStatus,IsCompulsoryAcquisition,CompulsoryAcquisitionArea,IsElectricityPower,IsTapWater,IsGas,IsDrainer,NonInfrastructureReason,RealEstateBroker,ContractDate,CreateTime,CreateId,UpdateTime,UpdateId")] RealEstateDetail realEstateDetail)
        {
            if (ModelState.IsValid)
            {
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
            return View(realEstateDetail);
        }

        // POST: RealEstateDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ObjectName,City,Region,Section,Subsection,PlaceNumber,Area,RightsScope,AppendicesNames,IsLandOwner,LandOwner,IsOtherObligee,OtherObligee,IsRegisteredManager,RegisteredManager,IsOwnership,OwnershipType,IsOtherRights,OtherRightsType,IsTrust,TrustContent,IsBaseRightsSettingBurden,BaseRightsSettingBurdenStatus,IsSettingOtherRights,SettingOtherRightsType,IsRestrictingRegistration,RestrictingRegistrationType,OtherRestrictingRegistration,IsOtherBaseRightsItemBy254,OtherBaseRightsItemBy254,IsOtherBaseRightsItemRelated,OtherBaseRightsItemRelated,IsUseByConvention,UseByConventionContent,IsRespectivelyManage,IsRespectivelyManageBy826,RespectivelyManageBy826Type,RespectivelyManageBy826Content,IsRent,IsLend,RentLendStatus,IsOccupiedWithoutRights,OccupiedWithoutRightsStatus,IsPublicWay,PublicWayPlaceAppendice,PublicWayArea,UrbanLandSection,NonUrbanLandSection,NonUrbanLandType,UnKnownLandRegulationStatus,BuildRate,VolumeRate,IsUrbanPlanningManual,DevelopMethodRestrictionsType,OtherDevelopMethodRestriction,IsBuildingRestrictedRegion,IsFarmLand,BuildFarmhouseType,FarmLandRegulation,IsMountLand,MountLandRestrictions,IsBanningBuildByKeepSoilLaw,BanningBuildByKeepSoilLawRestrictions,IsRiverRegion,RiverRegionRestrictions,IsDrainFacilityRegion,DrainFacilityRegionRestrictions,IsNationalPark,NationalParkType,NationalParkRestrictions,IsDrinkingWaterSource,DrinkingWaterSourceType,DrinkingWaterSourceRestrictions,IsWaterProtectionAreaByLaw,WaterProtectionAreaByLawRestrictions,IsPolutedArea,PolutedAreaType,PolutedAreaRestrictions,TransactionType,TransactionPrice,PaymentMethod,IsLandValueAddedTax,LandValueAddedTax,IsLandTax,LandTax,IsStampDuty,StampDuty,IsOtherTax,OtherTax,IsConstructionBenefitFee,ConstructionBenefitFee,IsRegistrationFee,RegistrationFee,IsSurveyFee,SurveyFee,IsOtherProcessingFee,OtherProcessingFee,IsContractFee,ContractFee,IsOwnershipTransferAgencyFee,OwnershipTransferAgencyFee,IsOtherFee,OtherFee,ChooseManageType,ManageMethod,IsBreachOfContractPunishment,BreachOfContractPunishment,OtherTransactionItem,SurroundingsAppendiceType,Surroundings,IsCadastralMapRetest,IsCadastralMapRetestAnnouced,IsOutOfBoundsBuilding,OutOfBoundsBuildingStatus,IsCompulsoryAcquisition,CompulsoryAcquisitionArea,IsElectricityPower,IsTapWater,IsGas,IsDrainer,NonInfrastructureReason,RealEstateBroker,ContractDate,CreateTime,CreateId,UpdateTime,UpdateId")] RealEstateDetail realEstateDetail)
        {
            if (id != realEstateDetail.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
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

            return View(realEstateDetail);
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
                    var boolValue = (bool?)propertyInfo.GetValue(realEstateDetail, null);
                    //html = html.Replace($"${propertyInfo.Name}$", boolValue is not null ? ((bool)boolValue ? "&#x25A0;有 &#x25A1;無" : "&#x25A1;有 &#x25A0;無") : "&#x25A1;有 &#x25A1;無");
                    if (boolValue is not null)
                    {
                        html = html.Replace($"${propertyInfo.Name}$", (bool)boolValue ? "&#x25A0;" : "&#x25A1;");
                        html = html.Replace($"$!{propertyInfo.Name}$", (bool)boolValue ? "&#x25A1;" : "&#x25A0;");
                    }
                    else
                    {
                        html = html.Replace($"${propertyInfo.Name}$", "&#x25A1;");
                        html = html.Replace($"$!{propertyInfo.Name}$", "&#x25A1;");
                    }
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

                    //html = html.Replace("$PropertyType1$", "<input type = \"checkbox\" id = \"cbox1\" value = \"first_checkbox\"><label for= \"cbox1\"> This is the first checkbox </label>");
                }

                if (propertyInfo.PropertyType == typeof(string) && multipleChoiceItems.Contains(propertyInfo.Name))
                {
                    var enumArrayString = (string?)(propertyInfo.GetValue(realEstateDetail, null));

                    if (enumArrayString is not null)
                    {
                        var enumArray = enumArrayString.Split(',');

                        foreach (var enumInt in enumArray)
                        {
                            var enumConut = 1;

                            while (html.Contains($"${propertyInfo.Name}{enumConut}$"))
                            {
                                if (Convert.ToInt32(enumInt) == enumConut)
                                    html = html.Replace($"${propertyInfo.Name}{enumConut}$", "&#x25A0;");
                                else
                                    html = html.Replace($"${propertyInfo.Name}{enumConut}$", "&#x25A1;");

                                enumConut++;
                            }
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
