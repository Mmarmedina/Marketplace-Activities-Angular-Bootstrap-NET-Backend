using SPRENCIA.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPRENCIA.Infraestructure.Contracts.DTOs
{
    public class ActivityAddRequestDto
    {
        //MMM Dto entrada de actividades (datos que envía el frontend).
        public string Title { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        // TODO: el usuario puede marcar una opción o varias. Ver cómo se hace en el frontend (un selector no es) y con qué formato llega aquí, una lista de string?

        // public List<string> Schedule { get; set; }
    }
}
