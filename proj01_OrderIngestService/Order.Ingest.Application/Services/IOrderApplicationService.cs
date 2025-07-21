using Order.Ingest.Application.Dtos;
using System.Threading.Tasks;

namespace Order.Ingest.Application.Services;

public interface IOrderApplicationService
{
    Task ProcessOrderAsync(OrderRequestDto dto);
}
