using SPRENCIA.Application.Contracts;
using SPRENCIA.Application.Contracts.Services;
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
            var activities = await _activityRepository.GetAll();
            return activities;
        }

        public async Task<Activity> GetById(int id)
        {
            var activity = await _activityRepository.GetById(id);
            return activity;
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
            var activityDeleted = await _activityRepository.DeleteById(id);

            if (activityDeleted == true)
            {
                return true;
            }

            return false;
        }
    }
}
