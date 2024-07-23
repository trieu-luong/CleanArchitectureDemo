using CleanArchitectureDemo.Application.DTOs;
using CleanArchitectureDemo.Application.Repositories;
using MediatR;

namespace CleanArchitectureDemo.Application.Teams.Queries
{
    public class GetTeamsHandle : IRequestHandler<GetTeamsQuery, IEnumerable<TeamDto>>
    {
        private readonly ITeamRepository _teamRepository;

        public GetTeamsHandle(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }

        public async Task<IEnumerable<TeamDto>> Handle(GetTeamsQuery request, CancellationToken cancellationToken)
        {
            return await _teamRepository.GetTeamsAsync();
        }
    }
}