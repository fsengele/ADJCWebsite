using Microsoft.AspNetCore.Mvc;

namespace ADJCWebsite.Controllers;

public class PredicationsController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }
}
