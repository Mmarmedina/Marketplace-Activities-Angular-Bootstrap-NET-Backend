using SPRENCIA.Application.Contracts;
using SPRENCIA.Application.Contracts.Services;
using SPRENCIA.Domain.Models;
using SPRENCIA.Infraestructure.Contracts;
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
    }
}
