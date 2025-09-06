using CartApi.Models.Dto;
using CartApi.Utility;
using static CartApi.Utility.StaticDetails;


namespace CartApi.Service.IService
{
    public class ProductService : IProductService
    {
        private readonly IBaseService _baseService;
        public ProductService(IBaseService baseService)
        {
                _baseService = baseService;
        }
        public async Task<ResponseDto?> GetAllProductAsync()
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = Utility.StaticDetails.ApiType.GET,
                Url = StaticDetails.ProductApiBase+ "/api/ProductApi"
            });
        }

        public async Task<ResponseDto?> GetProductByIdAsync(int productId)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = ApiType.GET,
                Url = StaticDetails.ProductApiBase +"/api/ProductApi/"+ productId
            }) ;
        }
    }
}
