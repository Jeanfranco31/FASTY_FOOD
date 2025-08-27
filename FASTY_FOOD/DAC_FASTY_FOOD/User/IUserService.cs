using BE_FASTY_FOOD.DefaultResponse;
using BE_FASTY_FOOD.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAC_FASTY_FOOD.User
{
    public interface IUserService
    {
        Task<Response> GetAllUsers();
        Task<Response> CreateNewUser(UserDto user);
        Task<Response> UpdateUser(UserDto user);
        Task<Response> FoundByIdentification(string identification);
        Task<Response> FoundByCompanyName(string companyName);
    }
}
