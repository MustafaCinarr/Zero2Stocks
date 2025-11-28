using Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfigurations;

public class AssetCommentConfiguration : IEntityTypeConfiguration<AssetComment>
{
    public void Configure(EntityTypeBuilder<AssetComment> builder)
    {
        builder.HasOne(ac => ac.Asset)
            .WithMany(a => a.Comments)
            .HasForeignKey(ac => ac.AssetId);

        builder.HasOne(ac => ac.Member)
            .WithMany(m => m.Comments)
            .HasForeignKey(ac => ac.MemberId);
    }
}
