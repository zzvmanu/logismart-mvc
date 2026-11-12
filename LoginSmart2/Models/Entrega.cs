namespace LogiSmart2.Models
{
    public class Entrega
    {
        public int Id { get; set; }

        public DateTime? DataEnvio { get; set; }

        public DateTime? DataEntrega { get; set; }

        public string Status { get; set; } = "Aguardando";

        public int PedidoId { get; set; }

        public Pedido? Pedido { get; set; }

        public int? EntregadorId { get; set; }

        public Entregador? Entregador { get; set; }
    }
}