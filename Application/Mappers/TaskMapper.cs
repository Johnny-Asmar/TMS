using Application.ViewModel;
using AutoMapper;
using Task = Domain.Models.Task;

namespace Application.Mappers;

public class TaskMapper : Profile
{
    public TaskMapper()
    {
        CreateMap<Task, TasksViewModel>();
    }
}