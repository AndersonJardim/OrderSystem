namespace Order.Ingest.Application.Dtos;

public class OrderRequestDto
{
    public Guid OrderId { get; set; }
    public List<OrderItemDto> Items { get; set; }
}

public class OrderItemDto
{
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
}
