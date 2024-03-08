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
            // Borrar
            // reviewDto.ActivityId = review.ActivityId;
         
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

       
        // Dto salida incluye activityId
        public static ReviewWithActivityIdDto MapToReviewWithActivityIdDto(Review review)
        {
            ReviewWithActivityIdDto ReviewWithActivityIdDto = new ReviewWithActivityIdDto();
            ReviewWithActivityIdDto.Id = review.Id;
            ReviewWithActivityIdDto.ReviewText = review.ReviewText;
            ReviewWithActivityIdDto.ActivityId = review.ActivityId;

            return ReviewWithActivityIdDto;
        }

        // 
        public static List<ReviewWithActivityIdDto> ReviewsWithActivityIdDto(List<Review> reviews)
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
