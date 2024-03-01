using SPRENCIA.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPRENCIA.Infraestructure.Contracts.DTOs
{
    public class ActivityAddRequestDto
    {
        
        public string Title { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        // Falta la propiedad horarios 

        // MMM Aquí el frontend puede indicar que una actividad tiene varios horarios

        // public List<ActivitySchedulesRequestDto> ActivitySchedules { get; set; }
    }
}
