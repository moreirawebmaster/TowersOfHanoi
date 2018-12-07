using System.Collections.Generic;
using System.Linq;
using TowersOfHanoi.Domain.Histories;

namespace TowersOfHanoi.Application.Games.Commands.NewGame.Factory
{
    public class NewGameFactory : INewGameFactory
    {
        public History Create(NewGameFactoryRequestDto dto)
        {
            var history = new History
            {
                User = dto.User,
                Start = dto.Start,
                End = dto.End
            };

            return history;
        }

        public List<History> Create(List<NewGameFactoryRequestDto> dto)
        {
            var histories = dto.Select(Create).ToList();
            return histories;
        }
    }
}
