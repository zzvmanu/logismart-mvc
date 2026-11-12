using System;
using System.Collections.Generic;
using System.Text;

namespace LogiSmart.Domain.Entities
{
    public class Entregador
    {
        public int Id { get; set; }

        public string Nome { get; set; } = string.Empty;

        public string Telefone { get; set; } = string.Empty;

        public string Veiculo { get; set; } = string.Empty;

        public bool Ativo { get; set; } = true;

        public ICollection<Entrega> Entregas { get; set; } = new List<Entrega>();
    }
}
