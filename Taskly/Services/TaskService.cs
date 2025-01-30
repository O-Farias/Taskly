using Microsoft.EntityFrameworkCore;
using Taskly.Data;
using Taskly.Models;

namespace Taskly.Services
{
    public class TaskService : ITaskService
    {
        private readonly TasklyContext _context;

        public TaskService(TasklyContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Task>> GetAllTasksAsync()
        {
            return await _context.Tasks
                .OrderByDescending(t => t.CreatedAt)
                .ToListAsync();
        }

        public async Task<Task> GetTaskByIdAsync(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task == null)
                throw new KeyNotFoundException($"Tarefa com ID {id} não encontrada.");

            return task;
        }

        public async Task<Task> CreateTaskAsync(Task task)
        {
            if (string.IsNullOrEmpty(task.Title))
                throw new ArgumentException("O título da tarefa é obrigatório.");

            task.CreatedAt = DateTime.Now;

            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();

            return task;
        }

        public async Task<Task> UpdateTaskAsync(int id, Task task)
        {
            if (id != task.Id)
                throw new ArgumentException("IDs não correspondem.");

            var existingTask = await _context.Tasks.FindAsync(id);
            if (existingTask == null)
                throw new KeyNotFoundException($"Tarefa com ID {id} não encontrada.");

            existingTask.Title = task.Title;
            existingTask.Description = task.Description;
            existingTask.IsCompleted = task.IsCompleted;

            if (task.IsCompleted && !existingTask.IsCompleted)
                existingTask.CompletedAt = DateTime.Now;

            await _context.SaveChangesAsync();

            return existingTask;
        }

        public async Task DeleteTaskAsync(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task == null)
                throw new KeyNotFoundException($"Tarefa com ID {id} não encontrada.");

            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
        }
    }
}