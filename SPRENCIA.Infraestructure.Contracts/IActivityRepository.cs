using SPRENCIA.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPRENCIA.Infraestructure.Contracts
{
    public interface IActivityRepository
    {
        // MMM Métodos de consulta, insercción, edición y borrado de actividades.

        Task<List<Activity>> GetAll();

        Task<Activity> GetById(int id);
    }
}
