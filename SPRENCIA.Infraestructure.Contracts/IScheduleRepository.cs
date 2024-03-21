using SPRENCIA.Domain.Models;

namespace SPRENCIA.Infraestructure.Contracts
{
    public interface IScheduleRepository
    {
        Task<List<Schedule>> GetAll();
        Task<Schedule> GetById(int id);
        Task<List<Schedule>> GetByIdList(List<int> schedule);
        Task<List<ActivitiesSchedulesSchedules>> GetAllAllActivities();
        Task<List<Schedule>> GetAllOnlyAnActivity(int activityId);
    }
}
