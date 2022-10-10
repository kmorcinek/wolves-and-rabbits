using Microsoft.AspNetCore.Mvc;

namespace KMorcinek.WolvesAndRabbits.Web.Controllers;

[ApiController]
public class IndexController : ControllerBase
{
    [HttpGet("")]
    public ContentResult ConfirmVerify()
    {
        var html = System.IO.File.ReadAllText(@"./assets/verified.html");
        return base.Content(html, "text/html");
    }
}