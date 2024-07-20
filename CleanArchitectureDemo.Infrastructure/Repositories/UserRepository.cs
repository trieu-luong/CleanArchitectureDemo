using CleanArchitectureDemo.Application.DTOs;
using CleanArchitectureDemo.Application.Repositories;
using CleanArchitectureDemo.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureDemo.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public UserRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<IEnumerable<UserDto>> GetUsersAsync()
        {
            return await _applicationDbContext.Users
                .Select(user => new UserDto
                {
                    Id = user.Id,
                    Name = user.Name,
                    Email = user.Email
                }).ToListAsync();
        }
    }
}