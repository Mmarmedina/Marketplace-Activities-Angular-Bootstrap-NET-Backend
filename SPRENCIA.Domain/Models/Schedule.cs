using System.ComponentModel.DataAnnotations;

namespace SPRENCIA.Domain.Models
{
    public class Schedule
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public List<ActivitiesSchedules> ActivitySchedules { get; set; }


    }
}
