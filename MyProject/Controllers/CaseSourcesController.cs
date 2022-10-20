using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyProject.Data;
using MyProject.Models;
using MyProject.Models.Items;
using MyProject.ViewModels;
using Newtonsoft.Json;

namespace MyProject.Controllers
{
    public class CaseSourcesController : Controller
    {
        private readonly MyProjectContext _context;

        public CaseSourcesController(MyProjectContext context)
        {
            _context = context;
        }

        // GET: CaseSources
        public async Task<IActionResult> Index()
        {
              return View(await _context.CaseSource.ToListAsync());
        }

        // GET: CaseSources/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CaseSource == null)
            {
                return NotFound();
            }

            var caseSource = await _context.CaseSource.Include(d => d.AppendixItems).FirstOrDefaultAsync(m => m.Id == id);

            if (caseSource == null)
            {
                return NotFound();
            }

            var caseSourceLandInventoryItemsViewModel = new CaseSourceLandInventoryItemsViewModel
            {
                Id = caseSource.Id,
                CaseName = caseSource.CaseName,
                TotalPrice = caseSource.TotalPrice,
                UnitPrice = caseSource.UnitPrice,
                Section = caseSource.Section,
                Subsection = caseSource.Subsection,
                PlaceNumber = caseSource.PlaceNumber,
                LandCount = caseSource.LandCount,
                TotalAreaInSquareMeter = caseSource.TotalAreaInSquareMeter,
                TotalAreaInPing = caseSource.TotalAreaInPing,
                BuildRate = caseSource.BuildRate,
                VolumeRate = caseSource.VolumeRate,
                Hold = caseSource.Hold,
                SellingAreaInSquareMeter = caseSource.SellingAreaInSquareMeter,
                SellingAreaInPing = caseSource.SellingAreaInPing,
                UseSection = caseSource.UseSection,
                UseStatus = caseSource.UseStatus,
                Environment = caseSource.Environment,
                Feature = caseSource.Feature,
                IsCadastralMap = caseSource.IsCadastralMap,
                IsAerialPhoto = caseSource.IsAerialPhoto,
                IsTranscript = caseSource.IsTranscript,
                IsUseSection = caseSource.IsUseSection,
                IsUrbanPlanningManual = caseSource.IsUrbanPlanningManual,
                IsCurrentPhotos = caseSource.IsCurrentPhotos,
                ValueAddedTax = caseSource.ValueAddedTax,
                Other = caseSource.Other,
                Agent = caseSource.Agent,
                Phone = caseSource.Phone,
                LandInventoryItems = JsonConvert.DeserializeObject<List<LandInventoryItem>>(caseSource.LandInventories),
                AppendixItems = caseSource.AppendixItems
            };

            return View(caseSourceLandInventoryItemsViewModel);
        }

        // GET: CaseSources/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CaseSources/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CaseSourceId,CaseName,TotalPrice,UnitPrice,Section,Subsection,LandCount,TotalAreaInSquareMeter,TotalAreaInPing,BuildRate,VolumeRate,Hold,SellingAreaInSquareMeter,SellingAreaInPing,UseSection,UseStatus,Environment,Feature,IsCadastralMap,IsAerialPhoto,IsTranscript,IsUseSection,IsUrbanPlanningManual,IsCurrentPhotos,ValueAddedTax,Other,Agent,Phone")] CaseSource caseSource, List<LandInventoryItem> landInventoryItems)
        {
            if (ModelState.IsValid)
            {
                var landInventories = JsonConvert.SerializeObject(landInventoryItems);
                caseSource.LandInventories = landInventories;
                caseSource.CreateId = User.Identity.Name;
                caseSource.CreateTime = DateTime.Now;
                _context.Add(caseSource);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(caseSource);
        }

        // GET: CaseSources/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CaseSource == null)
            {
                return NotFound();
            }

            var caseSource = await _context.CaseSource.FindAsync(id);
            if (caseSource == null)
            {
                return NotFound();
            }

            var caseSourceLandInventoryItemsViewModel = new CaseSourceLandInventoryItemsViewModel
            {
                Id = caseSource.Id,
                CaseName = caseSource.CaseName,
                TotalPrice = caseSource.TotalPrice,
                UnitPrice = caseSource.UnitPrice,
                Section = caseSource.Section,
                Subsection = caseSource.Subsection,
                PlaceNumber = caseSource.PlaceNumber,
                LandCount = caseSource.LandCount,
                TotalAreaInSquareMeter = caseSource.TotalAreaInSquareMeter,
                TotalAreaInPing = caseSource.TotalAreaInPing,
                BuildRate = caseSource.BuildRate,
                VolumeRate = caseSource.VolumeRate,
                Hold = caseSource.Hold,
                SellingAreaInSquareMeter = caseSource.SellingAreaInSquareMeter,
                SellingAreaInPing = caseSource.SellingAreaInPing,
                UseSection = caseSource.UseSection,
                UseStatus = caseSource.UseStatus,
                Environment = caseSource.Environment,
                Feature = caseSource.Feature,
                IsCadastralMap = caseSource.IsCadastralMap,
                IsAerialPhoto = caseSource.IsAerialPhoto,
                IsTranscript = caseSource.IsTranscript,
                IsUseSection = caseSource.IsUseSection,
                IsUrbanPlanningManual = caseSource.IsUrbanPlanningManual,
                IsCurrentPhotos = caseSource.IsCurrentPhotos,
                ValueAddedTax = caseSource.ValueAddedTax,
                Other = caseSource.Other,
                Agent = caseSource.Agent,
                Phone = caseSource.Phone,
                LandInventoryItems = JsonConvert.DeserializeObject<List<LandInventoryItem>>(caseSource.LandInventories)
            };

            return View(caseSourceLandInventoryItemsViewModel);
        }

