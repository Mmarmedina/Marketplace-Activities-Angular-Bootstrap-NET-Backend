﻿using SPRENCIA.Infraestructure.Contracts.DTOs;

namespace SPRENCIA.Infraestructure.Mappers
{
    public class ActivitiesSchedulesMapper
    {
        // Se toman dos objetos como entrada(ActivityAddRequestDto newActivity y ActivityDto activityAdded) y se mapean propiedades (activityId + ScheduleId) a un nuevo objeto ActivitiyScheduleDto, que luego es devuelto por la función.
        public static ActivitiyScheduleDto MapToActivitiesSchedulesDto(ActivityAddRequestDto newActivity, ActivityDto activityAdded)
        {
            ActivitiyScheduleDto activityScheduleDto = new ActivitiyScheduleDto();
            activityScheduleDto.ActivityId = activityAdded.Id;
            activityScheduleDto.ScheduleId = newActivity.Schedule;
            return activityScheduleDto;
        }
    }
}