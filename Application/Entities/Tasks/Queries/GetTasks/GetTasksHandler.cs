using Application.Entities.Tasks.Queries.GetTaskById;
using Application.ViewModel;
using AutoMapper;
using Domain.Models;
using MediatR;
using Task = Domain.Models.Task;

namespace Application.Entities.Tasks.Queries.GetTasks;

public class GetTasksHandler : IRequestHandler<GetTasksQuery, List<GetTasksDTO>>
{
    private IMapper _mapper;
    public postgresContext _postgresContext;

    public GetTasksHandler(postgresContext postgresContext, IMapper mapper)
    {
        _mapper = mapper;
        _postgresContext = postgresContext;
    }

    public async Task<List<GetTasksDTO>> Handle(GetTasksQuery request, CancellationToken cancellationToken)
    {
        // // Get All Tasks
        // List<Task> listOfTasks =  _postgresContext.Tasks.ToList();
        // // convert to TaskViewModel
        // List <TasksViewModel> tasksViewModel = _mapper.Map<List<TasksViewModel>>(listOfTasks);
        // return tasksViewModel;
        var tasks = (from taskTable in _postgresContext.Tasks
            join userTable in _postgresContext.Users on taskTable.AssignedTo equals userTable.Id
            select new GetTasksDTO 
                {
                    Id = taskTable.Id, 
                    Description = taskTable.Description,
                    status = taskTable.status,
                    endDate = taskTable.endDate,
                    Title = taskTable.Title, 
                    Name = userTable.Name
                }).ToList();

        return tasks;

    }

}