using Microsoft.AspNetCore.Mvc;

namespace KMorcinek.WolvesAndRabbits.Web.Controllers;

[ApiController]
[Route("[controller]")]
public class IndexController : ControllerBase
{
    [HttpGet("verify")]
    public ContentResult Verify()
    {
        var html = "<div>Your account has been verified.</div>";
        return base.Content(html, "text/html");
    }
    
}