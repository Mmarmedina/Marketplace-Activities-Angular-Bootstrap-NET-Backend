using SPRENCIA.Infraestructure.Contracts.DTOs;

namespace SPRENCIA.Infraestructure.Mappers
{
    public class ActivitiesSchedulesMapper
    {
        /// MMM
        // Se usa en la petición para crear una nueva actividad.
        // Queremos crear un DTO que represente los campos de un registro de la entidad activities_schedules (activityId + scheduleId).
        // El DTO se llama: activityScheduleDto.
        // Para crearlo se pasan como parámetros ActivityAddRequestDto newActivity, ActivityDto activityAdded.
        // En la variable newActivity está el activityId de la actividad creada, mientras que activityAdded, los horarios de la nueva actividad.

        public static ActivitiyScheduleDto MapToActivitiesSchedulesDto(ActivityAddRequestDto newActivity, ActivityDto activityAdded)
        {
            ActivitiyScheduleDto activityScheduleDto = new ActivitiyScheduleDto();
            activityScheduleDto.ActivityId = activityAdded.Id;
            activityScheduleDto.ScheduleId = newActivity.Schedule;
            return activityScheduleDto;
        }
    }
}