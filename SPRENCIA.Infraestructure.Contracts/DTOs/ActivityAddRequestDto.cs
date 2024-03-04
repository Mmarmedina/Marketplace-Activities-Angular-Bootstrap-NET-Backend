namespace SPRENCIA.Infraestructure.Contracts.DTOs
{
    public class ActivityAddRequestDto
    {
        //MMM Dto entrada de actividades (datos que envía el frontend).
        public string Title { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public List<string> Schedule { get; set; }
    }
}
