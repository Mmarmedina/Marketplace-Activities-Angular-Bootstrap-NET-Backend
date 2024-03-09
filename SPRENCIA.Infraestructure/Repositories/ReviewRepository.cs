using Microsoft.EntityFrameworkCore;
using SPRENCIA.Domain.Models;
using SPRENCIA.Infraestructure.Contracts;

namespace SPRENCIA.Infraestructure.Repositories
{
    public class ReviewRepository: IReviewRepository
    {
        private readonly SprenciaDbContext _context;

        public ReviewRepository(SprenciaDbContext dbcontext)
        {
            _context = dbcontext;
        }
        
        // MMM Sacar todas las opiniones juntas (tanto de Sprencia como de actividades), es decir, todos los registros de la tabla Reviews.
        public async Task<List<Review>> GetAll()
        {
            List<Review> reviews = await _context.Reviews.ToListAsync();
            return reviews;
        }

        // MMM Método para sacar todas las opiniones sobre actividades. Son todas aquellas en las que el campo ActivityId en la tabla Reviews no es nulo (la opinión está asociada siempre a una actividad). 
        public async Task<List<Review>> GetAllAboutActivities()
        {
            List<Review> reviewsActivities = await _context.Reviews.Where(r => r.ActivityId != null).ToListAsync();
            return reviewsActivities;
        }

        // MMM Método para sacar solo las opiniones de Sprencia (son las que tienen el campo ActivityID = null). 
        public async Task<List<Review>> GetAllAboutSprencia()
        {
            List<Review> reviewsSprencia = await _context.Reviews.Where(r => r.ActivityId == null).ToListAsync();
            return reviewsSprencia;
        }

        // MMM Método para recuperar todas las opiniones asociadas a una actividad
        public async Task<List<Review>> GetAllOneActivity(int activityId)
        {
            List<Review> reviewsOneActivity = await _context.Reviews.Where(r => r.ActivityId ==  activityId).ToListAsync();
            return reviewsOneActivity;
        }

        // MMM Método para recuperar una opinión por ID.
        public async Task<Review?> GetById(int id)
        {
            Review? review = await _context.Reviews.Where(r => r.Id == id).FirstOrDefaultAsync();
            return review;
        }

       

    }
}
