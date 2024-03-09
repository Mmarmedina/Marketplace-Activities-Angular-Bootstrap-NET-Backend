namespace SPRENCIA.Infraestructure.Contracts.DTOs
{
    public class ActivitiyScheduleDto
    {
        // MMM Dto para representar los campos de la entidad activities_schedules.
        public int ActivityId { get; set; }

        // MMM Es una lista de IDs de horarios, para representar que una actividad puede tener varios horarios asociados.
        public List<int> ScheduleId { get; set; }

        

    }
}
