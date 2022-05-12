using Entities.Models;

namespace BlazorProducts.Client.HttpRepository
{
    public interface ICountryHttpRepository
    {
        Task<List<Country>> GetCountries();
        Task<Country> GetCountryById(int id);
    }
}
