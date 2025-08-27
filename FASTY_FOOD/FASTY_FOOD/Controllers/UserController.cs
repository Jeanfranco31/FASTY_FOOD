using BE_FASTY_FOOD.DefaultResponse;
using BE_FASTY_FOOD.Dto;
using DAC_FASTY_FOOD.User;
using Microsoft.AspNetCore.Mvc;

namespace FASTY_FOOD.Controllers
{
    [ApiController]
    public class UserController : Controller
    {
        private readonly UserService _userService;
        Response _response;
        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateUser([FromBody] UserDto user)
        {
            _response = await _userService.CreateNewUser(user);
            if (_response.code == CodeStatus.ERROR) return BadRequest(user);
            return Ok(user);
        }

        [HttpGet("[action]/{companyName}")]
        public async Task<IActionResult> FoundByCompanyName(string companyName)
        {
            _response = await _userService.FoundByCompanyName(companyName);
            if (_response.code == CodeStatus.ERROR) return BadRequest(_response);
            return Ok(_response);
        }

        [HttpGet("[action]/{identification}")]
        public async Task<IActionResult> FoundByIdentification(string identification)
        {
            _response = await _userService.FoundByIdentification(identification);
            if (_response.code == CodeStatus.ERROR) return BadRequest(_response);
            return Ok(_response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllUsers()
        {
            _response = await _userService.GetAllUsers();
            if (_response.code == CodeStatus.ERROR) return BadRequest(_response);
            return Ok(_response);
        }

        [HttpPost("[action]")]
        public async Task<Response> UpdateUser([FromBody] UserDto user)
        {
            return await _userService.UpdateUser(user);
        }
    }
}
