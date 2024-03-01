using Microsoft.EntityFrameworkCore;
using SPRENCIA.Domain.Models;
using SPRENCIA.Infraestructure.Contracts;
using SPRENCIA.Infraestructure.Contracts.DTOs;


namespace SPRENCIA.Infraestructure.Repositories
{
    public class ActivityRepository : IActivityRepository
    {    
        private readonly SprenciaDbContext _context;

        public ActivityRepository (SprenciaDbContext dbcontext)
        { 
            _context = dbcontext;
        }
        public async Task<List<Activity>> GetAll()
        {
            List<Activity> activities = await _context.Activities.ToListAsync();
            return activities;
        }

        public async Task<Activity?> GetById(int id)
        {
            Activity? activity = await _context.Activities.Where(x => x.Id == id).FirstOrDefaultAsync();
            return activity;
        }

        // Método create con mapeos
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

        // Método create sin mapeos
        /*
        public async Task<ActivityDto> Create(ActivityAddRequestDto newActivity)
        {
            
            // MMM TODO: Sacarlo a un método a parte (Mappers)
            ActivityAddRequestDto activityRequestDto = newActivity;

            Activity activity = new Activity();
            activity.Title = activityRequestDto.Title;
            activity.Description = activityRequestDto.Description;
            activity.Price = activityRequestDto.Price;
            // MMM El horario no sé cómo ponerlo
            // activity.ActivitySchedules = activityRequestDto.ActivitySchedules;
             
            var activityAdded = await _context.Activities.AddAsync(activity);
            _context.SaveChanges();

            ActivityDto ActivityDto = new ActivityDto();
            ActivityDto.Title = activityAdded.Entity.Title;
            ActivityDto.Description = activityAdded.Entity.Description;
            ActivityDto.Price = activityAdded.Entity.Price;
            // MMM Revisar cómo devuelve al frontend horarios?
            // ActivityDto.ActivitySchedules = activityAdded.Entity.ActivitySchedules; 

            return ActivityDto;

        }*/

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
