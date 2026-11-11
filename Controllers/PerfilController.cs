using Microsoft.AspNetCore.Mvc;

public class PerfilController : Controller
{
   
    public IActionResult Index()
    {
        return View();
    }

 
    [HttpPost]
    public IActionResult Salvar(
        string nome,
        string sobrenome,
        string email,
        string telefone,
        string endereco,
        string cidade,
        string estado)
    {
      
        if (string.IsNullOrEmpty(nome) ||
            string.IsNullOrEmpty(email))
        {
            ViewBag.Msg = "Preencha os campos obrigatórios!";
            return View("Index");
        }

        ViewBag.Msg = "Dados salvos com sucesso!";
        return View("Index");
    }

    public IActionResult AlterarSenha()
    {
        return View();
    }

    [HttpPost]
    public IActionResult AlterarSenha(
        string senhaAtual,
        string novaSenha,
        string confirmarSenha)
    {
       
        if (string.IsNullOrEmpty(senhaAtual) ||
            string.IsNullOrEmpty(novaSenha) ||
            string.IsNullOrEmpty(confirmarSenha))
        {
            ViewBag.Msg = "Preencha todos os campos!";
            return View();
        }

        
        if (novaSenha != confirmarSenha)
        {
            ViewBag.Msg = "As senhas não coincidem!";
            return View();
        }


        ViewBag.Msg = "Senha alterada com sucesso!";
        return View();
    }
}