
using System.Collections.Generic;

namespace LogiSmartMVC.Models
{
    public static class DadosFake
    {
        public static List<Produto> Produtos = new List<Produto>
        {
            // ELETRÔNICOS
            new Produto
            {
                Id = 1,
                Nome = "Fone Bluetooth",
                Categoria = "Eletrônicos",
                Descricao = "Fone sem fio com conexão Bluetooth.",
                Preco = 89.90,
                Quantidade = 20
            },
            new Produto
            {
                Id = 2,
                Nome = "Mouse Gamer",
                Categoria = "Eletrônicos",
                Descricao = "Mouse óptico para jogos e uso diário.",
                Preco = 59.90,
                Quantidade = 15
            },
            new Produto
            {
                Id = 3,
                Nome = "Teclado USB",
                Categoria = "Eletrônicos",
                Descricao = "Teclado USB de tamanho padrão.",
                Preco = 79.90,
                Quantidade = 12
            },

            // MODA
            new Produto
            {
                Id = 4,
                Nome = "Camiseta Básica",
                Categoria = "Moda",
                Descricao = "Camiseta casual de algodão.",
                Preco = 49.90,
                Quantidade = 30
            },
            new Produto
            {
                Id = 5,
                Nome = "Boné Casual",
                Categoria = "Moda",
                Descricao = "Boné ajustável para uso diário.",
                Preco = 39.90,
                Quantidade = 18
            },
            new Produto
            {
                Id = 6,
                Nome = "Mochila",
                Categoria = "Moda",
                Descricao = "Mochila para trabalho, estudo e viagens.",
                Preco = 119.90,
                Quantidade = 10
            },

            // CASA E DECORAÇÃO
            new Produto
            {
                Id = 7,
                Nome = "Luminária LED",
                Categoria = "Casa e Decoração",
                Descricao = "Luminária para ambientes internos.",
                Preco = 45.90,
                Quantidade = 14
            },
            new Produto
            {
                Id = 8,
                Nome = "Garrafa Térmica",
                Categoria = "Casa e Decoração",
                Descricao = "Garrafa para conservar bebidas.",
                Preco = 69.90,
                Quantidade = 22
            },
            new Produto
            {
                Id = 9,
                Nome = "Organizador Multiuso",
                Categoria = "Casa e Decoração",
                Descricao = "Organizador para objetos domésticos.",
                Preco = 34.90,
                Quantidade = 16
            },

            // BELEZA
            new Produto
            {
                Id = 10,
                Nome = "Kit de Skincare",
                Categoria = "Beleza",
                Descricao = "Kit de cuidados básicos para a pele.",
                Preco = 99.90,
                Quantidade = 11
            },
            new Produto
            {
                Id = 11,
                Nome = "Necessaire",
                Categoria = "Beleza",
                Descricao = "Bolsa organizadora de produtos pessoais.",
                Preco = 29.90,
                Quantidade = 25
            },

            // ESPORTES
            new Produto
            {
                Id = 12,
                Nome = "Garrafa Esportiva",
                Categoria = "Esportes",
                Descricao = "Garrafa para atividades físicas.",
                Preco = 24.90,
                Quantidade = 20
            },
            new Produto
            {
                Id = 13,
                Nome = "Colchonete de Exercícios",
                Categoria = "Esportes",
                Descricao = "Colchonete para exercícios e alongamentos.",
                Preco = 79.90,
                Quantidade = 8
            },

            // LIVROS E PAPELARIA
            new Produto
            {
                Id = 14,
                Nome = "Caderno Universitário",
                Categoria = "Livros e Papelaria",
                Descricao = "Caderno universitário de 10 matérias.",
                Preco = 32.90,
                Quantidade = 35
            },
            new Produto
            {
                Id = 15,
                Nome = "Kit de Canetas",
                Categoria = "Livros e Papelaria",
                Descricao = "Conjunto de canetas para escrita.",
                Preco = 19.90,
                Quantidade = 40
            },

            // EMBALAGENS
            new Produto
            {
                Id = 16,
                Nome = "Caixa Pequena",
                Categoria = "Embalagens",
                Descricao = "Caixa de papelão para envios.",
                Preco = 10.00,
                Quantidade = 5
            },
            new Produto
            {
                Id = 17,
                Nome = "Caixa Média",
                Categoria = "Embalagens",
                Descricao = "Caixa de papelão de tamanho médio.",
                Preco = 20.00,
                Quantidade = 10
            },
            new Produto
            {
                Id = 18,
                Nome = "Envelope",
                Categoria = "Embalagens",
                Descricao = "Envelope para pequenos envios.",
                Preco = 5.00,
                Quantidade = 15
            }
        };
    }
}
