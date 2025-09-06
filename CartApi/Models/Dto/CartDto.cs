namespace CartApi.Models.Dto
{
    public class CartDto
    {
        public int CartId { get; set; }
        public int ProductId { get; set; }
        public string OrderedBy { get; set; }
        public int ProductQuantity { get; set; }
        public bool IsPlaced { get; set; }
        public DateTime AddedDate { get; set; }
    }
}
