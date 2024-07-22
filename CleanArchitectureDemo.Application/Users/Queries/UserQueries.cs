using CleanArchitectureDemo.Application.DTOs;
using CleanArchitectureDemo.Application.Repositories;

namespace CleanArchitectureDemo.Application.Users.Queries
{
    public class UserQueries : IUserQueries
    {
        private readonly IUserRepository _userRepository;

        public UserQueries(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<UserDto>> GetListUser()
        {
            return await _userRepository.GetUsersAsync();
        }
    }
}