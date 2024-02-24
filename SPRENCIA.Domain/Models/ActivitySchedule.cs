using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPRENCIA.Domain.Models
{
    public class ActivitySchedule
    {
        public int ActivityId { get; set; }
        public Activity Activity { get; set; }

        public int ScheduleId { get; set; }
        public Schedule Schedule { get; set; }
    }
}
