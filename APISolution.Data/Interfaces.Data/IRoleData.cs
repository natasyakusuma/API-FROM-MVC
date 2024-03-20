using APISolution.Domain;


namespace APISolution.Data.Interfaces.Data
{
    public interface IRoleData : ICrud<Role>
    {
        Task AddUserToRole(string username, int roleId);
    }
}
