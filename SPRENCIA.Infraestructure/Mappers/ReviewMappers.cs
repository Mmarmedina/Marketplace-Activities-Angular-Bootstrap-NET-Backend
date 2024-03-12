using SPRENCIA.Application.Mappers;
using SPRENCIA.Domain.Models;
using SPRENCIA.Infraestructure.Contracts.DTOs;

namespace SPRENCIA.Infraestructure.Mappers
{
    public class ReviewMappers
    {
        // MMM Mapear UNA LISTA de objetos tipo entidad (Review) a una lista de objetos tipo DTO (ReviewWithActivityIdDto).
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

        //  Mapear un objeto tipo entidad (Review) a una un objeto tipo DTO (ReviewWithActivityIdDto).
        public static ReviewWithActivityIdDto MapToReviewWithActivityIdDto(Review review)
        {
            ReviewWithActivityIdDto reviewWithActivityIdDto = new ReviewWithActivityIdDto();
            reviewWithActivityIdDto.Id = review.Id;
            reviewWithActivityIdDto.ReviewText = review.ReviewText;
            reviewWithActivityIdDto.ActivityId = review.ActivityId;

            return reviewWithActivityIdDto;
        }

    }
}
