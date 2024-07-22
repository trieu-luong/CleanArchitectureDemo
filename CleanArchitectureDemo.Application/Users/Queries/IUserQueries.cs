using CleanArchitectureDemo.Application.DTOs;

namespace CleanArchitectureDemo.Application.Users.Queries
{
    public interface IUserQueries
    {
        Task<IEnumerable<UserDto>> GetListUser();
    }
}