using SPRENCIA.Domain.Models;
using SPRENCIA.Infraestructure.Contracts.DTOs;
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
        Task<Activity> GetById(int id);
        Task<ActivityDto> Create(ActivityAddRequestDto newActivity);
    }
}
