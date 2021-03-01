using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using eCommerceAssessment.Models;
using eCommerceAssessment.Dtos.User;
using eCommerceAssessment.Data;
using Microsoft.EntityFrameworkCore;
using System;

namespace eCommerceAssessment.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        private readonly IAuthRepository _authRepo;
        public UserService(IMapper mapper, DataContext context, IAuthRepository authRepo)
        {
            this._mapper = mapper;
            this._context = context;
            this._authRepo = authRepo;
        }

        private static List<User> users = new List<User>{};

        public async Task<ServiceResponse<List<UserGetDto>>> AddUser(UserRegisterDto newUser)
        {
            ServiceResponse<List<UserGetDto>> serviceResponse = new ServiceResponse<List<UserGetDto>>(); 
            try
            {
                ServiceResponse<int> response = await _authRepo.Register(new User { 
                    fName = newUser.fName,
                    lName = newUser.lName,
                    email = newUser.email,
                    typeid = newUser.type
                }, newUser.password);
                serviceResponse.Data = (_context.Users.Select(u => _mapper.Map<UserGetDto>(u))).ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<UserGetDto>>> GetAllUsers()
        {
            ServiceResponse<List<UserGetDto>> serviceResponse = new ServiceResponse<List<UserGetDto>>();
            try
            {
                List<User> dbUsers = await _context.Users.ToListAsync();
                serviceResponse.Data = dbUsers.Select(u => _mapper.Map<UserGetDto>(u)).ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<UserGetDto>> GetUserById(int id)
        {
            ServiceResponse<UserGetDto> serviceResponse = new ServiceResponse<UserGetDto>();
            try
            {
                User dbUser = await _context.Users.FirstOrDefaultAsync(u => u.id == id);
                serviceResponse.Data = _mapper.Map<UserGetDto>(dbUser); 
            }
            catch(Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<UserGetDto>> UpdateUser(UserUpdateDto updatedUser)
        {
            ServiceResponse<UserGetDto> serviceResponse = new ServiceResponse<UserGetDto>();
            try{
                User user = await _context.Users.FirstOrDefaultAsync(u => u.id == updatedUser.id);

                user.fName = updatedUser.fName;
                user.lName = updatedUser.lName;
                user.email = updatedUser.email;
                _authRepo.CreatePasswordHash(updatedUser.password, out byte[] passwordHash, out byte[] passwordSalt);
                user.passwordHash = passwordHash;
                user.passwordSalt = passwordSalt;
                user.typeid = updatedUser.type;
                // user.type = await _context.UserTypes.FirstOrDefaultAsync(u => u.id == updatedUser.type);

                _context.Users.Update(user);
                await _context.SaveChangesAsync();
                serviceResponse.Data = _mapper.Map<UserGetDto>(user);
                                                                                                                                                                                                        }
            catch (Exception ex) {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<UserGetDto>>> DeleteUser(int id)
        {
            ServiceResponse<List<UserGetDto>> serviceResponse = new ServiceResponse<List<UserGetDto>>();
            try{
                User user = await _context.Users.FirstAsync(u => u.id == id);
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
                
                serviceResponse.Data = (_context.Users.Select(u => _mapper.Map<UserGetDto>(u))).ToList();
            }
            catch (Exception ex) {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }
    }
}