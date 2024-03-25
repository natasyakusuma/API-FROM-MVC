using APISolution.BLL.DTOs;
using APISolution.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace APISolution.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleBLL _roleBLL;

        public RoleController(IRoleBLL roleBLL)
        {
            _roleBLL = roleBLL;
        }

        [HttpGet]
        public async Task<IEnumerable<RoleDTO>> Get()
        {
            var results = await _roleBLL.GetAllRoles();
            return results;
        }
    }
}
