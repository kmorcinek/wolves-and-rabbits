using KMorcinek.WolvesAndRabbits.Web.Adapters;
using Microsoft.AspNetCore.Mvc;

namespace DotNet8.WolvesAndRabbits.Web.Controllers
{
    [ApiController]
    [Route("api/")]
    public class GameController : ControllerBase
    {
        readonly IWolvesAdapter wolvesAdapter = new CsharpWolvesAdapter();

        public GameController()
        {
            wolvesAdapter.Reset(null);
        }

        [HttpGet("next-game")]
        public dynamic Get()
        {
            return wolvesAdapter.GetNextTurn();
        }
    }
}