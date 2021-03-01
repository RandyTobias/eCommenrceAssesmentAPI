using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using eCommerceAssessment.Models;
using eCommerceAssessment.Dtos.ShippingProvider;
using eCommerceAssessment.Data;
using Microsoft.EntityFrameworkCore;
using System;

namespace eCommerceAssessment.Services.ShippingProviderService
{
    public class ShippingProviderService : IShippingProviderService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        public ShippingProviderService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<ServiceResponse<List<ShippingProviderGetDto>>> AddShippingProvider(ShippingProviderAddDto newShippingProvider)
        {
            ServiceResponse<List<ShippingProviderGetDto>> serviceResponse = new ServiceResponse<List<ShippingProviderGetDto>>(); 
            ShippingProvider shippingProvider = _mapper.Map<ShippingProvider>(newShippingProvider);
            try
            {
                await _context.ShippingProviders.AddAsync(shippingProvider);
                await _context.SaveChangesAsync();
                serviceResponse.Data = (_context.ShippingProviders.Select(u => _mapper.Map<ShippingProviderGetDto>(u))).ToList();
            }
            catch(Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<ShippingProviderGetDto>>> GetAllShippingProviders()
        {
            ServiceResponse<List<ShippingProviderGetDto>> serviceResponse = new ServiceResponse<List<ShippingProviderGetDto>>();
            try
            {
                List<ShippingProvider> dbShippingProviders = await _context.ShippingProviders.ToListAsync();
                serviceResponse.Data = dbShippingProviders.Select(u => _mapper.Map<ShippingProviderGetDto>(u)).ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<ShippingProviderGetDto>> GetShippingProviderById(int id)
        {
            ServiceResponse<ShippingProviderGetDto> serviceResponse = new ServiceResponse<ShippingProviderGetDto>();
            try
            {
                ShippingProvider dbShippingProvider = await _context.ShippingProviders.FirstOrDefaultAsync(u => u.id == id);
                serviceResponse.Data = _mapper.Map<ShippingProviderGetDto>(dbShippingProvider); 
            }
            catch(Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<ShippingProviderGetDto>> UpdateShippingProvider(ShippingProviderUpdateDto updatedShippingProvider)
        {
            ServiceResponse<ShippingProviderGetDto> serviceResponse = new ServiceResponse<ShippingProviderGetDto>();
            try{
                ShippingProvider shippingProvider = await _context.ShippingProviders.FirstOrDefaultAsync(u => u.id == updatedShippingProvider.id);

                shippingProvider.id = updatedShippingProvider.id;
                shippingProvider.name = updatedShippingProvider.name;
                shippingProvider.nameShort = updatedShippingProvider.nameShort;
                shippingProvider.rateFlat = updatedShippingProvider.rateFlat;

                _context.ShippingProviders.Update(shippingProvider);
                await _context.SaveChangesAsync();
                serviceResponse.Data = _mapper.Map<ShippingProviderGetDto>(shippingProvider);
            }
            catch (Exception ex) {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<ShippingProviderGetDto>>> DeleteShippingProvider(int id)
        {
            ServiceResponse<List<ShippingProviderGetDto>> serviceResponse = new ServiceResponse<List<ShippingProviderGetDto>>();
            try{
                ShippingProvider shippingProvider = await _context.ShippingProviders.FirstAsync(u => u.id == id);
                _context.ShippingProviders.Remove(shippingProvider);
                await _context.SaveChangesAsync();
                
                serviceResponse.Data = (_context.ShippingProviders.Select(u => _mapper.Map<ShippingProviderGetDto>(u))).ToList();
            }
            catch (Exception ex) {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }
    }
}