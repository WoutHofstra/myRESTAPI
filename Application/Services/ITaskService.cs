using myRESTAPI.Application.DTOs;

namespace myRESTAPI.Application.Services
{
    public interface ITaskService
    {
        Task<TaskDTO> CreateTaskAsync(CreateTaskDTO dto);
        Task<TaskDTO> GetTaskById(int id);
        Task<List<TaskDTO>> GetAllTasksAsync();
        Task<bool> DeleteTaskAsync(int id);
    }
}