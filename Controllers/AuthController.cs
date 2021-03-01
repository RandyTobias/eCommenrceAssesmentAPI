using System.Threading.Tasks;
using eCommerceAssessment.Data;
using eCommerceAssessment.Dtos.User;
using eCommerceAssessment.Models;
using Microsoft.AspNetCore.Mvc;

namespace eCommerceAssessment.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepo;
        public AuthController(IAuthRepository authRepo)
        {
            this._authRepo = authRepo;
        }

        
        [HttpPost("Register")]
        public async Task<IActionResult> Register (UserRegisterDto request)
        {
            ServiceResponse<int> response = await _authRepo.Register(new User { email = request.email }, request.password);
            if(!response.Success) {
                return BadRequest(response);
            }
            return Ok(response);
        }
        
        [HttpPost("Login")]
        public async Task<IActionResult> Login(UserLoginDto request)
        {
            ServiceResponse<string> response = await _authRepo.Login(
                request.email, request.password);
            if(!response.Success) {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}