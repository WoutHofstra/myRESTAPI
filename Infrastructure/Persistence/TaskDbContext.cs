using Microsoft.EntityFrameworkCore;
using myRESTAPI.Domain.Entities;

namespace myRESTAPI.Infrastructure.Persistence
{
    public class TaskDbContext : DbContext
    {
        public TaskDbContext(DbContextOptions<TaskDbContext> options)
            :base(options)
        {
        }
        public DbSet<TaskEntity> Tasks { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TaskEntity>(entity =>
            {
            entity.HasKey(t => t.Id);   
            entity.Property(t => t.Title).IsRequired().HasMaxLength(200);
            entity.Property(t => t.Description).HasMaxLength(1000);
            entity.Property(t => t.CreatedAt).IsRequired();
            });
        }
    }
}