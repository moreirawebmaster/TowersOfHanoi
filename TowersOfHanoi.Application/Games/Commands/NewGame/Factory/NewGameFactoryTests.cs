using NUnit.Framework;
using TowersOfHanoi.Domain.Users;

namespace TowersOfHanoi.Application.Games.Commands.NewGame.Factory
{
    [TestFixture]
    public class NewGameFactoryTests
    {
        private NewGameFactory _gameFactory;
        private User _user;

        [SetUp]
        public void SetUp()
        {
            _user = new User
            {
                Id = 1,
                Name = "Thiago"
            };

            _gameFactory = new NewGameFactory();
        }

        [Test]
        public void TestCreateShouldCreateNewHistory()
        {
            var result = _gameFactory.Create(
                new NewGameFactoryRequestDto
                {
                    User = _user,
                    Start = "A",
                    End = "C"
                });

            Assert.That(result.IsValid, Is.EqualTo(true));
            Assert.That(result.Start, Is.EqualTo("A"));
            Assert.That(result.End, Is.EqualTo("C"));
        }
    }
}