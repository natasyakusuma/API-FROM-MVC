using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APISolution.BLL.DTOs;
using APISolution.BLL.Interfaces;
using APISolution.Data.Interfaces.Data;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace APISolution.BLL
{
    public class UserBLL : IUserBLL
    {
        private readonly IUserData _userData;
        private readonly IMapper _mapper;

        public UserBLL(IUserData user, IMapper mapper)
        {
            _userData = user;
            _mapper = mapper;
        }

        public async Task<Task> ChangePassword(string username, string newPassword)
        {
            try
            {
                var changePassword = await _userData.ChangePassword(username, newPassword);
                return changePassword;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



        public async Task<IEnumerable<UserDTO>> GetAll()
        {
            var users = await _userData.GetAll();
            var userDTOs = _mapper.Map<IEnumerable<UserDTO>>(users);
            return userDTOs;

        }

        public async Task<IEnumerable<UserDTO>> GetAllWithRoles()
        {
            var users = await _userData.GetAllWithRoles();
            var userDTOs = _mapper.Map<IEnumerable<UserDTO>>(users);
            return userDTOs;
        }

        public Task<UserDTO> GetByUsername(string username)
        {
            throw new NotImplementedException();
        }

        public Task<UserDTO> GetUserWithRoles(string username)
        {
            throw new NotImplementedException();
        }

        public Task<Task> Insert(UserCreateDTO entity)
        {
            throw new NotImplementedException();
        }

        public async Task<UserDTO> Login(string username, string password)
        {
            try
            {
                var login = await _userData.Login(username, password);
                var loginDto = _mapper.Map<UserDTO>(login);
                return loginDto;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
