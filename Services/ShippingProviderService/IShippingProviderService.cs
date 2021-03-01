using System.Collections.Generic;
using System.Threading.Tasks;
using eCommerceAssessment.Models;
using eCommerceAssessment.Dtos.ShippingProvider;

namespace eCommerceAssessment.Services.ShippingProviderService
{
    public interface IShippingProviderService
    {
        Task<ServiceResponse<List<ShippingProviderGetDto>>> GetAllShippingProviders();
        Task<ServiceResponse<ShippingProviderGetDto>> GetShippingProviderById(int id);
        Task<ServiceResponse<List<ShippingProviderGetDto>>> AddShippingProvider(ShippingProviderAddDto newShippingProvider);
        Task<ServiceResponse<ShippingProviderGetDto>> UpdateShippingProvider(ShippingProviderUpdateDto updatedShippingProvider);
        Task<ServiceResponse<List<ShippingProviderGetDto>>> DeleteShippingProvider(int id);
    }
}