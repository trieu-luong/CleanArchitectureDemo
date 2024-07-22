using CleanArchitectureDemo.Application.DTOs;

namespace CleanArchitectureDemo.Application.Users.Commands
{
    public interface ICreateUserCommand
    {
        Task Execute(UserDto model);
    }
}