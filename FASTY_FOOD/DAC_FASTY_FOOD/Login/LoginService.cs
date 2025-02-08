using BE_FASTY_FOOD.DefaultResponse;
using BE_FASTY_FOOD.Dto;
using BL_FASTY_FOOD.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAC_FASTY_FOOD.Login
{
    public class LoginService : ILoginService
    {
        private readonly LoginRepository _loginRepository;
        public LoginService(LoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }

        public async Task<Response> ValidateLogin(LoginDto login)
        {
            return await _loginRepository.ValidateLogin(login);
        }
    }
}
