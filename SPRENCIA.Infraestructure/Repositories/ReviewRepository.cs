using Microsoft.EntityFrameworkCore;
using SPRENCIA.Domain.Models;
using SPRENCIA.Infraestructure.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPRENCIA.Infraestructure.Repositories
{
    public class ReviewRepository: IReviewRepository
    {
        private readonly SprenciaDbContext _context;

        public ReviewRepository(SprenciaDbContext dbcontext)
        {
            _context = dbcontext;
        }
        public async Task<List<Review>> GetAll()
        {
            List<Review> reviews = await _context.Reviews.ToListAsync();
            return reviews;
        }
    }
}
