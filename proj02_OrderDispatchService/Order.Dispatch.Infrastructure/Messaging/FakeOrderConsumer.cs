using System.Text.Json;
using Order.Dispatch.Application.Interfaces;

namespace Order.Dispatch.Infrastructure.Messaging;

public class FakeOrderConsumer : IOrderConsumer
{
    private readonly IOrderDispatchService _dispatchService;

    public FakeOrderConsumer(IOrderDispatchService dispatchService)
    {
        _dispatchService = dispatchService;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        //Simulando... um recebimento de 3 pedidos
        for (int i = 1; i <= 3; i++)
        {
            var message = JsonSerializer.Serialize(new
            {
                OrderId = $"Pedido-{i}",
                CreatedAt = DateTime.UtcNow
            });

            Console.WriteLine($"[FAKE CONSUMER] Mensagem recebida: {message}");
            await _dispatchService.DispatchAsync(message);
            await Task.Delay(1000, cancellationToken);
        }
    }
}
