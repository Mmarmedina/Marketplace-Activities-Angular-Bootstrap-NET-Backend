﻿using Microsoft.AspNetCore.Mvc;
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
