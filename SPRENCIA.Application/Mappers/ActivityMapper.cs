using SPRENCIA.Infraestructure.Contracts.DTOs;
using SPRENCIA.Domain.Models;



namespace SPRENCIA.Application.Mappers
{
    public class ActivityMapper
    {
        public static List<ActivityDto> MapToActivitiesDto(List<Activity> activities)
        {
            List<ActivityDto> activitiesDto = new List<ActivityDto>();

            foreach (Activity activity in activities)
            {
                ActivityDto activityDto = ActivityMapper.MapToActivityDto(activity);
                activitiesDto.Add(activityDto);
            }

            return activitiesDto;

        }

        public static ActivityDto MapToActivityDto(Activity activity)
        {
            ActivityDto activityDto = new ActivityDto();
            activityDto.Id = activity.Id;
            activityDto.Title = activity.Title;
            activityDto.Description = activity.Description;
            activityDto.Price = activity.Price;
            activityDto.Review = activityDto.Review;
            // Hacerlo igual que las opiniones. 
           // activityDto.ActivitiesSchedulesAndSchedules = activityDto.ActivitiesSchedulesAndSchedules;
            return activityDto;

        }

       
    }
}
