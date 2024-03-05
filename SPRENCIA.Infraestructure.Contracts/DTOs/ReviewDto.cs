using System.ComponentModel.DataAnnotations;

namespace SPRENCIA.Infraestructure.Contracts.DTOs
{
    public class ReviewDto
    {
      
        //MMM Dto salida de opiniones (datos para enviar al frontend). Se incluye como propiedad dentro de ActivityDto.
        public int Id { get; set; }
        public string ReviewText { get; set; }
    }
}
