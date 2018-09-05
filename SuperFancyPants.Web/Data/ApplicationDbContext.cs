using System;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SuperFancyPants.Web.Data;
using SuperFancyPants.Web.Domain;

namespace SuperFancyPants.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext<UserAccount>
    {
        public DbSet<Movie> Movie { get; set; }
        public DbSet<Todo> Todos { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<SkillToUserAccount> SkillToUserAccounts { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
