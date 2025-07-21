using Order.Dispatch.Application.Interfaces;
using Order.Dispatch.Application.Services;
using Order.Dispatch.Infrastructure.Messaging;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IOrderConsumer, FakeOrderConsumer>();

builder.Services.AddScoped<IOrderDispatchService, OrderDispatchService>();
builder.Services.AddHostedService<OrderConsumer>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var consumer = scope.ServiceProvider.GetRequiredService<IOrderConsumer>();
    await consumer.StartAsync(CancellationToken.None);
}

app.UseAuthorization();
app.MapControllers();

app.Run();
