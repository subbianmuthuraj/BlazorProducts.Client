using Entities.Models;
using Microsoft.AspNetCore.Components;

namespace BlazorProducts.Client.Components
{
    public partial class CountryTable
    {
        [Parameter]
        public List<Country> Countries { get; set; }
    }
}
