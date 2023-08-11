using Application.ViewModel;
using AutoMapper;
using Domain.Models;
using MediatR;
using Task = Domain.Models.Task;

namespace Application.Entities.Tasks.Queries.GetTaskById;

public class GetTaskByIdHandler : IRequestHandler<GetTaskByIdQuery, TasksViewModel>
{
    private IMapper _mapper;
    public postgresContext _postgresContext;
    
    public GetTaskByIdHandler(postgresContext postgresContext, IMapper mapper)
    {
        _mapper = mapper;
        _postgresContext = postgresContext;
    }

    public async Task<TasksViewModel> Handle(GetTaskByIdQuery request, CancellationToken cancellationToken)
    {
        // Get Task By id
        var Fetchedtask = _postgresContext.Tasks.FirstOrDefault(t => t.Id == request.id);
        if (Fetchedtask != null)
        {
            // If exists, get Task
            TasksViewModel tasksViewModel = _mapper.Map<TasksViewModel>(Fetchedtask);
            return tasksViewModel;
        }
        else
        {
            // Task does not exist
            throw new Exception("Does not exist");
        }

    }
}