using Taskly.Models;

namespace Taskly.Services
{
    public interface ITaskService
    {
        Task<IEnumerable<TodoTask>> GetAllTasksAsync();
        Task<TodoTask> GetTaskByIdAsync(int id);
        Task<TodoTask> CreateTaskAsync(TodoTask task);
        Task<TodoTask> UpdateTaskAsync(int id, TodoTask task);
        Task DeleteTaskAsync(int id);
    }
}