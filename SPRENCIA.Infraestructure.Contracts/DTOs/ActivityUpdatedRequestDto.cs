namespace SPRENCIA.Infraestructure.Contracts.DTOs
{
    public class ActivityUpdatedRequestDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public List<int> Schedule { get; set; }

    }
}
