using CleanArchitectureDemo.Application.DTOs;
using MediatR;

namespace CleanArchitectureDemo.Application.Teams.Queries
{
    public class GetTeamsQuery : IRequest<IEnumerable<TeamDto>>
    {
    }
}