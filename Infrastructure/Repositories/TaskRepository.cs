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
            _db.ChangeTracker.Clear();
            return await _db.Tasks.AsNoTracking().FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<List<TaskEntity>> GetAllTasks()
        {
            _db.ChangeTracker.Clear();
            return await _db.Tasks.AsNoTracking().ToListAsync();
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
            var existing = await _db.Tasks.FirstOrDefaultAsync(t => t.Id == id);

            if (updatedEntity.Title != existing.Title && updatedEntity.Title != "")
                existing.Title = updatedEntity.Title;

            if (updatedEntity.Description != existing.Description && updatedEntity.Description != "")
                existing.Description = updatedEntity.Description;

            if (updatedEntity.Deadline != existing.Deadline)
                existing.Deadline = updatedEntity.Deadline;

            existing.UpdatedAt = DateTime.UtcNow;

            await _db.SaveChangesAsync();
            return existing;
        }

        public async Task<TaskEntity> CompleteTask(int id)
        {
            var existing = await _db.Tasks.FirstOrDefaultAsync(t => t.Id == id);

            existing.IsCompleted = true;
            existing.UpdatedAt = DateTime.UtcNow;

            await _db.SaveChangesAsync();
            return existing;
        }
    }
}