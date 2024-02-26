using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPRENCIA.Infraestructure.Contracts.DTOs
{
    public enum ScheduleType
    {
        Morning,
        Afternoon,
        OnWeekend
    }
    public class ActivitySchedulesRequestDto
    {
        // MMM Envío del frontend los distintos horarios de una actividad. Se usa en ActivityAddRequestDto.

        public ScheduleType Type { get; set; }
    }
}
