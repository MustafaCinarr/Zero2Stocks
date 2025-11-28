using Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfigurations;

public class AssetConfiguration : IEntityTypeConfiguration<Asset>
{
    public void Configure(EntityTypeBuilder<Asset> builder)
    {
        builder.HasMany(a => a.PortfolioItems)
            .WithOne(pi => pi.Asset)
            .HasForeignKey(pi => pi.AssetId);

        builder.HasMany(a => a.Comments)
            .WithOne(c => c.Asset)
            .HasForeignKey(c => c.AssetId);
    }
}
