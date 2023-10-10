using Application.Entities.Tasks.Commands.UpdateTask;
using FluentValidation;

namespace Application.Validators;

public class UpdateTaskValidator : AbstractValidator<UpdateTaskCommand>
{
    public UpdateTaskValidator() 
    {
        RuleFor(model => model.title).NotEmpty().WithMessage("Title is required");
        RuleFor(model => model.description).NotEmpty().WithMessage("Description is required");
        RuleFor(model => model.userId).NotEmpty().WithMessage("Assigned to Who?");
        RuleFor(model => model.endDate).NotEmpty().WithMessage("Date is required").GreaterThanOrEqualTo(DateTime.Today.AddDays(-1));;
        RuleFor(model => model.status).NotEmpty().WithMessage("Status is required");
    }
}