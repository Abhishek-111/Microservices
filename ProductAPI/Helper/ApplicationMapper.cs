using ProductAPI.Models;
using ProductAPI.Models.Dto;

namespace ProductAPI.Helper
{
    public static class ApplicationMapper
    {
        public static Product ProductDtoToModel(ProductDto model)
        {
            return new Product
            {
                ProductId = model.ProductId,
                ProductDescription = model.ProductDescription,
                ProductName = model.ProductName,
                ProductPrice = model.ProductPrice,
                AvailableQuantity = model.AvailableQuantity,
                ProductWeight = model.ProductWeight,
                DateAdded = DateTime.Now,
                LastUpdated = DateTime.MinValue
            };
        }

        public static ProductDto ProductModelToDto(Product product)
        {
            return new ProductDto
            {
                ProductId = product.ProductId,
                ProductDescription = product.ProductDescription,
                ProductName = product.ProductName,
                ProductPrice = product.ProductPrice,
                AvailableQuantity = product.AvailableQuantity,
                ProductWeight = product.ProductWeight,
                DateAdded = product.DateAdded,
                LastUpdated = product.LastUpdated,
            };
        }
    }
}
