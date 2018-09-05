using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace SuperFancyPants.Web.Domain
{
    public class UserAccount : IdentityUser
    {
        public string FirstName { get; set; }

        public IList<Todo> Todos { get; set; }
        public IList<Movie> Movies { get; set; }
        public IList<SkillToUserAccount> SkillToUserAccounts { get; set; }
    }
}