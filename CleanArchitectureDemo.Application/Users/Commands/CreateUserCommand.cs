using CleanArchitectureDemo.Application.DTOs;
using CleanArchitectureDemo.Application.Repositories;
using CleanArchitectureDemo.Domain.Entities;

namespace CleanArchitectureDemo.Application.Users.Commands
{
    public class CreateUserCommand : ICreateUserCommand
    {
        private readonly IUserRepository _userRepository;

        public CreateUserCommand(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task Execute(UserDto model)
        {
            var user = new User()
            {
                Email = model.Email,
                Id = model.Id,
                Name = model.Name,
                PhoneNumber = model.PhoneNumber
            };

            await _userRepository.CreateUserAsync(user);
        }
    }
}