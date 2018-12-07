using System.Collections.Generic;
using TowersOfHanoi.Domain.Histories;
using TowersOfHanoi.Domain.Users;

namespace TowersOfHanoi.Application.Games.Commands.NewGame.Factory
{
    public interface INewGameFactory
    {
        History Create(NewGameFactoryRequestDto dto);
        List<History> Create(List<NewGameFactoryRequestDto> dto);
    }
}
