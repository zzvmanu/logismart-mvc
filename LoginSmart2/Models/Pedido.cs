using LogiSmart2.Models;

namespace LogiSmart2.Models
{
    public class Pedido
    {
        public int Id { get; set; }

        public DateTime DataPedido { get; set; } = DateTime.Now;

        public string Status { get; set; } = "Pendente";

        public int ClienteId { get; set; }

        public Cliente? Cliente { get; set; }

        public ICollection<ItemPedido> Itens { get; set; } = new List<ItemPedido>();

        public Entrega? Entrega { get; set; }
    }
}