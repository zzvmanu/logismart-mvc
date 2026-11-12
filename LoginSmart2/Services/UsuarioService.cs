using LogiSmart2.Data;
using LogiSmart2.Models;

namespace LogiSmart2.Services
{
    public class UsuarioService
    {
        private readonly LogiSmart2DbContext _context;

        public UsuarioService(LogiSmart2DbContext context)
        {
            _context = context;
        }

        public Usuario CriarUsuario(Usuario usuario)
        {
            var emailExiste = _context.Usuarios.Any(u => u.Email == usuario.Email);

            if (emailExiste)
            {
                throw new Exception("Já existe um usuário com este e-mail.");
            }

            _context.Usuarios.Add(usuario);
            _context.SaveChanges();

            return usuario;
        }

        public Usuario? BuscarPorEmail(string email)
        {
            return _context.Usuarios.FirstOrDefault(u => u.Email == email);
        }

        public Usuario? Login(string email, string senha)
        {
            return _context.Usuarios
                .FirstOrDefault(u => u.Email == email && u.Senha == senha);
        }
    }
}