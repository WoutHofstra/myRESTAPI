using myRESTAPI.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace myRESTAPI.Infrastructure.Repositories
{
    public interface ITaskRepository
    {
        Task<TaskEntity> CreateTask(TaskEntity entity);
        Task<TaskEntity> GetById(int id);
        Task<List<TaskEntity>> GetAllTasks();
        Task<bool> DeleteTask(int id);
        Task<TaskEntity> UpdateTask(int id, TaskEntity entity);
        Task<TaskEntity> CompleteTask(int id);
    }
}