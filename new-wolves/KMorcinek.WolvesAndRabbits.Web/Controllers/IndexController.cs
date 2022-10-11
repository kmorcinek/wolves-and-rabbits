using KMorcinek.WolvesAndRabbits.Web.Adapters;
using Microsoft.AspNetCore.Mvc;

namespace KMorcinek.WolvesAndRabbits.Web.Controllers;

[ApiController]
public class IndexController : ControllerBase
{
    // readonly IWolvesAdapter _wolvesAdapter = new CsharpWolvesAdapter();
    //
    // [HttpGet(Name = "next-turn")]
    // public string GetNextTurn()
    // {
    //     return _wolvesAdapter.GetNextTurn();
    //     // return Enumerable.Range(1, 5).Select(index => new WeatherForecast
    //     //     {
    //     //         Date = DateTime.Now.AddDays(index),
    //     //         TemperatureC = Random.Shared.Next(-20, 55),
    //     //         Summary = Summaries[Random.Shared.Next(Summaries.Length)]
    //     //     })
    //     //     .ToArray();
    // }

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