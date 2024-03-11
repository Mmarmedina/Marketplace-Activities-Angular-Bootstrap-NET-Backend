using Microsoft.EntityFrameworkCore;
using SPRENCIA.Domain.Models;
using SPRENCIA.Infraestructure.Contracts;
using SPRENCIA.Infraestructure.Contracts.DTOs;
using SPRENCIA.Infraestructure.Mappers;



namespace SPRENCIA.Infraestructure.Repositories
{
    public class ActivityRepository : IActivityRepository
    {    
        private readonly SprenciaDbContext _context;

        public ActivityRepository (SprenciaDbContext dbcontext)
        { 
            _context = dbcontext;
        }
        // MMM Método que hace petición a BBDD de todas las actividades.
        public async Task<List<Activity>> GetAll()
        {
            List<Activity> activities = await _context.Activities.ToListAsync();
            return activities;
        }

        // MMM Método que hace petición a BBDD de una actividad.
        public async Task<Activity?> GetById(int id)
        {
            Activity? activity = await _context.Activities.Where(x => x.Id == id).FirstOrDefaultAsync();
            return activity;
        }

        // MMM Método que pide a la BBDD insertar una actividad.
        public async Task<ActivityDto> Create(ActivityAddRequestDto newActivity)
        {
            // Se crea objeto actividad (almacenado en la variable activity) y se le asignan los valores insertados por el usuario en el frontend (ActivityAddRequestDto)
            Activity activity = Mappers.ActivityMapper.MapToActivity(newActivity);

            Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<Activity> activityAdded = await _context.Activities.AddAsync(activity);
            _context.SaveChanges();

            // Actividad añadida en base de datos se mapea a un DTO de salida para sacarlo en la API y enviarlo al frontend.
            ActivityDto activityDto = Mappers.ActivityMapper.MapToActivityDtoFromEntity(activityAdded.Entity);

            return activityDto;

        }

        public async Task<ActivityDto> Update(ActivityUpdatedRequestDto activityUpdateRequestDto)
        {
            // Primero buscar la actividad en BBDD.
            Activity? searchUpdatedActivity = await _context.Activities.Where(a => a.Id == activityUpdateRequestDto.Id).FirstOrDefaultAsync();

            // El objeto que devuelve la BBDD (actividad) se le asignan los valores actualizados que ha enviado el frontend.
            Activity activityUpdated = ActivityMapper.MapToActivityFromActivityUpdatedRequestDto(activityUpdateRequestDto, searchUpdatedActivity);

            // Actualizar la actividad en BBDD.
            _context.Activities.Update(activityUpdated);

            // Recuperar el horario/s de la actividad de la BBDD (entidad ActivitiesSchedules).
            List<ActivitiesSchedules> searchUpdateScheduleActivity = await _context.ActivitiesSchedules.Where(sa => sa.ActivityId == activityUpdateRequestDto.Id).ToListAsync();

            // Eliminar los registros existentes en ActivitiesSchedules
            _context.ActivitiesSchedules.RemoveRange(searchUpdateScheduleActivity);

            // Insertar los nuevos registros en ActivitiesShedules con los nuevos horarios.
            // Crear una lista de ActivitiesSchedules 

            // Del ActivityUpdatedRequestDto tengo el ID, y el scheduleID

            List<ActivitiesSchedules> activitySchedulesUpdated = new List<ActivitiesSchedules>();
           
            foreach (ActivitiesSchedules schedule in searchUpdateScheduleActivity)
            {
                ActivitiesSchedules activityScheduleUpdated = new ActivitiesSchedules();
                activityScheduleUpdated.ActivityId = schedule.ActivityId;
                activityScheduleUpdated.ScheduleId = schedule.ScheduleId;

                _context.ActivitiesSchedules.Add(activityScheduleUpdated);
            }

            // Guardar los cambios. 
            _context.SaveChanges();

            // Método que devuelve una la actividad y sus horarios (innher join (activities + activitiesSchedules).
            List<ActivitiesSchedulesActivities> activityWithSchedules = await GetByIdWithSchedules(activityUpdateRequestDto);

            ActivityDto activityUpdatedDto = ActivityMapper.MapToResponseActivitityUpdateDto(activityUpdated, activityWithSchedules);

            return activityUpdatedDto;

        }

