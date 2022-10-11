using System.Text.Json;
using KMorcinek.WolvesAndRabbits.Web.Adapters;
using Microsoft.AspNetCore.Mvc;

namespace KMorcinek.WolvesAndRabbits.Web.Controllers;

[ApiController]
public class IndexController : ControllerBase
{
    readonly IWolvesAdapter _wolvesAdapter = new CsharpWolvesAdapter();

    [HttpGet("next-turn")]
    public ActionResult<string> GetNextTurn()
    {
        var nextTurn = _wolvesAdapter.GetNextTurn();
        return JsonSerializer.Serialize(nextTurn);
    }
    
    [HttpGet("reset")]
    public void Reset()
    {
        _wolvesAdapter.Reset(null);
    }
}