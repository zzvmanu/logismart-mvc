using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace LogiSmartMVC.Controllers
{
    public class MotoristaController : Controller
    {
        public IActionResult Index()
        {
            var entregas = new List<Entrega>
    {
        new Entrega
        {
            Id = 1,
            Cliente = "João",
            Endereco = "Rua das Flores, 123 - SP",
            Status = "Em andamento"
        },
        new Entrega
        {
            Id = 2,
            Cliente = "Maria",
            Endereco = "Av. Brasil, 500 - SP",
            Status = "Concluído"
        }
    };


            return View(entregas);
        }
    }
}
public class Entrega
{
    public int Id { get; set; }
    public string Cliente { get; set; } = "";
    public string Endereco { get; set; } = "";
    public string Status { get; set; } = "";
}