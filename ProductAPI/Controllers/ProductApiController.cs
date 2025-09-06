using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductAPI.Data;
using ProductAPI.Helper;
using ProductAPI.Models;
using ProductAPI.Models.Dto;

namespace ProductApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductApiController : ControllerBase
    {
        private readonly AppDbContext _context;
        private ResponseDto _response;
        public ProductApiController(AppDbContext context)
        {
            _context = context;
            _response = new ResponseDto();
        }

        [HttpGet]
       // [Route("get-all")]
      //  [Authorize]
        public ResponseDto GetAllProducts()
        {
            var productList = new List<ProductDto>();
            try
            {
                IEnumerable<Product> allProducts = _context.Products.ToList();
                if (allProducts.Any())
                {
                    foreach (var product in allProducts)
                    {
                        productList.Add(ApplicationMapper.ProductModelToDto(product));
                    }
                    _response.Result = allProducts;
                }
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpGet]
        [Route("{id:int}")]
        public ResponseDto GetProductById(int id)
        {
            try
            {
                var product = _context.Products.FirstOrDefault(p => p.ProductId == id);
                if (product != null)
                {
                    _response.Result = ApplicationMapper.ProductModelToDto(product);
                }

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        // Allowing only admin to add products to the db
        [HttpPost]
       // [Route("add-product")]
        [Authorize(Roles = "ADMIN")]
        public ResponseDto AddProduct([FromBody] ProductDto product)
        {
            try
            {
                _context.Add(ApplicationMapper.ProductDtoToModel(product));
                _context.SaveChanges();
                _response.Result = product;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpDelete]
        //[Route("delete-product/{id:int}")]
        [Route("{id:int}")]
        [Authorize(Roles ="ADMIN")]
        public ResponseDto DeleteProduct(int id)
        {
            try
            {
                var product = _context.Products.FirstOrDefault(product => product.ProductId == id);
                if(product != null)
                {
                    _context.Products.Remove(product);
                    _context.SaveChanges();
                    _response.IsSuccess = true;
                    _response.Result =product;
                }
            }
            catch(Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpPut]
        //[Route("update-product{id:int}")]
        [Route("{id:int}")]
        [Authorize(Roles = "ADMIN")]
        public ResponseDto UpdateProduct([FromBody] ProductDto updatedProduct, int id)
        {
            // check for availability
            var productToUpdate = _context.Products.FirstOrDefault(p => p.ProductId == id);
            try
            {
                if (productToUpdate != null)
                {
                    productToUpdate.ProductName = updatedProduct.ProductName;
                    productToUpdate.ProductDescription = updatedProduct.ProductDescription;
                    productToUpdate.ProductDescription = updatedProduct.ProductDescription;
                    productToUpdate.ProductPrice = updatedProduct.ProductPrice;
                    productToUpdate.AvailableQuantity = updatedProduct.AvailableQuantity;
                    productToUpdate.LastUpdated = DateTime.Now;

                    _context.SaveChanges();
                    _response.IsSuccess = true;
                    _response.Result = productToUpdate;
                }
            }
            catch(Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
           
        }
    }


}
