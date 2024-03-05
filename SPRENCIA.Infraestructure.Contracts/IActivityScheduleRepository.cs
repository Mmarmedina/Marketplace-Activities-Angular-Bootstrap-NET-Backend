using SPRENCIA.Domain.Models;
using SPRENCIA.Infraestructure.Contracts.DTOs;

namespace SPRENCIA.Infraestructure.Contracts
{
    public interface IActivityScheduleRepository
    {
        //MMM Dto salida de horarios (datos para enviar al frontend: activityID + scheduleID). Se incluye como propiedad dentro de ActivityDto.
        Task<ActivitiyScheduleDto> Create(ActivitiyScheduleDto activityScheduleDto);


    }
}
