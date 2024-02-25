using Microsoft.EntityFrameworkCore;
using SPRENCIA.Domain.Models;
using SPRENCIA.Infraestructure.Contracts;
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
    }
}
