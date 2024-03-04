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

        public async Task<List<ActivitiyScheduleDto>> Create(ActivitiyScheduleDto activityScheduleDto)
        {
            // Aquí hay que mapear el activityScheduleDto a objeto tipo entidad activities_schedule.
            ActivitiesSchedules schedule = ScheduleMapper.MapToActivitiesSchedulesDtoFromEntity(activityScheduleDto);

            // Se añade el objeto creado a BBDD
            Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<ActivityScheduleDto> scheduleAdded = await _context.ActivitiesSchedules.AddAsync(schedule);
            _context.SaveChangesAsync();

            // Actividad/Horario añadida en base de datos se mapea a un DTO de salida para sacarlo en la API y enviarlo al frontend.
            ActivitiyScheduleDto activitycheduleMapped = ScheduleMapper.MapToActivitiesSchedules(scheduleAdded);

            return activityscheduleMapped;
        }

       

        // Se hace una petición al servicio para insertar en la tabla activities_schedules el horario de la actividad.

        


    }
}
