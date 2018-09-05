using System.ComponentModel.DataAnnotations;

namespace SuperFancyPants.Web.Domain
{
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
}