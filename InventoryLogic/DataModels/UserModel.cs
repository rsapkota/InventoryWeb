﻿namespace InventoryLogic.DataModels
{
	public class UserModel
	{
		public int UserId { get; set; }
		public string FullName { get; set; }
		public string Email { get; set; } = string.Empty;
		public DateTime DateCreated { get; set; } = DateTime.Now;
		public string Role { get; set; }
		public string Gender { get; set; }
		public string Address { get; set; }
		public string Image { get; set; }
		public string City { get; set; }
		public string Phone { get; set; }
		public string MobileNo { get; set; }
		public string ShopName { get; set; }
		public bool IsActive { get; set; }
		public DateTime? CreatedOn { get; set; }
		public DateTime? ModifiedOn { get; set; }
	}
}
