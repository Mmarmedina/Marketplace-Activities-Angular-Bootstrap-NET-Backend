using Microsoft.EntityFrameworkCore;
using SPRENCIA.Domain.Models;
using SPRENCIA.Infraestructure.Contracts;

namespace SPRENCIA.Infraestructure.Repositories
{
    public class ScheduleRepository: IScheduleRepository
    {
        // TODO: hacer consulta inner join a la base de datos: creo un método que haga una consulta usando inner join, tablas activity_schedule + la tabla horarios.

        private readonly SprenciaDbContext _context;

        public ScheduleRepository(SprenciaDbContext dbcontext)
        {
            _context = dbcontext;
        }
        public async Task<List<Schedule>> GetAll()
        {
            // Hacer un método para recuperar todos los horarios


            // MMM TODO: Hacer una consulta de la tabla activities_schedules + schedules en ActivityScheduleRepository.cs

            /*
             List<Schedule> activitiesSchedulesAndSchedules = await _context.ActivitiesSchedules
                .Join(
                    _context.Schedules,
                    sa => sa.Id,
                    s => s.Id,
                    (sa,s) => new ActivitiesSchedulesAndSchedules { ActivitySchedules = sa, Schedules = s}
                )
                .ToListAsync();

            return activitiesSchedulesAndSchedules;
             
             */

            return new List<Schedule> { };
        }
    }
}
