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
    public postgresContext _postgresContext;

    public CreateUserTokenHandler()
    {
    }

    public async Task<string> Handle(CreateUserTokenQuery request, CancellationToken cancellationToken)
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.Name, "username"),
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ThisIsMySecretKeyzzxxxxxx"));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: "xxxxx",
            audience: "xxxx",
            claims: claims,
            expires: DateTime.Now.AddMinutes(30), // Set token expiration
            signingCredentials: creds
        );
        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenString = tokenHandler.WriteToken(token);
        return tokenString;
    }

}