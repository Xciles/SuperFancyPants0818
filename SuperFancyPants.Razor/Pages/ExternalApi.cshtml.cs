using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace SuperFancyPants.Razor.Pages
{
    public class UserAccount
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public Address Address { get; set; }
        public string Phone { get; set; }
        public string Website { get; set; }
        public Company Company { get; set; }
    }

    public class Address
    {
        public string Street { get; set; }
        public string Suite { get; set; }
        public string City { get; set; }
        public string Zipcode { get; set; }
        public Geo Geo { get; set; }
    }

    public class Geo
    {
        public string Lat { get; set; }
        public string Lng { get; set; }
    }

    public class Company
    {
        public string Name { get; set; }
        public string CatchPhrase { get; set; }
        public string Bs { get; set; }
    }


    public class ExternalApiModel : PageModel
    {
        private readonly IHttpClientFactory _clientFactory;
        public IList<UserAccount> UserAccounts { get; set; }

        public ExternalApiModel(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task OnGetAsync()
        {
            var client = _clientFactory.CreateClient("jsonApi");
            string result = await client.GetStringAsync("users");

            //var client = _clientFactory.CreateClient();
            //string result = await client.GetStringAsync("https://jsonplaceholder.typicode.com/users");

            UserAccounts = JsonConvert.DeserializeObject<IList<UserAccount>>(result);


            //using (HttpClient client = new HttpClient())
            //{
            //    string result = await client.GetStringAsync("https://jsonplaceholder.typicode.com/users");

            //}
        }
    }
}