using Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfigurations;

public class AssetConfiguration : IEntityTypeConfiguration<Asset>
{
    public void Configure(EntityTypeBuilder<Asset> builder)
    {
        builder.Property(a => a.Symbol)
            .IsRequired()
            .HasMaxLength(10);

        builder.HasIndex(a => a.Symbol)
            .IsUnique();

        builder.Property(a => a.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.HasMany(a => a.PortfolioItems)
            .WithOne(pi => pi.Asset)
            .HasForeignKey(pi => pi.AssetId);

        builder.HasMany(a => a.Comments)
            .WithOne(c => c.Asset)
            .HasForeignKey(c => c.AssetId);
    }
}
