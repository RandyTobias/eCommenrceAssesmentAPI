using System.Collections.Generic;
using System.Threading.Tasks;
using eCommerceAssessment.Models;
using eCommerceAssessment.Dtos.Address;

namespace eCommerceAssessment.Services.AddressService
{
    public interface IAddressService
    {
        Task<ServiceResponse<List<AddressGetDto>>> GetAllAddresses();
        Task<ServiceResponse<AddressGetDto>> GetAddressById(int id);
        Task<ServiceResponse<List<AddressGetDto>>> AddAddress(AddressAddDto newAddress);
        Task<ServiceResponse<AddressGetDto>> UpdateAddress(AddressUpdateDto updatedAddress);
        Task<ServiceResponse<List<AddressGetDto>>> DeleteAddress(int id);
    }
}