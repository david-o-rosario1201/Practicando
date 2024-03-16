using Library.Models;
using Microsoft.EntityFrameworkCore;

namespace Practicando.API.DAL;

public class Contexto : DbContext
{
    public Contexto(DbContextOptions<Contexto> options) : base(options)
    {
        
    }

    public DbSet<Usuarios> Usuarios { get; set; }
    public DbSet<TiposTelefonos> TiposTelefonos { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<TiposTelefonos>().HasData(new List<TiposTelefonos>()
        {
            new TiposTelefonos() {TipoId = 1, Descripcion = "Teléfono"},
            new TiposTelefonos() {TipoId = 2, Descripcion = "Celular"},
            new TiposTelefonos() {TipoId = 3, Descripcion = "Oficina"},
        });
    }
}
