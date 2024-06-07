using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace WebAPI92.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Rol> Rol { get; set; }

        public DbSet<Autor> Autor {get; set; }
        public DbSet<Libro> Libro { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().HasData(new Usuario
            {
                PkUsuario = 1,
                Nombre = "Angel",
                User = "angelmarfil",
                Password = "password",
                FkRol = 1,
            });

            modelBuilder.Entity<Rol>().HasData(new Rol
            {
                PkRol = 1,
                Nombre = "sa"
            });
        }

    }
}
