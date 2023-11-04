using InventoryLogic.Setting;
using InventoryLogic.ViewModel;

namespace InventoryLogic.PaginationView
{
    public class BrandPagination
    {
        public string SearchTerm { get; set; }
        public List<BrandView>? Brands { get; set; }
        public int TotalPages { get; set; }
        public int PageNumber { get; set; }
    }
}
