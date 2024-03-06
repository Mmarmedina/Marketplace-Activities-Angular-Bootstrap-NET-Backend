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

        /*
        
        public static ActivitiesSchedules MapToActivitySchedule(ActivitiyScheduleDto activityScheduleDto)
        {

            ActivitiesSchedules activitySchedule = new ActivitiesSchedules();
            activitySchedule.ActivityId = activityScheduleDto.ActivityId;





            activitySchedule.ScheduleId = activitySchedule.ScheduleId;

            return activitySchedule;

        }
        
        
        /* 

        public static ActivitiyScheduleDto MapToActivitiyScheduleDto(ActivitiesSchedules scheduleAdded)
        {
            ActivitiyScheduleDto activityScheduleDto = new ActivitiyScheduleDto();
            
            activityScheduleDto.ActivityId = scheduleAdded.ActivityId;
            
            List<int> scheduleIdList = new List<int> { scheduleAdded.ScheduleId };
            activityScheduleDto.ScheduleId = scheduleIdList;

            return activityScheduleDto;
        }

       

        /*
        
        public static ActivitiyScheduleDto MapToActivitiyScheduleDto(ActivitiesSchedules scheduleAdded)
        {
            List<ActivitiyScheduleDto> activityScheduleDtoList = new List<ActivitiyScheduleDto>();

            foreach (ActivitiesSchedules schedule in scheduleAdded)
            {
                ActivitiyScheduleDto activityScheduleDto = new ActivitiyScheduleDto();
                activityScheduleDto.ActivityId = schedule.ActivityId;

                List<int> scheduleIdList = new List<int> { schedule.ScheduleId };
                activityScheduleDto.ScheduleId = scheduleIdList;

                activityScheduleDtoList.Add(activityScheduleDto);
            }

            return activityScheduleDto;

        } 
        */
    }

}   