        // MMM Recuperar todos los registros activities_schedules + schedules (inner join entre ambas entidades).
        public async Task<List<ActivitiesSchedulesActivities>> GetByIdWithSchedules(ActivityUpdatedRequestDto activityUpdateRequestDto)
        {
            List<ActivitiesSchedulesActivities> activityWithSchedules = await _context.ActivitiesSchedules
                .Where(sa => sa.ActivityId == activityUpdateRequestDto.Id)
                .Join(
                _context.Activities,
                   sa => sa.ActivityId,
                   a => a.Id,
                   (sa, a) => new ActivitiesSchedulesActivities
                   {
                       ActivitiesSchedules = new List<ActivitiesSchedules> { sa },
                       Activities = new List<Activity> { a }
                   })
               .ToListAsync();

            return activityWithSchedules;
        }

        /*
         * // MMM Recuperar todos los registros activities_schedules + schedules (inner join entre ambas entidades).
        public async Task<List<ActivitiesSchedulesSchedules>> GetByIdWithSchedules(int id)
        {
            List<ActivitiesSchedulesSchedules> activityWithSchedules = await _context.ActivitiesSchedules
                .Where(sa => sa.ActivityId == id)
                .Join(
                _context.Schedules,
                   sa => sa.ScheduleId,
                   s => s.Id,
                   (sa, s) => new ActivitiesSchedulesSchedules
                   {
                       ActivitiesSchedules = new List<ActivitiesSchedules> { sa },
                       Schedules = new List<Schedule> { s }
                   })
               .ToListAsync();

            return activityWithSchedules;
        }
        */





















        /*
         * public async Task<Activity> Update(ActivityUpdatedRequestDto activityUpdateRequestDto)
        {
            // Primero buscar la actividad en BBDD.
            Activity? searchUpdatedActivity = await _context.Activities.Where(a => a.Id == activityUpdateRequestDto.Id).FirstOrDefaultAsync();

            // El objeto que devuelve la BBDD (actividad) se le asignan los valores que ha enviado el frontend.
            Activity activityUpdated = ActivityMapper.MapToActivityFromActivityUpdatedRequestDto(activityUpdateRequestDto, searchUpdatedActivity);

            // Actualizar la actividad en BBDD.
            _context.Activities.Update(activityUpdated);

            // Recuperar el horario/s de la actividad de la BBDD (entidad ActivitiesSchedules).
            List<ActivitiesSchedules> searchUpdateScheduleActivity = await _context.ActivitiesSchedules.Where(sa => sa.ActivityId == activityUpdateRequestDto.Id).ToListAsync();

            // Eliminar los registros existentes en ActivitiesSchedules
            _context.ActivitiesSchedules.RemoveRange(searchUpdateScheduleActivity);

            // Insertar los nuevos registros en ActivitiesShedules con los nuevos horarios.
            foreach (ActivitiesSchedules schedule in searchUpdateScheduleActivity)
            {
                _context.ActivitiesSchedules.Add(new ActivitiesSchedules
                {
                    ActivityId = schedule.ActivityId,
                    ScheduleId = schedule.ScheduleId,
                });
            }

            // Guardar los cambios. 
            _context.SaveChanges();

            return activityUpdated;
        }

        */


        /*
        public async Task<Activity> Update(ActivityUpdatedRequestDto activityUpdateRequestDto)
        {
            // Primero buscar la actividad en BBDD.
            Activity? searchUpdatedActivity = await _context.Activities.Where(a => a.Id == activityUpdateRequestDto.Id).FirstOrDefaultAsync();

            // El objeto que devuelve la BBDD (actividad) se le asignan los valores que ha enviado el frontend.
            Activity activityUpdated = ActivityMapper.MapToActivityFromActivityUpdatedRequestDto(searchUpdatedActivity, activityUpdateRequestDto);

            // Modificar el contexto en la memoria y guardar los cambios en BBDD.
            _context.Activities.Update(activityUpdated);
            _context.SaveChanges();

            return activityUpdated;
        }
        */

        // MMM Método que pide a la base de datos eliminar una actividad.
        public async Task<bool> DeleteById(int id)
        {
            Activity? activityDeleted = await _context.Activities.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (activityDeleted != null)
            {
                _context.Activities.Remove(activityDeleted);
                _context.SaveChanges();
                return true;
            }
            
            return false;
        }
    }
}
