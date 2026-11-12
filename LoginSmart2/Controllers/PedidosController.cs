using LogiSmart.Domain.Entities;
using LogiSmart2.Services;
using Microsoft.AspNetCore.Mvc;

namespace LogiSmart2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidosController : ControllerBase
    {
        private readonly PedidoService _pedidoService;

        public PedidosController(PedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }

        [HttpGet]
        public IActionResult GetPedidos()
        {
            var pedidos = _pedidoService.BuscarPedidos();

            return Ok(pedidos);
        }

        [HttpPost]
        public IActionResult CriarPedido(Pedido pedido)
        {
            try
            {
                _pedidoService.CriarPedido(pedido);

                return CreatedAtAction(
                    nameof(GetPedidos),
                    new { id = pedido.Id },
                    pedido);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarPedido(int id, Pedido pedido)
        {
            try
            {
                var pedidoAtualizado =
                    _pedidoService.AtualizarPedido(id, pedido);

                if (pedidoAtualizado == null)
                    return NotFound("Pedido não encontrado.");

                return Ok(pedidoAtualizado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult ExcluirPedido(int id)
        {
            var excluido = _pedidoService.ExcluirPedido(id);

            if (!excluido)
                return NotFound("Pedido não encontrado.");

            return NoContent();
        }
    }
}