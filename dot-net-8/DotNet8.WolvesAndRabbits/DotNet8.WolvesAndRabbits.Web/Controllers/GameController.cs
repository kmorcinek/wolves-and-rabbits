using KMorcinek.WolvesAndRabbits.Web.Adapters;
using Microsoft.AspNetCore.Mvc;

namespace DotNet8.WolvesAndRabbits.Web.Controllers
{
    [ApiController]
    [Route("api/")]
    public class GameController : ControllerBase
    {
        // Static so it is not reinstantiated at every API call, server has to keep the game state
        static readonly IWolvesAdapter wolvesAdapter = new CsharpWolvesAdapter();

        static GameController()
        {
            wolvesAdapter.Reset(null);
        }

        [HttpGet("next-game")]
        public dynamic Get()
        {
            return wolvesAdapter.GetNextTurn();
        }

        [HttpPost("reset-game")]
        public dynamic ResetGame()
        {
            return wolvesAdapter.Reset(null);
        }
    }
}