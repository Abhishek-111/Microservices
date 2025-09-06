using CartApi.Data;
using CartApi.Helper;
using CartApi.Models.Dto;
using CartApi.Service.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Security.Claims;

namespace CartApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartApiController : ControllerBase
    {
        private readonly AppDbContext _context;
        protected ResponseDto _response;
        private readonly IProductService _productService;
        public CartApiController(AppDbContext context, IProductService productService)
        {
            _context = context;
            _response = new ResponseDto();
            _productService = productService;
        }

        [HttpPost]
       [Authorize]
        public ResponseDto AddToCart([FromBody] CartDto cartItem)
        {
            try
            {

                string user = GetUserName();
                //string user = "amit@gmail.com";
                _context.Add(ApplicationMapper.CartDtoToModel(cartItem, user));
                _context.SaveChanges();
                _response.Result = cartItem;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllProduct()
        {
           // var currentUser = GetUserName();
            List<ProductDto?> list = new();

            ResponseDto? response = await _productService.GetAllProductAsync();
            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<ProductDto>>(Convert.ToString(response.Result));
            }
            return Ok(list);
        }
        [HttpGet]
        [Authorize]
        [Route("get-user-cart")]
        public async Task<IActionResult> GetUserCartItems()
        {
            List<CartDto?> list = new();
            var cartDetails= new List<CartDetailsDto>();
            ProductDto? product = new();

            var user = GetUserName();
            var cartItems = _context.Carts.Where(x => x.OrderedBy == user && x.IsPlaced == false).ToList();
            if (cartItems != null)
            {
              
                //
                foreach (var cartItem in cartItems)
                {
                    // fetch that product
                   
                    ResponseDto? response = await _productService.GetProductByIdAsync(cartItem.ProductId);
                    if (response != null && response.IsSuccess)
                    {
                        product = JsonConvert.DeserializeObject<ProductDto>(Convert.ToString(response.Result));
                    }

                    cartDetails.Add(new CartDetailsDto()
                    {
                        CartId = cartItem.CartId,
                        ProductName = product.ProductName,
                        ProductDescription = product.ProductDescription,
                        ProductPrice = product.ProductPrice,
                        ProductWeight = product.ProductWeight,
                        OrderedBy = user,
                        ProductQuantity = cartItem.ProductQuantity,
                        IsPlaced = cartItem.IsPlaced,
                        AddedDate = cartItem.AddedDate
                    });
                    // add to cart Details dto
                    //list.Add(ApplicationMapper.CartModelToDto(cartItem));
                }
                return Ok(cartDetails);
            }
            return BadRequest();
            
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetProductById([FromRoute] int productId)
        {
            ProductDto? product = new();
            ResponseDto? response = await _productService.GetProductByIdAsync(productId);
            if (response != null && response.IsSuccess)
            {
                product = JsonConvert.DeserializeObject<ProductDto>(Convert.ToString(response.Result));
            }
            return Ok(product);
        }


        // Get User from HttpContext
        private string GetUserName()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                var userClaims = identity.Claims;
                return userClaims.FirstOrDefault(u => u.Type == ClaimTypes.Email)?.Value;
            }
            return string.Empty;
        }
    }
}
