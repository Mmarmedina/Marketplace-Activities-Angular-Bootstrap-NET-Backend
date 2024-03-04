using SPRENCIA.Domain.Models;

namespace SPRENCIA.Infraestructure.Contracts.DTOs
{
    public class ScheduleDto
    {
        //MMM Dto salida de horarios (datos para enviar al frontend). Se incluye como propiedad dentro de ActivityDto.
        public List<Schedule> Schedule { get; set; }    
    }
}