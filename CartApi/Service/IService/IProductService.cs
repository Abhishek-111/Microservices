using CartApi.Models.Dto;

namespace CartApi.Service.IService
{
    public interface IProductService
    {
        Task<ResponseDto?> GetAllProductAsync();
        Task<ResponseDto?> GetProductByIdAsync(int productId);
        //Task<ResponseDto?> GetProduct(string productId);
        //Task<ResponseDto?> GetProduct(string productId);
        //Task<ResponseDto?> GetProduct(string productId);

    }
}
