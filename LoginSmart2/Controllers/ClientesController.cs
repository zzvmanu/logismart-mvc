using LogiSmart.Domain.Entities;
using LogiSmart2.Services;
using Microsoft.AspNetCore.Mvc;

namespace LogiSmart2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly ClienteService _clienteService;

        public ClientesController(ClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet]
        public IActionResult GetClientes()
        {
            var clientes = _clienteService.BuscarClientes();

            return Ok(clientes);
        }

        [HttpPost]
        public IActionResult CriarCliente(Cliente cliente)
        {
            _clienteService.CriarCliente(cliente);

            return CreatedAtAction(nameof(GetClientes), new { id = cliente.Id }, cliente);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarCliente(int id, Cliente cliente)
        {
            var clienteAtualizado = _clienteService.AtualizarCliente(id, cliente);

            if (clienteAtualizado == null)
                return NotFound("Cliente não encontrado.");

            return Ok(clienteAtualizado);
        }

        [HttpDelete("{id}")]
        public IActionResult ExcluirCliente(int id)
        {
            var excluido = _clienteService.ExcluirCliente(id);

            if (!excluido)
                return NotFound("Cliente não encontrado.");

            return NoContent();
        }
    }
}