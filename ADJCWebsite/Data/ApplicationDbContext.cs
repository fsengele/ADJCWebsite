using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ADJCWebsite.Models;

namespace ADJCWebsite.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext(options)
    {
        public DbSet<VolunteerApplication> VolunteerApplications => Set<VolunteerApplication>();
    }
}
