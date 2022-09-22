using System;
using System.Collections.Generic;
using System.Linq;
using iText.Forms;
using iText.Forms.Fields;
using iText.IO.Source;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyProject.Data;
using MyProject.Models;
using iText.Html2pdf;
using iText.Layout.Font;
using iText.Kernel.Font;
using iText.Html2pdf.Resolver.Font;
using iText.IO.Font;

namespace MyProject.Controllers
{
    public class PropertiesController : Controller
    {
        private readonly MyProjectContext _context;

        public PropertiesController(MyProjectContext context)
        {
            _context = context;
        }

        // GET: Properties
        public async Task<IActionResult> Index()
        {
              return _context.Property != null ? 
                          View(await _context.Property.ToListAsync()) :
                          Problem("Entity set 'MyProjectContext.Property'  is null.");
        }

        // GET: Properties/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Property == null)
            {
                return NotFound();
            }

            var @property = await _context.Property
                .FirstOrDefaultAsync(m => m.Id == id);
            if (@property == null)
            {
                return NotFound();
            }

            return View(@property);
        }

        // GET: Properties/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Properties/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CaseName,LetterNumber,SellingPrice,Address,Type,OtherType,Use,OtherUse,TotalArea,MainArea,AttachedArea,SharedArea,OtherArea,OtherAreaDefine,SettingPrice,HoldArea,LandSection,BuildingFinishedDate,UnitPrice,Decorate,GasFacility,Balcony,BuildingName,UpperGroundFloors,UnderGroundFloors,SitDirection,FaceDirection,RoadWidth,LightingFace,RoomCounts,HallCounts,ToliteCounts,NeiborCounts,ElevatorCounts,ElementarySchool,JuniorHighSchool,Park,Market,BusStation,MRTStation,Status,Rent,RentPeriodFrom,RentPeriodTo,MainMaterial,OutsideMaterial,Courtyard,Guard,ManagementFee,Parking,ParkingArea,Floor,Number,ParkingFee,ParkingPrice,ParkingEntrance,ParkingType,BringingType,GiftPillar,GiftWallCabinet,GiftLiquorCabinet,GiftPhone,GiftSofa,GiftHeater,GiftBedding,GiftCooker,GiftGas,GiftTV,GiftFridge,GiftAirCon,GiftOther,Feature,Note,Leader,Manager,Sales,Phone,CaseNumber")] Property @property)
        {
            if (ModelState.IsValid)
            {
                _context.Add(@property);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(@property);
        }

        // GET: Properties/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Property == null)
            {
                return NotFound();
            }

            var @property = await _context.Property.FindAsync(id);
            if (@property == null)
            {
                return NotFound();
            }
            return View(@property);
        }

        // POST: Properties/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CaseName,LetterNumber,SellingPrice,Address,Type,OtherType,Use,OtherUse,TotalArea,MainArea,AttachedArea,SharedArea,OtherArea,OtherAreaDefine,SettingPrice,HoldArea,LandSection,BuildingFinishedDate,UnitPrice,Decorate,GasFacility,Balcony,BuildingName,UpperGroundFloors,UnderGroundFloors,SitDirection,FaceDirection,RoadWidth,LightingFace,RoomCounts,HallCounts,ToliteCounts,NeiborCounts,ElevatorCounts,ElementarySchool,JuniorHighSchool,Park,Market,BusStation,MRTStation,Status,Rent,RentPeriodFrom,RentPeriodTo,MainMaterial,OutsideMaterial,Courtyard,Guard,ManagementFee,Parking,ParkingArea,Floor,Number,ParkingFee,ParkingPrice,ParkingEntrance,ParkingType,BringingType,GiftPillar,GiftWallCabinet,GiftLiquorCabinet,GiftPhone,GiftSofa,GiftHeater,GiftBedding,GiftCooker,GiftGas,GiftTV,GiftFridge,GiftAirCon,GiftOther,Feature,Note,Leader,Manager,Sales,Phone,CaseNumber")] Property @property)
        {
            if (id != @property.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(@property);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PropertyExists(@property.Id))
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
            return View(@property);
        }

        // GET: Properties/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Property == null)
            {
                return NotFound();
            }

            var @property = await _context.Property
                .FirstOrDefaultAsync(m => m.Id == id);
            if (@property == null)
            {
                return NotFound();
            }

