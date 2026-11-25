using ADJCWebsite.Models;
using Microsoft.AspNetCore.Mvc;

namespace ADJCWebsite.Controllers;

public class ContactController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        return View(new ContactMessageViewModel());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Index(ContactMessageViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        ViewData["EmailNotConfigured"] = true;
        ModelState.AddModelError(string.Empty, "La messagerie de l'Église n'est pas encore configurée. Votre message n'a pas été envoyé. Veuillez nous contacter lors d'un culte ou revenir lorsque ce service sera disponible.");
        return View(model);
    }
}
