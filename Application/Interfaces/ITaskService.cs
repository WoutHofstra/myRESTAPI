using myRESTAPI.Application.DTOs;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace myRESTAPI.Application.Interfaces
{
    public interface ITaskService
    {
        Task<TaskResponseDTO> CreateTaskAsync(CreateTaskDTO dto);
        Task<IEnumerable<TaskResponseDTO>> GetAllTasksAsync();
        Task<TaskResponseDTO?> GetTaskByIdAsync(int id);
        Task<TaskResponseDTO?> UpdateTaskAsync(int id, UpdateTaskDTO dto);
        Task<bool> DeleteTaskAsync(int id);
        Task<TaskResponseDTO?> CompleteTaskAsync(int id);
    }    
}