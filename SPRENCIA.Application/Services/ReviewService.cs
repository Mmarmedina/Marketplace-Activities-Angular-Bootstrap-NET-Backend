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

        // MMM Recuperar todas las opiniones de la entidad Reviews (tanto de las de actividades como de las de Sprencia).
        public async Task<List<ReviewWithActivityIdDto>> GetAll()
        {
            List<Review> reviews = await _reviewRepository.GetAll();
            List<ReviewWithActivityIdDto> reviewsDto = ReviewMapper.MapToReviewsWithActivityIdDto(reviews);
            return reviewsDto;
        }

        // MMM Recuperar sólo los registros de la tabla opiniones que estén asociados a una actividad (es decir, solo las opiniones de actividades).
        public async Task<List<ReviewWithActivityIdDto>> GetAllAboutActivities()
        {
            List<Review> reviewsActivities = await _reviewRepository.GetAllAboutActivities();
            List<ReviewWithActivityIdDto> reviewsActivitiesDto = ReviewMapper.MapToReviewsWithActivityIdDto(reviewsActivities);
            return reviewsActivitiesDto;
        }

        // MMM Recuperar sólo las opiniones de Sprencia.
        public async Task<List<ReviewDto>> GetAllAboutSprencia()
        {
            List<Review> reviewsSprencia = await _reviewRepository.GetAllAboutSprencia();
            List<ReviewDto> reviewsSprenciaDto = ReviewMapper.MapToReviewsDto(reviewsSprencia);
            return reviewsSprenciaDto;
        }

        //  MMM Recuperar una opinión por ID.
        public async Task<ReviewWithActivityIdDto> GetById(int id)
        {
            Review review = await _reviewRepository.GetById(id);
            ReviewWithActivityIdDto reviewDto = ReviewMapper.MapToReviewWithActivityIdDto(review);

            return reviewDto;
        }
    }
}
