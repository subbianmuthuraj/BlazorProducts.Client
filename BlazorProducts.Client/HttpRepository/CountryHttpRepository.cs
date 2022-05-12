using Entities.Models;
using System.Net.Http.Json;

namespace BlazorProducts.Client.HttpRepository
{
    public class CountryHttpRepository : ICountryHttpRepository
    {
        private readonly HttpClient _client;

        public CountryHttpRepository(HttpClient httpClient)
        {
            _client = httpClient;
        }
        public async Task<List<Country>> GetCountries()
        {
            var countries = await _client.GetFromJsonAsync<List<Country>>("countries");
            return countries;
        }

        public async Task<Country> GetCountryById(int id)
        {
            var country = await _client.GetFromJsonAsync<Country>($"countries/{id}");
            return country;
        }
    }
}
