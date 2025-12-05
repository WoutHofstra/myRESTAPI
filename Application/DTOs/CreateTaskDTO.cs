namespace myRESTAPI.Application.DTOs
{
    public class CreateTaskDTO
    {
        public required string Title { get; set; }
        public string? Description { get; set; }
        public DateTime Deadline { get; set; }
    }

    
}