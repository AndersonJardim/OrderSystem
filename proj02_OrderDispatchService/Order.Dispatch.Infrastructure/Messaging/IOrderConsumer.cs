namespace Order.Dispatch.Infrastructure.Messaging;

public interface IOrderConsumer
{
    Task StartAsync(CancellationToken cancellationToken);
}
