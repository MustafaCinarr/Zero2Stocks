using Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfigurations;

public class PortfolioConfiguration : IEntityTypeConfiguration<Portfolio>
{
    public void Configure(EntityTypeBuilder<Portfolio> builder)
    {
        builder.HasOne(p => p.Member)
            .WithMany(m => m.Portfolios)
            .HasForeignKey(p => p.MemberId);

        builder.HasMany(p => p.Items)
            .WithOne(pi => pi.Portfolio)
            .HasForeignKey(pi => pi.PortfolioId);
    }
}
