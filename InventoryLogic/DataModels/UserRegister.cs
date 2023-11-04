using System.ComponentModel.DataAnnotations;

namespace InventoryLogic.DataModels
{
    public class UserRegister
    {
        [Required]
		public string FullName { get; set; }
		[Required, EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required, StringLength(100, MinimumLength = 6)]
        public string Password { get; set; } = string.Empty;
        [Compare("Password", ErrorMessage = "The passwords do not match.")]
        public string ConfirmPassword { get; set; } = string.Empty;
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
