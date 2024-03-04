namespace SPRENCIA.Infraestructure.Contracts.DTOs
{
    public class ActivityDto
    {
        // MMM Dto salida de actividades (datos para enviar al frontend: unión de actividad, opinión y horario).
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public ScheduleDto Schedule { get; set; }

        public ReviewDto Review { get; set; }
    }
}
