using Microsoft.EntityFrameworkCore;
using StudioXFirstTask.Data;
using StudioXFirstTask.Models;
using StudioXFirstTask.Services.Interfaces;
using StudioXFirstTask.ViewModels.City;
using System.Threading.Tasks;

namespace StudioXFirstTask.Services
{
    public class CityService : ICityService
    {
        private readonly ApplicationDbContext _context;

        public CityService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddCityAsync(CityFormViewModel model)
        {
            City cityToAdd = new City();
            cityToAdd.Name = model.Name;
            cityToAdd.CountryId = model.CountryId;

            await _context.Cities.AddAsync(cityToAdd);
            await _context.SaveChangesAsync();
        }

        public async Task<List<City>> GetAllAsync(int page, int pageSize)
        {
            return await _context.Cities
                .Include(c=>c.Country)
                .Skip((page-1)*pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<City?> GetCityAsync(int id)
        {
            return await _context.Cities.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<City?> GetCityByNameAsync(string cityName)
        {
            return await _context.Cities.FirstOrDefaultAsync(c => c.Name == cityName);
        }

        public async Task<int> GetCount()
        {
            return await _context.Cities.CountAsync();
        }

        public async Task UpdateCityAsync(int id, CityFormViewModel model)
        {
            City cityToEdit = await GetCityAsync(id);
            cityToEdit.Name = model.Name;
            cityToEdit.CountryId = model.CountryId;

            await _context.SaveChangesAsync();
        }
    }
}
