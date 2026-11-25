using System.ComponentModel.DataAnnotations;

namespace ADJCWebsite.Models;

public sealed class ContactMessageViewModel
{
    [Display(Name = "Nom complet")]
    [Required(ErrorMessage = "Veuillez saisir votre nom complet.")]
    [StringLength(120, ErrorMessage = "Le nom ne peut pas dépasser 120 caractères.")]
    public string FullName { get; set; } = string.Empty;

    [Display(Name = "Adresse e-mail")]
    [Required(ErrorMessage = "Veuillez saisir votre adresse e-mail.")]
    [EmailAddress(ErrorMessage = "Veuillez saisir une adresse e-mail valide.")]
    [StringLength(180, ErrorMessage = "L'adresse e-mail ne peut pas dépasser 180 caractères.")]
    public string Email { get; set; } = string.Empty;

    [Display(Name = "Sujet")]
    [Required(ErrorMessage = "Veuillez saisir un sujet.")]
    [StringLength(160, MinimumLength = 3, ErrorMessage = "Le sujet doit contenir entre 3 et 160 caractères.")]
    public string Subject { get; set; } = string.Empty;

    [Display(Name = "Message")]
    [Required(ErrorMessage = "Veuillez saisir votre message.")]
    [StringLength(2000, MinimumLength = 10, ErrorMessage = "Le message doit contenir entre 10 et 2 000 caractères.")]
    public string Message { get; set; } = string.Empty;
}
