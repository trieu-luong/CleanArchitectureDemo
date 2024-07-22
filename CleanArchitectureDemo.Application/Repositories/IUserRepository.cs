using CleanArchitectureDemo.Application.DTOs;
using CleanArchitectureDemo.Domain.Entities;

namespace CleanArchitectureDemo.Application.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserDto>> GetUsersAsync();

        Task CreateUserAsync(User user);
    }
}