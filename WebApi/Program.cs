using EventBusExample.Interfaces.Repositories;
using Microsoft.AspNetCore.Hosting;
using EventBusExample.Interfaces;
using EventBusExample.Repositories;
using EventBusExample.Services;
using EventBusExample.Services.Messaging;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// This adds MediatR for auto-hookup of event publishers and consumers
// You need to add the assemblies that contain the INotification class
// You can add multiple and they will fire in the order they are registered
builder.Services.AddMediatR(cfg => {    
    cfg.RegisterServicesFromAssemblyContaining<Program>(); // Contains the consumer - AnotherUserRegisteredIntegrationEventHandler
    cfg.RegisterServicesFromAssemblyContaining<InMemoryMessageQueue>(); // Contains the consumer - UserRegisteredIntegrationEventHandler
});

builder.Services.AddSingleton<IUserRepository, InMemoryUserRepository>();
builder.Services.AddSingleton<InMemoryMessageQueue>();
builder.Services.AddSingleton<IEventBus, EventBus>();
builder.Services.AddHostedService<IntegrationEventProcessorJob>();

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

app.Run();
