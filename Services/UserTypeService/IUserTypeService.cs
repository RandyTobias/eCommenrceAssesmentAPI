using System.Collections.Generic;
using System.Threading.Tasks;
using eCommerceAssessment.Models;
using eCommerceAssessment.Dtos.UserType;

namespace eCommerceAssessment.Services.UserTypeService
{
    public interface IUserTypeService
    {
        Task<ServiceResponse<List<UserTypeGetDto>>> GetAllUserTypes();
        Task<ServiceResponse<UserTypeGetDto>> GetUserTypeById(int id);
        Task<ServiceResponse<List<UserTypeGetDto>>> AddUserType(UserTypeAddDto newUserType);
        Task<ServiceResponse<UserTypeGetDto>> UpdateUserType(UserTypeUpdateDto updatedUserType);
        Task<ServiceResponse<List<UserTypeGetDto>>> DeleteUserType(int id);
    }
}