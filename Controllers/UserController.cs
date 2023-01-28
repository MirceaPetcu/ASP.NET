using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProiectV1.Helpers.Attributes;
using ProiectV1.Models;
using ProiectV1.Models.DTOs;
using ProiectV1.Models.Enums;
using ProiectV1.Services.UserServices;
using BCryptNet = BCrypt.Net.BCrypt;

namespace ProiectV1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate(UserRequestDTO user)
        {
            var response = userService.Authenticate(user);
            if(response == null)
            {
                return BadRequest("Username or password is incorect!");
            }
            return Ok(response);
        }

        [HttpPost("create-admin")]
        public IActionResult CreateAdmin(UserRequestDTO user)
        {
            if (userService.FindByUsername(user.UserName) != null)
                return BadRequest("Username already exists!");
            if (userService.FindByEmail(user.Email) != null)
                return BadRequest("Email already exists!");

            var localUser = new User
            {
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Role = Role.Admin,
                Email = user.Email,
                HashPassword = BCryptNet.HashPassword(user.Password)
            };
            
            userService.Create(localUser);
            return Ok();
        }

        //[Authorization(Role.Admin)]
        [HttpGet("get-all-admin")]
        public IActionResult GetAllAdmin()
        {
            var users = userService.GetAllUsers();
            return Ok(users);
        }

        //[Authorization(Role.Admin)]
        [HttpDelete("delete-user-by-admin")]
        public IActionResult DeleteUser(string username)
        {
            if(userService.FindByUsername(username) == null)
            {
                return BadRequest("Ther is no user with this username!");
            }
            userService.DeleteUser(username);
            return Ok();
        }
        [HttpPut("update-user")]
        public IActionResult UpdateUser([FromBody] UserRequestDTO userRequest,[FromQuery]UserDTO userDTO)
        {
            var response = userService.Authenticate(userRequest);
            if (response == null)
            {
                return BadRequest("Username or password is incorect!");
            }
            else
            {
                if (userService.FindByUsername(userDTO.UserName) != null)
                    return BadRequest("Username already exists!");
                if (userService.FindByEmail(userDTO.Email) != null)
                    return BadRequest("Email already exists!");
                //poate sa isi puna aceleasi date
                var role = userService.GetRoleByUsername(userRequest.UserName);
                var userToUpdate = new User
                {

                    UserName = userDTO.UserName,
                    Email = userDTO.Email,
                    HashPassword = userDTO.Password,
                    FirstName = userRequest.FirstName,
                    LastName = userRequest.LastName,
                    Role = role
                    
                };
                userService.Update(userToUpdate);
                return Ok();
            }
        }


    }
}
