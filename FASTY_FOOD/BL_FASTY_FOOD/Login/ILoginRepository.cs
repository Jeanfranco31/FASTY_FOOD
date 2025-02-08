using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE_FASTY_FOOD.Dto;
using BE_FASTY_FOOD.DefaultResponse;

namespace BL_FASTY_FOOD.Login
{
    public interface ILoginRepository
    {
        Task<Response> ValidateLogin(LoginDto login);
    }
}
