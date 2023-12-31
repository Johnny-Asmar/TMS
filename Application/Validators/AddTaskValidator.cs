using Application.Entities.Tasks.Commands.AddTask;
using Application.Entities.Tasks.Commands.UpdateTask;
using FluentValidation;

namespace Application.Validators;

public class AddTaskValidator : AbstractValidator<AddTaskCommand>
{
    public AddTaskValidator() 
        {
            RuleFor(model => model.title).NotEmpty().WithMessage("Title is required");
            RuleFor(model => model.description).NotEmpty().WithMessage("Description is required");
            RuleFor(model => model.UserId).NotEmpty().WithMessage("Assigned to Who?");
            RuleFor(model => model.endDate).NotEmpty().WithMessage("Date is required").GreaterThanOrEqualTo(DateTime.Today.AddDays(-1));
            RuleFor(model => model.status).NotEmpty().WithMessage("Status is required");
        }
}