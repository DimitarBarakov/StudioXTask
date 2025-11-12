using System.ComponentModel.DataAnnotations;

namespace StudioXFirstTask.ViewModels.Country
{
    public class CountryFormViewModel
    {
        [Required]
        
        public string Name { get; set; } = null!;
    }
}
