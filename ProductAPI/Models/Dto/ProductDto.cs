namespace ProductAPI.Models.Dto
{
    public class ProductDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string ProductDescription { get; set; } = string.Empty;
        public decimal ProductWeight { get; set; }
        public decimal ProductPrice { get; set; }
        public int AvailableQuantity { get; set; } = 0;
        public DateTime DateAdded { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
