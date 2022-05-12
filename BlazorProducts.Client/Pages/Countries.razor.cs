﻿
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
        private CountryParameters countryParameters = new CountryParameters();

        [Inject]
        public ICountryHttpRepository CountryRepo { get; set; }

        protected async override Task OnInitializedAsync()
        {
            await GetCountries();

        }
        private async Task SelectedPage(int page)
        {
            countryParameters.PageNumber = page;
            await GetCountries();
        }

        private async Task GetCountries()
        {
            var pagingResponse = await CountryRepo.GetCountries(countryParameters);

            CountryList = pagingResponse.Items;
            MetaData = pagingResponse.MetaData;
        }
        private async Task SetPageSize(int pageSize)
        {
            countryParameters.PageSize = pageSize;
            countryParameters.PageNumber = 1;

            await GetCountries();
        }

        private async Task SearchChanged(string searchTerm)
        {
            countryParameters.PageNumber = 1;
            countryParameters.SearchTerm = searchTerm;
            await GetCountries();
        }

        private async Task SortChanged(string orderBy)
        {
            countryParameters.OrderBy = orderBy;
            await GetCountries();
        }
    }
}
