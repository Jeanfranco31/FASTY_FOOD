using BE_FASTY_FOOD.DefaultResponse;
using BE_FASTY_FOOD.Dto;
using BE_FASTY_FOOD.Models;
using DAC_FASTY_FOOD.Rol;
using Microsoft.AspNetCore.Mvc;

namespace FASTY_FOOD.Controllers
{
    [ApiController]
    public class RolController : Controller
    {
        private readonly RolService _rolService;
        private Response _response = new();

        public RolController(RolService rolService)
        {
            _rolService = rolService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllRols()
        {
            _response = await _rolService.GetAllRols();
            if(_response.code == CodeStatus.ERROR) return BadRequest();
            return Ok(_response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateNewRol([FromBody] RolDto rol)
        {
            _response = await _rolService.CreateRol(rol);
            if (_response.code == CodeStatus.ERROR) return BadRequest(_response);
            return Ok(_response);
        }

        [HttpGet("[action]/{status?}/{profile?}")]
        public async Task<IActionResult> GetRolsByStatus(bool? status, string? profile)
        {
            _response = await _rolService.GetRolByStatusOrProfileName(status, profile);
            if (_response.code == CodeStatus.ERROR) return BadRequest(_response);
            return Ok(_response);
        }
    }
}
