using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eCommerceAssessment.Models;
using eCommerceAssessment.Services.ShippingProviderService;
using eCommerceAssessment.Dtos.ShippingProvider;
using Microsoft.AspNetCore.Authorization;

namespace eCommerceAssessment.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ShippingProviderController : ControllerBase
    {
        private readonly IShippingProviderService _shippingProviderService;
        public ShippingProviderController(IShippingProviderService shippingProviderService)
        {
            this._shippingProviderService = shippingProviderService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            ServiceResponse<List<ShippingProviderGetDto>> response = await _shippingProviderService.GetAllShippingProviders();
            if (response.Data == null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            ServiceResponse<ShippingProviderGetDto> response = await _shippingProviderService.GetShippingProviderById(id);
            if (response.Data == null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> AddShippingProvider(ShippingProviderAddDto newShippingProvider)
        {
            ServiceResponse<List<ShippingProviderGetDto>> response = await _shippingProviderService.AddShippingProvider(newShippingProvider); 
            if (response.Data == null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateShippingProvider(ShippingProviderUpdateDto updatedShippingProvider)
        {
            ServiceResponse<ShippingProviderGetDto> response = await _shippingProviderService.UpdateShippingProvider(updatedShippingProvider);
            if (response.Data == null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            ServiceResponse<List<ShippingProviderGetDto>> response = await _shippingProviderService.DeleteShippingProvider(id);
            if (response.Data == null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }
    }
}