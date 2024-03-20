using SPRENCIA.Application.Contracts.Services;
using SPRENCIA.Application.Mappers;
using SPRENCIA.Domain.Models;
using SPRENCIA.Infraestructure.Contracts;
using SPRENCIA.Infraestructure.Contracts.DTOs;

namespace SPRENCIA.Application.Services
{
    public class ScheduleService: IScheduleService
    {
        private readonly IScheduleRepository _scheduleRepository;

        public ScheduleService(IScheduleRepository scheduleRepository)
        {
            _scheduleRepository = scheduleRepository;
        }

        public async Task<List<ScheduleDto>> GetAll()
        {
            List<Schedule> schedules = await _scheduleRepository.GetAll();
            List<ScheduleDto> schedulesDto = ScheduleMapper.MaptoSchedulesDto(schedules);
            return schedulesDto;
        }
    }
}
