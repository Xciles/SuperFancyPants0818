using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SuperFancyPants.Razor.Pages
{
    public class User
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class AboutModel : PageModel
    {
        public string Message { get; set; }
        public IList<User> Users { get; set; }

        public void OnGet()
        {
            Message = "Your application description page.";
            Users = new List<User>
            {
                new User{Name = "Rick", Description = "Dit is rick!"},
                new User{Name = "Robbert", Description = "Dit is rick!"},
                new User{Name = "Rick", Description = "Dit is rick!"},
                new User{Name = "Rick", Description = "Dit is rick!"},
                new User{Name = "Rick", Description = "Dit is rick!"}
            };
        }
    }
}
