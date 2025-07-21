using Order.Dispatch.Application.Interfaces;
using System;
using System.Threading.Tasks;

namespace Order.Dispatch.Application.Services;

public class OrderDispatchService : IOrderDispatchService
{
    public Task DispatchAsync(string message)
    {
        Console.WriteLine($"[DISPATCH] Processing order: {message}");
        // Chamada HTTP, push para outra fila, etc.
        return Task.CompletedTask;
    }
}
