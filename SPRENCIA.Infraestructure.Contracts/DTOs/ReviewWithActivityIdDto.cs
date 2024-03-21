namespace SPRENCIA.Infraestructure.Contracts.DTOs
{
    public class ReviewWithActivityIdDto
    {
        // Para mostrar en la API la información relativa a una opinión se han creado dos DTOs.
        // ReviewDto sólo incluye el ID y ReviewText. 
        // Para algunas peticiones interesa mostrar también la actividad asociada a la opinión y se ha creado este DTO: ReviewWithActivityIdDto. 
        public int Id { get; set; }

        public string ReviewText { get; set; }

        public int? ActivityId { get; set; }

    }
    
}
