using APISolution.BLL.DTOs;
using System.Collections.Generic;

namespace APISolution.BLL.Interfaces
{
    public interface IUserBLL
    {
        Task<Task> ChangePassword(string username, string newPassword);
        Task<IEnumerable<UserDTO>> GetAll();
        Task<UserDTO> GetByUsername(string username);
        Task<Task> Insert(UserCreateDTO entity);

        Task<UserDTO> Login(string username, string password);

        Task<UserDTO> GetUserWithRoles(string username);
        Task<IEnumerable<UserDTO>> GetAllWithRoles();
    }
}
