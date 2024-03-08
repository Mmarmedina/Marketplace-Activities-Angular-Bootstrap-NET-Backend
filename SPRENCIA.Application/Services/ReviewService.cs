using SPRENCIA.Application.Contracts.Services;
using SPRENCIA.Application.Mappers;
using SPRENCIA.Domain.Models;
using SPRENCIA.Infraestructure.Contracts;
using SPRENCIA.Infraestructure.Contracts.DTOs;

namespace SPRENCIA.Application.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepository;

        public ReviewService(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        // Recuperar todas las opiniones de la entidad Reviews (las de las actividades y las de Sprencia).
        public async Task<List<ReviewDto>> GetAll()
        {
            List<Review> reviews = await _reviewRepository.GetAll();
            List<ReviewDto> reviewsDto = ReviewMapper.MapToReviewsDto(reviews);
            return reviewsDto;
        }

        // Recuperar solo los registros de la tabla opiniones que estén asociados a una actividad (es decir, solo las opiniones de actividades).
        public async Task<List<ReviewWithActivityIdDto>> GetAllAboutActivities()
        {
            List<Review> reviewsActivities = await _reviewRepository.GetAllAboutActivities();
            List<ReviewWithActivityIdDto> reviewsActivitiesDto = ReviewMapper.ReviewsWithActivityIdDto(reviewsActivities);
            return reviewsActivitiesDto;
        }

        public async Task<List<ReviewDto>> GetAllAboutSprencia()
        {
            List<Review> reviewsSprencia = await _reviewRepository.GetAllAboutSprencia();
            List<ReviewDto> reviewsSprenciaDto = ReviewMapper.MapToReviewsDto(reviewsSprencia);
            return reviewsSprenciaDto;
        }

        //  Recuperar una opinión por ID.
        public async Task<ReviewDto> GetById(int id)
        {
            Review review = await _reviewRepository.GetById(id);
            ReviewDto reviewDto = ReviewMapper.MapToReviewDto(review);

            return reviewDto;
        }
    }
}
