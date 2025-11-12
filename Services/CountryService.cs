using Microsoft.EntityFrameworkCore;
using StudioXFirstTask.Data;
using StudioXFirstTask.Models;
using StudioXFirstTask.Services.Interfaces;
using StudioXFirstTask.ViewModels.City;
using StudioXFirstTask.ViewModels.Country;

namespace StudioXFirstTask.Services
{
    public class CountryService : ICountryService
    {
        private readonly ApplicationDbContext _dbContext;

        public CountryService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddCountryAsync(CountryFormViewModel model)
        {
            Country countryToAdd = new Country()
            {
                Name = model.Name
            };
            await _dbContext.Countries.AddAsync(countryToAdd);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Country>> GetAll()
        {
            return await _dbContext.Countries.Include(c=>c.Cities).ToListAsync();
        }

        public async Task<List<AddCityCountriesViewModel>> GetCountriesModelAsync()
        {
            return await _dbContext.Countries.Select(x => new AddCityCountriesViewModel()
            {
                Id = x.Id,
                Name = x.Name,
            }).ToListAsync();
        }

        public async Task<Country?> GetCountryAsync(int countryId)
        {
            return await _dbContext.Countries.FirstOrDefaultAsync(c=>c.Id == countryId);
        }

        public async Task<Country?> GetCountryByNameAsync(string name)
        {
            var country = await _dbContext.Countries.FirstOrDefaultAsync(c => c.Name == name);
            return country;
        }

        public async Task UpdateCountryAsync(int id, CountryFormViewModel model)
        {
            Country? countryToEdit = await GetCountryAsync(id);
            countryToEdit.Name = model.Name;
            await _dbContext.SaveChangesAsync();
        }
    }
}
