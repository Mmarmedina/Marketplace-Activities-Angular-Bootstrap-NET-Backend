using SPRENCIA.Domain.Models;
using SPRENCIA.Infraestructure.Contracts.DTOs;

namespace SPRENCIA.Infraestructure.Mappers
{
    public class ScheduleMapper
    {
        
        public static ScheduleDto MapToActivitiesSchedulesDtoFromEntity(ActivitiesSchedules scheduledAdded)
        {
            // El objeto que se crea en el servicio se convierte en tipo entidad.

            

            return scheduleDto;

        }

        /*public static ActivityDto MapToActivityDtoFromEntity(Activity activityAdded)
        {

            ActivityDto ActivityDto = new ActivityDto();
            ActivityDto.Title = activityAdded.Title;
            ActivityDto.Description = activityAdded.Description;
            ActivityDto.Price = activityAdded.Price;
            // MMM TODO Revisar cómo devuelve al frontend horarios?
            // ActivityDto.ActivitySchedules = activityAdded.ActivitySchedules; 

            return ActivityDto;

        }*/


    }   
}
