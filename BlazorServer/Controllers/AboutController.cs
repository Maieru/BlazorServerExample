using Microsoft.AspNetCore.Mvc;

namespace BlazorServer.Controllers
{
    public class AboutController : Controller
    {
        [HttpGet("/api/v1/GetStatus")]
        public async Task<IActionResult> GetStatus() => Json("The app is running");
    }
}
