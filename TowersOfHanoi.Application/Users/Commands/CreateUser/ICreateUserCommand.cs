using System.Threading.Tasks;

namespace TowersOfHanoi.Application.Users.Commands
{
    public interface ICreateUserCommand
    {
        Task<CreateUserResponseDto> Execute(CreateUserRequestDto dto);
    }
}
