using Microsoft.AspNetCore.Mvc;
using SPRENCIA.Application.Contracts.Services;
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
        public async Task<List<ActivityDto>> GetAll()
        {
            List<ActivityDto> activities = await _activityService.GetAll();
            return activities;
        }

        [HttpGet("{id}")]
        public async Task<ActivityDto> GetById(int id) 
        {
            ActivityDto activity = await _activityService.GetById(id);
            return activity;
        }

        // MMM El frontend en la petición HTTP post envía un objeto con los datos que el usuario ha cumplimentado (nombre, título, descripción, precio y horario/s).
        // El objeto se alamacena en la varible newActivity. Se tipa como ActivityAddRequestDto.
        // El objeto almacenado en la variable newActivity se envía al servicio.
        // Si la variable que almacena la respuesta de la petición al servicio (activityAdded) es null (no se envía ninguna actividad), se indica "La petición no ha podido realizarse".
        // Si la variable que almacena la respuesta de la petición al servicio de la petición al servicio (activityAdded) no es null, se indica que la respuesta es correcta. 
        // El método devuelve objeto tipo ActionResult (BadRequest or Ok).

        [HttpPost]
        [Route("NewActivity")]
        public async Task<ActionResult> Create([FromBody] ActivityAddRequestDto newActivity)
        {
            ActivityDto activityAdded = await _activityService.Create(newActivity);

            if(activityAdded == null) 
            {
                return BadRequest("La petición no ha podido realizarse");
            }
            else
            {
                return Ok(activityAdded);
            }
        }
      
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteById(int id)
        {
            bool activityDeleted = await _activityService.DeleteById(id);
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
