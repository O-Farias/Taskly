using AutoMapper;
using Taskly.DTOs;
using Taskly.Models;

namespace Taskly.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<TodoTask, TaskDto>();
            CreateMap<TodoTask, TaskSummaryDto>();

            CreateMap<CreateTaskDto, TodoTask>()
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.Now))
                .ForMember(dest => dest.IsCompleted, opt => opt.MapFrom(src => false));

            CreateMap<UpdateTaskDto, TodoTask>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null))
                .ForMember(dest => dest.CompletedAt, opt => opt.MapFrom((src, dest) =>
                    src.IsCompleted && !dest.IsCompleted ? DateTime.Now : dest.CompletedAt));
        }
    }
}