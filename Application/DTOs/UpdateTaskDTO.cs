namespace myRESTAPI.Application.DTOs
{
    public class UpdateTaskDTO
    {
        public required string Title { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
    }
}