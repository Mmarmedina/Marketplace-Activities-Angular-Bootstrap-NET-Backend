using SPRENCIA.Infraestructure.Contracts.DTOs;

namespace SPRENCIA.Application.Contracts.Services
{
    public interface IReviewService
    {
        Task <List<ReviewDto>> GetAll();
        Task<List<ReviewWithActivityIdDto>> GetAllAboutActivities();
        Task<List<ReviewDto>> GetAllAboutSprencia();
        Task<ReviewDto> GetById(int id);
    }
}
