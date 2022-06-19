using Clinic.API.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Clinic.API.DAL
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<History> History { get; set; }
        public DbSet<Models.Clinic> Clinic { get; set; }
        //public DbSet<AppUser> appUsers { get; set; }

    }
}
