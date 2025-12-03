using Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public class Zero2StocksContext : DbContext
{
    public Zero2StocksContext(DbContextOptions<Zero2StocksContext> options) : base(options)
    {
        
    }

    public DbSet<Asset> Assets { get; set; } = null!;

    public DbSet<AssetComment> AssetComments { get; set; } = null!;

    public DbSet<Member> Members { get; set; } = null!;

    public DbSet<Portfolio> Portfolios { get; set; } = null!;

    public DbSet<PortfolioItem> PortfolioItems { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(Zero2StocksContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
