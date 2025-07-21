using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Order.Dispatch.Application.Interfaces;

namespace Order.Dispatch.Infrastructure.Messaging;

public class OrderConsumer : BackgroundService
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger<OrderConsumer> _logger;

    public OrderConsumer(IServiceProvider serviceProvider, ILogger<OrderConsumer> logger)
    {
        _serviceProvider = serviceProvider;
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("OrderConsumer started.");

        while (!stoppingToken.IsCancellationRequested)
        {
            // Simulação de mensagem recebida de uma fila
            var fakeMessage = $"Order-{Guid.NewGuid()}";

            using (var scope = _serviceProvider.CreateScope())
            {
                var dispatchService = scope.ServiceProvider.GetRequiredService<IOrderDispatchService>();
                await dispatchService.DispatchAsync(fakeMessage);
            }

            await Task.Delay(5000, stoppingToken); // Aguarda 5 segundos
        }

        _logger.LogInformation("OrderConsumer stopped.");
    }
}
