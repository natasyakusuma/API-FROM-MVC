using APISolution.BLL.DTOs;
using System.Collections.Generic;

namespace APISolution.BLL.Interfaces
{
    public interface IUserBLL
    {
        Task ChangePassword(string username, string newPassword);
        Task Delete(string username);
        Task<IEnumerable<UserDTO>> GetAll();
        Task <UserDTO> GetByUsername(string username);
        Task Insert(UserCreateDTO entity);
        Task <UserDTO> Login(string username, string password);
        Task <UserDTO> LoginMVC(LoginDTO loginDTO);

        Task <UserDTO> GetUserWithRoles(string username);
        Task <IEnumerable<UserDTO>> GetAllWithRoles();    }
}
