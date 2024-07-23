using CleanArchitectureDemo.Application.DTOs;
using CleanArchitectureDemo.Domain.Entities;

namespace CleanArchitectureDemo.Application.Repositories
{
    public interface ITeamRepository
    {
        Task<IEnumerable<TeamDto>> GetTeamsAsync();

        Task CreateTeamAsync(Team Team);
    }
}