using jet_store.Domain;
using Microsoft.EntityFrameworkCore;

namespace jet_store.Infra.Data.Context;
public class ProductContext : DbContext
{
    public ProductContext(DbContextOptions<ProductContext> options) : base(options){}

    public DbSet<Products> Products { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductContext).Assembly);
    }
}
