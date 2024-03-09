using SPRENCIA.Domain.Models;
using SPRENCIA.Infraestructure.Contracts.DTOs;

namespace SPRENCIA.Application.Mappers
{
    public class ReviewMapper
    {
        // MMM Mapear UN OBJETO tipo entidad (Review) a objeto tipo DTO salida (ReviewDto).
        public static ReviewDto MapToReviewDto(Review review)
        {
            ReviewDto reviewDto = new ReviewDto();
            reviewDto.Id = review.Id;
            reviewDto.ReviewText = review.ReviewText;

            return reviewDto;
        }

        // MMM Mapear UNA LISTA de objetos tipo entidad (Review) a una lista de objetos tipo DTO ((ReviewDto).
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

        // MMM Mapear UN OBJETO tipo entidad (Review) a objeto tipo DTO salida (ReviewWithActivityIdDto). Diferencia con el primer método (MapToReviewDto) que en este caso el DTO incluye el ActivityID.
        public static ReviewWithActivityIdDto MapToReviewWithActivityIdDto(Review review)
        {
            ReviewWithActivityIdDto ReviewWithActivityIdDto = new ReviewWithActivityIdDto();
            ReviewWithActivityIdDto.Id = review.Id;
            ReviewWithActivityIdDto.ReviewText = review.ReviewText;
            ReviewWithActivityIdDto.ActivityId = review.ActivityId;

            return ReviewWithActivityIdDto;
        }

        // MMM Mapear UNA LISTA DE OBJETOS tipo entidad (Review) a objeto tipo DTO salida (ReviewWithActivityIdDto). Igual que el MapToReviewWithActivityIdDto incluye el ActivityId.
        public static List<ReviewWithActivityIdDto> MapToReviewsWithActivityIdDto(List<Review> reviews)
        {
            List<ReviewWithActivityIdDto> reviewsWithActivityIdDto = new List<ReviewWithActivityIdDto>();

            foreach (Review review in reviews)
            {
                ReviewWithActivityIdDto reviewWithActivityIdDto = ReviewMapper.MapToReviewWithActivityIdDto(review);
                reviewsWithActivityIdDto.Add(reviewWithActivityIdDto);
            }

            return reviewsWithActivityIdDto;

        }

    }

}
