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

        // MMM Recuperar todos los registros de la tabla horarios. 
        public async Task<List<Schedule>> GetAll()
        {
            List<Schedule> schedules = await _context.Schedules.ToListAsync();
            return schedules;
        }

        // MMM Recuperar un horario.
        public async Task<Schedule?> GetById(int id)
        {
            Schedule? schedule = await _context.Schedules.FirstOrDefaultAsync();
            return schedule;
        }

        // MMM Método recibe por parámetro una lista de IDs de horarios y saca todo los registros de la tabla de horarios que contengan esos ID.
        // Cuando se crea una nueva actividad se recibe una lista de enteros con los IDs de los horarios, con esa información se pueden devolver todos los registros de la tabla horarios que tengan los ids proporcionados.
        public async Task<List<Schedule>> GetByIdList(List<int> scheduleIds)
        {
            List<Schedule> schedules = await _context.Schedules
                .Where(s => scheduleIds.Contains(s.Id))
                .ToListAsync();

            return schedules;
        }

        // MMM Recuperar todos los registros activities_schedules + schedules (inner join entre ambas entidades).
        public async Task<List<ActivitiesSchedulesSchedules>> GetAllAllActivities()
        {
            List<ActivitiesSchedulesSchedules> activitiesWithSchedules = await _context.ActivitiesSchedules
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

            return activitiesWithSchedules;
        }

        // MMM Recuperar todos los horarios asociados a una actividad (inner join tabla activities_schedules + schedules).
        // El método devuevle solo los horarios de la actividad.
        public async Task<List<Schedule>> GetAllOnlyAnActivity(int activityId)
        {
            List<Schedule> schedules = await _context.ActivitiesSchedules
                .Where(sa => sa.ActivityId == activityId)
                .Join(
                   _context.Schedules,
                   sa => sa.ScheduleId,
                   s => s.Id,
                   (sa, s) => s)
                .ToListAsync();

            return schedules;
        }
    }
}


