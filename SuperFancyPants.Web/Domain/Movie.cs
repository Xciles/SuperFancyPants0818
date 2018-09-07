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

        //[NotMapped]
        //public IList<string> UserAccountIds { get; set; }
    }
}