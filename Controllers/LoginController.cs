using Microsoft.AspNetCore.Mvc;

public class LoginController : Controller
{
    static List<UsuarioFake> usuarios = new List<UsuarioFake>()
    {
        new UsuarioFake { Email = "admin@email.com", Senha = "123", Tipo = "Admin" },
        new UsuarioFake { Email = "cliente@email.com", Senha = "123", Tipo = "Cliente" },
        new UsuarioFake { Email = "cliente2@email.com", Senha = "123", Tipo = "Cliente" },
        new UsuarioFake { Email = "motorista@email.com", Senha = "123", Tipo = "Motorista" }
    };

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(string email, string senha)
    {
        if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(senha))
        {
            ViewBag.Erro = "Preencha todos os campos.";
            return View("Index");
        }

        var user = usuarios.FirstOrDefault(u => u.Email == email && u.Senha == senha);

        if (user == null)
        {
            ViewBag.Erro = "Login inválido";
            return View("Index");
        }

        HttpContext.Session.SetString("Usuario", user.Email);
        HttpContext.Session.SetString("Tipo", user.Tipo);

        if (user.Tipo == "Admin")
            return RedirectToAction("Index", "Admin");

        if (user.Tipo == "Cliente")
            return RedirectToAction("Index", "Cliente");

        if (user.Tipo == "Motorista")
            return RedirectToAction("Index", "Motorista");

        return View("Index");
    }

    [HttpPost]
    public IActionResult Cadastro(string nome, string email, string senha, string confirmarSenha, string tipo)
    {
        if (senha != confirmarSenha)
        {
            ViewBag.Erro = "As senhas não coincidem.";
            return View("Index");
        }

        usuarios.Add(new UsuarioFake
        {
            Email = email,
            Senha = senha,
            Tipo = tipo
        });

        return RedirectToAction("Index");
    }

    //AQUI FICA O LOGOUT
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index", "Home");
    }
}

public class UsuarioFake
{
    public string Email { get; set; } = "";
    public string Senha { get; set; } = "";
    public string Tipo { get; set; } = "";
}