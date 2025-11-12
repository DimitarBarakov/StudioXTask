using StudioXFirstTask.Models;
using StudioXFirstTask.ViewModels.City;

namespace StudioXFirstTask.Services.Interfaces
{
    public interface ICityService
    {
        public Task<List<City>> GetAllAsync(int page, int pageSize);
        public Task<City?> GetCityAsync(int id);
        public Task<City?> GetCityByNameAsync(string cityName);
        public Task AddCityAsync(CityFormViewModel model);
        public Task UpdateCityAsync(int id, CityFormViewModel mdoel);
        public Task<int> GetCount();
    }
}
