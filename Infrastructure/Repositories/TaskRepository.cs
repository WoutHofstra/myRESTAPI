using myRESTAPI.Domain.Entities;
using myRESTAPI.Infrastructure.Repositories;

namespace myRESTAPI.Infrastructure.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly AppDbContext _db;

        public TaskRepository(AppDbContext db)
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
    }
}