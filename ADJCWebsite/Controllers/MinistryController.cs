using Microsoft.AspNetCore.Mvc;

namespace ADJCWebsite.Controllers;

public class MinistryController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
