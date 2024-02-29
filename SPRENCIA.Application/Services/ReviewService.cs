using SPRENCIA.Application.Contracts;
using SPRENCIA.Application.Contracts.Services;
using SPRENCIA.Application.Mappers;
using SPRENCIA.Domain.Models;
using SPRENCIA.Infraestructure.Contracts;
using SPRENCIA.Infraestructure.Contracts.DTOs;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPRENCIA.Application.Services
{
    public class ReviewService: IReviewService
    {
        private readonly IReviewRepository _reviewRepository;

        public ReviewService(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        /* public async Task<List<ReviewDto>> GetAll()
        {
            List<Review> reviews = await _reviewRepository.GetAll();
            List<ReviewDto> reviewsDto = ReviewMapper.MapToReviewDto(reviews);
            return reviewsDto;
        }*/
    }
}
