using myRESTAPI.Application.DTOs;
using myRESTAPI.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using myRESTAPI.Infrastructure.Repositories;
using System;

namespace myRESTAPI.Application.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;

        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<TaskDTO> CreateTaskAsync(CreateTaskDTO dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Title))
                throw new ArgumentException("Title can not be empty!");

            var entity = new TaskEntity
            {
                Title = dto.Title,
                Description = dto.Description,
                Deadline = dto.Deadline,
                CreatedAt = DateTime.UtcNow
            };

            var saved = await _taskRepository.CreateTask(entity);

            return new TaskDTO
            {
                Id = saved.Id,
                Title = saved.Title,
                Description = saved.Description,
                Deadline = saved.Deadline,
                CreatedAt = saved.CreatedAt
            };
        }

        public async Task<TaskDTO> GetTaskById(int id)
        {
            var entity = await _taskRepository.GetById(id);
            if (entity == null)
                return null;

            return new TaskDTO
            {
                Id = entity.Id,
                Title = entity.Title,
                Description = entity.Description,
                Deadline = entity.Deadline,
                CreatedAt = entity.CreatedAt
            };
        }

        public async Task<List<TaskDTO>> GetAllTasksAsync()
        {
            var list = await _taskRepository.GetAllTasks();

            return list.Select(entity => new TaskDTO
            {
               Id = entity.Id,
               Title = entity.Title,
               Description = entity.Description,
               Deadline = entity.Deadline,
               CreatedAt = entity.CreatedAt 
            }).ToList();
        }

        public async Task<bool> DeleteTaskAsync(int id)
        {
            return await _taskRepository.DeleteTask(id);
        }

        public async Task<TaskDTO> UpdateTaskAsync(int id, UpdateTaskDTO dto)
        {
            var entityToUpdate = new TaskEntity
            {
                Title = dto.Title,
                Description = dto.Description,
                Deadline = dto.Deadline,
            };
            var entity = await _taskRepository.UpdateTask(id, entityToUpdate);

            return new TaskDTO
            {
                Id = entity.Id,
                Title = entity.Title,
                Description = entity.Description,
                Deadline = entity.Deadline,
                CreatedAt = entity.CreatedAt
            };
        }

        public async Task<TaskDTO> CompleteTaskAsync(int id)
        {
            var entity = await _taskRepository.CompleteTask(id);
            if (entity == null)
            {
                return null;
            }

            return new TaskDTO
            {
                Id = entity.Id,
                Title = entity.Title,
                Description = entity.Description,
                Deadline = entity.Deadline,
                CreatedAt = entity.CreatedAt
            };
        }
    }
}