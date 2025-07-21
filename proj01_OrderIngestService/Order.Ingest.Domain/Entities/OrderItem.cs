namespace Order.Ingest.Domain.Entities;

public class OrderItem
{
    public Guid ProductId { get; }
    public int Quantity { get; }
    public decimal Price { get; }

    public decimal Total => Quantity * Price;

    public OrderItem(Guid productId, int quantity, decimal price)
    {
        ProductId = productId;
        Quantity = quantity;
        Price = price;
    }
}
