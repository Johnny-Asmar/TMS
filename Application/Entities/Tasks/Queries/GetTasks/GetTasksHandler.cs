using Application.Entities.Tasks.Queries.GetTaskById;
using Application.ViewModel;
using AutoMapper;
using Domain.Models;
using MediatR;
using Task = Domain.Models.Task;

namespace Application.Entities.Tasks.Queries.GetTasks;

public class GetTasksHandler : IRequestHandler<GetTasksQuery, List<TasksViewModel>>
{
    private IMapper _mapper;
    public postgresContext _postgresContext;

    public GetTasksHandler(postgresContext postgresContext, IMapper mapper)
    {
        _mapper = mapper;
        _postgresContext = postgresContext;
    }

    public async Task<List<TasksViewModel>> Handle(GetTasksQuery request, CancellationToken cancellationToken)
    {
        // Get All Tasks
        List<Task> listOfTasks =  _postgresContext.Tasks.ToList();
        // convert to TaskViewModel
        List <TasksViewModel> tasksViewModel = _mapper.Map<List<TasksViewModel>>(listOfTasks);
        return tasksViewModel;


    }

}