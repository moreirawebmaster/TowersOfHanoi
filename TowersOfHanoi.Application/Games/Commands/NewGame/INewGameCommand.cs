using System.Threading.Tasks;
using TowersOfHanoi.Application.Game.NewGame;

namespace TowersOfHanoi.Application.Games.Commands.NewGame
{
    public interface INewGameCommand
    {
        Task Play(PlayRequestDto dto);
    }
}
