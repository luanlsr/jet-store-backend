using jet_store.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace jet_store.Infra.Data.Context;
public class ProductContext : DbContext
{
    public ProductContext(DbContextOptions<ProductContext> options) : base(options){}

    public DbSet<Product> Product { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductContext).Assembly);
    }
}
