using Microsoft.AspNetCore.Mvc;
using MyProject.Data;
using MyProject.Models.Items;
using MyProject.ViewModels;
using Newtonsoft.Json;

namespace MyProject.Controllers
{
    public class LandInventoriesViewComponent : ViewComponent
    {
        private readonly MyProjectContext _context;

        public LandInventoriesViewComponent(MyProjectContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(List<LandInventoryItem>? landInventoryItems)
        {
            if (landInventoryItems is not null)
                return View("Default", new CaseSourceLandInventoryItemsViewModel() { LandInventoryItems = landInventoryItems });
            else
                return View("Default");
        }
    }
}
