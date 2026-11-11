
using LogiSmartMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Json;

namespace LogiSmartMVC.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ClienteController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            var email = HttpContext.Session.GetString("Usuario");

            ViewBag.Pedidos = new List<string>();

            if (email == "cliente@email.com")
            {
                ViewBag.Pedidos = new List<string>
                {
                    "Pedido #1 - Em andamento"
                };
            }
            else if (email == "cliente2@email.com")
            {
                ViewBag.Pedidos = new List<string>
                {
                    "Pedido #2 - Concluído"
                };
            }

            return View();
        }

        public async Task<IActionResult> Produtos()
        {
            var client = _httpClientFactory.CreateClient("LogiSmartAPI");

            try
            {
                var produtosApi = await client.GetFromJsonAsync<List<ProdutoApi>>(
                    "api/Produtos");

                var produtos = produtosApi?.Select(p => new Produto
                {
                    Id = p.Id,
                    Nome = p.Nome,
                    Categoria = p.Categoria,
                    Descricao = p.Descricao,
                    Preco = (double)p.Preco,
                    Quantidade = p.Estoque,
                    ImagemUrl = p.ImagemUrl
                }).ToList() ?? new List<Produto>();

                return View(produtos);
            }
            catch (HttpRequestException)
            {
                ViewBag.Erro = "Não foi possível carregar os produtos. Verifique se a API está funcionando.";
                return View(new List<Produto>());
            }
        }

        private class ProdutoApi
        {
            public int Id { get; set; }
            public string Nome { get; set; } = "";
            public string Categoria { get; set; } = "";
            public string Descricao { get; set; } = "";
            public decimal Preco { get; set; }
            public int Estoque { get; set; }
            public string ImagemUrl { get; set; } = "";
        }

        [HttpPost]
        public async Task<IActionResult> Comprar(int id)
        {
            var client = _httpClientFactory.CreateClient("LogiSmartAPI");

            try
            {
                var resposta = await client.PostAsync(
                    $"api/Produtos/{id}/comprar?quantidade=1",
                    null
                );

                if (resposta.IsSuccessStatusCode)
                {
                    TempData["Sucesso"] = "Compra realizada com sucesso! O estoque foi atualizado.";
                }
                else
                {
                    var mensagem = await resposta.Content.ReadAsStringAsync();

                    TempData["Aviso"] = string.IsNullOrWhiteSpace(mensagem)
                        ? "Não foi possível realizar a compra."
                        : mensagem;
                }
            }
            catch (HttpRequestException)
            {
                TempData["Aviso"] = "Não foi possível conectar à API. Verifique se ela está funcionando.";
            }

            return RedirectToAction("Produtos");
        }
    }
}
