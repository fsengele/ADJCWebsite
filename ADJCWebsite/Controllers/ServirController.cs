using ADJCWebsite.Data;
using ADJCWebsite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ADJCWebsite.Controllers;

public class ServirController(ApplicationDbContext dbContext) : Controller
{
    [HttpGet]
    public IActionResult Index(string? department = null)
    {
        var model = new VolunteerApplicationViewModel();
        if (VolunteerApplicationViewModel.Departments.Contains(department ?? string.Empty))
        {
            model.Department = department!;
        }

        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Index(VolunteerApplicationViewModel model)
    {
        if (!VolunteerApplicationViewModel.Departments.Contains(model.Department))
        {
            ModelState.AddModelError(nameof(model.Department), "Veuillez choisir un département proposé.");
        }

        if (!VolunteerApplicationViewModel.ParticipationTypes.Contains(model.ParticipationType))
        {
            ModelState.AddModelError(nameof(model.ParticipationType), "Veuillez choisir un type de participation proposé.");
        }

        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var application = new VolunteerApplication
        {
            FirstName = model.FirstName.Trim(),
            LastName = model.LastName.Trim(),
            Email = model.Email.Trim(),
            Country = model.Country.Trim(),
            Department = model.Department,
            ParticipationType = model.ParticipationType,
            SkillsExperience = model.SkillsExperience.Trim(),
            Motivation = model.Motivation.Trim(),
            ConsentGiven = model.ConsentGiven,
            Status = "Pending",
            CreatedAtUtc = DateTime.UtcNow
        };

        try
        {
            dbContext.VolunteerApplications.Add(application);
            await dbContext.SaveChangesAsync();
        }
        catch (DbUpdateException)
        {
            ModelState.AddModelError(string.Empty, "Votre demande n'a pas pu être enregistrée. Veuillez réessayer ultérieurement.");
            return View(model);
        }

        TempData["VolunteerApplicationSubmitted"] = "Merci pour votre demande. Elle a bien été enregistrée et sera examinée par notre équipe.";
        return RedirectToAction(nameof(Index), new { submitted = true });
    }
}
