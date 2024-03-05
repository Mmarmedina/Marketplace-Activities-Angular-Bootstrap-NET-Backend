using SPRENCIA.Infraestructure.Contracts.DTOs;

namespace SPRENCIA.Application.Mappers
{
    public class ScheduleMapper
    {
        public static ActivitiyScheduleDto MapToActivitiesSchedulesDto(ActivityAddRequestDto newActivity, ActivityDto activityAdded)
        {
            ActivitiyScheduleDto activityScheduleDto = new ActivitiyScheduleDto();
            activityScheduleDto.ActivityId = activityAdded.Id;
            activityScheduleDto.ScheduleId = newActivity.Schedule;
            return activityScheduleDto;
        }
        
    }
}
