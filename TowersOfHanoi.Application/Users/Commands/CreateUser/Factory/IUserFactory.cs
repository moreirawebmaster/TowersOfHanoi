using TowersOfHanoi.Domain.Users;

namespace TowersOfHanoi.Application.Users.Commands.CreateUser.Factory
{
    public interface IUserFactory
    {
        User Create(string name);
    }
}
