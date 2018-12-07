using System.Threading.Tasks;
using TowersOfHanoi.Application.Users.Commands.CreateUser.Factory;
using TowersOfHanoi.CrossCutting;
using TowersOfHanoi.Domain.Users;

namespace TowersOfHanoi.Application.Users.Commands
{
    public class CreateUserCommand : ICreateUserCommand
    {
        private readonly IRepository<User> _userRepository;
        private readonly IUserFactory _userFactory;

        public CreateUserCommand(IRepository<User> userRepository, IUserFactory userFactory)
        {
            _userRepository = userRepository;
            _userFactory = userFactory;
        }

        public async Task<CreateUserResponseDto> Execute(CreateUserRequestDto dto)
        {
            var user = _userFactory.Create(dto.Name);
            var result = _userRepository.Insert(user);
            await _userRepository.SaveAsync();
            return await Task.FromResult(new CreateUserResponseDto
            {
                Id = result.Id,
                Name = result.Name,
            });
        }
    }
}