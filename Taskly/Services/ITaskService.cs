using Taskly.Models;

namespace Taskly.Services
{
    public interface ITaskService
    {
        Task<IEnumerable<Task>> GetAllTasksAsync();
        Task<Task> GetTaskByIdAsync(int id);
        Task<Task> CreateTaskAsync(Task task);
        Task<Task> UpdateTaskAsync(int id, Task task);
        Task DeleteTaskAsync(int id);
    }
}