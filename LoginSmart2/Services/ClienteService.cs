using LogiSmart.Domain.Entities;
using LogiSmart2.Data;

namespace LogiSmart2.Services
{
    public class ClienteService
    {
        private readonly LogiSmart2DbContext _context;

        public ClienteService(LogiSmart2DbContext context)
        {
            _context = context;
        }

        public List<Cliente> BuscarClientes()
        {
            return _context.Clientes.ToList();
        }

        public Cliente CriarCliente(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            _context.SaveChanges();

            return cliente;
        }

        public Cliente? AtualizarCliente(int id, Cliente cliente)
        {
            var clienteExistente = _context.Clientes.Find(id);

            if (clienteExistente == null)
                return null;

            clienteExistente.Nome = cliente.Nome;
            clienteExistente.Email = cliente.Email;
            clienteExistente.Telefone = cliente.Telefone;
            clienteExistente.Endereco = cliente.Endereco;

            _context.SaveChanges();

            return clienteExistente;
        }

        public bool ExcluirCliente(int id)
        {
            var cliente = _context.Clientes.Find(id);

            if (cliente == null)
                return false;

            _context.Clientes.Remove(cliente);
            _context.SaveChanges();

            return true;
        }
    }
}