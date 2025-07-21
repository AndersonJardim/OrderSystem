using Microsoft.Extensions.Configuration;
using Order.Ingest.Domain.Interfaces;
using System.Threading.Tasks;
using System.Net.Http.Json;
using OrderEntity = Order.Ingest.Domain.Entities.Order;

namespace Order.Ingest.Infrastructure.Messaging;

public class FakeOrderPublisher : IOrderPublisher
{
    private readonly HttpClient _httpClient;
    private readonly string _dispatchUrl;

    public FakeOrderPublisher(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _dispatchUrl = configuration["DispatchService:Url"]!;
    }

    public async Task PublishAsync(OrderEntity order)
    {
        //Console.WriteLine($"[FAKE PUBLISHER] Order {order.OrderId} with {order.Items.Count} items published.");
        //return Task.CompletedTask;

        var dto = new
        {
            OrderId = order.OrderId,
            Items = order.Items.Select(i => new
            {
                ProductId = i.ProductId,
                Quantity = i.Quantity,
                Price = i.Price
            }).ToList()
        };

        var response = await _httpClient.PostAsJsonAsync($"{_dispatchUrl}/api/order", dto);

        if (!response.IsSuccessStatusCode)
        {
            Console.WriteLine($"[ERRO] Falha ao enviar pedido: {response.StatusCode}");
        }
        else
        {
            Console.WriteLine($"[OK] Pedido {order.OrderId} enviado com sucesso via HTTP.");
        }
    }
}
