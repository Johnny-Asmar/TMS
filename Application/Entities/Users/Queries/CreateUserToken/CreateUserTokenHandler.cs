using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Application.Entities.Users.Queries.Login;
using Domain.Models;
using MediatR;
using Microsoft.IdentityModel.Tokens;
using Task = System.Threading.Tasks.Task;

namespace Application.Entities.Users.Queries.CreateUserToken;

public class CreateUserTokenHandler : IRequestHandler<CreateUserTokenQuery, string>
{
    public CreateUserTokenHandler()
    {
    }

    public async Task<string> Handle(CreateUserTokenQuery request, CancellationToken cancellationToken)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ThisIsMySecretKeyzzxxxxxx"));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var claims = new[]
        {
            new Claim(ClaimTypes.Name, "username"),
            new Claim(ClaimTypes.Role, "Admin"),
        };
        var token = new JwtSecurityToken(
            issuer: "http://localhost:5125",
            audience: "http://localhost:5125",
            claims: claims,
            expires: DateTime.Now.AddMinutes(30), // Set token expiration
            signingCredentials: creds
        );
        return new JwtSecurityTokenHandler().WriteToken(token);

    }
}