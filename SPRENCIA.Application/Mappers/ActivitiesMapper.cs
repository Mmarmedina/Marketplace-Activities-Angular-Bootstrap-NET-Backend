using SPRENCIA.Domain.Models;
using SPRENCIA.Infraestructure.Contracts.DTOs;


namespace SPRENCIA.Application.Mappers
{
    public class ActivitiesMapper
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

        // TODO: método de 

    }
}
