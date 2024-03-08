using SPRENCIA.Infraestructure.Contracts.DTOs;

namespace SPRENCIA.Application.Contracts.Services
{
    public interface IReviewService
    {
        Task <List<ReviewDto>> GetAll();
        Task<List<ReviewDto>> GetAllAboutActivities();
        Task<List<ReviewSprenciaDto>> GetAllAboutSprencia();
        Task<ReviewDto> GetById(int id);
    }
}
