using CartApi.Models;
using CartApi.Models.Dto;

namespace CartApi.Helper
{
    public static class ApplicationMapper
    {
        public static CartDto CartModelToDto(Cart cart)
        {
            return new CartDto
            {
                CartId = cart.CartId,
                ProductId = cart.ProductId,
                OrderedBy = cart.OrderedBy,
                ProductQuantity = cart.ProductQuantity,
                AddedDate = cart.AddedDate,
                IsPlaced = cart.IsPlaced,
            };
        }
        public static Cart CartDtoToModel(CartDto cart,string user)
        {
            return new Cart
            {
                ProductId = cart.ProductId,
                OrderedBy = user,
                ProductQuantity = cart.ProductQuantity,
                AddedDate = DateTime.Now,
                IsPlaced = false

            };
        }
    }
}
