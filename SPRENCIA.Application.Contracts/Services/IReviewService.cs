using SPRENCIA.Infraestructure.Contracts.DTOs;

namespace SPRENCIA.Application.Contracts.Services
{
    public interface IReviewService
    {
        Task <List<ReviewWithActivityIdDto>> GetAll();
        Task<List<ReviewWithActivityIdDto>> GetAllAboutActivities();
        Task<List<ReviewDto>> GetAllAboutSprencia();
        Task<ReviewWithActivityIdDto> GetById(int id);
    }
}
