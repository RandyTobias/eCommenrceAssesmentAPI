using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using eCommerceAssessment.Models;
using eCommerceAssessment.Dtos.UserType;
using eCommerceAssessment.Data;
using Microsoft.EntityFrameworkCore;
using System;

namespace eCommerceAssessment.Services.UserTypeService
{
    public class UserTypeService : IUserTypeService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        public UserTypeService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        private static List<User> userTypes = new List<User>{};

        public async Task<ServiceResponse<List<UserTypeGetDto>>> AddUserType(UserTypeAddDto newUserType)
        {
            ServiceResponse<List<UserTypeGetDto>> serviceResponse = new ServiceResponse<List<UserTypeGetDto>>(); 
            UserType userType = _mapper.Map<UserType>(newUserType);
            try
            {
                await _context.UserTypes.AddAsync(userType);
                await _context.SaveChangesAsync();
                serviceResponse.Data = (_context.UserTypes.Select(u => _mapper.Map<UserTypeGetDto>(u))).ToList();
            }
            catch(Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<UserTypeGetDto>>> GetAllUserTypes()
        {
            ServiceResponse<List<UserTypeGetDto>> serviceResponse = new ServiceResponse<List<UserTypeGetDto>>();
            try
            {
                List<UserType> dbUserTypes = await _context.UserTypes.ToListAsync();
                serviceResponse.Data = dbUserTypes.Select(u => _mapper.Map<UserTypeGetDto>(u)).ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<UserTypeGetDto>> GetUserTypeById(int id)
        {
            ServiceResponse<UserTypeGetDto> serviceResponse = new ServiceResponse<UserTypeGetDto>();
            try
            {
                UserType dbUserType = await _context.UserTypes.FirstOrDefaultAsync(u => u.id == id);
                serviceResponse.Data = _mapper.Map<UserTypeGetDto>(dbUserType); 
            }
            catch(Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<UserTypeGetDto>> UpdateUserType(UserTypeUpdateDto updatedUserType)
        {
            ServiceResponse<UserTypeGetDto> serviceResponse = new ServiceResponse<UserTypeGetDto>();
            try{
                UserType userType = await _context.UserTypes.FirstOrDefaultAsync(u => u.id == updatedUserType.id);

                userType.id = updatedUserType.id;
                userType.type = updatedUserType.type;
                userType.accessLevel = updatedUserType.accessLevel;

                _context.UserTypes.Update(userType);
                await _context.SaveChangesAsync();
                serviceResponse.Data = _mapper.Map<UserTypeGetDto>(userType);
            }
            catch (Exception ex) {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<UserTypeGetDto>>> DeleteUserType(int id)
        {
            ServiceResponse<List<UserTypeGetDto>> serviceResponse = new ServiceResponse<List<UserTypeGetDto>>();
            try{
                UserType userType = await _context.UserTypes.FirstAsync(u => u.id == id);
                _context.UserTypes.Remove(userType);
                await _context.SaveChangesAsync();
                
                serviceResponse.Data = (_context.UserTypes.Select(u => _mapper.Map<UserTypeGetDto>(u))).ToList();
            }
            catch (Exception ex) {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }
    }
}