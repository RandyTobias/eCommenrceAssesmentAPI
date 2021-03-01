using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eCommerceAssessment.Models;
using eCommerceAssessment.Services.ProductService;
using eCommerceAssessment.Dtos.Product;
using Microsoft.AspNetCore.Authorization;

namespace eCommerceAssessment.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            this._productService = productService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            ServiceResponse<List<ProductGetDto>> response = await _productService.GetAllProducts();
            if (response.Data == null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            ServiceResponse<ProductGetDto> response = await _productService.GetProductById(id);
            if (response.Data == null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(ProductAddDto newProduct)
        {
            ServiceResponse<List<ProductGetDto>> response = await _productService.AddProduct(newProduct); 
            if (response.Data == null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(ProductUpdateDto updatedProduct)
        {
            ServiceResponse<ProductGetDto> response = await _productService.UpdateProduct(updatedProduct);
            if (response.Data == null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            ServiceResponse<List<ProductGetDto>> response = await _productService.DeleteProduct(id);
            if (response.Data == null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }
    }
}