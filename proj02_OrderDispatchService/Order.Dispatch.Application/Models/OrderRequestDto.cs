namespace Order.Dispatch.Application.Dtos;

public class OrderRequestDto
{
    public Guid OrderId { get; set; }
    public List<OrderItemRequestDto> Items { get; set; }
}

public class OrderItemRequestDto
{
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
}
