using System.Threading.Tasks;

namespace Order.Dispatch.Application.Interfaces;

public interface IOrderDispatchService
{
    Task DispatchAsync(string message);
}
