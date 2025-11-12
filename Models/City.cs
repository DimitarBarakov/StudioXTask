using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudioXFirstTask.Models
{
    public class City
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Country))]
        public int CountryId { get; set; }

        [Required]
        public Country Country { get; set; } = null!;
    }
}
