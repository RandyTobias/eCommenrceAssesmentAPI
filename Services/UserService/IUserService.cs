using System.Collections.Generic;
using System.Threading.Tasks;
using eCommerceAssessment.Models;
using eCommerceAssessment.Dtos.User;

namespace eCommerceAssessment.Services.UserService
{
    public interface IUserService
    {
        Task<ServiceResponse<List<UserGetDto>>> GetAllUsers();
        Task<ServiceResponse<UserGetDto>> GetUserById(int id);
        Task<ServiceResponse<List<UserGetDto>>> AddUser(UserRegisterDto newUser);
        Task<ServiceResponse<UserGetDto>> UpdateUser(UserUpdateDto updatedUser);
        Task<ServiceResponse<List<UserGetDto>>> DeleteUser(int id);
    }
}