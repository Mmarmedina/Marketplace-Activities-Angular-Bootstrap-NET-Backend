using SPRENCIA.Infraestructure.Contracts.DTOs;

namespace SPRENCIA.Application.Contracts.Services
{
    public interface IActivityService
    {
        Task<List<ActivityDto>> GetAll();
        Task<ActivityDto> GetById(int id);
        Task<ActivityDto> Create(ActivityAddRequestDto newActivity);
        Task<bool> DeleteById(int id);
    }
}