        // POST: CaseSources/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CaseSourceId,CaseName,TotalPrice,UnitPrice,Section,Subsection,LandCount,TotalAreaInSquareMeter,TotalAreaInPing,BuildRate,VolumeRate,Hold,SellingAreaInSquareMeter,SellingAreaInPing,UseSection,UseStatus,Environment,Feature,IsCadastralMap,IsAerialPhoto,IsTranscript,IsUseSection,IsUrbanPlanningManual,IsCurrentPhotos,ValueAddedTax,Other,Agent,Phone,CreateTime,CreateId")] CaseSource caseSource, List<LandInventoryItem> landInventoryItems)
        {
            if (id != caseSource.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    caseSource.UpdateId = User.Identity.Name;
                    caseSource.UpdateTime = DateTime.Now;
                    _context.Update(caseSource);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CaseSourceExists(caseSource.Id))
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
            return View(caseSource);
        }

        public IActionResult AddRow(string? json)
        {
            var landInventoryItems = JsonConvert.DeserializeObject<List<LandInventoryItem>>(json);
            landInventoryItems.Add(new LandInventoryItem());

            return ViewComponent("LandInventories", landInventoryItems);
        }

        public IActionResult RemoveRow(string? json, int index)
        {
            var landInventoryItems = JsonConvert.DeserializeObject<List<LandInventoryItem>>(json);
            landInventoryItems.RemoveAt(index);

            return ViewComponent("LandInventories", landInventoryItems);
        }

        // GET: CaseSources/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CaseSource == null)
            {
                return NotFound();
            }

            var caseSource = await _context.CaseSource
                .FirstOrDefaultAsync(m => m.Id == id);
            if (caseSource == null)
            {
                return NotFound();
            }

