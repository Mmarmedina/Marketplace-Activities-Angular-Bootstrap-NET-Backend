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
        Task<List<ActivityDto>> GetAll();
        Task<ActivityDto> GetById(int id);
        Task<ActivityDto> Create(ActivityAddRequestDto newActivity);
        Task<bool> DeleteById(int id);
    }
}
