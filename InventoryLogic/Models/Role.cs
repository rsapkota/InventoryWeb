using System.ComponentModel.DataAnnotations;

namespace InventoryLogic.Models
{
	public class Role
    {
        [Key]
        public int RoleId { get; set; }
        public string Name { get; set; }
    }
}
