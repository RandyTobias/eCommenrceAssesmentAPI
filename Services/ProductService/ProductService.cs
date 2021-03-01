using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using eCommerceAssessment.Models;
using eCommerceAssessment.Dtos.Product;
using eCommerceAssessment.Data;
using Microsoft.EntityFrameworkCore;
using System;

namespace eCommerceAssessment.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        public ProductService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<ServiceResponse<List<ProductGetDto>>> AddProduct(ProductAddDto newProduct)
        {
            ServiceResponse<List<ProductGetDto>> serviceResponse = new ServiceResponse<List<ProductGetDto>>(); 
            Product product = _mapper.Map<Product>(newProduct);
            try
            {
                await _context.Products.AddAsync(product);
                await _context.SaveChangesAsync();
                serviceResponse.Data = (_context.Products.Select(u => _mapper.Map<ProductGetDto>(u))).ToList();
            }
            catch(Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<ProductGetDto>>> GetAllProducts()
        {
            ServiceResponse<List<ProductGetDto>> serviceResponse = new ServiceResponse<List<ProductGetDto>>();
            try
            {
                List<Product> dbProducts = await _context.Products.ToListAsync();
                serviceResponse.Data = dbProducts.Select(u => _mapper.Map<ProductGetDto>(u)).ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<ProductGetDto>> GetProductById(int id)
        {
            ServiceResponse<ProductGetDto> serviceResponse = new ServiceResponse<ProductGetDto>();
            try
            {
                Product dbProduct = await _context.Products.FirstOrDefaultAsync(u => u.id == id);
                serviceResponse.Data = _mapper.Map<ProductGetDto>(dbProduct); 
            }
            catch(Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<ProductGetDto>> UpdateProduct(ProductUpdateDto updatedProduct)
        {
            ServiceResponse<ProductGetDto> serviceResponse = new ServiceResponse<ProductGetDto>();
            try{
                Product product = await _context.Products.FirstOrDefaultAsync(u => u.id == updatedProduct.id);

                product.id = updatedProduct.id;
                product.code = updatedProduct.code;
                product.name = updatedProduct.name;
                product.description = updatedProduct.description;
                product.price = updatedProduct.price;
                product.stock = updatedProduct.stock;

                _context.Products.Update(product);
                await _context.SaveChangesAsync();
                serviceResponse.Data = _mapper.Map<ProductGetDto>(product);
            }
            catch (Exception ex) {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<ProductGetDto>>> DeleteProduct(int id)
        {
            ServiceResponse<List<ProductGetDto>> serviceResponse = new ServiceResponse<List<ProductGetDto>>();
            try{
                Product product = await _context.Products.FirstAsync(u => u.id == id);
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
                
                serviceResponse.Data = (_context.Products.Select(u => _mapper.Map<ProductGetDto>(u))).ToList();
            }
            catch (Exception ex) {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }
    }
}