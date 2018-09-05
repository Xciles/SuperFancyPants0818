using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SuperFancyPants.Web.Data;

namespace SuperFancyPants.Web.Data
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public UserAccount UserAccount { get; set; }
        public string UserAccountId { get; set; }
    }

    public class Todo
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsDone { get; set; }

        public UserAccount UserAccount { get; set; }
        public string UserAccountId { get; set; }
    }

    public class UserAccount : IdentityUser
    {
        public string FirstName { get; set; }

        public IList<Todo> Todos { get; set; }
        public IList<Movie> Movies { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<UserAccount>
    {
        public DbSet<Movie> Movie { get; set; }
        public DbSet<Todo> Todos { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

    }
}
