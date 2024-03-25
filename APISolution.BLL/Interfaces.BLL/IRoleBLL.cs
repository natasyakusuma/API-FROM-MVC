using APISolution.BLL.DTOs;
using System.Collections.Generic;

namespace APISolution.BLL.Interfaces
{
    public interface IRoleBLL
    {
        Task<IEnumerable<RoleDTO>> GetAllRoles();
        Task <Task> AddRole(string roleName);
        Task <Task> AddUserToRole(string username, int roleId);
    }
}
