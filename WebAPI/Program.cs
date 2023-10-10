using System.Reflection;
using System.Text;
using Application.Entities.Tasks.Commands.AddTask;
using Application.Entities.Tasks.Commands.UpdateTask;
using Application.Entities.Users.Queries.Register;
using Application.Repositories.Abstraction;
using Application.Repositories.Implementations;
using Application.Validators;
using Application.ViewModel;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Persistence.DB;
using Task = Domain.Models.Task;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure DB
builder.Services.AddScoped(typeof(Context), typeof(Context));
// Configure Interfaces
builder.Services.AddScoped<ITaskRepository, TaskRepository>();

// Configure MediatR pattern
builder.Services.AddMediatR(typeof(AddTaskCommand).GetTypeInfo().Assembly);

// Add the custom pipeline validation to DI
builder.Services.AddScoped<IValidator<AddTaskCommand>, AddTaskValidator>();
builder.Services.AddScoped<IValidator<UpdateTaskCommand>, UpdateTaskValidator>();
builder.Services.AddScoped<IValidator<AddUserCommand>, AddUserValidator>();


// Configure CORS to send APIs to the FrontEnd
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowOrigin",
        builder =>
        {
            builder.WithOrigins("http://localhost:3000")
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

// Configure JWT
var key = Encoding.UTF8.GetBytes("ThisIsMySecretKeyzzxxxxxx");
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.SaveToken = true;
        options.RequireHttpsMetadata = false;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidIssuer = "http://localhost:5125",
            ValidAudience = "http://localhost:5125",
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),

        };
    });


var app = builder.Build();
app.UseCors("AllowOrigin");

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