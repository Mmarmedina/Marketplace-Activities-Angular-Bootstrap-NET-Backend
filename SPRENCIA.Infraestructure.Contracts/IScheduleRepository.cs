using SPRENCIA.Domain.Models;

namespace SPRENCIA.Infraestructure.Contracts
{
    public interface IScheduleRepository
    {
        Task<List<Schedule>> GetAll();
        Task<List<Schedule>> GetAllOnlyAnActivity(int activityId);
        Task<List<Schedule>> GetByIdList(List<int> schedule);
    }
}
