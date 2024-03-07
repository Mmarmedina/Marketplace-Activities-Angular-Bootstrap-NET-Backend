using SPRENCIA.Infraestructure.Contracts.DTOs;
using SPRENCIA.Domain.Models;



namespace SPRENCIA.Application.Mappers
{
    public class ActivityMapper
    {
        // Convertir LISTA de objetos tipo Actividad a lista de objetos tipo ActivityDto.
        public static List<ActivityDto> MapToActivitiesDto(List<Activity> activities)
        {
            List<ActivityDto> activitiesDto = new List<ActivityDto>();

            foreach (Activity activity in activities)
            {
                // Se crea un objeto ActivityDto a partir del objeto Activity actual
                ActivityDto activityDto = ActivityMapper.MapToActivityDto(activity);
                activitiesDto.Add(activityDto);
            }

            return activitiesDto;

        }

        // Convertir OBJETO tipo Actividad a objeto tipo ActivityDto.
        public static ActivityDto MapToActivityDto(Activity activity)
        {
            ActivityDto activityDto = new ActivityDto();
            activityDto.Id = activity.Id;
            activityDto.Title = activity.Title;
            activityDto.Description = activity.Description;
            activityDto.Price = activity.Price;
            
            // ?activityDto.Review = activityDto.Review;
            // TODO: Hacerlo igual que las opiniones. 
           
            return activityDto;

        }

        // Crear un objeto ActivityDto que contenga información de la actividad, los horarios y las opiniones para enviar al frontend.
        public static ActivityDto MapToResponseActivityDto(ActivityDto activityDto, List<ScheduleDto> schedules)
        {
            ActivityDto responseActivityDto = new ActivityDto();
            responseActivityDto.Id = activityDto.Id;
            responseActivityDto.Title = activityDto.Title;
            responseActivityDto.Description = activityDto.Description;
            responseActivityDto.Price = activityDto.Price;
            responseActivityDto.Schedule = schedules;
            // Hacerlo igual que las opiniones. 

            return responseActivityDto;
        }

    }
}
