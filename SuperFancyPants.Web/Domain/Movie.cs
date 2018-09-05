using System.ComponentModel.DataAnnotations;

namespace SuperFancyPants.Web.Domain
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public UserAccount UserAccount { get; set; }
        public string UserAccountId { get; set; }
    }

    public class MovieViewModel
    {
        public int MovieId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}