using SPRENCIA.Domain.Models;
using SPRENCIA.Infraestructure.Contracts.DTOs;

namespace SPRENCIA.Infraestructure.Mappers
{
    public class ActivityMapper
    {
        public static Activity MapToActivity(ActivityAddRequestDto newActivity)
        {
            ActivityAddRequestDto activityRequestDto = newActivity;

            // Se crea objeto actividad (almacenado en la variable activity) y se le asignan los valores insertados por el usuario en el frontend (ActivityAddRequestDto)
            Activity activity = new Activity();
            activity.Title = activityRequestDto.Title;
            activity.Description = activityRequestDto.Description;
            activity.Price = activityRequestDto.Price;
          
            return activity;
        }

        public static ActivityDto MapToActivityDtoFromEntity(Activity activityAdded)
        {
                        
            ActivityDto activityDto = new ActivityDto();
            activityDto.Id = activityAdded.Id;
            activityDto.Title = activityAdded.Title;
            activityDto.Description = activityAdded.Description;
            activityDto.Price = activityAdded.Price;

            return activityDto;

        }

    }    
}
