using LogiSmart2.Models;
using LogiSmart2.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LogiSmart2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly UsuarioService _usuarioService;
        private readonly string _chave = "chave-secreta-logismart-2026-123456789";
        public UsuariosController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost]
        public IActionResult CriarUsuario(Usuario usuario)
        {
            try
            {
                var novoUsuario = _usuarioService.CriarUsuario(usuario);

                return Ok(novoUsuario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{email}")]
        public IActionResult BuscarPorEmail(string email)
        {
            var usuario = _usuarioService.BuscarPorEmail(email);

            if (usuario == null)
            {
                return NotFound("Usuário não encontrado.");
            }
            return Ok(usuario);
        }
        [HttpPost("login")]
        public IActionResult Login(string email, string senha)
        {
            var usuario = _usuarioService.Login(email, senha);

            if (usuario == null)
            {
                return Unauthorized("E-mail ou senha inválidos.");
            }

            var claims = new[]
            {
        new Claim(ClaimTypes.Name, usuario.Nome),
        new Claim(ClaimTypes.Email, usuario.Email),
        new Claim(ClaimTypes.Role, usuario.Perfil)
    };

            var chave = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_chave));

            var credenciais = new SigningCredentials(
                chave,
                SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
        issuer: "LogiSmart2",
        audience: "LogiSmart2",
        claims: claims,
        expires: DateTime.UtcNow.AddHours(2),
        signingCredentials: credenciais);

            var tokenString = new JwtSecurityTokenHandler()
                .WriteToken(token);

            return Ok(new
            {
                token = tokenString
            });
        }
    }
}