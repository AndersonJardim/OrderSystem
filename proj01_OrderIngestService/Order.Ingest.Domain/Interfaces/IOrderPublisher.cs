using OrderEntity = Order.Ingest.Domain.Entities.Order;

namespace Order.Ingest.Domain.Interfaces;

public interface IOrderPublisher
{
    Task PublishAsync(OrderEntity order);
}
