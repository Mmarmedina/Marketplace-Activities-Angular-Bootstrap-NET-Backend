﻿using SPRENCIA.Application.Contracts.Services;
using SPRENCIA.Application.Mappers;
using SPRENCIA.Domain.Models;
using SPRENCIA.Infraestructure.Contracts;
using SPRENCIA.Infraestructure.Contracts.DTOs;
using SPRENCIA.Infraestructure.Mappers;


namespace SPRENCIA.Application.Services
{
    public class ActivityService : IActivityService
    {
        private readonly IActivityRepository _activityRepository;
        private readonly IActivityScheduleRepository _activityScheduleRepository;
        private readonly IScheduleRepository _scheduleRepository;
       

        public ActivityService(IActivityRepository activityRepository, IActivityScheduleRepository activityScheduleRepository, IScheduleRepository scheduleRepository)
        {
            _activityRepository = activityRepository;
            _activityScheduleRepository = activityScheduleRepository;
            _scheduleRepository = scheduleRepository;
        }

        public async Task<List<ActivityDto>> GetAll()
        {
            // Petición al repositorio que devuelva todas las actividades. La variable activities guarda una lista de objetos tipo entidad, de la tabla actividades.
            List<Activity> activities = await _activityRepository.GetAll();

            // Mapear la lista de objetos tipo actividad a lista de objetos tipo ActivityDTO.
            List<ActivityDto> activitiesDto = ActivityMapper.MapToActivitiesDto(activities);

            // Solicitud de consulta al repositorio de todos horarios de todas las actividades (inner join: tablas activities_schedules + schedules). El método devuelve solo los horarios de las actividades.
            List<Schedule> shedules = await _scheduleRepository.GetAllAllActivities();

            // Mapear los registros de la tabla schedules para que estén tipados como SchedulesDto.
            List<ScheduleDto> scheduleDtos = ScheduleMapper.MaptoSchedulesDto(shedules);

            // Añadir los horarios al objeto respuesta que devuelve la API (que incluye actividad, horarios y opiniones).
            List<ActivityDto> activitiesResponseDto = ActivityMapper.MapToResponseActivitiesDto(activitiesDto, scheduleDtos);

            return activitiesResponseDto;
        }

        public async Task<ActivityDto> GetById(int id)
        {
            Activity activity = await _activityRepository.GetById(id);

            ActivityDto activityDto = ActivityMapper.MapToActivityDto(activity);

            // Se recuperan los horarios de una actividad mediante la relación las entidades activities_schedules + schedules.
            List<Schedule> schedules = await _scheduleRepository.GetAllOnlyAnActivity(activityDto.Id);

            // Mapear lista de objetos (horarios) recuperada de tipo entidad (Schedule) a lista objetos tipo DTO (ScheduleDto).
            List<ScheduleDto> schedulesDto = ScheduleMapper.MaptoSchedulesDto(schedules);

            // Añadir los horarios al objeto respuesta que devuelve la API (que incluye actividad, horarios y opiniones).
            ActivityDto activityResponseDto = ActivityMapper.MapToResponseActivityDto(activityDto, schedulesDto);

            return activityResponseDto;
        }
        
        public async Task<ActivityDto> Create(ActivityAddRequestDto newActivity)
        {
            ActivityDto? activityAdded = null;
            ActivityDto? activityResponseDto = null;
            
            // Se verifica si la variable newActivity es nula (es decir, si llega el objeto con la información del front).

            if (newActivity != null)
            {
                // Si los datos son válidos, se llama al método Create del repositorio de actividad para crear la nueva actividad.
                // El objeto que devuelve el método del servicio es del tipo ActivityDto.

                activityAdded = await _activityRepository.Create(newActivity);

                // Al crear la actividad se indica uno o varios horarios para ésta. El horario de la nueva actividad se debe insertar en la entidad activities_schedules.
                // El activityID se saca de la variable activityAdded (que se crea tras insertar la nueva actividad en BBDD), y el horario se saca del DTO de entrada (ActivityAddRequestDto) que incluye el horario que se le ha asignado a la actividad desde el frontend.
                
                ActivitiyScheduleDto activitySchedule = ActivitiesSchedulesMapper.MapToActivitiesSchedulesDto(newActivity, activityAdded);

                // Insertar los horarios de la nueva actividad en la tabla activities_schedules.
                ActivitiyScheduleDto scheduleAdded = await _activityScheduleRepository.Create(activitySchedule);

                // Recuperar de la tabla Schedules los horarios de la actividad creada.
                List<Schedule> schedulesActivity = await _scheduleRepository.GetByIdList(activitySchedule.ScheduleId);

                // Mapear lista de objetos recuperada de tipo entidad (Schedule) a lista objetos tipo DTO (ScheduleDto).
                List<ScheduleDto> schedulesDto = ScheduleMapper.MaptoSchedulesDto(schedulesActivity);

                // Asignar el horario a activityDto
                activityResponseDto = ActivityMapper.MapToResponseActivityDto(activityAdded, schedulesDto);

            }
            return activityResponseDto;
        }

        public async Task<bool> DeleteById(int id)
        {
            bool activityDeleted = await _activityRepository.DeleteById(id);

            if (activityDeleted == true)
            {
                return true;
            }

            return false;
        }
    }
}
