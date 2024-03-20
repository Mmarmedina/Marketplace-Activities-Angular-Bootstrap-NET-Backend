using SPRENCIA.Infraestructure.Contracts.DTOs;

namespace SPRENCIA.Application.Contracts.Services
{
    public interface IScheduleService
    {
        Task<List<ScheduleDto>> GetAll();
    }
}
