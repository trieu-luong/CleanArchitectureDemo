using CleanArchitectureDemo.Application.DTOs;
using CleanArchitectureDemo.Application.Interfaces;
using CleanArchitectureDemo.Application.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureDemo.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<UserDto>> GetListUser()
        {
            return await _userRepository.GetUsersAsync();
        }
    }
}
