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
