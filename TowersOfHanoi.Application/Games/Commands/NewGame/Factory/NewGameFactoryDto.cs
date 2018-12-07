using TowersOfHanoi.Domain.Users;

namespace TowersOfHanoi.Application.Games.Commands.NewGame.Factory
{
    public class NewGameFactoryRequestDto
    {
        public User User { get; set; }
        public string Start { get; set; }
        public string End { get; set; }
    }
}
