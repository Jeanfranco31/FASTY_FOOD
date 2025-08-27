using BE_FASTY_FOOD.DefaultResponse;
using BE_FASTY_FOOD.Dto;
using BE_FASTY_FOOD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL_FASTY_FOOD.Rol
{
    public interface IRolRepository
    {
        Task<Response> GetAllRols();
        Task<Response> CreateRol(RolDto rol);
        Task<Response> GetRolByStatusOrProfileName(bool? status, string profile);
    }
}
