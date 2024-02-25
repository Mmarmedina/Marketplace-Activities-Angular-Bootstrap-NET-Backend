using SPRENCIA.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPRENCIA.Application.Contracts.Services
{
    public interface IReviewService
    {
        Task<List<Review>> GetAll();
    }
}
