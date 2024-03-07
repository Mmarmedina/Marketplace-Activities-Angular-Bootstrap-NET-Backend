using SPRENCIA.Domain.Models;

namespace SPRENCIA.Infraestructure.Contracts
{
    public interface IScheduleRepository
    {
        // Task<List<Schedule>> GetAll();
        Task<List<Schedule>> GetById(List<int> schedule);
    }
}
