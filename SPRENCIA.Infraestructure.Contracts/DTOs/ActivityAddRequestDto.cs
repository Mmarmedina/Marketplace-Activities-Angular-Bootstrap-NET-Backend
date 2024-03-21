namespace SPRENCIA.Infraestructure.Contracts.DTOs
{
    public class ActivityAddRequestDto
    {
        //MMM Dto entrada de actividades: representa los datos que envía el frontend desde un formulario, indicando título, descripción, precio y uno o varios horarios para la misma actividad.
        public string Title { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        // MMM El uso de List<int> Schedule permite almacenar múltiples IDs de horarios seleccionados en el formulario. Cada ID de horario representaría una opción seleccionada por el usuario en el checkbox. 
        public List<int> Schedule { get; set; }
    }
}
