using SPRENCIA.Application.Contracts;
using SPRENCIA.Application.Contracts.Services;
using SPRENCIA.Application.Mappers;
using SPRENCIA.Domain.Models;
using SPRENCIA.Infraestructure.Contracts;
using SPRENCIA.Infraestructure.Contracts.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPRENCIA.Application.Services
{
    public class ActivityService : IActivityService
    {
        private readonly IActivityRepository _activityRepository;

        public ActivityService(IActivityRepository activityRepository)
        {
            _activityRepository = activityRepository;
        }

        public async Task<List<Activity>> GetAll()
        {
            List<Activity> activities = await _activityRepository.GetAll();
            return activities;
        }

        public async Task<ActivityDto> GetById(int id)
        {
            // MMM Sin mapeo: Activity activity = await _activityRepository.GetById(id, activityDto);
            // return activity;vo

            // MMM Devolver activity DTO
            // Crear un metodo en ActivityMapper que sea igual que el método de Cipri ClientDto, recibe una actividad de tipo Activity y tiene que devolver ActivityDto

            Activity activity = await _activityRepository.GetById(id);
            ActivityDto activityDto = ActivityMapper.MapToActivityDto(activity);
            return activityDto;
            
        }

        public async Task<ActivityDto> Create(ActivityAddRequestDto newActivity)
        {
            ActivityDto? activityAdded = null;

            if (activityAdded != null)
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
