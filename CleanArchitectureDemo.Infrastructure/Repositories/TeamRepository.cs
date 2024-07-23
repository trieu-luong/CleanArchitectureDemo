using CleanArchitectureDemo.Application.DTOs;
using CleanArchitectureDemo.Application.Repositories;
using CleanArchitectureDemo.Domain.Entities;
using CleanArchitectureDemo.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureDemo.Infrastructure.Repositories
{
    public class TeamRepository : ITeamRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public TeamRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<IEnumerable<TeamDto>> GetTeamsAsync()
        {
            return await _applicationDbContext.Teams
                .Select(Team => new TeamDto
                {
                    Id = Team.Id,
                    Name = Team.Name,
                    Email = Team.Email
                }).ToListAsync();
        }

        public async Task CreateTeamAsync(Team Team)
        {
            _applicationDbContext.Teams.Add(Team);
            await _applicationDbContext.SaveChangesAsync();
        }
    }
}