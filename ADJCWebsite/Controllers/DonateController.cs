using Microsoft.AspNetCore.Mvc;

namespace ADJCWebsite.Controllers;

public class DonateController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }
}
