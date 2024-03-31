using SPRENCIA.Domain.Models;
using SPRENCIA.Infraestructure.Contracts.DTOs;

namespace SPRENCIA.Infraestructure.Mappers
{
    public class ActivityMapper

    {
        // MMM Convertir un objeto ActivityAddRequestDto a un objeto Activity para poder insertar una nueva actividad en BBDD.
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

        // MMM Convertir un objeto Activity en ActivityDto (solo con la información de la actividad). No se incluyen horarios ni opiniones.
        public static ActivityDto MapToActivityDtoFromEntity(Activity activityAdded)
        {
            ActivityDto activityDto = new ActivityDto();
            activityDto.Id = activityAdded.Id;
            activityDto.Title = activityAdded.Title;
            activityDto.Description = activityAdded.Description;
            activityDto.Price = activityAdded.Price;
           
            return activityDto;

        }

        // MMM Petición POST de actividades. La actividad que se quiere actualizar se recupera de la base de datos (searchUpdatedActivity) y se le asignan los valores que ha enviado el frontend (sólo los datos relativos a la actividad).
        public static Activity MapToActivityFromActivityUpdatedRequestDto(ActivityUpdatedRequestDto activityUpdatedRequestDto, Activity searchUpdatedActivity)
        {
            searchUpdatedActivity.Id = activityUpdatedRequestDto.Id;
            searchUpdatedActivity.Title = activityUpdatedRequestDto.Title;
            searchUpdatedActivity.Description = activityUpdatedRequestDto.Description;
            searchUpdatedActivity.Price = activityUpdatedRequestDto.Price;

            return searchUpdatedActivity; 
        }

        // MMM Crear un OBJETO ActivityDto que contenga información de la actividad y los horarios para devolverlo al frontend una vez ha sido editada la actividad y guardada en la BBDD.
        public static ActivityDto MapToResponseActivityDto(ActivityDto activityDto, List<ScheduleDto> schedulesDto, List<ReviewWithActivityIdDto> reviewsDto)
        {
            ActivityDto responseActivityDto = new ActivityDto();
            responseActivityDto.Id = activityDto.Id;
            responseActivityDto.Title = activityDto.Title;
            responseActivityDto.Description = activityDto.Description;
            responseActivityDto.Price = activityDto.Price;
            responseActivityDto.Schedule = schedulesDto;
            responseActivityDto.Review = reviewsDto;

            return responseActivityDto;
        }

    }
}
