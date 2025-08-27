using BE_FASTY_FOOD.DefaultResponse;
using BE_FASTY_FOOD.Dto;
using BL_FASTY_FOOD.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAC_FASTY_FOOD.User
{
    public class UserService : IUserService
    {
        private readonly UserRepository _userRepository = new UserRepository();
        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;   
        }

        public async Task<Response> CreateNewUser(UserDto user)
        {
            return await _userRepository.CreateNewUser(user);
        }

        public async Task<Response> FoundByCompanyName(string companyName)
        {
            return await _userRepository.FoundByCompanyName(companyName);
        }

        public async Task<Response> FoundByIdentification(string identification)
        {
            return await _userRepository.FoundByIdentification(identification);
        }

        public async Task<Response> GetAllUsers()
        {
            return await _userRepository.GetAllUsers();
        }

        public async Task<Response> UpdateUser(UserDto user)
        {
            return await _userRepository.UpdateUser(user);
        }
    }
}
