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
            // TODO: falta horario.
            // activity.ActivitySchedules = activityRequestDto.ActivitySchedules;?

            return activity;

        }

        public static ActivityDto MapToActivityDtoFromEntity(Activity activityAdded)
        {
                        
            ActivityDto ActivityDto = new ActivityDto();
            ActivityDto.Title = activityAdded.Title;
            ActivityDto.Description = activityAdded.Description;
            ActivityDto.Price = activityAdded.Price;
            // MMM TODO Revisar cómo devuelve al frontend horarios?
            // ActivityDto.ActivitySchedules = activityAdded.ActivitySchedules; 

            return ActivityDto;

        }













    }

       
    
}
