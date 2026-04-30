using System.Collections.Generic;

namespace LogiSmartMVC.Models
{
    public static class DadosFake
    {
        public static List<Produto> Produtos = new List<Produto>
        {
            new Produto { Id = 1, Nome = "Caixa Pequena", Preco = 10.0, Quantidade = 5 },
            new Produto { Id = 2, Nome = "Caixa Média", Preco = 20.0, Quantidade = 10 },
            new Produto { Id = 3, Nome = "Envelope", Preco = 5.0, Quantidade = 15}
        };
    }
}