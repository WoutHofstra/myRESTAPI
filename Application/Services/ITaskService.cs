using myRESTAPI.Application.DTOs;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace myRESTAPI.Application.Services
{
    public interface ITaskService
    {
        Task<TaskDTO> CreateTaskAsync(CreateTaskDTO dto);
        Task<TaskDTO> GetTaskById(int id);
        Task<List<TaskDTO>> GetAllTasksAsync();
        Task<bool> DeleteTaskAsync(int id);
        Task<TaskDTO> UpdateTaskAsync(int id, UpdateTaskDTO dto);
        Task<TaskDTO> CompleteTaskAsync(int id);
    }
}