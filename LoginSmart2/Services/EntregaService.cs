using LogiSmart.Domain.Entities;
using LogiSmart2.Data;
using Microsoft.EntityFrameworkCore;

namespace LogiSmart2.Services
{
    public class EntregaService
    {
        private readonly LogiSmart2DbContext _context;

        public EntregaService(LogiSmart2DbContext context)
        {
            _context = context;
        }

        public List<Entrega> BuscarEntregas()
        {
            return _context.Entregas.ToList();
        }

        public Entrega CriarEntrega(Entrega entrega)
        {
            var pedidoExiste = _context.Pedidos.Any(p => p.Id == entrega.PedidoId);

            if (!pedidoExiste)
            {
                throw new Exception("Pedido não encontrado.");
            }

            entrega.Status = "Aguardando";

            _context.Entregas.Add(entrega);
            _context.SaveChanges();

            return entrega;
        }
    }
}