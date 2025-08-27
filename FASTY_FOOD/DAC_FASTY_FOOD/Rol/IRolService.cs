using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE_FASTY_FOOD.DefaultResponse;
using BE_FASTY_FOOD.Dto;

namespace DAC_FASTY_FOOD.Rol
{
    public interface IRolService
    {
        Task<Response> GetAllRols();
        Task<Response> CreateRol(RolDto rol);
        Task<Response> GetRolByStatusOrProfileName(bool? status, string profile);

    }
}
