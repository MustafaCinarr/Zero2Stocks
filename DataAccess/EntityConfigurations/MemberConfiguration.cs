using Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfigurations;

public class MemberConfiguration : IEntityTypeConfiguration<Member>
{
    public void Configure(EntityTypeBuilder<Member> builder)
    {
        builder.Property(m => m.UserName)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(m => m.Email)
            .IsRequired()
            .HasMaxLength(100);

        builder.HasIndex(m => m.Email)
            .IsUnique();

        builder.Property(m => m.PasswordHash)
            .IsRequired()
            .HasMaxLength(256);

        builder.HasMany(m => m.Portfolios)
            .WithOne(p => p.Member)
            .HasForeignKey(p => p.MemberId);

        builder.HasMany(m => m.Comments)
            .WithOne(c => c.Member)
            .HasForeignKey(c => c.MemberId);
    }
}
