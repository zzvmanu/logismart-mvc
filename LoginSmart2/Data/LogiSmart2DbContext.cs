using LogiSmart.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace LogiSmart2.Data
{
    public class LogiSmart2DbContext : DbContext
    {
        public LogiSmart2DbContext(DbContextOptions<LogiSmart2DbContext> options)
            : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<ItemPedido> ItensPedido { get; set; }
        public DbSet<Entrega> Entregas { get; set; }
        public DbSet<Entregador> Entregadores { get; set; }
        public DbSet<LogiSmart2.Models.Usuario> Usuarios { get; set; }
    }
}