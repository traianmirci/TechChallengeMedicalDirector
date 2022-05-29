using MedicalDirector.API.DTOs.Users;
using MedicalDirector.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace MedicalDirector.Controllers
{

    [ApiController]
    [Route("users")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly UserService _userService;

        public UserController(ILogger<UserController> logger, UserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        [HttpGet]
        public async Task<IEnumerable<UserInfoDTO>> GetUserList()
        {
            var users = await _userService.GetUserList();
            return users;
        }
                 
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserDetails(int id)
        {
            var user = await _userService.GetUserDetails(id);

            if (user == null)
                return NotFound();

            return Ok(user);
        }
    }

}
