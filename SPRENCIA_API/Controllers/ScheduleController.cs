using Microsoft.AspNetCore.Mvc;
using SPRENCIA.Application.Contracts.Services;
using SPRENCIA.Infraestructure.Contracts.DTOs;

namespace SPRENCIA_API.Controllers
{
    [Route("api/[controller]")]
    public class ScheduleController : ControllerBase
    {
        private readonly IScheduleService _scheduleService;

        public ScheduleController(IScheduleService scheduleService)
        {
            _scheduleService = scheduleService;
        }

        [HttpGet]
        public async Task<List<ScheduleDto>> GetAll()
        {
            List<ScheduleDto> schedulesDto = await _scheduleService.GetAll();
            return schedulesDto;
        }
    }
}
