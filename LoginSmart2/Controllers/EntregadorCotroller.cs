using LogiSmart.Domain.Entities;
using LogiSmart2.Services;
using Microsoft.AspNetCore.Mvc;

namespace LogiSmart2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntregadoresController : ControllerBase
    {
        private readonly EntregadorService _entregadorService;

        public EntregadoresController(EntregadorService entregadorService)
        {
            _entregadorService = entregadorService;
        }

        [HttpGet]
        public IActionResult GetEntregadores()
        {
            var entregadores = _entregadorService.BuscarEntregadores();

            return Ok(entregadores);
        }

        [HttpPost]
        public IActionResult CriarEntregador(Entregador entregador)
        {
            try
            {
                _entregadorService.CriarEntregador(entregador);

                return CreatedAtAction(
                    nameof(GetEntregadores),
                    new { id = entregador.Id },
                    entregador);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarEntregador(int id, Entregador entregador)
        {
            var entregadorAtualizado =
                _entregadorService.AtualizarEntregador(id, entregador);

            if (entregadorAtualizado == null)
                return NotFound("Entregador não encontrado.");

            return Ok(entregadorAtualizado);
        }

        [HttpDelete("{id}")]
        public IActionResult ExcluirEntregador(int id)
        {
            var excluido = _entregadorService.ExcluirEntregador(id);

            if (!excluido)
                return NotFound("Entregador não encontrado.");

            return NoContent();
        }
    }
}