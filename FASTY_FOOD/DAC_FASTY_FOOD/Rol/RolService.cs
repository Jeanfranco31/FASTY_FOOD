using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL_FASTY_FOOD.Rol;
using BE_FASTY_FOOD.DefaultResponse;
using BE_FASTY_FOOD.Dto;

namespace DAC_FASTY_FOOD.Rol
{
    public class RolService : IRolService
    {
        private readonly RolRepository _rolRepository;

        public RolService(RolRepository rolRepository)
        {
            _rolRepository = rolRepository;
        }

        public async Task<Response> CreateRol(RolDto rol)
        {
            return await _rolRepository.CreateRol(rol);
        }

        public async Task<Response> GetAllRols()
        {
            return await _rolRepository.GetAllRols();
        }

        public async Task<Response> GetRolByStatusOrProfileName(bool? status, string profile)
        {
            return await _rolRepository.GetRolByStatusOrProfileName(status, profile);
        }
    }
}
