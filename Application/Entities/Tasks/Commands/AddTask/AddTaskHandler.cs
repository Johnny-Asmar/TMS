
using Application;
using Application.Entities.Tasks.Commands.AddTask;
using Application.Repositories.Abstraction;
using Application.Validators;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Persistence.DB;
using Task = Domain.Models.Task;


public class AddTaskHandler : IRequestHandler<AddTaskCommand, ApiResponse<string>>
{
    private readonly IValidator<AddTaskCommand> _validator;
    private ITaskRepository _taskRepository;
    
    public AddTaskHandler(ITaskRepository taskRepository, IValidator<AddTaskCommand> validator)
    {
        _validator = validator;
        _taskRepository = taskRepository;
    }

    public async Task<ApiResponse<string>> Handle(AddTaskCommand request, CancellationToken cancellationToken)
    {
        // Check if Task Input is Valid
        var validationResult = await _validator.ValidateAsync(request);
        if (!validationResult.IsValid)
        {
            new ApiResponse<string>(-1, "NOT VALIDATED", "NOT PASSED", new ValidationException(validationResult.Errors).ToString());
        }
        // If valid, create Task and add it to DB
        return _taskRepository.AddTask(request);
    }
}