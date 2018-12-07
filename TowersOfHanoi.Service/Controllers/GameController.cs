using System.Threading.Tasks;
using System.Web.Http;
using TowersOfHanoi.Application.Game.NewGame;
using TowersOfHanoi.Application.Games.Commands.NewGame;

namespace TowersOfHanoi.Service.Controllers
{
    public class GameController : ApiController
    {

        private readonly INewGameCommand _gameCommand;

        public GameController(INewGameCommand gameCommand)
        {
            _gameCommand = gameCommand;
        }

        public async Task<IHttpActionResult> Post(int userId, int amountDisk = 3)
        {
            await Task.Run(() => _gameCommand.Play(new PlayRequestDto { TotalDisk = amountDisk, UserId = userId }));
            return Ok();
        }
    }
};