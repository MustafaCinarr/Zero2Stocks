using Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfigurations;

public class PortfolioItemConfiguration : IEntityTypeConfiguration<PortfolioItem>
{
    public void Configure(EntityTypeBuilder<PortfolioItem> builder)
    {
        builder.HasOne(pi => pi.Portfolio)
            .WithMany(p => p.Items)
            .HasForeignKey(pi => pi.PortfolioId);

        builder.HasOne(pi => pi.Asset)
            .WithMany(a => a.PortfolioItems)
            .HasForeignKey(pi => pi.AssetId);
    }
}