            return View(@property);
        }

        // POST: Properties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Property == null)
            {
                return Problem("Entity set 'MyProjectContext.Property'  is null.");
            }
            var @property = await _context.Property.FindAsync(id);
            if (@property != null)
            {
                _context.Property.Remove(@property);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //public FileStreamResult CreatePdf()
        //{
        //    var source = new FileStream(@"D:\demo2.pdf", FileMode.Open, FileAccess.Read);
        //    var ms = new MemoryStream();
        //    source.CopyTo(ms);
        //    source.Close();

        //    ms.Position = 0;
        //    ByteArrayOutputStream baos = new ByteArrayOutputStream();//
        //    var pdf = new PdfDocument(new PdfReader(ms, new ReaderProperties()), new PdfWriter(baos));

        //    var document = new Document(pdf);
        //    PdfAcroForm form = PdfAcroForm.GetAcroForm(document.GetPdfDocument(), false);

        //    PdfFormField toSet;
        //    IDictionary<String, PdfFormField> fields = form.GetFormFields();
        //    fields.TryGetValue("X2", out toSet);
        //    toSet.SetValue("James Bond");
        //    document.Close();

        //    ms.Position = 0;
        //    return new FileStreamResult(ms, "application/pdf");
        //}

        //public FileStreamResult CreatePdf()
        //{
        //    var source = new FileStream(@"D:\demo1.pdf", FileMode.Open, FileAccess.Read);
        //    var ms = new MemoryStream();
        //    source.CopyTo(ms);
        //    source.Close();

        //    //var writer = new PdfWriter(ms);
        //    //writer.SetCloseStream(false);
        //    //var pdf = new PdfDocument(writer);

        //    ms.Position = 0;
        //    ByteArrayOutputStream baos = new ByteArrayOutputStream();
        //    var pdf = new PdfDocument(new PdfReader(ms, new ReaderProperties()), new PdfWriter(baos));

        //    var document = new Document(pdf);
        //    document.Add(new Paragraph("Hello World"));
        //    document.Close();

        //    ms.Position = 0;
        //    return new FileStreamResult(ms, "application/pdf");
        //}

        public async Task<ContentResult?> CreatePdf(int? id)
        //public async Task<FileStreamResult?> CreatePdf(int? id)
        {
            if (id == null || _context.Property == null)
            {
                return null;
            }

            var @property = await _context.Property.FindAsync(id);
            if (@property == null)
            {
                return null;
            }

            var html = System.IO.File.ReadAllText(@"D:\table.html");

            foreach (var propertyInfo in @property.GetType().GetProperties())
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
                    html = html.Replace($"${propertyInfo.Name}$", propertyInfo.GetValue(@property, null)?.ToString());
                    continue;
                }

                if (propertyInfo.PropertyType == typeof(bool) || Nullable.GetUnderlyingType(propertyInfo.PropertyType) == typeof(bool))
                {
                    var boolValue = (bool?)propertyInfo.GetValue(@property, null);
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
                    var date = (DateTime?)propertyInfo.GetValue(@property, null);
                    html = html.Replace($"${propertyInfo.Name}$", date is not null ? $"{date.Value.Year}年{date.Value.Month}月{date.Value.Day}日" : "__年__月__日");
                }

                if (propertyInfo.PropertyType.IsEnum || Nullable.GetUnderlyingType(propertyInfo.PropertyType) is not null && Nullable.GetUnderlyingType(propertyInfo.PropertyType).IsEnum)
                {
                    var enumValue = propertyInfo.GetValue(@property, null);
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
            }

            return new ContentResult
            {
                Content = html,
                ContentType = "text/html"
            };
            
            //var ms = new MemoryStream();

            //var fontProvider = new DefaultFontProvider();
            //fontProvider.AddSystemFonts();

            //// 有bug
            ////var fontProvider = new FontProvider();
            //var sysfont = PdfFontFactory.CreateFont("MHei-Medium", "UniCNS-UCS2-H", PdfFontFactory.EmbeddingStrategy.FORCE_NOT_EMBEDDED);
            ////var sysfont = PdfFontFactory.CreateFont(@"D:\font\NotoSansTC-Medium.otf", PdfEncodings.IDENTITY_H, PdfFontFactory.EmbeddingStrategy.PREFER_EMBEDDED);
            //fontProvider.AddFont(sysfont.GetFontProgram(), "UniCNS-UCS2-H");

            //var properties = new ConverterProperties();
            //properties.SetFontProvider(fontProvider);

            //HtmlConverter.ConvertToPdf(html, ms, properties);
            
            //return new FileStreamResult(new MemoryStream(ms.ToArray()), "application/pdf");
        }

        private bool PropertyExists(int id)
        {
          return (_context.Property?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
