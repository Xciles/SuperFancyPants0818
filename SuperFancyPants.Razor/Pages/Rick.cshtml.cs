using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SuperFancyPants.Razor.Pages
{
    public class RickModel : PageModel
    {
        public string NotMessage { get; set; }

        [BindProperty]
        public string Value { get; set; }

        public void OnGet()
        {
            NotMessage = "Not a message";
        }

        public void OnPost()
        {
            
        }
    }
}