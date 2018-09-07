using System.ComponentModel.DataAnnotations;

namespace SuperFancyPants.Web.Domain
{
    public class SkillToUserAccount
    {
        [Key]
        public int Id { get; set; }
        public UserAccount UserAccount { get; set; }
        public Skill Skill { get; set; }
        public string UserAccountId { get; set; }
        public int SkillId { get; set; }
    }
}