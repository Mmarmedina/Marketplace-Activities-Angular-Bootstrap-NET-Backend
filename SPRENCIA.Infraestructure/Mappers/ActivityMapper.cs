using SPRENCIA.Domain.Models;
using SPRENCIA.Infraestructure.Contracts.DTOs;

namespace SPRENCIA.Infraestructure.Mappers
{
    public class ActivityMapper

    {
        // MMM Mapear los datos de un objeto ActivityAddRequestDto a un objeto Activity, para poder insertar una nueva actividad en BBDD.
        public static Activity MapToActivity(ActivityAddRequestDto newActivity)
        {
            // Está asignando el objeto newActivity (que es del tipo ActivityAddRequestDto) a una nueva variable llamada actividadRequestDto, del mismo tipo. 
            ActivityAddRequestDto activityRequestDto = newActivity;

            // Se crea objeto actividad (almacenado en la variable activity) y se le asignan los valores insertados por el usuario en el frontend (ActivityAddRequestDto)
            Activity activity = new Activity();
            activity.Title = activityRequestDto.Title;
            activity.Description = activityRequestDto.Description;
            activity.Price = activityRequestDto.Price;
          
            return activity;
        }

        // MMM Mapear los datos de una entidad Activity a un objeto DTO (ActivityDto).
        public static ActivityDto MapToActivityDtoFromEntity(Activity activityAdded)
        {
            ActivityDto activityDto = new ActivityDto();
            activityDto.Id = activityAdded.Id;
            activityDto.Title = activityAdded.Title;
            activityDto.Description = activityAdded.Description;
            activityDto.Price = activityAdded.Price;
           
            return activityDto;

        }

        // La actividad que se quiere actualizar se recupera de la base de datos (searchUpdatedActivity) y se le asignan los valores que ha enviado el frotend.
        public static Activity MapToActivityFromActivityUpdatedRequestDto(Activity searchUpdatedActivity, ActivityUpdatedRequestDto activityUpdatedRequestDto)
        {
            searchUpdatedActivity.Id = activityUpdatedRequestDto.Id;
            searchUpdatedActivity.Title = activityUpdatedRequestDto.Title;
            searchUpdatedActivity.Description = activityUpdatedRequestDto.Description;
            searchUpdatedActivity.Price = activityUpdatedRequestDto.Price;

            return searchUpdatedActivity;
        }
    }
}
