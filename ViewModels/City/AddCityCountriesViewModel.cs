using System.ComponentModel.DataAnnotations;

namespace StudioXFirstTask.ViewModels.City
{
    public class AddCityCountriesViewModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = null!;
    }
}
