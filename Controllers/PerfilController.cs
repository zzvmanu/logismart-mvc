using Microsoft.AspNetCore.Mvc;

public class PerfilController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Salvar(string nome, string email)
    {
        if (string.IsNullOrEmpty(nome) || string.IsNullOrEmpty(email))
        {
            ViewBag.Msg = "Preencha os campos";
            return View("Index");
        }

        ViewBag.Msg = "Dados salvos com sucesso!";
        return View("Index");
    }
}