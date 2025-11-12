using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudioXFirstTask.Models;
using StudioXFirstTask.Services.Interfaces;
using StudioXFirstTask.ViewModels.Country;

namespace StudioXFirstTask.Controllers
{
    public class CountryController : Controller
    {
        private readonly ICountryService countryService;
        public CountryController(ICountryService service)
        {
            countryService = service;
        }
        public async Task<IActionResult> Index()
        {   
            List<Country> countries = await countryService.GetAll();

            return View(countries);
        }
        [HttpGet]
        [Authorize]
        public IActionResult Add()
        {
            return View(new CountryFormViewModel());
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Add(CountryFormViewModel model)
        {
            if (await countryService.GetCountryByNameAsync(model.Name) != null)
            {
                ModelState.AddModelError("Name", "Country with this name allready exists");
            }
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            await countryService.AddCountryAsync(model);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var country = await countryService.GetCountryAsync(id);

            var model = new CountryFormViewModel()
            {
                Name = country.Name
            };

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, CountryFormViewModel model)
        {
            if (await countryService.GetCountryByNameAsync(model.Name) != null)
            {
                ModelState.AddModelError("Name", "Country with this name allready exists");
            }
            if (!ModelState.IsValid) 
            {
                return View(model);
            }
            await countryService.UpdateCountryAsync(id, model);
            return RedirectToAction("Index");
        }
    }
}
