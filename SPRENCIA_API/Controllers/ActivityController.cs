using Microsoft.AspNetCore.Mvc;
using SPRENCIA.Application.Contracts.Services;
using SPRENCIA.Domain.Models;

namespace SPRENCIA_API.Controllers
{
    [Route("api/[controller]")]
    public class ActivityController : ControllerBase
    {
        private readonly IActivityService _activityService;

        public ActivityController(IActivityService activityService)
        {
            _activityService = activityService;
        }

        [HttpGet]
        public async Task<List<Activity>> GetAll()
        {
            var activities = await _activityService.GetAll();
            return activities;
        }
        
    }
}
