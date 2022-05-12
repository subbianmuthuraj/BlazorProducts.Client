
using Entities.Models;
using Microsoft.AspNetCore.Components;
using BlazorProducts.Client.HttpRepository;
using SharedDto.RequestFeatures;

namespace BlazorProducts.Client.Pages
{
    public partial class Countries
    {
        public List<Country> CountryList { get; set; } = new List<Country>();
        public MetaData MetaData { get; set; } = new MetaData();
        private GeneralParameters generalParameters = new GeneralParameters();

        [Inject]
        public ICountryHttpRepository CountryRepo { get; set; }

        protected async override Task OnInitializedAsync()
        {
            await GetCountries();

        }
        private async Task SelectedPage(int page)
        {
            generalParameters.PageNumber = page;
            await GetCountries();
        }

        private async Task GetCountries()
        {
            var pagingResponse = await CountryRepo.GetCountries(generalParameters);

            CountryList = pagingResponse.Items;
            MetaData = pagingResponse.MetaData;
        }
    }
}
