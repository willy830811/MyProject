using Microsoft.AspNetCore.Mvc;
using MyProject.Data;
using MyProject.Models.Items;
using MyProject.ViewModels;

namespace MyProject.Controllers
{
    public class RealEstateDetailLandInventoriesViewComponent : ViewComponent
    {
        private readonly MyProjectContext _context;

        public RealEstateDetailLandInventoriesViewComponent(MyProjectContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(List<RealEstateDetailLandInventoryItem>? landInventoryItems)
        {
            if (landInventoryItems is not null)
                return View("Default", new RealEstateDetailViewModel() { LandInventoryItems = landInventoryItems });
            else
                return View("Default");
        }
    }
}
