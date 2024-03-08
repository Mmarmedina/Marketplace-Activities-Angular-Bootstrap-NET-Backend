using SPRENCIA.Infraestructure.Contracts.DTOs;

namespace SPRENCIA.Infraestructure.Mappers
{
    public class ActivitiesSchedulesMapper
    {
        // Petición para crear una nueva actividad. Se toman dos objetos como entrada (ActivityAddRequestDto newActivity y ActivityDto activityAdded) y se mapean propiedades (activityId + ScheduleId) a un nuevo objeto ActivitiyScheduleDto, que luego son devueltos por la función.
        public static ActivitiyScheduleDto MapToActivitiesSchedulesDto(ActivityAddRequestDto newActivity, ActivityDto activityAdded)
        {
            ActivitiyScheduleDto activityScheduleDto = new ActivitiyScheduleDto();
            activityScheduleDto.ActivityId = activityAdded.Id;
            activityScheduleDto.ScheduleId = newActivity.Schedule;
            return activityScheduleDto;
        }
    }
}