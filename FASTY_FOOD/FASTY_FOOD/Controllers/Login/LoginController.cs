using BE_FASTY_FOOD.DefaultResponse;
using BE_FASTY_FOOD.Dto;
using DAC_FASTY_FOOD.Login;
using Microsoft.AspNetCore.Mvc;

namespace FASTY_FOOD.Controllers.Login
{
    [ApiController]
    public class LoginController : Controller
    {
        private readonly LoginService _loginService;
        public LoginController(LoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost("[action]")]

        public async Task<IActionResult> ValidateLogin(LoginDto login)
        {
            Response response = await _loginService.ValidateLogin(login);
            if(response.code == CodeStatus.ERROR)
            {
                return BadRequest();
            }
            return Ok(response);
        }

    }
}
