using TowersOfHanoi.Domain.Users;

namespace TowersOfHanoi.Application.Users.Commands.CreateUser.Factory
{
    public class UserFactory : IUserFactory
    {
        public User Create(string name)
        {
            var user = new User
            {
                Name = name
            };

            return user;
        }
    }
}