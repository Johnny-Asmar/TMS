using Application.Repositories.Abstraction;
using Application.Repositories.Implementations;
using FluentValidation;
using MediatR;
using Persistence.DB;

namespace Application.Entities.Tasks.Commands.UpdateTask;

public class UpdateTaskHandler : IRequestHandler<UpdateTaskCommand, ApiResponse<string>>
{
    private readonly IValidator<UpdateTaskCommand> _validator;
    private ITaskRepository _taskRepository;
    
    public UpdateTaskHandler(ITaskRepository taskRepository, IValidator<UpdateTaskCommand> validator)
    {
        _validator = validator;
        _taskRepository = taskRepository;
    }
    
    public async Task<ApiResponse<string>> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
    {
        // Check if Task Input is Valid
        var validationResult = await _validator.ValidateAsync(request);
        if (!validationResult.IsValid)
        {
            return new ApiResponse<string>(1, "Update Task FAILED", "Not Done", validationResult.Errors.ToString());
        }

        return _taskRepository.UpdateTask(request);
    }
}