namespace CartApi.Models.Dto
{
    public class CartDetailsDto
    {
        public int CartId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal ProductPrice { get; set; }
        public decimal ProductWeight { get; set; }
        public string OrderedBy { get; set; }
        public int ProductQuantity { get; set; }
        public bool IsPlaced { get; set; }
        public DateTime AddedDate { get; set; }
    }
}
