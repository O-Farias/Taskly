using Taskly.DTOs;

namespace Taskly.Services
{
    public interface ITaskService
    {
        Task<IEnumerable<TaskDto>> GetAllTasksAsync();
        Task<TaskDto> GetTaskByIdAsync(int id);
        Task<TaskDto> CreateTaskAsync(CreateTaskDto taskDto);
        Task<TaskDto> UpdateTaskAsync(int id, UpdateTaskDto taskDto);
        Task DeleteTaskAsync(int id);
    }
}