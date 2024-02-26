using Microsoft.EntityFrameworkCore;
using SPRENCIA.Domain.Models;
using SPRENCIA.Infraestructure.Contracts;
using SPRENCIA.Infraestructure.Contracts.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var activities = await _context.Activities.ToListAsync();
            return activities;
        }

        public async Task<Activity?> GetById(int id)
        {
            var activity = await _context.Activities.Where(x => x.Id == id).FirstOrDefaultAsync();
            return activity;
        }

        public async Task<ActivityDto> Create(ActivityAddRequestDto newActivity)
        {
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
            ActivityDto.Id = activityAdded.Entity.Id;
            ActivityDto.Title = activityAdded.Entity.Title;
            ActivityDto.Description = activityAdded.Entity.Description;
            ActivityDto.Price = activityAdded.Entity.Price;
            // MMM Revisar cómo devuelve al frontend horarios?
            // ActivityDto.ActivitySchedules = activityAdded.Entity.ActivitySchedules; 

            return ActivityDto;
          
        }

        public async Task<bool> DeleteById(int id)
        {
            var activityDeleted = await _context.Activities.Where(x => x.Id == id).FirstOrDefaultAsync();
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
