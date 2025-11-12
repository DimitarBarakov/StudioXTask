using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudioXFirstTask.Models;
using StudioXFirstTask.Services.Interfaces;
using StudioXFirstTask.ViewModels.City;

namespace StudioXFirstTask.Controllers
{
    public class CityController : Controller
    {
        private readonly ICityService cityService;
        private readonly ICountryService countryService;
        public CityController(ICityService service, ICountryService service1) 
        {
            cityService = service;
            countryService = service1;
        }
        public async Task<IActionResult> Index(int page = 1, int pageSize = 2)
        {
            var model = await cityService.GetAllAsync(page, pageSize);
            int totalCountries = await cityService.GetCount();

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = (int)Math.Ceiling((double)totalCountries / pageSize);

            return View(model);
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Add() { 
            CityFormViewModel model = new CityFormViewModel();
            model.Countries = await countryService.GetCountriesModelAsync();

            return View(model);
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Add(CityFormViewModel model)
        {
            if (await cityService.GetCityByNameAsync(model.Name) != null)
            {
                ModelState.AddModelError("Name", "City with this name allready exists");
            }
            if (!ModelState.IsValid)
            {
                model.Countries = await countryService.GetCountriesModelAsync();
                return View(model);
            }
            await cityService.AddCityAsync(model);
            return RedirectToAction("Index");
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Edit(int id)
        {
            var city = await cityService.GetCityAsync(id);
            CityFormViewModel model = new CityFormViewModel();
            model.CountryId = city.CountryId;
            model.Name = city.Name;
            model.Countries = await countryService.GetCountriesModelAsync();

            return View(model);
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Edit(int id, CityFormViewModel model)
        {
            if (await cityService.GetCityByNameAsync(model.Name) != null)
            {
                ModelState.AddModelError("Name", "City with this name allready exists");
            }
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            await cityService.UpdateCityAsync(id, model);
            return RedirectToAction("Index");
        }
    }
}
