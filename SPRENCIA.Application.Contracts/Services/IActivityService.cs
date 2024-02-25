using SPRENCIA.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPRENCIA.Application.Contracts.Services
{
    public interface IActivityService
    {
        Task<List<Activity>> GetAll();
    }
}
