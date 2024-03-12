using SPRENCIA.Domain.Models;
using SPRENCIA.Infraestructure.Contracts.DTOs;

namespace SPRENCIA.Application.Mappers
{
    public class ScheduleMapper
    {
        // MMM Convertir OBJETO tipo entidad (Schedule) a tipo DTO (ScheduleDto).
        public static ScheduleDto MapToScheduleDto(Schedule schedule) 
        {
           ScheduleDto scheduleDto =  new ScheduleDto();
           scheduleDto.Id = schedule.Id;
           scheduleDto.Name = schedule.Name;

           return scheduleDto;
        }

        // MMM Pasar UNA LISTA DE OBJETOS tipo entidad (Schedule - Horarios) a lista de objetos tipo DTO (ScheduleDto).
        public static List<ScheduleDto> MaptoSchedulesDto(List<Schedule> schedules)
        {
            List<ScheduleDto> schedulesDto = new List<ScheduleDto>();

            foreach (Schedule schedule in schedules)
            {
                ScheduleDto scheduleDto = ScheduleMapper.MapToScheduleDto(schedule);
                schedulesDto.Add(scheduleDto);
            }

            return schedulesDto;

        }

        // MMM Convertir una LISTA DE OBJETOS del tipo ActivitiesSchedules + Schedules, en una lista de objetos SchedulesDto.
        // Se usa para asignar a cada actividad sus horarios en la petición HTTP GET para recuperar todas las actividades, con la información de los horarios y opiniones.
        public static List<ScheduleDto> MapToSchedulesDto(ActivityDto activityDto, List<ActivitiesSchedulesSchedules> activitiesShedules)
        {
            // Se crea un objeto del tipo ScheduleDto(que tendrá el ID del horario y el horario).
            List<ScheduleDto> schedulesForActivity = new List<ScheduleDto>();

            // Se ha recibido por parémetro una lista que es la suma de ActivitiesSchedules + Schedules, almacenada en activitiesShedulesDto. 
            // Se usa un bucle anidado para iterar dentro de la tabla ActivitiesSchedules que está dentro de activitiesShedulesDto. 
            foreach (ActivitiesSchedulesSchedules activitySchedulesDtoItem in activitiesShedules)
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

        // Se usa en la petición de Update (ActivityService).
        public static List<ScheduleDto> MapToSchedulesDtoFromJoinActivitiesSchedulesSchedules(Activity activity, List<ActivitiesSchedulesSchedules> activitiesShedules)
        {
            // Se crea un objeto del tipo ScheduleDto(que tendrá el ID del horario y el horario).
            List<ScheduleDto> schedulesForActivity = new List<ScheduleDto>();

            // Se ha recibido por parémetro una lista que es la suma de ActivitiesSchedules + Schedules, almacenada en activitiesShedulesDto. 
            // Se usa un bucle anidado para iterar dentro de la tabla ActivitiesSchedules que está dentro de activitiesShedulesDto. 
            foreach (ActivitiesSchedulesSchedules activitySchedulesDtoItem in activitiesShedules)
            {
                foreach (ActivitiesSchedules activitySchedule in activitySchedulesDtoItem.ActivitiesSchedules)
                {
                    // Si el ID de la actividad (contenido en activityDto) conincide con el ID de la actividad de la tabla intermedia (activities_schedules), se crea un objeto ScheduleDto, con el ID del horario y su el Name de éste. 
                    if (activitySchedule.ActivityId == activity.Id)
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
