using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SuperFancyPants.Web.Domain
{
    public class Skill
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ELevel Level { get; set; }
        
        public IList<SkillToUserAccount> SkillToUserAccounts { get; set; }
    }
}