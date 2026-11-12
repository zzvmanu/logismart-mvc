using LogiSmart.Domain.Entities;
using LogiSmart2.Data;

namespace LogiSmart2.Services
{
    public class EntregadorService
    {
        private readonly LogiSmart2DbContext _context;

        public EntregadorService(LogiSmart2DbContext context)
        {
            _context = context;
        }

        public List<Entregador> BuscarEntregadores()
        {
            return _context.Entregadores.ToList();
        }

        public Entregador CriarEntregador(Entregador entregador)
        {
            if (string.IsNullOrWhiteSpace(entregador.Nome))
            {
                throw new Exception("O nome do entregador é obrigatório.");
            }

            _context.Entregadores.Add(entregador);
            _context.SaveChanges();

            return entregador;
        }

        public Entregador? AtualizarEntregador(int id, Entregador entregador)
        {
            var entregadorExistente = _context.Entregadores.Find(id);

            if (entregadorExistente == null)
                return null;

            entregadorExistente.Nome = entregador.Nome;
            entregadorExistente.Telefone = entregador.Telefone;
            entregadorExistente.Veiculo = entregador.Veiculo;
            entregadorExistente.Ativo = entregador.Ativo;

            _context.SaveChanges();

            return entregadorExistente;
        }

        public bool ExcluirEntregador(int id)
        {
            var entregador = _context.Entregadores.Find(id);

            if (entregador == null)
                return false;

            _context.Entregadores.Remove(entregador);
            _context.SaveChanges();

            return true;
        }
    }
}