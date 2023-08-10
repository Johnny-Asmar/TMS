using System.Reflection;
using System.Text;
using Application.Entities.Tasks.Commands.AddTask;
using Application.Entities.Tasks.Commands.UpdateTask;
using Application.Entities.Users.Queries.Register;
using Application.Validators;
using Domain.Models;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Task = Domain.Models.Task;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure DB
builder.Services.AddScoped(typeof(postgresContext), typeof(postgresContext));

// Configure MediatR pattern
builder.Services.AddMediatR(typeof(AddTaskCommand).GetTypeInfo().Assembly);

// Add the custom pipeline validation to DI
builder.Services.AddScoped<IValidator<AddTaskCommand>, AddTaskValidator>();
builder.Services.AddScoped<IValidator<UpdateTaskCommand>, UpdateTaskValidator>();
builder.Services.AddScoped<IValidator<AddUserCommand>, AddUserValidator>();

// Configure JWT
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "xxxxx",
            ValidAudience = "xxxx",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ThisIsMySecretKeyzzxxxxxx")) // Replace with your secret key
        };
    });

// Configure role-based authorization
builder.Services.AddAuthorization(options => {
    options.AddPolicy("Admin", policy => policy.RequireRole("admin"));
    options.AddPolicy("User", policy => policy.RequireRole("user"));
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseAuthentication();

app.MapControllers();

app.Run();