using Microsoft.AspNetCore.Mvc;
using LogiSmartMVC.Models;
using System.Linq;

namespace LogiSmartMVC.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Produtos()
        {
            return View(DadosFake.Produtos);
        }

        [HttpPost]
        public IActionResult AdicionarProduto(string nome, double preco, int quantidade)
        {
            var novo = new Produto
            {
                Id = DadosFake.Produtos.Count + 1,
                Nome = nome,
                Preco = preco,
                Quantidade = quantidade
            };  
               

            DadosFake.Produtos.Add(novo);

            return RedirectToAction("Produtos");
        }

        public IActionResult ExcluirProduto(int id)
        {
            var produto = DadosFake.Produtos.FirstOrDefault(p => p.Id == id);

            if (produto != null)
                DadosFake.Produtos.Remove(produto);

            return RedirectToAction("Produtos");

         
        }
        public IActionResult EditarProduto(int id)
        {
            var produto = DadosFake.Produtos.FirstOrDefault(p => p.Id == id);

            if (produto == null)
                return RedirectToAction("Produtos");

            return View(produto);
        }
        [HttpPost]
        public IActionResult SalvarEdicao(Produto produto)
        {
            var p = DadosFake.Produtos.FirstOrDefault(x => x.Id == produto.Id);

            if (p != null)
            {
                p.Nome = produto.Nome;
                p.Preco = produto.Preco;
            }

            return RedirectToAction("Produtos");
        }
    }
}