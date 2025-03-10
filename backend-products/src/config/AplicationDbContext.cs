using backend_products.src.models;
using Microsoft.EntityFrameworkCore;
public class AplicationDbContext:DbContext
{

    public AplicationDbContext(DbContextOptions<AplicationDbContext> options) :base(options){

    }

    public DbSet<Producto> Productos{set;get;}
    
}