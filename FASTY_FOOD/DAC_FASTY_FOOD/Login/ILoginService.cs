using BE_FASTY_FOOD.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE_FASTY_FOOD.DefaultResponse;

namespace DAC_FASTY_FOOD.Login
{
    public interface ILoginService
    {
        Task<Response> ValidateLogin(LoginDto login);

    }
}
