using MyInfrastructure;
using System.Runtime.CompilerServices;
using WebApplication23.Controllers;

// Hi, Teacher Yee.

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpContextAccessor();

builder.Services.AddScoped<IMyService, MyService>();    

//builder.Services.AddScoped<IServiceBusTopic, FakeServiceBusTopic>();
builder.Services.AddMyService();
//builder.Services.AddScope

builder.Services.AddInfrastructure();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

await app.RunAsync();


public static class MyExtensions
{
    public static IServiceCollection AddMyService(this IServiceCollection services)
    {
        services.AddScoped<IServiceBusTopic, FakeServiceBusTopic>();

        return services;
    }
}