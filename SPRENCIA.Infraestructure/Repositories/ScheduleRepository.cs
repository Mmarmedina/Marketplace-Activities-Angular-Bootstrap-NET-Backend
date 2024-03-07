using Microsoft.EntityFrameworkCore;
using SPRENCIA.Domain.Models;
using SPRENCIA.Infraestructure.Contracts;

namespace SPRENCIA.Infraestructure.Repositories
{
    public class ScheduleRepository : IScheduleRepository
    {
        private readonly SprenciaDbContext _context;

        public ScheduleRepository(SprenciaDbContext dbcontext)
        {
            _context = dbcontext;
        }

        // Recuperar todos los registros de la tabla horarios. 
        public async Task<List<Schedule>> GetAll()
        {
            List<Schedule> schedules = await _context.Schedules.ToListAsync();
            return schedules;
        }

        // Recuperar un horario.
        public async Task<Schedule?> GetById(int id)
        {
            Schedule? schedule = await _context.Schedules.FirstOrDefaultAsync();
            return schedule;
        }

        // Método recibe por parámetro una lista de IDs de horarios y saca todo los registros de la tabla de horarios que contengan esos ID.
        // Cuando se crea una nueva actividad se recibe una lista de enteros con los IDs de los horarios, con esa información se pueden devolver todos los registros de la tabla horarios que tengan los ids proporcionados.
        public async Task<List<Schedule>> GetByIdList(List<int> scheduleIds)
        {
            List<Schedule> schedules = await _context.Schedules
                .Where(s => scheduleIds.Contains(s.Id))
                .ToListAsync();

            return schedules;
        }

        // Recuperar todos los registros activities_schedules + schedules (inner join entre ambas entidades).
        public async Task<List<ActivitiesSchedulesSchedule>> GetAllAllActivities()
        {
            List<ActivitiesSchedulesSchedule> activitiesSchedulesAndSchedules = await _context.ActivitiesSchedules
               .Join(_context.Schedules,
                   sa => sa.Id,
                   s => s.Id,
                   (sa, s) => new ActivitiesSchedulesSchedule { ActivitySchedules = sa, Schedules = s }
               )
               .ToListAsync();

            return activitiesSchedulesAndSchedules;
        }

        // Recuperar todos los horarios asociados a una actividad (inner join tabla activities_schedules + schedules).
        public async Task<List<Schedule>> GetAllOnlyAnActivity(int activityId)
        {
            List<Schedule> schedules = await _context.ActivitiesSchedules
                .Join(
                   _context.Schedules,
                   sa => sa.Id,
                   s => s.Id,
                   (sa, s) => s)
                .ToListAsync();

            return schedules;
        }
    }
}


