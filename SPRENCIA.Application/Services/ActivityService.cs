using SPRENCIA.Application.Contracts.Services;
using SPRENCIA.Application.Mappers;
using SPRENCIA.Domain.Models;
using SPRENCIA.Infraestructure.Contracts;
using SPRENCIA.Infraestructure.Contracts.DTOs;


namespace SPRENCIA.Application.Services
{
    public class ActivityService : IActivityService
    {
        private readonly IActivityRepository _activityRepository;
        private readonly IActivityScheduleRepository _activityScheduleRepository;

        public ActivityService(IActivityRepository activityRepository, IActivityScheduleRepository activityScheduleRepository)
        {
            _activityRepository = activityRepository;
            _activityScheduleRepository = activityScheduleRepository;
        }

        public async Task<List<ActivityDto>> GetAll()
        {
            List<Activity> activities = await _activityRepository.GetAll();
            List <ActivityDto> activitiesDto = ActivityMapper.MapToActivitiesDto(activities);
            return activitiesDto;
        }

        public async Task<ActivityDto> GetById(int id)
        {
            // MMM Devolver activity DTO
            // Crear un metodo en ActivityMapper que sea igual que el método de Cipri ClientDto, recibe una actividad de tipo Activity y tiene que devolver ActivityDto
            // MMM El front necesita un objeto con las actividades, las opiniones y los horarios. 
            Activity activity = await _activityRepository.GetById(id);
            ActivityDto activityDto = ActivityMapper.MapToActivityDto(activity);
            return activityDto;
        }

        // MMM 
        public async Task<ActivityDto> Create(ActivityAddRequestDto newActivity)
        {
            ActivityDto? activityAdded = null;
            

            // Se verifica si la variable newActivity es nula (es decir, si llega el objeto con la información del front).

            if (newActivity != null)
            {
                // Si los datos son válidos, se llama al método Create del repositorio de actividad para crear la nueva actividad.
                // El objeto que devuelve el método del servicio es del tipo ActivityDto.

                activityAdded = await _activityRepository.Create(newActivity);

                // Al crear la actividad se indica uno o varios horarios para ésta. El horario de la nueva actividad se debe insertar en la entidad activities_schedules.
                // El activityID se saca de la variable activityAdded (que se crea tras insertar la nueva actividad en BBDD), y el horario se saca del DTO de entrada (ActivityAddRequestDto) que incluye el horario que se le ha asignado a la actividad desde el frontend.
                
                ActivitiyScheduleDto activitySchedule = ScheduleMapper.MapToActivitiesSchedulesDto(newActivity, activityAdded);

                List<ActivitiyScheduleDto> scheduleAdded = await _activityScheduleRepository.Create(activitySchedule);


                // REPOSITORIO: 
                // Crear un repositorio, por ejemplo, activityScheduleRepository.
                // Ese repositorio tendrá un método (activityScheduleRepository) cuya finalidad es hacer una petición a BBDD para insertar el horario de la actividad en la tabla activity_Schedule. 
                // Hay que crear un objeto que sea la suma del Id de la actividad, que está en activityAdded.ID + el horario que está en newActivity.Id (objeto del tipo activityRequestDto).


                // SERVICIO: 
                // Ese método se va a llamar aquí desde el servicio, tipo: await activityScheduleRepository.Insert(activitySchedule) y el resultado se almacena en una variable.
                // El repositorio tendrá que tener algo como: await _context.Activities.AddAsync(activitySchedule): objeto que incluye el id actividad y su horario.

                // Repositorio despues de hacer la petición/inserción a bbdd datos devuelve un objeto que hay que mapear para devolver al frontend.
                // Se devuelve activityAdded



                // TODO: Después de insertar la actividad tengo que insertar su relación con el horario. 
                // El horario me tiene que venir en el activityRequestDto.
            }

            return activityAdded;
        }

        public async Task<bool> DeleteById(int id)
        {
            bool activityDeleted = await _activityRepository.DeleteById(id);

            if (activityDeleted == true)
            {
                return true;
            }

            return false;
        }

        
    }
}
