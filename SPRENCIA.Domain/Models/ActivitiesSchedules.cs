using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SPRENCIA.Domain.Models
{
    public class ActivitiesSchedules
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("ActivityId")]
        public int ActivityId { get; set; }
        public Activity Activity { get; set; }

        [ForeignKey("ScheduleId")]
        public int ScheduleId { get; set; }
        public Schedule Schedule { get; set; }
    }
}
