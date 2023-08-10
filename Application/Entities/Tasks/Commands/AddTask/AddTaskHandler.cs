
using Application.Entities.Tasks.Commands.AddTask;
using Application.Validators;
using Domain.Models;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Task = Domain.Models.Task;


public class AddTaskHandler : IRequestHandler<AddTaskCommand, string>
{
    private readonly IValidator<AddTaskCommand> _validator;
    private postgresContext _postgresContext;
    
    public AddTaskHandler(postgresContext postgresContext, IValidator<AddTaskCommand> validator)
    {
        _validator = validator;
        _postgresContext = postgresContext;
    }

    public async Task<string> Handle(AddTaskCommand request, CancellationToken cancellationToken)
    {
        // Check if Task Input is Valid
        var validationResult = await _validator.ValidateAsync(request);

        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }
        
        // If valid, create Task and add it to DB
        Task task = new Task();
        task.Priority = request.priority;
        task.Title = request.title;
        task.Description = request.description;
        task.AssignedTo = request.UserId;
        task.endDate = request.endDate;
        task.status = request.status;
        await _postgresContext.Tasks.AddAsync(task);
        _postgresContext.SaveChanges();
        return "done";
    }
}