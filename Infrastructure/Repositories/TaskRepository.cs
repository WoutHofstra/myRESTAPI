using myRESTAPI.Domain.Entities;
using myRESTAPI.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace myRESTAPI.Infrastructure.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TaskDbContext _db;

        public TaskRepository(TaskDbContext db)
        {
            _db = db;
        }

        public async Task<TaskEntity> CreateTask(TaskEntity entity)
        {
            _db.Tasks.Add(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        public async Task<TaskEntity> GetById(int id)
        {
            return await _db.Tasks.FindAsync(id);
        }

        public async Task<List<TaskEntity>> GetAllTasks()
        {
            return await _db.Tasks.ToListAsync();
        }

        public async Task<bool> DeleteTask(int id)
        {
            var entity = await _db.Tasks.FindAsync(id);
            if (entity == null)
                return false;

            _db.Tasks.Remove(entity);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<TaskEntity> UpdateTask(int id, TaskEntity updatedEntity)
        {
            var existing = await _db.Tasks.FindAsync(updatedEntity);
            if (existing == null)
                return null;

            existing.Title = updatedEntity.Title;
            existing.Description = updatedEntity.Description;
            existing.Deadline = updatedEntity.Deadline;

            await _db.SaveChangesAsync();
            return existing;
        }

        public async Task<TaskEntity> CompleteTask(int id)
        {
            var existing = await _db.Tasks.FindAsync(id);
            if (existing == null)
                return null;

            existing.CompletedAt = DateTime.UtcNow;

            await _db.SaveChangesAsync();
            return existing;
        }
    }
}