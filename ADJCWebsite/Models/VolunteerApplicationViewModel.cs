using System.ComponentModel.DataAnnotations;

namespace ADJCWebsite.Models;

public sealed class VolunteerApplicationViewModel
{
    public static IReadOnlyList<string> Departments { get; } =
    [
        "Médias & Communication",
        "Protocole & Accueil",
        "Partenariats",
        "Évangélisation",
        "Louange & Adoration",
        "Enseignement biblique",
        "Œuvres sociales",
        "Intercession & Prière"
    ];

    public static IReadOnlyList<string> ParticipationTypes { get; } =
    ["Sur place", "À distance", "Flexible"];

    [Required(ErrorMessage = "Veuillez saisir votre prénom.")]
    [StringLength(80, ErrorMessage = "Le prénom ne peut pas dépasser 80 caractères.")]
    [Display(Name = "Prénom")]
    public string FirstName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Veuillez saisir votre nom.")]
    [StringLength(80, ErrorMessage = "Le nom ne peut pas dépasser 80 caractères.")]
    [Display(Name = "Nom")]
    public string LastName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Veuillez saisir votre adresse e-mail.")]
    [EmailAddress(ErrorMessage = "Veuillez saisir une adresse e-mail valide.")]
    [StringLength(180, ErrorMessage = "L'adresse e-mail ne peut pas dépasser 180 caractères.")]
    [Display(Name = "Adresse e-mail")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Veuillez saisir votre pays de résidence.")]
    [StringLength(100, ErrorMessage = "Le pays ne peut pas dépasser 100 caractères.")]
    [Display(Name = "Pays de résidence")]
    public string Country { get; set; } = string.Empty;

    [Required(ErrorMessage = "Veuillez choisir un département.")]
    [Display(Name = "Département souhaité")]
    public string Department { get; set; } = string.Empty;

    [Required(ErrorMessage = "Veuillez choisir un type de participation.")]
    [Display(Name = "Type de participation")]
    public string ParticipationType { get; set; } = string.Empty;

    [Required(ErrorMessage = "Veuillez décrire vos compétences et votre expérience.")]
    [StringLength(2000, MinimumLength = 10, ErrorMessage = "Ce champ doit contenir entre 10 et 2 000 caractères.")]
    [Display(Name = "Compétences et expérience")]
    public string SkillsExperience { get; set; } = string.Empty;

    [Required(ErrorMessage = "Veuillez expliquer votre motivation.")]
    [StringLength(2000, MinimumLength = 10, ErrorMessage = "Ce champ doit contenir entre 10 et 2 000 caractères.")]
    [Display(Name = "Motivation")]
    public string Motivation { get; set; } = string.Empty;

    [Range(typeof(bool), "true", "true", ErrorMessage = "Votre consentement est nécessaire pour envoyer votre demande.")]
    [Display(Name = "Consentement")]
    public bool ConsentGiven { get; set; }
}
