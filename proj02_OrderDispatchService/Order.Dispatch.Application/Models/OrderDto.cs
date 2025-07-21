namespace Order.Dispatch.Application.Models;

public class OrderDto
{
    public Guid OrderId { get; set; } = default!;
    public List<OrderItemDto> Items { get; set; } = new();
}

public class OrderItemDto
{
    public Guid ProductId { get; set; } = default!;
    public int Quantity { get; set; }
    public decimal Price { get; set; }
}
