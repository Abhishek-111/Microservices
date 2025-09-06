using System.ComponentModel.DataAnnotations;

namespace CartApi.Models
{
    public class Cart
    {
        [Key]
        public int CartId { get; set; }
        public int ProductId { get; set; }
        public string OrderedBy { get; set; }
        public int ProductQuantity { get;set; }

        // to check if order is placed
        public bool IsPlaced { get; set; }
        public DateTime AddedDate { get; set; }
    }
}
