using MyProject.Models;
using MyProject.Models.Items;

namespace MyProject.ViewModels
{
    public class CaseSourceLandInventoryItemsViewModel : CaseSource
    {
        public List<LandInventoryItem>? LandInventoryItems { get; set; }
    }
}
