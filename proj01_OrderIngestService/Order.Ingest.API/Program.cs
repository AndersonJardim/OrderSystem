using Order.Ingest.API.Extensions;
using Order.Ingest.Application.Services;
using Order.Ingest.Domain.Interfaces;
using Order.Ingest.Infrastructure.Messaging;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerDoc();
builder.Services.AddSwaggerDoc();

builder.Services.AddScoped<IOrderApplicationService, OrderApplicationService>();

//Meu teste local
//builder.Services.AddScoped<IOrderPublisher, FakeOrderPublisher>();
//
//Meu testes ao outro sistema
builder.Services.AddHttpClient<IOrderPublisher, FakeOrderPublisher>();
//Ao usar o RabbitMq
//builder.Services.AddScoped<IOrderPublisher, RabbitMqOrderPublisher>();



var app = builder.Build();

//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}
app.UseSwaggerDoc();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
