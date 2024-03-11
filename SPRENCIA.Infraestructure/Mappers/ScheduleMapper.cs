using SPRENCIA.Domain.Models;
using SPRENCIA.Infraestructure.Contracts.DTOs;

namespace SPRENCIA.Infraestructure.Mappers
{
    public class ScheduleMapper
    {
        // MMM Mapear lista de DTO (activityScheduleDto) a una LISTA DE OBJETOS tipo entidad ActivitiesSchedules.

        public static List<ActivitiesSchedules> MapToActivitySchedules(ActivitiyScheduleDto activityScheduleDto)
        {

            List<ActivitiesSchedules> activitySchedules = new List<ActivitiesSchedules>();

            foreach (int scheduleId in activityScheduleDto.ScheduleId)
            {
                ActivitiesSchedules activitiesSchedule = new ActivitiesSchedules();
                activitiesSchedule.ActivityId = activityScheduleDto.ActivityId;
                activitiesSchedule.ScheduleId = scheduleId;

                activitySchedules.Add(activitiesSchedule);
            }

            return activitySchedules;

        }

        public static List<ScheduleDto> MapToSchedulesDtoFromJoinActivitiesSchedulesActivities(ActivityDto activityDto, List<ActivitiesSchedulesSchedules> activitiesShedulesDto)
        {
            // Se crea un objeto del tipo ScheduleDto(que tendrá el ID del horario y el horario).
            List<ScheduleDto> schedulesForActivity = new List<ScheduleDto>();

            // Se ha recibido por parémetro una lista que es la suma de ActivitiesSchedules + Schedules, almacenada en activitiesShedulesDto. 
            // Se usa un bucle anidado para iterar dentro de la tabla ActivitiesSchedules que está dentro de activitiesShedulesDto. 
            foreach (ActivitiesSchedulesSchedules activitySchedulesDtoItem in activitiesShedulesDto)
            {
                foreach (ActivitiesSchedules activitySchedule in activitySchedulesDtoItem.ActivitiesSchedules)
                {
                    // Si el ID de la actividad (contenido en activityDto) conincide con el ID de la actividad de la tabla intermedia (activities_schedules), se crea un objeto ScheduleDto, con el ID del horario y su el Name de éste. 
                    if (activitySchedule.ActivityId == activityDto.Id)
                    {
                        ScheduleDto scheduleDto = new ScheduleDto
                        {
                            Id = activitySchedule.ScheduleId,
                            Name = activitySchedule.Schedule.Name
                        };
                        // Cada objeto creado en cada vuelta se añade a schedulesForActivities.
                        schedulesForActivity.Add(scheduleDto);
                    }
                }
            }

            return schedulesForActivity;
        }
    }

    
   
}

