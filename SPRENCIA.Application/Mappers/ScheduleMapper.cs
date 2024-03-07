using SPRENCIA.Domain.Models;
using SPRENCIA.Infraestructure.Contracts.DTOs;

namespace SPRENCIA.Application.Mappers
{
    public class ScheduleMapper
    {
     
        // Convertir objeto tipo entidad (Schedule) a tipo DTO (ScheduleDto).
        public static ScheduleDto MapToScheduleDto(Schedule schedule) 
        {
           ScheduleDto scheduleDto =  new ScheduleDto();
           scheduleDto.Id = schedule.Id;
           scheduleDto.Name = schedule.Name;

           return scheduleDto;
        }

        // Pasar lista de objetos tipo entidad (Schedule - Horarios) a lista de objetos tipo DTO (ScheduleDto).
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

        /* Borrar: este método está en ActivitiesSchedulesMappers

        // Se toman dos objetos como entrada(ActivityAddRequestDto newActivity y ActivityDto activityAdded) y se mapean propiedades (activityId + ScheduleId) a un nuevo objeto ActivitiyScheduleDto, que luego es devuelto por la función.
        public static ActivitiyScheduleDto MapToActivitiesSchedulesDto(ActivityAddRequestDto newActivity, ActivityDto activityAdded)
        {
            ActivitiyScheduleDto activityScheduleDto = new ActivitiyScheduleDto();
            activityScheduleDto.ActivityId = activityAdded.Id;
            activityScheduleDto.ScheduleId = newActivity.Schedule;
            return activityScheduleDto;
        }
        */
    } 
}
