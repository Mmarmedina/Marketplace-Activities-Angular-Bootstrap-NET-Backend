using SPRENCIA.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPRENCIA.Infraestructure.Contracts.DTOs
{
    public class ActivityDto
    {
        // MMM Dto salida de actividades (datos para enviar al frontend: unión de actividad, opinión y horario).
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        // Añadir ScheduleDto 
        public ActivitiesSchedulesAndSchedules ActivitiesSchedulesAndSchedules { get; set; }

        public ReviewDto ReviewText { get; set; }
    }
}
