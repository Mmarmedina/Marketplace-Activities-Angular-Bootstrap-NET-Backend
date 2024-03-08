using SPRENCIA.Infraestructure.Contracts.DTOs;
using SPRENCIA.Domain.Models;

namespace SPRENCIA.Application.Mappers
{
    public class ActivityMapper
    {
        // Convertir LISTA de objetos tipo Actividad a lista de objetos tipo ActivityDto (solo información de la actividad, sin horarios y opiniones).
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

        // Convertir OBJETO tipo Actividad a objeto tipo ActivityDto (solo información de la actividad, sin horarios y opiniones).
        public static ActivityDto MapToActivityDto(Activity activity)
        {
            ActivityDto activityDto = new ActivityDto();
            activityDto.Id = activity.Id;
            activityDto.Title = activity.Title;
            activityDto.Description = activity.Description;
            activityDto.Price = activity.Price;
           
            return activityDto;
        }

        // Crear un objeto ActivityDto que contenga información de la actividad, los horarios y las opiniones para enviar al frontend (suma DTO ActivityDto, ScheduleDto, ReviewDto).
        public static ActivityDto MapToResponseActivityDto(ActivityDto activityDto, List<ScheduleDto> schedules, List<ReviewDto> reviews)
        {
            ActivityDto responseActivityDto = new ActivityDto();
            responseActivityDto.Id = activityDto.Id;
            responseActivityDto.Title = activityDto.Title;
            responseActivityDto.Description = activityDto.Description;
            responseActivityDto.Price = activityDto.Price;
            responseActivityDto.Schedule = schedules;
            responseActivityDto.Review = reviews;

            return responseActivityDto;
        }

        
        public static List<ActivityDto> MapToResponseActivitiesDto(List<ActivityDto> activitiesDto, List<ScheduleDto> schedulesDto)
        {
            List<ActivityDto> activitiesResponseDto = new List<ActivityDto>();

            foreach (ActivityDto activityDto in activitiesDto)
            {
                ActivityDto activityResponseDto = new ActivityDto();

                activityResponseDto.Id = activityDto.Id;
                activityResponseDto.Title = activityDto.Title;
                activityResponseDto.Description = activityDto.Description;
                activityResponseDto.Price = activityDto.Price;

                // Asignar los horarios a ActivityDto
                activityResponseDto.Schedule = schedulesDto;

                // Asignar las opiniones a ActivityDto
                

                // Agregar la actividad a la lista de actividades con los horarios (almacenada en activitiesResponseDto)
                activitiesResponseDto.Add(activityResponseDto);
            }

            return activitiesResponseDto;

        }
    }
}
