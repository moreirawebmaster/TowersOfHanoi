using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using TowersOfHanoi.Domain.Histories;

namespace TowersOfHanoi.Domain.Users
{
    [TestFixture]
    public class UserTests
    {
        private readonly User _user;
        private const int Id = 1;
        private const string Name = "Teste";

        public UserTests()
        {
            _user = new User
            {
                History = new List<History>
                {
                    new History
                    {
                        Start = "A",
                        End = "B"
                    },
                    new History
                    {
                        Start = "A",
                        End = "B"
                    },new History
                    {
                        Start = "A",
                        End = "C"
                    },new History
                    {
                        Start = "B",
                        End = "A"
                    }
                }
            };
        }

        [Test]
        public void TestSetAndGetId()
        {
            _user.Id = Id;
            Assert.That(_user.Id, Is.EqualTo(Id));
        }

        [Test]
        public void TestSetAndGetName()
        {
            _user.Name = Name;
            Assert.That(_user.Name, Is.EqualTo(Name));
        }

        [Test]
        public void TestGetHistories()
        {
            Assert.That(_user.History.Any(), Is.EqualTo(true));
        }

        [Test]
        public void TestGetHistoriesGreaterThanZero()
        {
            Assert.That(_user.History.Count, Is.GreaterThan(0));
        }
    }
}