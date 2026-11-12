using LogiSmart.Domain.Entities;
using LogiSmart2.Services;
using Microsoft.AspNetCore.Mvc;

namespace LogiSmart2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItensPedidoController : ControllerBase
    {
        private readonly ItemPedidoService _itemPedidoService;

        public ItensPedidoController(ItemPedidoService itemPedidoService)
        {
            _itemPedidoService = itemPedidoService;
        }

        [HttpGet]
        public IActionResult GetItens()
        {
            var itens = _itemPedidoService.BuscarItens();

            return Ok(itens);
        }

        [HttpPost]
        public IActionResult CriarItem(ItemPedido item)
        {
            try
            {
                _itemPedidoService.CriarItem(item);

                return CreatedAtAction(nameof(GetItens), new { id = item.Id }, item);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}