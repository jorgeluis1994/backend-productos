using backend_products.src.models;
using Microsoft.EntityFrameworkCore;
public class AplicationDbContext : DbContext
{

    public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options)
    {

    }

    //Tabla productos
    public DbSet<Producto> Productos { set; get; }
    //Tabla Transacciones
    public DbSet<Transaccion> Transacciones { get; set; }

}