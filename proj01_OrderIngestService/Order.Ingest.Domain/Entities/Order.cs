namespace Order.Ingest.Domain.Entities;

public class Order
{
    public Guid OrderId { get; }
    public List<OrderItem> Items { get; }

    public decimal Total => Items.Sum(i => i.Total);

    public Order(Guid orderId, List<OrderItem> items)
    {
        OrderId = orderId;
        Items = items;
    }
}
