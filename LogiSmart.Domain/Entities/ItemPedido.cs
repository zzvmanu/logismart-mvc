using System;
using System.Collections.Generic;
using System.Text;

namespace LogiSmart.Domain.Entities
{
    public class ItemPedido
    {
        public int Id { get; set; }

        public int Quantidade { get; set; }

        public decimal PrecoUnitario { get; set; }

        public int PedidoId { get; set; }

        public Pedido? Pedido { get; set; }

        public int ProdutoId { get; set; }

        public Produto? Produto { get; set; }
    }
}
