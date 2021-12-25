using Microsoft.EntityFrameworkCore;

namespace Reports.API.Models
{
    public class TaskContext : DbContext
    {
        public TaskContext(DbContextOptions<TaskContext> options) 
            : base(options) {}

        public DbSet<Task> Tasks { get; set; } = null!;
        public DbSet<Employer> Employers { get; set; } = null!;
        public DbSet<Comment> Comments { get; set; } = null!;
    }
}