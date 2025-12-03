using AutoMapper;
using Business.GenericRepository.ConcManager;
using Business.GenericRepository.ConcRep;
using Business.GenericRepository.IntRep;
using Business.GenericRepository.IntServices;
using Business.Mapper;
using DataAccess;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<Zero2StocksContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IAuthenticationService, AuthenticationManager>();

var mapperConfig = new MapperConfiguration(cfg =>
{
    cfg.AddProfile<AssetMapping>();
    cfg.AddProfile<AssetCommentMapping>();
    cfg.AddProfile<MemberMapping>();
    cfg.AddProfile<PortfolioMapping>();
    cfg.AddProfile<PortfolioItemMapping>();
});
builder.Services.AddSingleton(mapperConfig.CreateMapper());

builder.Services.AddScoped<IMemberRepository, MemberRepository>();
builder.Services.AddScoped<IPortfolioRepository, PortfolioRepository>();
builder.Services.AddScoped<IPortfolioItemRepository, PortfolioItemRepository>();
builder.Services.AddScoped<IAssetRepository, AssetRepository>();

builder.Services.AddScoped<IMemberService, MemberManager>();
builder.Services.AddScoped<IPortfolioService, PortfolioManager>();
builder.Services.AddScoped<IPortfolioItemService, PortfolioItemManager>();
builder.Services.AddScoped<IAssetService, AssetManager>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
