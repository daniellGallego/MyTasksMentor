using MyTasksMentor.API.FakeRepositories;
using MyTasksMentor.Application.Services;
using MyTasksMentor.Domain.Interfaces;
using MyTasksMentor.Infrastructure.Persistence;
using MyTasksMentor.Infrastructure.Repositories;
using MyTasksMentor.API.Middleware;
using MyTasksMentor.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<ITaskRepository, TaskRepository>();
builder.Services.AddSingleton<MongoDbContext>();
builder.Services.AddScoped<TaskService>();
builder.Services.AddScoped<INoteRepository, NoteRepository>();

builder.Services.AddHttpClient<AiService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowVue", policy =>
    {
        policy
            .WithOrigins("http://localhost:5173")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.

    app.UseSwagger();
    app.UseSwaggerUI();


app.UseHttpsRedirection();
app.UseMiddleware<ExceptionMiddleware>();

app.UseAuthorization();

app.UseCors("AllowVue");
app.MapControllers();

app.Run();
