using LogiSmart.Domain.Entities;
using LogiSmart2.Services;
using Microsoft.AspNetCore.Mvc;

namespace LogiSmart2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntregasController : ControllerBase
    {
        private readonly EntregaService _entregaService;

        public EntregasController(EntregaService entregaService)
        {
            _entregaService = entregaService;
        }

        [HttpGet]
        public IActionResult GetEntregas()
        {
            var entregas = _entregaService.BuscarEntregas();

            return Ok(entregas);
        }

        
        [HttpPost]
        public IActionResult CriarEntregas(Entrega entrega)
        {
            try
            {
                _entregaService.CriarEntrega(entrega);

                return CreatedAtAction(nameof(GetEntregas), new { id = entrega.Id }, entrega);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}