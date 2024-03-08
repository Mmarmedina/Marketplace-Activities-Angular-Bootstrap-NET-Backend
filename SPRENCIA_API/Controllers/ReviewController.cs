using Microsoft.AspNetCore.Mvc;
using SPRENCIA.Application.Contracts.Services;
using SPRENCIA.Infraestructure.Contracts.DTOs;

namespace SPRENCIA_API.Controllers
{

    [Route("api/[controller]")]
    public class ReviewController : ControllerBase
    {
       private readonly IReviewService _reviewService;

       public ReviewController(IReviewService reviewService)
       {
            _reviewService = reviewService;
       }

       [HttpGet]
       public async Task<List<ReviewDto>> GetAll()
       {
            List<ReviewDto> reviewsDto = await _reviewService.GetAll();
            return reviewsDto;
       }

        [HttpGet]
        [Route("Activities")]

        public async Task<List<ReviewDto>> GetAllAboutActivities()
        {
            List<ReviewDto> reviewsActivities = await _reviewService.GetAllAboutActivities();
            return reviewsActivities;
        }

        [HttpGet]
        [Route("Sprencia")]

        public async Task<List<ReviewSprenciaDto>> GetAllAboutSprencia()
        {
            List<ReviewSprenciaDto> reviewsSprenciaDto = await _reviewService.GetAllAboutSprencia();
            return reviewsSprenciaDto;
        }

        [HttpGet("{id}")]
        public async Task<ReviewDto> GetById(int id)
        {
            ReviewDto reviewDto = await _reviewService.GetById(id);
            return reviewDto;
        }
    }
}
