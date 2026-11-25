using System.ComponentModel.DataAnnotations;

namespace ADJCWebsite.Models;

public sealed class VolunteerApplication
{
    public int Id { get; set; }

    [Required, StringLength(80)]
    public string FirstName { get; set; } = string.Empty;

    [Required, StringLength(80)]
    public string LastName { get; set; } = string.Empty;

    [Required, EmailAddress, StringLength(180)]
    public string Email { get; set; } = string.Empty;

    [Required, StringLength(100)]
    public string Country { get; set; } = string.Empty;

    [Required, StringLength(120)]
    public string Department { get; set; } = string.Empty;

    [Required, StringLength(30)]
    public string ParticipationType { get; set; } = string.Empty;

    [Required, StringLength(2000)]
    public string SkillsExperience { get; set; } = string.Empty;

    [Required, StringLength(2000)]
    public string Motivation { get; set; } = string.Empty;

    public bool ConsentGiven { get; set; }

    [Required, StringLength(30)]
    public string Status { get; set; } = "Pending";

    public DateTime CreatedAtUtc { get; set; }
}
