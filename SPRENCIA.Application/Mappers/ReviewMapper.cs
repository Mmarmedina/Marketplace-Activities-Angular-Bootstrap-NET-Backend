﻿using SPRENCIA.Domain.Models;
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
            reviewDto.Author = review.Author;
            reviewDto.Date = review.Date;

            return reviewDto;
        }

        // MMM Mapear UNA LISTA de objetos tipo entidad (Review) a una lista de objetos tipo DTO (ReviewDto).
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

        //  Mapear un objeto tipo entidad (Review) a una un objeto tipo DTO (ReviewWithActivityIdDto).
        public static ReviewWithActivityIdDto MapToReviewWithActivityIdDto(Review review)
        {
            ReviewWithActivityIdDto reviewWithActivityIdDto = new ReviewWithActivityIdDto();
            reviewWithActivityIdDto.Id = review.Id;
            reviewWithActivityIdDto.ReviewText = review.ReviewText;
            reviewWithActivityIdDto.Author = review.Author;
            reviewWithActivityIdDto.Date = review.Date;
            reviewWithActivityIdDto.ActivityId = review.ActivityId;

            return reviewWithActivityIdDto;
        }

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

    }

}
