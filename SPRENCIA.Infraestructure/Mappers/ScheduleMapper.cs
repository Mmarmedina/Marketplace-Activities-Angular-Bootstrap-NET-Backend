using SPRENCIA.Domain.Models;
using SPRENCIA.Infraestructure.Contracts.DTOs;

namespace SPRENCIA.Infraestructure.Mappers
{
    public class ScheduleMapper
    {
        // Aquí hay que mapear el activityScheduleDto a una lista de objetos tipo entidad ActivitiesSchedules.

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

    }

}   

