using SPRENCIA.Domain.Models;

namespace SPRENCIA.Infraestructure.Contracts
{
    public interface IReviewRepository
    {
        Task<List<Review>> GetAll();
        Task<List<Review>> GetAllAboutActivities();
        Task<List<Review>> GetAllAboutSprencia();
        Task <List<Review>> GetAllOneActivity(int id);
        Task<Review> GetById(int id);
    }
}
