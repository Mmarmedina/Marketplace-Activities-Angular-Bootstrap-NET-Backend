using SPRENCIA.Domain.Models;
using SPRENCIA.Infraestructure.Contracts.DTOs;

namespace SPRENCIA.Application.Mappers
{
    public class ReviewMapper
    {
        // Mapear objeto tipo entidad (Review) a objeto tipo DTO salida (ReviewDto).
        public static ReviewDto MapToReviewDto(Review review)
        {
            ReviewDto reviewDto = new ReviewDto();
            reviewDto.Id = review.Id;
            reviewDto.ReviewText = review.ReviewText;
            reviewDto.ActivityId = review.ActivityId;
         
            return reviewDto;
        }

        // Mapear una lista de objetos tipo entidad a una lista de objetos tipo DTO.
        public static List<ReviewDto> MapToReviewsDto(List<Review> reviews)
        {
            List<ReviewDto> reviewsDto = new List<ReviewDto>();

            foreach (Review review in reviews)
            {
                ReviewDto reviewDto = ReviewMapper.MapToReviewDto(review);
                reviewsDto.Add(reviewDto);
            }

            return reviewsDto;

        }

        // Mapear objeto tipo entidad con información opinión de Sprencia
        public static ReviewSprenciaDto MapToReviewSprenciaDto(Review review)
        {
            ReviewSprenciaDto reviewSprenciaDto = new ReviewSprenciaDto();
            reviewSprenciaDto.Id = review.Id;
            reviewSprenciaDto.ReviewText = review.ReviewText;

            return reviewSprenciaDto;
        }

        // Lista de opiniones sobre Sprencia: Mapear lista de objetos tipo entidad con información opinión de Sprencia
        public static List<ReviewSprenciaDto> MapToReviewsSprenciaDto(List<Review> reviews)
        {
            List<ReviewSprenciaDto> reviewsSprenciaDto = new List<ReviewSprenciaDto>();

            foreach (Review review in reviews)
            {
                ReviewSprenciaDto reviewSprenciaDto = ReviewMapper.MapToReviewSprenciaDto(review);
                reviewsSprenciaDto.Add(reviewSprenciaDto);
            }

            return reviewsSprenciaDto;

        }
    }

}
