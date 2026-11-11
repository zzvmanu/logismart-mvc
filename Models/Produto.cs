
namespace LogiSmartMVC.Models
{
    public class Produto
    {
        public int Id { get; set; }

        public string Nome { get; set; } = "";

        public string Categoria { get; set; } = "";

        public string Descricao { get; set; } = "";

        public double Preco { get; set; }

        public int Quantidade { get; set; }

        public string ImagemUrl { get; set; } = "";
    }
}
