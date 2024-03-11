using SPRENCIA.Domain.Models;
using SPRENCIA.Infraestructure.Contracts.DTOs;

namespace SPRENCIA.Infraestructure.Contracts
{
    public interface IActivityRepository
    {
        Task<List<Activity>> GetAll();
        Task<Activity> GetById(int id);
        Task<ActivityDto> Create(ActivityAddRequestDto newActivity);
        Task<ActivityDto> Update(ActivityUpdatedRequestDto activityUpdatedRequestDto);
        Task<bool> DeleteById(int id);
        
    }
}
