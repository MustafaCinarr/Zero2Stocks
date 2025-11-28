using Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public class BusinessPartnerContext : DbContext
{
    public BusinessPartnerContext(DbContextOptions<BusinessPartnerContext> options) : base(options)
    {
    }

    public DbSet<Asset> Assets { get; set; } = null!;

    public DbSet<AssetComment> AssetComments { get; set; } = null!;

    public DbSet<Member> Members { get; set; } = null!;

    public DbSet<Portfolio> Portfolios { get; set; } = null!;

    public DbSet<PortfolioItem> PortfolioItems { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BusinessPartnerContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
