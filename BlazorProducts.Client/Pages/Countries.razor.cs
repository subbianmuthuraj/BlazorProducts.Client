
using Entities.Models;
using Microsoft.AspNetCore.Components;
using BlazorProducts.Client.HttpRepository;
namespace BlazorProducts.Client.Pages
{
    public partial class Countries
    {
        public List<Country> CountryList { get; set; } = new List<Country>();
        [Inject]
        public ICountryHttpRepository CountryRepo { get; set; }

        protected async override Task OnInitializedAsync()
        {
            CountryList = await CountryRepo.GetCountries();
            foreach (var country in CountryList)
            {
                Console.WriteLine(country.CountryName);
            }
        }
    }
}
