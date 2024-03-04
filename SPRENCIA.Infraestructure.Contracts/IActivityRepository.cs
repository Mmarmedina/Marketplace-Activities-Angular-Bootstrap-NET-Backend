using SPRENCIA.Domain.Models;
using SPRENCIA.Infraestructure.Contracts.DTOs;

namespace SPRENCIA.Infraestructure.Contracts
{
    public interface IActivityRepository
    {
        // MMM Métodos de consulta, insercción, edición y borrado de actividades.

        Task<List<Activity>> GetAll();

        Task<Activity> GetById(int id);

        Task<ActivityDto> Create(ActivityAddRequestDto newActivity);

        Task<bool> DeleteById(int id);

        // TODO: falta por hacer el método Update

    }
}
