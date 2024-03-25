using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APISolution.BLL.DTOs;
using APISolution.BLL.Interfaces;
using APISolution.Data.Interfaces.Data;
using APISolution.Domain;
using AutoMapper;
using static Dapper.SqlMapper;

namespace APISolution.BLL
{
    public class RoleBLL : IRoleBLL
    {
        private readonly IRoleData _roleData;
        private readonly IMapper _mapper;

        public async Task<Task> AddRole(string roleName)
        {
            var role = await _roleData.Insert(_mapper.Map<Role>(roleName));
            var roleDto = _mapper.Map<RoleCreateDTO>(role);
            return Task.CompletedTask;


        }

        public async Task<Task> AddUserToRole(string username, int roleId)
        {
            var roles = await _roleData.AddUserToRole(username, roleId);
            var roleDto = _mapper.Map<RoleDTO>(roles);
            return Task.CompletedTask;

        }

        public async Task<IEnumerable<RoleDTO>> GetAllRoles()
        {
            var roles = await _roleData.GetAll();
            var rolesDto = _mapper.Map<IEnumerable<RoleDTO>>(roles);
            return rolesDto;
        }

    
    }
}
