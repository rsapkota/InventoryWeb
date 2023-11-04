using InventoryLogic.Setting;
using System;
using System.ComponentModel.DataAnnotations;

namespace InventoryLogic.ViewModel
{
    public class BrandView
    {
        public int BrandId { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string TenantId { get; set; } = null!;
        public string SearchTerm { get; set; }
        public List<BrandView>? Brands { get; set; }
        public int TotalPages { get; set; }
        public int PageNumber { get; set; }

    }
}
