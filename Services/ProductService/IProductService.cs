using System.Collections.Generic;
using System.Threading.Tasks;
using eCommerceAssessment.Models;
using eCommerceAssessment.Dtos.Product;

namespace eCommerceAssessment.Services.ProductService
{
    public interface IProductService
    {
        Task<ServiceResponse<List<ProductGetDto>>> GetAllProducts();
        Task<ServiceResponse<ProductGetDto>> GetProductById(int id);
        Task<ServiceResponse<List<ProductGetDto>>> AddProduct(ProductAddDto newProduct);
        Task<ServiceResponse<ProductGetDto>> UpdateProduct(ProductUpdateDto updatedProduct);
        Task<ServiceResponse<List<ProductGetDto>>> DeleteProduct(int id);
    }
}