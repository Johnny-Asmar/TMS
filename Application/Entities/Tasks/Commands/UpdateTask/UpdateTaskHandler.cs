using Application.Entities.Tasks.Commands.AddTask;
using Application.Entities.Tasks.Commands.DeleteTask;
using Domain.Models;
using FluentValidation;
using MediatR;

namespace Application.Entities.Tasks.Commands.UpdateTask;

public class UpdateTaskHandler : IRequestHandler<UpdateTaskCommand, string>
{
    private readonly IValidator<UpdateTaskCommand> _validator;
    private postgresContext _postgresContext;
    
    public UpdateTaskHandler(postgresContext postgresContext, IValidator<UpdateTaskCommand> validator)
    {
        _validator = validator;
        _postgresContext = postgresContext;
    }
    
    public async Task<string> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request);

        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }
        
        var task = _postgresContext.Tasks.FirstOrDefault(t => t.Id == request.id);
        if (task != null)
        {
            task.Priority = request.priority;
            task.Title = request.title;
            task.Description = request.description;
            task.AssignedTo = request.UserId;
            task.endDate = request.endDate;
            task.status = request.status;
            await _postgresContext.SaveChangesAsync();
            return "done";
        }
        else
        {
            throw new Exception("Does not exist");
        }

    }
}