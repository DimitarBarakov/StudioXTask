using StudioXFirstTask.Models;
using StudioXFirstTask.ViewModels.City;
using StudioXFirstTask.ViewModels.Country;

namespace StudioXFirstTask.Services.Interfaces
{
    public interface ICountryService
    {
        public Task<Country?> GetCountryAsync(int countryId);
        public Task<Country?> GetCountryByNameAsync(string name);
        public Task AddCountryAsync(CountryFormViewModel model);
        public Task UpdateCountryAsync(int id, CountryFormViewModel model);
        public Task<List<Country>> GetAll();
        public Task<List<AddCityCountriesViewModel>> GetCountriesModelAsync();
    }
}
