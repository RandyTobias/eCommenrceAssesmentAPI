using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using eCommerceAssessment.Models;
using eCommerceAssessment.Dtos.Address;
using eCommerceAssessment.Data;
using Microsoft.EntityFrameworkCore;
using System;

namespace eCommerceAssessment.Services.AddressService
{
    public class AddressService : IAddressService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        public AddressService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        private static List<Address> Addresses = new List<Address>{};

        public async Task<ServiceResponse<List<AddressGetDto>>> AddAddress(AddressAddDto newAddress)
        {
            ServiceResponse<List<AddressGetDto>> serviceResponse = new ServiceResponse<List<AddressGetDto>>(); 
            Address Address = _mapper.Map<Address>(newAddress);
            try
            {
                await _context.Addresses.AddAsync(Address);
                await _context.SaveChangesAsync();
                serviceResponse.Data = (_context.Addresses.Select(u => _mapper.Map<AddressGetDto>(u))).ToList();
            }
            catch(Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<AddressGetDto>>> GetAllAddresses()
        {
            ServiceResponse<List<AddressGetDto>> serviceResponse = new ServiceResponse<List<AddressGetDto>>();
            try
            {
                List<Address> dbAddresss = await _context.Addresses.ToListAsync();
                serviceResponse.Data = dbAddresss.Select(u => _mapper.Map<AddressGetDto>(u)).ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<AddressGetDto>> GetAddressById(int id)
        {
            ServiceResponse<AddressGetDto> serviceResponse = new ServiceResponse<AddressGetDto>();
            try
            {
                Address dbAddress = await _context.Addresses.FirstOrDefaultAsync(a => a.id == id);
                serviceResponse.Data = _mapper.Map<AddressGetDto>(dbAddress); 
            }
            catch(Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<AddressGetDto>> UpdateAddress(AddressUpdateDto updatedAddress)
        {
            ServiceResponse<AddressGetDto> serviceResponse = new ServiceResponse<AddressGetDto>();
            try{
                Address Address = await _context.Addresses.FirstOrDefaultAsync(a => a.id == updatedAddress.id);

                Address.street1 = updatedAddress.street1;
                Address.street2 = updatedAddress.street2;
                Address.city = updatedAddress.city;
                Address.postalCode = updatedAddress.postalCode;
                Address.postalCodeExt = updatedAddress.postalCodeExt;
                Address.isPrimary = updatedAddress.isPrimary;
                Address.userid = updatedAddress.user;

                _context.Addresses.Update(Address);
                await _context.SaveChangesAsync();
                serviceResponse.Data = _mapper.Map<AddressGetDto>(Address);
            }
            catch (Exception ex) {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<AddressGetDto>>> DeleteAddress(int id)
        {
            ServiceResponse<List<AddressGetDto>> serviceResponse = new ServiceResponse<List<AddressGetDto>>();
            try{
                Address Address = await _context.Addresses.FirstAsync(a => a.id == id);
                _context.Addresses.Remove(Address);
                await _context.SaveChangesAsync();
                
                serviceResponse.Data = (_context.Addresses.Select(a => _mapper.Map<AddressGetDto>(a))).ToList();
            }
            catch (Exception ex) {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }
    }
}