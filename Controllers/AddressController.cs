using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eCommerceAssessment.Models;
using eCommerceAssessment.Services.AddressService;
using eCommerceAssessment.Dtos.Address;
using Microsoft.AspNetCore.Authorization;

namespace eCommerceAssessment.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _addressService;
        public AddressController(IAddressService addressService)
        {
            this._addressService = addressService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            ServiceResponse<List<AddressGetDto>> response = await _addressService.GetAllAddresses();
            if (response.Data == null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            ServiceResponse<AddressGetDto> response = await _addressService.GetAddressById(id);
            if (response.Data == null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> AddAddress(AddressAddDto newAddress)
        {
            ServiceResponse<List<AddressGetDto>> response = await _addressService.AddAddress(newAddress); 
            if (response.Data == null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAddress(AddressUpdateDto updatedAddress)
        {
            ServiceResponse<AddressGetDto> response = await _addressService.UpdateAddress(updatedAddress);
            if (response.Data == null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            ServiceResponse<List<AddressGetDto>> response = await _addressService.DeleteAddress(id);
            if (response.Data == null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }
    }
}