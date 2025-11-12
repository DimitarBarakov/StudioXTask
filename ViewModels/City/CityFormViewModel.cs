using StudioXFirstTask.Models;
using System.ComponentModel.DataAnnotations;

namespace StudioXFirstTask.ViewModels.City
{
    public class CityFormViewModel
    {
        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public int CountryId { get; set; }

        public List<AddCityCountriesViewModel> Countries { get; set; } = new List<AddCityCountriesViewModel>();
    }
}
