using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPRENCIA.Domain.Models
{
    public enum ScheduleType
    {
        Morning,
        Afternoon,
        OnWeekend
    }
    public class Schedule
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public ScheduleType Type { get; set; }
    }
}
