using SPRENCIA.Infraestructure.Contracts.DTOs;

namespace SPRENCIA.Application.Mappers
{
    public class ScheduleMapper
    {
        public static ActivitiyScheduleDto MapToActivitiesSchedulesDto(ActivityAddRequestDto newActivity, ActivityDto activityAdded)
        {
            ActivitiyScheduleDto newSchedule = new ActivitiyScheduleDto();
            newSchedule.ActivityId = activityAdded.Id;
            newSchedule.ScheduleId = newActivity.Schedule;
            return newSchedule;
        }
        
    }
}
