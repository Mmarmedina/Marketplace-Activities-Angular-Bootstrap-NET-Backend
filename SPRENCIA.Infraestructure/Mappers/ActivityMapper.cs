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

        // La actividad que se quiere actualizar se recupera de la base de datos (searchUpdatedActivity) y se le asignan los valores que ha enviado el frontend.
        public static Activity MapToActivityFromActivityUpdatedRequestDto(ActivityUpdatedRequestDto activityUpdatedRequestDto, Activity searchUpdatedActivity)
        {
            searchUpdatedActivity.Id = activityUpdatedRequestDto.Id;
            searchUpdatedActivity.Title = activityUpdatedRequestDto.Title;
            searchUpdatedActivity.Description = activityUpdatedRequestDto.Description;
            searchUpdatedActivity.Price = activityUpdatedRequestDto.Price;

            return searchUpdatedActivity;
        }

        // Una vez que actualiza la actividad método para devolver un DTO con la información editada de la actividad y su horario.
        public static ActivityDto MapToResponseActivitityUpdateDto(Activity activityUpdated, List<ActivitiesSchedulesActivities> activitiesShedulesActivities)
        {
            ActivityDto activityResponseDto = new ActivityDto();

            // Aquí se coge la actividad actualizada de la base de datos y se mapea pra que se activityDto. 
            ActivityDto activityUpdatedDto = ActivityMapper.MapToActivityDtoFromEntity(activityUpdated);

            // Lógica para crear el ScheduleDto, con la información del horario de la actividad para devolver al frontend.
            // Se crea un objeto del tipo ScheduleDto(que tendrá el ID del horario y el horario).
            List<ScheduleDto> schedulesForActivity = new List<ScheduleDto>();

            // Se ha recibido por parémetro una lista que es la suma de ActivitiesSchedules + Activities.
            // Se usa un bucle anidado para iterar dentro de la tabla ActivitiesSchedules que está dentro de activitiesShedulesDto. 
            foreach (ActivitiesSchedulesActivities activitiesShedulesActivitiesItem in activitiesShedulesActivities)
            {
                foreach (ActivitiesSchedules activitySchedule in activitiesShedulesActivitiesItem.ActivitiesSchedules)
                {
                    // Si el ID de la actividad (contenido en activityDto) conincide con el ID de la actividad de la tabla intermedia (activities_schedules), se crea un objeto ScheduleDto, con el ID del horario y su el Name de éste. 
                    if (activitySchedule.ActivityId == activityUpdated.Id)
                    {
                        ScheduleDto scheduleDto = new ScheduleDto()
                        {
                            Id = activitySchedule.ScheduleId,
                            // Name = activitySchedule.Schedule.Name
                        };
                        // Cada objeto creado en cada vuelta se añade a schedulesForActivities.
                        schedulesForActivity.Add(scheduleDto);
                    }
                }
            }

            activityUpdatedDto.Schedule = schedulesForActivity;

            return activityResponseDto;

        }

        // Crear un ActivityDto para enviar al servicio. 



        /*
        public static ActivityDto MapToResponseActivityDto(ActivityDto activityDto, List<ScheduleDto> schedules)
        {
            ActivityDto responseActivityDto = new ActivityDto();
            responseActivityDto.Id = activityDto.Id;
            responseActivityDto.Title = activityDto.Title;
            responseActivityDto.Description = activityDto.Description;
            responseActivityDto.Price = activityDto.Price;
            responseActivityDto.Schedule = schedules;
            

            return responseActivityDto;
        }

        public static Schedule MaptToScheduleDtoFromActivityUpdatedRequestDto(List<ActivitiesSchedules> searchUpdateScheduleActivity)
        {
            foreach (ActivitiesSchedules schedule in searchUpdateScheduleActivity)
            {
                ScheduleDto scheduleDto = new Schedule();
                scheduleDto.Id = schedule.Id;

            }

            return 
        }

        */



    }
}
