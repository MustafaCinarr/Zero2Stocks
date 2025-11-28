using Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfigurations;

public class MemberConfiguration : IEntityTypeConfiguration<Member>
{
    public void Configure(EntityTypeBuilder<Member> builder)
    {
        builder.HasMany(m => m.Portfolios)
            .WithOne(p => p.Member)
            .HasForeignKey(p => p.MemberId);

        builder.HasMany(m => m.Comments)
            .WithOne(c => c.Member)
            .HasForeignKey(c => c.MemberId);
    }
}
