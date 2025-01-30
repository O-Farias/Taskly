using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Taskly.Models;

namespace Taskly.Data
{
    public class TasklyContext : DbContext
    {
        public TasklyContext(DbContextOptions<TasklyContext> options) : base(options)
        {
        }

        public DbSet<TodoTask> Tasks { get; set; }
    }
}