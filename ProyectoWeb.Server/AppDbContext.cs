
using Microsoft.EntityFrameworkCore;
using ProyectoWeb.Shared.Entidades;

namespace ProyectoWeb.Server

{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Autor> Autores { get; set; }
        public DbSet<Libro> Libros { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<OrdenCompraCabecera> Cabeceras { get; set; }
        public DbSet<OrdenCompraDetalle> Detalles { get; set; }
    }
}
