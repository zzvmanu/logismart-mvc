
using LogiSmart.Domain.Entities;
using LogiSmart2.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LogiSmart2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly ProdutoService _produtoService;

        public ProdutosController(ProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        // Consulta pública dos produtos
        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetProdutos()
        {
            var produtos = _produtoService.BuscarProdutos();
            return Ok(produtos);
        }

        // Compra de produto
        [AllowAnonymous]
        [HttpPost("{id}/comprar")]
        public IActionResult ComprarProduto(int id, [FromQuery] int quantidade = 1)
        {
            if (quantidade <= 0)
                return BadRequest("A quantidade deve ser maior que zero.");

            var comprado = _produtoService.ComprarProduto(id, quantidade);

            if (!comprado)
                return BadRequest("Produto inexistente ou estoque insuficiente.");

            return Ok(new
            {
                mensagem = "Compra realizada com sucesso!",
                produtoId = id,
                quantidadeComprada = quantidade
            });
        }

        // Cadastro protegido
        [Authorize]
        [HttpPost]
        public IActionResult CriarProduto(Produto produto)
        {
            _produtoService.CriarProduto(produto);

            return CreatedAtAction(
                nameof(GetProdutos),
                new { id = produto.Id },
                produto
            );
        }

        // Atualização protegida
        [Authorize]
        [HttpPut("{id}")]
        public IActionResult AtualizarProduto(int id, Produto produto)
        {
            var produtoAtualizado = _produtoService.AtualizarProduto(id, produto);

            if (produtoAtualizado == null)
                return NotFound("Produto não encontrado.");

            return Ok(produtoAtualizado);
        }

        // Exclusão protegida
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult ExcluirProduto(int id)
        {
            var excluido = _produtoService.ExcluirProduto(id);

            if (!excluido)
                return NotFound("Produto não encontrado.");

            return NoContent();
        }
    }
}

