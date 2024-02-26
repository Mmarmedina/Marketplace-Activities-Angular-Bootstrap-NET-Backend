using Microsoft.AspNetCore.Mvc;
using SPRENCIA.Application.Contracts.Services;
using SPRENCIA.Domain.Models;
using SPRENCIA.Infraestructure.Contracts.DTOs;

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

        [HttpGet("{id}")]
        public async Task<Activity> GetById(int id) 
        {
            var activity = await _activityService.GetById(id);
            return activity;
        }

        
        [HttpPost]
        [Route("AddActivity")]
        public async Task<ActionResult> Create([FromBody] ActivityAddRequestDto newActivity)
        {
            var activityAdded = await _activityService.Create(newActivity);

            if(activityAdded == null) 
            {
                return BadRequest("La petición no ha podido realizarse");
            }
            else
            {
                return Ok(activityAdded);
            }

        }
     
    }
}
