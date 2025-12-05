using myRESTAPI.Application.DTOs;
using myRESTAPI.Domain.Entities;

namespace myRESTAPI.Infrastructure.Repositories
{
    public interface ITaskRepository
    {
        Task<TaskEntity> CreateTask(TaskEntity entity);
        Task<TaskEntity> GetById(int id);
        Task<List<TaskEntity>> GetAllTasks();
        Task<bool> DeleteTask(int id);
    }
}