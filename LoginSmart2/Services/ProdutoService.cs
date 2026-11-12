
using LogiSmart.Domain.Entities;
using LogiSmart2.Data;

namespace LogiSmart2.Services
{
    public class ProdutoService
    {
        private readonly LogiSmart2DbContext _context;

        public ProdutoService(LogiSmart2DbContext context)
        {
            _context = context;
        }

        public List<Produto> BuscarProdutos()
        {
            return _context.Produtos.ToList();
        }

        public Produto CriarProduto(Produto produto)
        {
            _context.Produtos.Add(produto);
            _context.SaveChanges();

            return produto;
        }

        public Produto? AtualizarProduto(int id, Produto produto)
        {
            var produtoExistente = _context.Produtos.Find(id);

            if (produtoExistente == null)
                return null;

            produtoExistente.Nome = produto.Nome;
            produtoExistente.Categoria = produto.Categoria;
            produtoExistente.Descricao = produto.Descricao;
            produtoExistente.Preco = produto.Preco;
            produtoExistente.Estoque = produto.Estoque;
            produtoExistente.ImagemUrl = produto.ImagemUrl;

            _context.SaveChanges();

            return produtoExistente;
        }

        public bool ComprarProduto(int id, int quantidade)
        {
            var produto = _context.Produtos.Find(id);

            if (produto == null || quantidade <= 0)
                return false;

            if (produto.Estoque < quantidade)
                return false;

            produto.Estoque -= quantidade;

            _context.SaveChanges();

            return true;
        }

        public bool ExcluirProduto(int id)
        {
            var produto = _context.Produtos.Find(id);

            if (produto == null)
                return false;

            _context.Produtos.Remove(produto);
            _context.SaveChanges();

            return true;
        }
    }
}
