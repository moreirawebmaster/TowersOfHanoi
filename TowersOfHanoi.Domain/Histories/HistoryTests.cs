using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using TowersOfHanoi.Domain.Users;

namespace TowersOfHanoi.Domain.Histories
{
    [TestFixture]
    public class HistoryTests
    {
        private readonly List<History> _history;
        private const int Id = 1;

        public HistoryTests()
        {
            var user = new User
            {
                Id = 1,
                Name = "teste"
            };

            _history = new List<History>
                {
                    new History
                    {
                        User = user,
                        Start = "A",
                        End = "B"
                    },
                    new History
                    {
                        User = user,
                        Start = "A",
                        End = "B"
                    },new History
                    {
                        User = user,
                        Start = "A",
                        End = "C"
                    },new History
                    {
                        User = user,
                        Start = "B",
                        End = "A"
                    }
            };
        }

        [Test]
        public void TestGetByUserId()
        {
            var history = _history.Where(x => x.User.Id == Id);
            Assert.That(history.Any, Is.EqualTo(true));
        }

        [Test]
        public void TestGetByUserIdGreaterThanZero()
        {
            var history = _history.Where(x => x.User.Id == Id);
            Assert.That(history.Count(), Is.GreaterThan(0));
        }
    }
}
