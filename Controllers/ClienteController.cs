using LogiSmartMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace LogiSmartMVC.Controllers
{
    public class ClienteController : Controller
    {
        public IActionResult Index()
        {
            var email = HttpContext.Session.GetString("Usuario");

            if (email == "cliente@email.com")
            {
                ViewBag.Pedidos = new List<string> { "Pedido #1 - Em andamento" };
            }
            else if (email == "cliente2@email.com")
            {
                ViewBag.Pedidos = new List<string> { "Pedido #2 - Concluído" };
            }

            return View();
        }
        public IActionResult Produtos()
        {
            return View(DadosFake.Produtos);
        }

        [HttpPost]
        public IActionResult Comprar(int id)
        {
            var produto = DadosFake.Produtos.FirstOrDefault(p => p.Id == id);

            if (produto != null && produto.Quantidade > 0)
            {
                produto.Quantidade--;
            }

            return RedirectToAction("Produtos");
        }
    }
}
