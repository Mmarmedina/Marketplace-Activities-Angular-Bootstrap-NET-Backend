using Microsoft.EntityFrameworkCore;
using SPRENCIA.Domain.Models;
using SPRENCIA.Infraestructure.Contracts;
using SPRENCIA.Infraestructure.Contracts.DTOs;
using SPRENCIA.Infraestructure.Mappers;

namespace SPRENCIA.Infraestructure.Repositories
{
    public class ActivityScheduleRepository: IActivityScheduleRepository
    {
        private readonly SprenciaDbContext _context;

        public ActivityScheduleRepository(SprenciaDbContext dbcontext)
        {
            _context = dbcontext;
        }

        // MMM Recupera todos los registros de la tabla activities_schedules.
        public async Task<List<ActivitiesSchedules>> GetAll()
        {
            List<ActivitiesSchedules> activitiesSchedules = await _context.ActivitiesSchedules.ToListAsync();

            return activitiesSchedules;
        }

        // MMM Método para insertar nuevos registros en la tabla activities_schedules.
        public async Task<ActivitiyScheduleDto> Create(ActivitiyScheduleDto activityScheduleDto)
        {
            // Aquí hay que mapear el activityScheduleDto a objeto tipo entidad activities_schedule.
            List<ActivitiesSchedules> activitySchedules = ScheduleMapper.MapToActivitySchedules(activityScheduleDto);

            // Se añade la lista creada a BBDD
            await _context.ActivitiesSchedules.AddRangeAsync(activitySchedules);
            _context.SaveChanges();

            return new ActivitiyScheduleDto { };
        }
      
    }
}
