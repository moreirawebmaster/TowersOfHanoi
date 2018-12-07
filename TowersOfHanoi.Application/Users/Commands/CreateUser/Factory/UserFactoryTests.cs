using NUnit.Framework;
using TowersOfHanoi.Application.Users.Commands.CreateUser.Factory;

namespace TowersOfHanoi.Application.Users.Commands.Factory
{
    [TestFixture]
    public class UserFactoryTests
    {
        private UserFactory _userFactory;

        [SetUp]
        public void SetUp()
        {
            _userFactory = new UserFactory();
        }

        [Test]
        public void TestCreateShouldCreateNewUser()
        {
            var result = _userFactory.Create("THIAGO");

            Assert.That(result.IsValid, Is.EqualTo(true));
            Assert.That(result.Name, Is.EqualTo("THIAGO"));
        }

        [Test]
        public void TestCreateNewUserIsValid()
        {
            var result = _userFactory.Create("THIAGO");
            Assert.That(result.IsValid, Is.EqualTo(true));
        }
    }
}
