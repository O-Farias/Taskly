using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Taskly.Data;
using Taskly.DTOs;
using Taskly.Models;

namespace Taskly.Services
{
    public class TaskService : ITaskService
    {
        private readonly TasklyContext _context;
        private readonly IMapper _mapper;

        public TaskService(TasklyContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TaskDto>> GetAllTasksAsync()
        {
            var tasks = await _context.Tasks
                .OrderByDescending(t => t.CreatedAt)
                .ToListAsync();
            return _mapper.Map<IEnumerable<TaskDto>>(tasks);
        }

        public async Task<TaskDto> GetTaskByIdAsync(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task == null)
                throw new KeyNotFoundException($"Tarefa com ID {id} não encontrada.");

            return _mapper.Map<TaskDto>(task);
        }

        public async Task<TaskDto> CreateTaskAsync(CreateTaskDto taskDto)
        {
            if (string.IsNullOrEmpty(taskDto.Title))
                throw new ArgumentException("O título da tarefa é obrigatório.");

            var task = _mapper.Map<TodoTask>(taskDto);
            task.CreatedAt = DateTime.Now;

            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();

            return _mapper.Map<TaskDto>(task);
        }

        public async Task<TaskDto> UpdateTaskAsync(int id, UpdateTaskDto taskDto)
        {
            var existingTask = await _context.Tasks.FindAsync(id);
            if (existingTask == null)
                throw new KeyNotFoundException($"Tarefa com ID {id} não encontrada.");

            _mapper.Map(taskDto, existingTask);

            if (taskDto.IsCompleted && !existingTask.CompletedAt.HasValue)
                existingTask.CompletedAt = DateTime.Now;

            await _context.SaveChangesAsync();

            return _mapper.Map<TaskDto>(existingTask);
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