using Microsoft.AspNetCore.Mvc;

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
    }
}
