using Application.Entities.Users.Queries.Login;
using Domain.Models;
using FluentValidation;
using MediatR;
using Persistence.DB;

namespace Application.Entities.Users.Queries.Register;

public class AddUserHandler : IRequestHandler<AddUserCommand, string>
{
    private readonly IValidator<AddUserCommand> _validator;
    public Context _postgresContext;
    
    public AddUserHandler(Context postgresContext, IValidator<AddUserCommand> validator)
    {
        _validator = validator;
        _postgresContext = postgresContext;
    }

    public async Task<string> Handle(AddUserCommand request, CancellationToken cancellationToken)
    {
        // Validate User Input
        var validationResult = await _validator.ValidateAsync(request);
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }
        // Get User by username
        var FetchedUser = _postgresContext.Users.FirstOrDefault(t => t.Username == request.username);
        if (FetchedUser != null)
        {
            // Same Username!
            return "username taken";
        }
        else
        {
            // create User
            User user = new User();
            user.Username = request.username;
            user.Password = request.password;
            user.Name = request.name;
            user.RoleId = 1;
            await _postgresContext.Users.AddAsync(user);
            _postgresContext.SaveChanges();
            return "success";
        }

    }


}