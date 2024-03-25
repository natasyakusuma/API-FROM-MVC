using APISolution.BLL.DTOs;
using APISolution.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using APISolution.Helpers;
using Microsoft.Extensions.Options;
using System.Security.Cryptography;


namespace APISolution.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserBLL _userBLL;
        private readonly AppSettings _appSettings;

        public UserController(IUserBLL userBLL, IOptions<AppSettings> appSettings)
        {
            _userBLL = userBLL;
            _appSettings = appSettings.Value;
        }

        [HttpGet]
        public async Task<IEnumerable<UserDTO>> GetAll()
        {
            var result = await _userBLL.GetAll();
            return result;
        }

        //Change Password
        [HttpPut]
        public async Task<IActionResult> ChangePassword(string username, string password)
        {
            try
            {
                // Check the account
                var user = await _userBLL.GetByUsername(username);
                if (user == null)
                {
                    throw new Exception("User isnt found"); // Use NotFound property without parentheses
                }

                await _userBLL.ChangePassword(username, password);
                return Ok("Password changed successfully."); // Use Ok property without parentheses
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }


        [HttpGet("/GetAllWithRoles")]
        public async Task<IEnumerable<UserDTO>> GetAllWithRoles()
        {
            var result = await _userBLL.GetAllWithRoles();
            return result;

        }

        [HttpPost]
        public async Task<ActionResult<LoginDTO>> Login(LoginDTO loginDTO)
        {
            try
            {
                var user = await _userBLL.Login(loginDTO.Username, loginDTO.Password);
                if (user == null)
                {
                    throw new Exception("Login Error");
                }
                var userRoles = await _userBLL.GetUserWithRoles(loginDTO.Username);

                //add auth
                List<Claim> claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.Name, loginDTO.Username));
                foreach (var role in userRoles.Roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, userRoles.Username));
                }

                //konfigurasi token JWT
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(claims),
                    Expires = DateTime.Now.AddHours(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                        SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var userWithToken = new LoginDTO
                {
                    Username = loginDTO.Username,
                    Password = loginDTO.Password,
                    Token = tokenHandler.WriteToken(token)
                };
                return userWithToken;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
