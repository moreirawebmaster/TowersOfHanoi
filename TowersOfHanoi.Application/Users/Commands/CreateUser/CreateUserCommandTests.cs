using NUnit.Framework;
using TowersOfHanoi.Application.Users.Commands.CreateUser.Factory;
using TowersOfHanoi.CrossCutting;
using TowersOfHanoi.CrossCutting.Test;
using TowersOfHanoi.Domain.Users;

namespace TowersOfHanoi.Application.Users.Commands
{
    [TestFixture]
    public class CreateUserCommandTests : BaseTest
    {
        private CreateUserCommand _command;
        private CreateUserRequestDto _dto;
        private User user;

        [SetUp]
        public void SettUp()
        {
            _dto = new CreateUserRequestDto
            {
                Name = "thiago"
            };

            mocker.GetMock<IRepository<User>>();
            SetUpDbSet(x => x.Set<User>());
            mocker.GetMock<IUserFactory>()
                .Setup(x => x.Create("thiago")).Returns(user);

            _command = mocker.Create<CreateUserCommand>();
        }

        [Test]
        public void TestExecuteShouldAddUserToTheDatabase()
        {
            _command.Execute(_dto);

            mocker.GetMock<IRepository<User>>()
                .Verify(p => p.Insert(user));
        }
    }
}
