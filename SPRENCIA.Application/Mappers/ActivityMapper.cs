using SPRENCIA.Domain.Models;
using SPRENCIA.Infraestructure.Contracts.DTOs;

namespace SPRENCIA.Application.Mappers
{
    public class ActivityMapper
    {
        // MMM Crear un OBJETO ActivityDto que contenga información de la actividad, los horarios y las opiniones para enviar al frontend (suma DTO ActivityDto, ScheduleDto, ReviewDto).
        public static ActivityDto MapToResponseActivityDto(ActivityDto activityDto, List<ScheduleDto> schedules, List<ReviewWithActivityIdDto> reviews)
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

        // MMM Crear UNA LISTA DE OBJETOS del tipo ActivityDto que contenga información de la actividad, los horarios y las opiniones para enviar al frontend (suma DTO ActivityDto, ActivitiesSchedulesSchedule, ReviewDtoWithActivityIdDto).
        public static List<ActivityDto> MapToResponseActivitiesDto(List<ActivityDto> activitiesDto, List<ActivitiesSchedulesSchedules> activitiesShedulesDto, List<ReviewWithActivityIdDto> reviewsDto)
        {
            // MMM Se inciacializa una nueva lista de ActivityDto que almacenará las actividades con sus horarios y opiniones.
            List<ActivityDto> activitiesResponseDto = new List<ActivityDto>();

            // MMM Se itera sobre la lista de actividades pasadas por parámetro en la variable activitiesDto.
            foreach (ActivityDto activityDto in activitiesDto)
            {
                // MMM Se crea un nuevo objeto ActivityDto para almacenar las actividades con los horarios.
                ActivityDto activityResponseDto = new ActivityDto();

                // MMM Se copian las propiedades y valores de activityDto pasado por parámetro al objeto que va almacenar la respuesta para el frontend: activityResponseDto.
                activityResponseDto.Id = activityDto.Id;
                activityResponseDto.Title = activityDto.Title;
                activityResponseDto.Description = activityDto.Description;
                activityResponseDto.Price = activityDto.Price;

                // MMM Lógica para asignar los horarios a cada actividad.

                // Mapear convertir lista de objetos tipo Activities_Schedules + Schedules en SchedulesDto.
                List<ScheduleDto> schedulesForActivity = ScheduleMapper.MapToSchedulesDtoFromJoinActivitiesSchedulesSchedules(activityDto, activitiesShedulesDto);

                // Se asigna la lista de horarios filtrados (schedulesForActivity) a la propiedad Schedule de la actividad actual.
                activityResponseDto.Schedule = schedulesForActivity;

                List<ReviewWithActivityIdDto> reviewsForActivity = new List<ReviewWithActivityIdDto>();

                foreach (ReviewWithActivityIdDto reviewDto in reviewsDto)
                {
                    if (reviewDto.ActivityId == activityDto.Id)
                    {
                        ReviewWithActivityIdDto reviewDtoItem = new ReviewWithActivityIdDto
                        {
                            Id = reviewDto.Id,
                            ReviewText = reviewDto.ReviewText,
                            ActivityId = reviewDto.ActivityId
                        };

                        reviewsForActivity.Add(reviewDtoItem);
                    }
                }

                // Asignar las opiniones a ActivityDto
                activityResponseDto.Review = reviewsForActivity;

                activitiesResponseDto.Add(activityResponseDto);
            }
            
            
            return activitiesResponseDto;
            
        }

        // MMM Convertir UN OBJETO tipo Actividad a objeto tipo ActivityDto (solo información de la actividad, sin horarios ni opiniones).
        public static ActivityDto MapToActivityDto(Activity activity)
        {
            ActivityDto activityDto = new ActivityDto();
            activityDto.Id = activity.Id;
            activityDto.Title = activity.Title;
            activityDto.Description = activity.Description;
            activityDto.Price = activity.Price;

            return activityDto;
        }

        // MMM Convertir LISTA de objetos tipo Actividad a lista de objetos tipo ActivityDto (solo información de la actividad, sin horarios ni opiniones).
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

        
    }
}
