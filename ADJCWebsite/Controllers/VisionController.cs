using Microsoft.AspNetCore.Mvc;

namespace ADJCWebsite.Controllers;

public class VisionController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
