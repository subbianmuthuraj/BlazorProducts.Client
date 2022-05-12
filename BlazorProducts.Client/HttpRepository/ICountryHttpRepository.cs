using BlazorProducts.Client.Features;
using Entities.Models;
using SharedDto.RequestFeatures;

namespace BlazorProducts.Client.HttpRepository
{
    public interface ICountryHttpRepository
    {
        Task<PagingResponse<Country>> GetCountries(CountryParameters countryParameters);
        Task<Country> GetCountryById(int id);
    }
}
