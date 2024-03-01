using SPRENCIA.Domain.Models;

namespace SPRENCIA.Infraestructure.Contracts
{
    public interface IScheduleRepository
    {
        Task<List<ActivitiesSchedulesAndSchedules>> GetAll();
    }
}
