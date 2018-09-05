using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Tracing;

namespace SuperFancyPants.Web.Domain
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public UserAccount UserAccount { get; set; }
        public string UserAccountId { get; set; }

        [NotMapped]
        public IList<string> UserAccountIds { get; set; }
    }

    public class MovieViewModel
    {
        public int MovieId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }

    public class Skill
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ELevel Level { get; set; }
        
        public IList<SkillToUserAccount> SkillToUserAccounts { get; set; }
    }

    public class SkillToUserAccount
    {
        [Key]
        public int Id { get; set; }
        public UserAccount UserAccount { get; set; }
        public Skill Skill { get; set; }
        public string UserAccountId { get; set; }
        public int SkillId { get; set; }
    }

    public enum ELevel
    {
        Novice, 
        Advanced, 
        Expert
    }

}