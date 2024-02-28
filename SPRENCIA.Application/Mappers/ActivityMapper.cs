using SPRENCIA.Infraestructure.Contracts.DTOs;
using SPRENCIA.Domain.Models;



namespace SPRENCIA.Application.Mappers
{
    public class ActivityMapper
    {
        public static ActivityDto MapToActivityDto(Activity activity)
        {
            ActivityDto activityDto = new ActivityDto();
            activityDto.Id = activity.Id;
            activityDto.Title = activity.Title;
            activityDto.Description = activity.Description;
            activityDto.Price = activity.Price;

            return activityDto;

        }
    }
}
