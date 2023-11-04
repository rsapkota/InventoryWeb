using InventoryLogic.Models;
using InventoryLogic.Setting;
using InventoryLogic.ViewModel;

namespace InventoryLogic.PaginationView
{
    public class PaginationModel
    {
        public string SearchTerm { get; set; }
        public List<Users>? user { get; set; }
		public int TotalPages { get; set; }
        public int PageNumber { get; set; }
    }
}
