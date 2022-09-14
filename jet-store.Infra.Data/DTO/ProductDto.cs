using jet_store.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace jet_store.Infra.Data.CTO;

public class ProductCto : IEntityTypeConfiguration<Products>
{
    public void Configure(EntityTypeBuilder<Products> builder)
    {
        builder.ToTable("products");
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id)
            .HasColumnName("product_id")
            .UseIdentityColumn();
        builder.Property(c => c.Name)
            .HasColumnName("product_name");
        builder.Property(c => c.Description)
            .HasColumnName("description");
        builder.Property(c => c.Image)
            .HasColumnName("image");
        builder.Property(c => c.Status)
            .HasColumnName("status");
        builder.Property(c => c.Price)
            .HasColumnName("price");
        builder.Property(c => c.Stock)
            .HasColumnName("stock");
    }
}