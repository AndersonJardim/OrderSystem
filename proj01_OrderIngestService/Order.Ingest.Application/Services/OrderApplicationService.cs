using OrderEntity = Order.Ingest.Domain.Entities.Order;
using OrderItemEntity = Order.Ingest.Domain.Entities.OrderItem;
using Order.Ingest.Application.Dtos;
using Order.Ingest.Domain.Interfaces;

namespace Order.Ingest.Application.Services;

public class OrderApplicationService : IOrderApplicationService
{
    private readonly IOrderPublisher _publisher;

    public OrderApplicationService(IOrderPublisher publisher)
    {
        _publisher = publisher;
    }

    public async Task ProcessOrderAsync(OrderRequestDto dto)
    {
        var order = new OrderEntity(
            dto.OrderId,
            dto.Items.Select(i =>
                new OrderItemEntity(i.ProductId, i.Quantity, i.Price)
            ).ToList()
        );

        await _publisher.PublishAsync(order);
    }
}
