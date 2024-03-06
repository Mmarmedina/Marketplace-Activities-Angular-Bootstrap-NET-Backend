namespace SPRENCIA.Infraestructure.Contracts.DTOs
{
    public class ActivitiyScheduleDto
    {
        public int ActivityId { get; set; }

        // MMM Es una lista de IDs de horarios, para representar que una actividad puede tener varios horarios asociados.
        public List<int> ScheduleId { get; set; }

        // public List<ScheduleDto> Schedule { get; set; }

    }
}
