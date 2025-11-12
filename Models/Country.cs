using System.ComponentModel.DataAnnotations;

namespace StudioXFirstTask.Models
{
    public class Country
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        public virtual List<City> Cities { get; set; }
    }
}
