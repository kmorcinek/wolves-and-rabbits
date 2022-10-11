using System.Text.Json;
using KMorcinek.WolvesAndRabbits.Web.Adapters;
using Microsoft.AspNetCore.Mvc;

namespace KMorcinek.WolvesAndRabbits.Web.Controllers;

[ApiController]
public class IndexController : ControllerBase
{
    readonly IWolvesAdapter _wolvesAdapter = new FsharpWolvesAdapter();

    [HttpGet("next-turn")]
    public ActionResult<string> GetNextTurn()
    {
        var nextTurn = _wolvesAdapter.GetNextTurn();
        // return nextTurn;
        return JsonSerializer.Serialize(nextTurn
        , new JsonSerializerOptions { WriteIndented = true });
    }
    
    [HttpGet("reset")]
    public void Reset()
    {
        _wolvesAdapter.Reset(null);
    }
    
    // [HttpGet("")]
    // public ContentResult ConfirmVerify()
    // {
    //     var html = System.IO.File.ReadAllText(@"~/index.html");
    //     return base.Content(html, "text/html");
    // }

    // [HttpGet("main.js")]
    // public ContentResult MainJs()
    // {
    //     var html = System.IO.File.ReadAllText(@"./assets/main.js");
    //     return base.Content(html, "text/html");
    // }
}