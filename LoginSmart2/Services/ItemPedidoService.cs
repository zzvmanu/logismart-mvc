using LogiSmart.Domain.Entities;
using LogiSmart2.Data;

namespace LogiSmart2.Services
{
    public class ItemPedidoService
    {
        private readonly LogiSmart2DbContext _context;

        public ItemPedidoService(LogiSmart2DbContext context)
        {
            _context = context;
        }

        public List<ItemPedido> BuscarItens()
        {
            return _context.ItensPedido.ToList();
        }

        public ItemPedido CriarItem(ItemPedido item)
        {
            var produtoExiste = _context.Produtos.Any(p => p.Id == item.ProdutoId);

            if (!produtoExiste)
            {
                throw new Exception("Produto não encontrado.");
            }

            _context.ItensPedido.Add(item);
            _context.SaveChanges();

            return item;
        }
    }
}