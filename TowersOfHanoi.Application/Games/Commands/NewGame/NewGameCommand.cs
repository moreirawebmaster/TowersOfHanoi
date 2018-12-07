using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TowersOfHanoi.Application.Game.NewGame;
using TowersOfHanoi.Application.Games.Commands.NewGame.Factory;
using TowersOfHanoi.CrossCutting;
using TowersOfHanoi.Domain.Histories;
using TowersOfHanoi.Domain.Users;

namespace TowersOfHanoi.Application.Games.Commands.NewGame
{
    public class NewGameCommand : INewGameCommand
    {
        private INewGameFactory _gameFactory;
        private IRepository<User> _userRepository;
        private IRepository<History> _historyRepository;

        public NewGameCommand(INewGameFactory gameFactory, IRepository<User> userRepository, IRepository<History> historyRepository)
        {
            _gameFactory = gameFactory;
            _userRepository = userRepository;
            _historyRepository = historyRepository;
        }

        public async Task Play(PlayRequestDto dto)
        {
            var user = await _userRepository.GetByIdAsync(dto.UserId);

            var pegs = SolveTowers(dto.TotalDisk);

            var histories = pegs.Select(x => new NewGameFactoryRequestDto
            {
                User = user,
                Start = x.Start,
                End = x.End
            }).ToList();

            var factory = _gameFactory.Create(histories);
            await Task.Run(async () =>
            {
                _historyRepository.BulkInsert(factory);
                await _historyRepository.SaveAsync();
            });
        }

        private List<Peg> SolveTowers(int totalDisks = 3, string startPeg = "A", string endPeg = "B", string tempPeg = "C", List<Peg> pegs = null)
        {
            if (pegs == null)
                pegs = new List<Peg>();

            if (totalDisks > 0)
            {
                SolveTowers(totalDisks - 1, startPeg, endPeg, tempPeg, pegs);
                pegs.Add(new Peg { Start = startPeg, End = endPeg });
                SolveTowers(totalDisks - 1, endPeg, tempPeg, startPeg, pegs);
            }

            return pegs;
        }
    }
}
