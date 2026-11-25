using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Options;

namespace ADJCWebsite.Areas.Identity.Pages.Account;

[AllowAnonymous]
public class RegisterModel : PageModel
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly IEmailSender _emailSender;
    private readonly ILogger<RegisterModel> _logger;
    private readonly IdentityOptions _identityOptions;

    public RegisterModel(
        UserManager<IdentityUser> userManager,
        SignInManager<IdentityUser> signInManager,
        IEmailSender emailSender,
        ILogger<RegisterModel> logger,
        IOptions<IdentityOptions> identityOptions)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _emailSender = emailSender;
        _logger = logger;
        _identityOptions = identityOptions.Value;
    }

    [BindProperty]
    public InputModel Input { get; set; } = new();

    public string? ReturnUrl { get; set; }
    public PasswordOptions PasswordPolicy => _identityOptions.Password;

    public class InputModel
    {
        [Required(ErrorMessage = "Veuillez saisir votre adresse e-mail.")]
        [EmailAddress(ErrorMessage = "Veuillez saisir une adresse e-mail valide.")]
        [Display(Name = "Adresse e-mail")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Veuillez saisir un mot de passe.")]
        [StringLength(100, ErrorMessage = "Le mot de passe doit comporter au moins {2} et au plus {1} caractères.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Mot de passe")]
        public string Password { get; set; } = string.Empty;

        [DataType(DataType.Password)]
        [Display(Name = "Confirmer le mot de passe")]
        [Compare("Password", ErrorMessage = "Les mots de passe ne correspondent pas.")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }

    public void OnGet(string? returnUrl = null)
    {
        ReturnUrl = returnUrl;
    }

    public async Task<IActionResult> OnPostAsync(string? returnUrl = null)
    {
        ReturnUrl = returnUrl;

        if (!ModelState.IsValid)
        {
            return Page();
        }

        var user = new IdentityUser
        {
            UserName = Input.Email,
            Email = Input.Email
        };

        var result = await _userManager.CreateAsync(user, Input.Password);
        if (!result.Succeeded)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return Page();
        }

        _logger.LogInformation("User created a new account with password.");

        var userId = await _userManager.GetUserIdAsync(user);
        var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
        var encodedCode = WebEncoders.Base64UrlEncode(System.Text.Encoding.UTF8.GetBytes(code));
        var callbackUrl = Url.Page(
            "/Account/ConfirmEmail",
            pageHandler: null,
            values: new { area = "Identity", userId, code = encodedCode, returnUrl },
            protocol: Request.Scheme);

        await _emailSender.SendEmailAsync(
            Input.Email,
            "Confirmez votre adresse e-mail",
            $"Veuillez confirmer votre compte ADJC en cliquant <a href='{HtmlEncoder.Default.Encode(callbackUrl ?? string.Empty)}'>ici</a>.");

        if (_identityOptions.SignIn.RequireConfirmedAccount)
        {
            return RedirectToPage("./RegisterConfirmation", new { email = Input.Email, returnUrl });
        }

        await _signInManager.SignInAsync(user, isPersistent: false);
        return LocalRedirect(returnUrl ?? Url.Content("~/")!);
    }
}
