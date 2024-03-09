using SPRENCIA.Domain.Models;
using SPRENCIA.Infraestructure.Contracts.DTOs;

namespace SPRENCIA.Application.Mappers
{
    public class ScheduleMapper
    {
        // MMM Convertir OBJETO tipo entidad (Schedule) a tipo DTO (ScheduleDto).
        public static ScheduleDto MapToScheduleDto(Schedule schedule) 
        {
           ScheduleDto scheduleDto =  new ScheduleDto();
           scheduleDto.Id = schedule.Id;
           scheduleDto.Name = schedule.Name;

           return scheduleDto;
        }

        // MMM Pasar UNA LISTA DE OBJETOS tipo entidad (Schedule - Horarios) a lista de objetos tipo DTO (ScheduleDto).
        public static List<ScheduleDto> MaptoSchedulesDto(List<Schedule> schedules)
        {
            List<ScheduleDto> schedulesDto = new List<ScheduleDto>();

            foreach (Schedule schedule in schedules)
            {
                ScheduleDto scheduleDto = ScheduleMapper.MapToScheduleDto(schedule);
                schedulesDto.Add(scheduleDto);
            }

            return schedulesDto;

        }
    } 
}
