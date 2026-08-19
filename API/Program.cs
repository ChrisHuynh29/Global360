using API.Middleware;
using Application;
using Infrastructure;
using Microsoft.OpenApi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "TaskManager API", Version = "v1" });
});

//DI for application services and repositories, it will register all the services related to the application layer
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices();

// Configure CORS to allow requests from any origin, with any header and any method
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

// Middlewares
app.UseMiddleware<CorrelationMiddleware>();
app.UseMiddleware<ExceptionHandlingMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();
app.UseCors();
app.UseRouting();
app.UseAuthorization();

app.MapControllers();

app.Run();
