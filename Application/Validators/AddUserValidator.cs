using Application.Entities.Users.Queries.Register;
using FluentValidation;
namespace Application.Validators;
using FluentValidation;


public class AddUserValidator : AbstractValidator<AddUserCommand> 
{
   
    public AddUserValidator()
    {
        RuleFor(model => model.username).NotEmpty().WithMessage("Title is required").Length(4, 70);
        RuleFor(model => model.password).NotEmpty().WithMessage("Description is required")
            .MinimumLength(8).WithMessage("Your password length must be at least 8.")
            .MaximumLength(16).WithMessage("Your password length must not exceed 16.")
            .Matches(@"[A-Z]+").WithMessage("Your password must contain at least one uppercase letter.")
            .Matches(@"[a-z]+").WithMessage("Your password must contain at least one lowercase letter.")
            .Matches(@"[0-9]+").WithMessage("Your password must contain at least one number.")
            .Matches(@"[\!\?\*\.]+").WithMessage("Your password must contain at least one (!? *.).");;
        RuleFor(model => model.name).NotEmpty().WithMessage("Name is required");
    }
}