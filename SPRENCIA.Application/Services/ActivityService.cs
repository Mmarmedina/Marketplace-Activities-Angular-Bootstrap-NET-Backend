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
        

        public ActivityService(IActivityRepository activityRepository)
        {
            _activityRepository = activityRepository;
        }

        public async Task<List<ActivityDto>> GetAll()
        {
            List<Activity> activities = await _activityRepository.GetAll();
            List <ActivityDto> activitiesDto = ActivitiesMapper.MapToActivitiesDto(activities);
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

        
        public async Task<ActivityDto> Create(ActivityAddRequestDto newActivity)
        {
            // Activity activityAdded = await _activityRepository.Create(newActivity);

            ActivityDto? activityAdded = null;

            if (newActivity != null)
            {
                activityAdded = await _activityRepository.Create(newActivity);
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