            return View(caseSource);
        }

        // POST: CaseSources/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CaseSource == null)
            {
                return Problem("Entity set 'MyProjectContext.CaseSource'  is null.");
            }
            var caseSource = await _context.CaseSource.FindAsync(id);
            if (caseSource != null)
            {
                _context.CaseSource.Remove(caseSource);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> AppendixIndex(int id)
        {
            var caseSouce = await _context.CaseSource.Include(d => d.AppendixItems).FirstOrDefaultAsync(x => x.Id == id);
            ViewBag.CaseSourceId = id;
            ViewBag.CaseSourceName = caseSouce.CaseName;

            return View(caseSouce.AppendixItems);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AppendixCreate(int caseSourceId, string name, IFormFile file)
        {
            if (file is not null)
            {
                using (var ms = new MemoryStream())
                {
                    file.CopyTo(ms);
                    var fileBytes = ms.ToArray();
                    string s = Convert.ToBase64String(fileBytes);

                    _context.Add(new AppendixItem { CaseSourceId = caseSourceId, Name = name, Base64 = s });
                }
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(AppendixIndex), new { Id = caseSourceId });
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> AppendixDelete(int caseSourceId, int id)
        {
            if (_context.AppendixItem == null)
            {
                return Problem("");
            }
            var appendixItem = await _context.AppendixItem.FindAsync(id);
            if (appendixItem != null)
            {
                _context.AppendixItem.Remove(appendixItem);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(AppendixIndex), new { Id = caseSourceId });
        }

        public async Task<ContentResult?> CreatePdf(int? id)
        {
            if (id == null || _context.CaseSource == null)
            {
                return null;
            }

            var caseSource = await _context.CaseSource.Include(e => e.AppendixItems).FirstOrDefaultAsync(x => x.Id == id);
            if (caseSource == null)
            {
                return null;
            }

            var html = System.IO.File.ReadAllText(@"D:\table3.html");

            foreach (var propertyInfo in caseSource.GetType().GetProperties())
            {
                if (
                    propertyInfo.PropertyType == typeof(string)
                    || propertyInfo.PropertyType == typeof(int)
                    || propertyInfo.PropertyType == typeof(float)
                    || Nullable.GetUnderlyingType(propertyInfo.PropertyType) == typeof(string)
                    || Nullable.GetUnderlyingType(propertyInfo.PropertyType) == typeof(int)
                    || Nullable.GetUnderlyingType(propertyInfo.PropertyType) == typeof(float)
                )
                {
                    html = html.Replace($"${propertyInfo.Name}$", propertyInfo.GetValue(caseSource, null)?.ToString());
                    continue;
                }

                if (propertyInfo.PropertyType == typeof(bool) || Nullable.GetUnderlyingType(propertyInfo.PropertyType) == typeof(bool))
                {
                    var boolValue = (bool?)propertyInfo.GetValue(caseSource, null);
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
                    var date = (DateTime?)propertyInfo.GetValue(caseSource, null);
                    html = html.Replace($"${propertyInfo.Name}$", date is not null ? $"{date.Value.Year}年{date.Value.Month}月{date.Value.Day}日" : "__年__月__日");
                }

                if (propertyInfo.PropertyType.IsEnum || Nullable.GetUnderlyingType(propertyInfo.PropertyType) is not null && Nullable.GetUnderlyingType(propertyInfo.PropertyType).IsEnum)
                {
                    var enumValue = propertyInfo.GetValue(caseSource, null);
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
            }

            // 處理List
            var originString = "<tr style='mso-height-source:userset;height:24.05pt'>\r\n<td colspan='2' style='border:1px solid #000000; vertical-align:middle;'>$SectionName$</td>\r\n<td colspan='2' style='border:1px solid #000000; vertical-align:middle;'>$PlaceNumber$</td>\r\n<td style='border:1px solid #000000; vertical-align:middle;'>$AreaInSquareMeter$</td>\r\n<td style='border:1px solid #000000; vertical-align:middle;'>$AreaInPing$</td>\r\n<td style='border:1px solid #000000; vertical-align:middle;'>$Hold$</td>\r\n<td style='border:1px solid #000000; vertical-align:middle;'>$HoldAreaInSquareMeter$</td>\r\n<td style='border:1px solid #000000; vertical-align:middle;'>$HoldAreaInPing$</td>\r\n<td style='border:1px solid #000000; vertical-align:middle;'>$PresentValue$</td>\r\n<td style='border:1px solid #000000; vertical-align:middle;'>$UseSection$</td>\r\n<td style='border:1px solid #000000; vertical-align:middle;'>$Note$</td>\r\n  \r\n </tr>";
            var landInventoriesString = string.Empty;
            var landInventoryItems = JsonConvert.DeserializeObject<List<LandInventoryItem>>(caseSource.LandInventories);

            if (landInventoryItems is not null && landInventoryItems.Count > 0)
            {
                foreach (var item in landInventoryItems)
                {
                    var newString = originString.Replace("$SectionName$", item.SectionName)
                        .Replace("$PlaceNumber$", item.PlaceNumber)
                        .Replace("$AreaInSquareMeter$", item.AreaInSquareMeter.ToString())
                        .Replace("$AreaInPing$", item.AreaInPing.ToString())
                        .Replace("$Hold$", item.Hold)
                        .Replace("$HoldAreaInSquareMeter$", item.HoldAreaInSquareMeter.ToString())
                        .Replace("$HoldAreaInPing$", item.HoldAreaInPing.ToString())
                        .Replace("$PresentValue$", item.PresentValue.ToString())
                        .Replace("$UseSection$", item.UseSection)
                        .Replace("$Note$", item.Note);

                    landInventoriesString += newString;
                }

                html = html.Replace("$LandInventoryItems$", landInventoriesString);
            }
            else
            {
                html = html.Replace("$LandInventoryItems$", "");
            }

            // 處理附件
            var originAppendixItemsString = "<p height='64'>$Name$</p><img width='595' max-height='842' src=\"data:image/$Format$;base64,$Base64$\">";
            var appendixItems = string.Empty;

            if (caseSource.AppendixItems is not null && caseSource.AppendixItems.Count > 0)
            {
                foreach (var item in caseSource.AppendixItems)
                {
                    var newListString = originAppendixItemsString.Replace("$Name$", item.Name)
                        .Replace("$Format$", item.Format)
                        .Replace("$Base64$", item.Base64);

                    appendixItems += newListString;
                }

                html = html.Replace("$AppendixItems$", appendixItems);
            }
            else
            {
                html = html.Replace("$AppendixItems$", "");
            }

            return new ContentResult
            {
                Content = html,
                ContentType = "text/html"
            };
        }

        private bool CaseSourceExists(int id)
        {
            return _context.CaseSource.Any(e => e.Id == id);
        }
    }
}
