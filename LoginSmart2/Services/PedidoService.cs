using LogiSmart.Domain.Entities;
using LogiSmart2.Data;

namespace LogiSmart2.Services
{
    public class PedidoService
    {
        private readonly LogiSmart2DbContext _context;

        public PedidoService(LogiSmart2DbContext context)
        {
            _context = context;
        }

        public List<Pedido> BuscarPedidos()
        {
            return _context.Pedidos.ToList();
        }

        public Pedido CriarPedido(Pedido pedido)
        {
            pedido.Status = "Pendente";

            var clienteExiste = _context.Clientes.Any(c => c.Id == pedido.ClienteId);

            if (!clienteExiste)
            {
                throw new Exception("Cliente não encontrado.");
            }

            _context.Pedidos.Add(pedido);
            _context.SaveChanges();

            return pedido;
        }

        public Pedido? AtualizarPedido(int id, Pedido pedido)
        {
            var pedidoExistente = _context.Pedidos.Find(id);

            if (pedidoExistente == null)
                return null;

            var clienteExiste = _context.Clientes.Any(c => c.Id == pedido.ClienteId);

            if (!clienteExiste)
            {
                throw new Exception("Cliente não encontrado.");
            }

            pedidoExistente.Status = pedido.Status;
            pedidoExistente.ClienteId = pedido.ClienteId;

            _context.SaveChanges();

            return pedidoExistente;
        }

        public bool ExcluirPedido(int id)
        {
            var pedido = _context.Pedidos.Find(id);

            if (pedido == null)
                return false;

            _context.Pedidos.Remove(pedido);
            _context.SaveChanges();

            return true;
        }
    }
}