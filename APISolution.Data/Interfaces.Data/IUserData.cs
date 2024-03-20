using System.Collections.Generic;
using APISolution.Domain;

namespace APISolution.Data.Interfaces.Data
{
    public interface IUserData : ICrud<User>
    {
        Task <IEnumerable<User>> GetAllWithRoles();
        Task <User> GetUserWithRoles(string username);
        Task <User> GetByUsername(string username);
        Task <User> Login(string username, string password);
        Task ChangePassword(string username, string newPassword);
    }
}
