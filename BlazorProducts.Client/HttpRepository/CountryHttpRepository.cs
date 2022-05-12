using BlazorProducts.Client.Features;
using Entities.Models;
using Microsoft.AspNetCore.WebUtilities;
using SharedDto.RequestFeatures;
using System.Net.Http.Json;
using System.Text.Json;

namespace BlazorProducts.Client.HttpRepository
{
    public class CountryHttpRepository : ICountryHttpRepository
    {
        private readonly HttpClient _client;
        private readonly JsonSerializerOptions _options =
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        public CountryHttpRepository(HttpClient httpClient)
        {
            _client = httpClient;
        }
        public async Task<PagingResponse<Country>> GetCountries(GeneralParameters generalParameters)
        {
            var queryStringParam = new Dictionary<string, string>
            {
                ["pageNumber"] = generalParameters.PageNumber.ToString()
            };
            var response = await _client.GetAsync(QueryHelpers.AddQueryString("countries", queryStringParam));
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            { throw new ApplicationException(content); }
            var pagingResponse = new PagingResponse<Country>
            {
                Items = JsonSerializer.Deserialize<List<Country>>(content, _options),
                MetaData = JsonSerializer.Deserialize<MetaData>(
                    response.Headers.GetValues("X-Pagination").First(), _options)
            };

            return pagingResponse;
        }

        public async Task<Country> GetCountryById(int id)
        {
            var country = await _client.GetFromJsonAsync<Country>($"countries/{id}");
            return country;
        }
    }
}
