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

        public async Task<ActivitiyScheduleDto> Create(ActivitiyScheduleDto activityScheduleDto)
        {
            // Aquí hay que mapear el activityScheduleDto a objeto tipo entidad activities_schedule.
            List<ActivitiesSchedules> activitySchedules = ScheduleMapper.MapToActivitySchedules(activityScheduleDto);

            // Se añade la lista creada a BBDD
            await _context.ActivitiesSchedules.AddRangeAsync(activitySchedules);
            _context.SaveChanges();

            return new ActivitiyScheduleDto();
        }


        /*
        
        public async Task<ActivitiyScheduleDto> Create(ActivitiyScheduleDto activityScheduleDto)
        {
            // Aquí hay que mapear el activityScheduleDto a objeto tipo entidad activities_schedule.
            List<ActivitiesSchedules> activitySchedules = ScheduleMapper.MapToActivitySchedules(activityScheduleDto);





            // <ActivitiesSchedules> activitySchedule = ScheduleMapper.MapToActivitySchedule(activityScheduleDto);

            // Se añade el objeto creado a BBDD
            // Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<ActivitiesSchedules> scheduleAdded = await _context.ActivitiesSchedules.AddAsync(activitySchedules);
            _context.SaveChanges();

            // Actividad/Horario añadida en base de datos se mapea a un DTO de salida para sacarlo en la API y enviarlo al frontend.
            ActivitiyScheduleDto activityScheduleMapped = ScheduleMapper.MapToActivitiyScheduleDto(scheduleAdded.Entity);

            return activityScheduleMapped;
        }


         */








        /* public async Task<List<ActivitiyScheduleDto>> Create(List<ActivitiyScheduleDto> activityScheduleDtos)
        {
            List<ActivitiyScheduleDto> activityScheduleMapped = new List<ActivitiyScheduleDto>();

            foreach (ActivitiyScheduleDto activityScheduleDto in activityScheduleDtos)
            {
                // Mapear cada ActivitiyScheduleDto a un objeto ActivitiesSchedules
                ActivitiesSchedules activitySchedule = ScheduleMapper.MapToActivitySchedule(activityScheduleDto);

                // Añadir el objeto a la base de datos
                Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<ActivitiesSchedules> scheduleAdded = await _context.ActivitiesSchedules.AddAsync(activitySchedule);
            }

            _context.SaveChangesAsync();

            // Actividad/Horario añadida en base de datos se mapea a un DTO de salida para sacarlo en la API y enviarlo al frontend.
            List <ActivitiyScheduleDto> activityScheduleMapped = ScheduleMapper.MapToActivitiyScheduleDto(scheduleAdded.Entity);

            return activityScheduleMapped;
        }
        
        */
        /*
        public async Task<List<ActivitiyScheduleDto>> Create(ActivitiyScheduleDto activityScheduleDto)
        {
            // Aquí hay que mapear el activityScheduleDto a objeto tipo entidad activities_schedule.
            ActivitiesSchedules activitySchedule = ScheduleMapper.MapToActivitySchedule(activityScheduleDto);

            // Se añade el objeto creado a BBDD
            Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<ActivitiesSchedules> scheduleAdded = await _context.ActivitiesSchedules.AddAsync(activitySchedule);
            _context.SaveChangesAsync();

            // Actividad/Horario añadida en base de datos se mapea a un DTO de salida para sacarlo en la API y enviarlo al frontend.
            List <ActivitiyScheduleDto> activityScheduleMapped = ScheduleMapper.MapToActivitiyScheduleDto(scheduleAdded.Entity);

            return activityScheduleMapped;
        }


         


        // Se hace una petición al servicio para insertar en la tabla activities_schedules el horario de la actividad.


        */

    }
}
