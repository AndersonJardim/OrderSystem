using Microsoft.AspNetCore.Mvc;
using Order.Ingest.Application.Dtos;
using Order.Ingest.Application.Services;

namespace Order.Ingest.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderApplicationService _orderService;
        private readonly ILogger<OrdersController> _logger;

        public OrdersController(IOrderApplicationService orderService, ILogger<OrdersController> logger)
        {
            _orderService = orderService;
            _logger = logger;
        }

        /// <summary>
        /// Recebe e processa um novo pedido.
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        public async Task<IActionResult> PostOrderAsync([FromBody] OrderRequestDto request, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _logger.LogInformation("Recebendo novo pedido com ID: {OrderId}", request.OrderId);

            try
            {
                await _orderService.ProcessOrderAsync(request);//, cancellationToken
                return Accepted(new { message = "Pedido recebido e está sendo processado." });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao processar pedido com ID: {OrderId}", request.OrderId);
                return StatusCode(500, new { message = "Erro interno ao processar o pedido." });
            }
        }
    }
}