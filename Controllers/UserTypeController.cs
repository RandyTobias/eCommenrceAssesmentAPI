using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eCommerceAssessment.Models;
using eCommerceAssessment.Services.UserTypeService;
using eCommerceAssessment.Dtos.UserType;
using Microsoft.AspNetCore.Authorization;

namespace eCommerceAssessment.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UserTypeController : ControllerBase
    {
        private readonly IUserTypeService _userTypeService;
        public UserTypeController(IUserTypeService userTypeService)
        {
            this._userTypeService = userTypeService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            ServiceResponse<List<UserTypeGetDto>> response = await _userTypeService.GetAllUserTypes();
            if (response.Data == null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            ServiceResponse<UserTypeGetDto> response = await _userTypeService.GetUserTypeById(id);
            if (response.Data == null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> AddUserType(UserTypeAddDto newUserType)
        {
            ServiceResponse<List<UserTypeGetDto>> response = await _userTypeService.AddUserType(newUserType); 
            if (response.Data == null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUserType(UserTypeUpdateDto updatedUserType)
        {
            ServiceResponse<UserTypeGetDto> response = await _userTypeService.UpdateUserType(updatedUserType);
            if (response.Data == null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            ServiceResponse<List<UserTypeGetDto>> response = await _userTypeService.DeleteUserType(id);
            if (response.Data == null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }
    }
}