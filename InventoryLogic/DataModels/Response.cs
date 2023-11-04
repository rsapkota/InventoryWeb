namespace InventoryLogic.DataModels
{
    public class Response
	{
        public int ReturnId { get; set; }
        public int StatusCode { get; set; }
        public bool Success { get; set; } = true;
		public string Message { get; set; } = "Invalid!";
	}
}
