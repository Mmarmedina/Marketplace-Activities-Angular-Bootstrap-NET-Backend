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

        // MMM ¿Aquí debería devolver no la actividad, sino un DTO que incluya la información de la actividad y también de la opinión asociada a la actividad para poder pintarla en la página detalle de la actividad?
        [HttpGet("{id}")]
        public async Task<Activity> GetById(int id) 
        {
            var activity = await _activityService.GetById(id);
            return activity;
        }

        
        [HttpPost]
        [Route("NewActivity")]
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

        /* MMM Forma simplificada, pero tampoco funciona. No añade, lo toma como null.
        [HttpPost]
        [Route("AddActivity")]
        public async Task<ActivityDto> Create([FromBody] ActivityAddRequestDto newActivity)
        {
            var activityAdded = await _activityService.Create(newActivity);
            return activityAdded;
        }
        */

        
        // MMM Me da error: hice restricción que no se borre actividad porque se quedan las opiniones sin las actividades asociadas. Además hay otros errores para ver en Swagger.
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteById(int id)
        {
            var activityDeleted = await _activityService.DeleteById(id);
            if (activityDeleted != true)
            {
                return BadRequest("La actividad no se ha podido eliminar de la base de datos.");
            }
            else
            {
                return Ok();
            }
        }

        // TODO: método PUT para editar una actividad que ya está en BBDD.

    }
}
