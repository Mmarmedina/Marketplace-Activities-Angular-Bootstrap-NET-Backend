using System.ComponentModel.DataAnnotations;

namespace SPRENCIA.Domain.Models
{
    public class Activity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public double Price { get; set; }

        public List<ActivitiesSchedules> ActivitySchedules { get; set; }

    }
}
