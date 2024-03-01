using Microsoft.EntityFrameworkCore;
using SPRENCIA.Application.Mappers;
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

        }

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
