using APISolution.Domain;


namespace APISolution.Data.Interfaces.Data
{
    public interface IRoleData : ICrud<Role>
    {
        Task<Task> AddUserToRole(string username, int roleId);
    }
}
