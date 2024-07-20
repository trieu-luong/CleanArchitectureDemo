using CleanArchitectureDemo.Application.DTOs;

namespace CleanArchitectureDemo.Application.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserDto>> GetUsersAsync();
    }
}