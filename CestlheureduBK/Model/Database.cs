using System.ComponentModel.DataAnnotations.Schema;
using CestlheureduBK.Common;
using Microsoft.EntityFrameworkCore;

namespace CestlheureduBK.Model;

public class BKDbContext(DbContextOptions<BKDbContext> options) : DbContext(options)
{
    public DbSet<CategorieDb> Categories { get; set; }

    public DbSet<MenuDb> Menus { get; set; }

    public DbSet<MenuRestaurantDb> MenusRestaurants { get; set; }

    public DbSet<MysteryCampaignDb> MysteryCampaigns { get; set; }

    public DbSet<MysteryProductDb> MysteryProducts { get; set; }

    public DbSet<MysteryRollDb> MysteryRolls { get; set; }

    public DbSet<OfferDb> Offers { get; set; }

    public DbSet<ProductDb> Products { get; set; }

    public DbSet<ProductRestaurantDb> ProductsRestaurants { get; set; }

    public DbSet<PromotionDb> Promotions { get; set; }

    public DbSet<PromotionRestaurantDb> PromotionsRestaurants { get; set; }

    public DbSet<RestaurantDb> Restaurants { get; set; }

    public DbSet<SnackDb> Snacks { get; set; }

    public DbSet<SnackAmountDb> SnackAmounts { get; set; }

    public DbSet<StepDb> Steps { get; set; }

    public DbSet<UpdateDb> Updates { get; set; }

    public DbSet<UserDb> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MenuRestaurantDb>().HasKey(m => new { m.MenuId, m.RestaurantId });
        modelBuilder.Entity<ProductRestaurantDb>().HasKey(m => new { m.ProductId, m.RestaurantId });
        modelBuilder.Entity<PromotionRestaurantDb>().HasKey(m => new { m.PromotionId, m.RestaurantId });

        modelBuilder.Entity<StepDb>().HasMany(p => p.Products).WithMany().UsingEntity("StepProducts");
        modelBuilder.Entity<StepDb>().HasMany(p => p.ProductsL).WithMany().UsingEntity("StepProductsL");
        modelBuilder.Entity<StepDb>().HasMany(p => p.ProductsXL).WithMany().UsingEntity("StepProductsXL");

        modelBuilder.Entity<UserDb>().Navigation(p => p.FavoriteRestaurant).AutoInclude();

        modelBuilder
            .Entity<MysteryCampaignDb>()
            .HasData(
                [
                    new()
                    {
                        Id = 1,
                        Month = "2024-09",
                        Kind = MysteryCampaignKind.Classic,
                        Price = 2.9,
                    },
                    new()
                    {
                        Id = 2,
                        Month = "2024-09",
                        Kind = MysteryCampaignKind.Veggie,
                        Price = 2.9,
                    },
                    new()
                    {
                        Id = 3,
                        Month = "2025-03",
                        Kind = MysteryCampaignKind.Classic,
                        Price = 2.9,
                    },
                    new()
                    {
                        Id = 4,
                        Month = "2025-03",
                        Kind = MysteryCampaignKind.Veggie,
                        Price = 2.9,
                    },
                ]
            );

        modelBuilder
            .Entity<ProductDb>()
            .HasData(
                [
                    new() { Id = "2", Name = "Big King" },
                    new() { Id = "15", Name = "Double Cheese Bacon XXL" },
                    new() { Id = "17", Name = "Double Whopper Cheese" },
                    new() { Id = "46", Name = "Steakhouse" },
                    new() { Id = "49", Name = "Whopper" },
                    new() { Id = "213", Name = "Big Fish" },
                    new() { Id = "463", Name = "Wrap Chicken Louisiane" },
                    new() { Id = "544", Name = "Wrap Crousty Chèvre" },
                    new() { Id = "664", Name = "Veggie Whopper" },
                    new() { Id = "666", Name = "Veggie Steakhouse" },
                    new() { Id = "702", Name = "Crispy Chicken Cheese" },
                    new() { Id = "801", Name = "Veggie Chicken Louisiane Steakhouse" },
                    new() { Id = "802", Name = "Chicken Louisiane Steakhouse" },
                    new() { Id = "953", Name = "Chicken Spicy" },
                    new() { Id = "1054", Name = "Master Cantal Bacon" },
                    new() { Id = "1055", Name = "Master Poulet Cantal" },
                    new() { Id = "1101", Name = "Double Cheese Bacon" },
                    new() { Id = "1110", Name = "Double King" },
                ]
            );
        modelBuilder
            .Entity<MysteryProductDb>()
            .HasData(
                [
                    new
                    {
                        Id = 1,
                        CampaignId = 1,
                        ProductId = "702",
                        Chance = 0.14,
                    },
                    new
                    {
                        Id = 2,
                        CampaignId = 1,
                        ProductId = "2",
                        Chance = 0.12,
                    },
                    new
                    {
                        Id = 3,
                        CampaignId = 1,
                        ProductId = "49",
                        Chance = 0.12,
                    },
                    new
                    {
                        Id = 4,
                        CampaignId = 1,
                        ProductId = "1101",
                        Chance = 0.11,
                    },
                    new
                    {
                        Id = 5,
                        CampaignId = 1,
                        ProductId = "463",
                        Chance = 0.10,
                    },
                    new
                    {
                        Id = 6,
                        CampaignId = 1,
                        ProductId = "46",
                        Chance = 0.10,
                    },
                    new
                    {
                        Id = 7,
                        CampaignId = 1,
                        ProductId = "953",
                        Chance = 0.07,
                    },
                    new
                    {
                        Id = 8,
                        CampaignId = 1,
                        ProductId = "802",
                        Chance = 0.07,
                    },
                    new
                    {
                        Id = 9,
                        CampaignId = 1,
                        ProductId = "1055",
                        Chance = 0.05,
                    },
                    new
                    {
                        Id = 10,
                        CampaignId = 1,
                        ProductId = "1054",
                        Chance = 0.05,
                    },
                    new
                    {
                        Id = 11,
                        CampaignId = 1,
                        ProductId = "17",
                        Chance = 0.04,
                    },
                    new
                    {
                        Id = 12,
                        CampaignId = 1,
                        ProductId = "15",
                        Chance = 0.03,
                    },
                    new
                    {
                        Id = 13,
                        CampaignId = 2,
                        ProductId = "664",
                        Chance = 0.26,
                    },
                    new
                    {
                        Id = 14,
                        CampaignId = 2,
                        ProductId = "544",
                        Chance = 0.26,
                    },
                    new
                    {
                        Id = 15,
                        CampaignId = 2,
                        ProductId = "666",
                        Chance = 0.24,
                    },
                    new
                    {
                        Id = 16,
                        CampaignId = 2,
                        ProductId = "801",
                        Chance = 0.24,
                    },
                    new
                    {
                        Id = 17,
                        CampaignId = 3,
                        ProductId = "2",
                        Chance = 0.16,
                    },
                    new
                    {
                        Id = 18,
                        CampaignId = 3,
                        ProductId = "1101",
                        Chance = 0.16,
                    },
                    new
                    {
                        Id = 19,
                        CampaignId = 3,
                        ProductId = "702",
                        Chance = 0.14,
                    },
                    new
                    {
                        Id = 20,
                        CampaignId = 3,
                        ProductId = "49",
                        Chance = 0.12,
                    },
                    new
                    {
                        Id = 21,
                        CampaignId = 3,
                        ProductId = "46",
                        Chance = 0.11,
                    },
                    new
                    {
                        Id = 22,
                        CampaignId = 3,
                        ProductId = "802",
                        Chance = 0.11,
                    },
                    new
                    {
                        Id = 23,
                        CampaignId = 3,
                        ProductId = "1110",
                        Chance = 0.05,
                    },
                    new
                    {
                        Id = 24,
                        CampaignId = 3,
                        ProductId = "1055",
                        Chance = 0.04,
                    },
                    new
                    {
                        Id = 25,
                        CampaignId = 3,
                        ProductId = "1054",
                        Chance = 0.03,
                    },
                    new
                    {
                        Id = 26,
                        CampaignId = 3,
                        ProductId = "213",
                        Chance = 0.03,
                    },
                    new
                    {
                        Id = 27,
                        CampaignId = 3,
                        ProductId = "17",
                        Chance = 0.03,
                    },
                    new
                    {
                        Id = 28,
                        CampaignId = 3,
                        ProductId = "15",
                        Chance = 0.02,
                    },
                    new
                    {
                        Id = 29,
                        CampaignId = 4,
                        ProductId = "664",
                        Chance = 0.36,
                    },
                    new
                    {
                        Id = 30,
                        CampaignId = 4,
                        ProductId = "666",
                        Chance = 0.32,
                    },
                    new
                    {
                        Id = 31,
                        CampaignId = 4,
                        ProductId = "801",
                        Chance = 0.32,
                    },
                ]
            );
    }
}

[Table("Categories")]
public record CategorieDb
{
    public required string Id { get; set; }

    public required string Name { get; set; }

    public string? Image { get; set; }

    public bool SubCategory { get; set; }

    public IList<ProductDb> Products { get; set; } = [];

    public IList<MenuDb> Menus { get; set; } = [];
}

[Table("Menus")]
public record MenuDb
{
    public required string Id { get; set; }

    public required string Name { get; set; }

    public string? Image { get; set; }

    public IList<StepDb> Steps { get; set; } = [];

    public IList<SnackAmountDb> Snacks { get; set; } = [];

    public IList<CategorieDb> Categories { get; set; } = [];

    public IList<PromotionDb>? Promotions { get; set; } = [];

    public bool AvailableInCatalogue { get; set; }
}

[Table("MenusRestaurants")]
public record MenuRestaurantDb
{
    public required string MenuId { get; set; }
    public required MenuDb Menu { get; set; }

    public required string RestaurantId { get; set; }
    public required RestaurantDb Restaurant { get; set; }

    public required bool Active { get; set; }

    [Column(TypeName = "decimal(4, 2)")]
    public required double Price { get; set; }

    [Column(TypeName = "decimal(4, 2)")]
    public double? PriceL { get; set; }

    [Column(TypeName = "decimal(4, 2)")]
    public double? PriceXL { get; set; }
}

public enum MysteryCampaignKind
{
    Classic,
    Veggie,
}

[Table("MysteryCampaigns")]
public record MysteryCampaignDb
{
    public int Id { get; set; }

    public required string Month { get; set; }

    public required MysteryCampaignKind Kind { get; set; }

    public required double Price { get; set; }
}

[Table("MysteryProducts")]
public record MysteryProductDb
{
    public int Id { get; set; }

    public required MysteryCampaignDb Campaign { get; set; }

    public required ProductDb Product { get; set; }

    [Column(TypeName = "decimal(4, 2)")]
    public required double Chance { get; set; }
}

[Table("MysteryRolls")]
public record MysteryRollDb
{
    public int Id { get; set; }

    public required MysteryProductDb Product { get; set; }

    public required UserDb User { get; set; }

    public required RestaurantDb Restaurant { get; set; }

    public required DateTime RollTime { get; set; }

    [Column(TypeName = "decimal(4, 2)")]
    public required double Price { get; set; }
}

[Table("Offers")]
public record OfferDb
{
    public required string Id { get; set; }

    public required string Title { get; set; }

    public required int Points { get; set; }

    public required PromotionDb Promotion { get; set; }
}

[Table("Products")]
public record ProductDb
{
    public required string Id { get; set; }

    public string RouteId { get; set; } = "";

    public required string Name { get; set; }

    public string? Image { get; set; }

    [Column(TypeName = "decimal(7, 2)")]
    public double? Energy { get; set; }

    public IList<SnackAmountDb> Snacks { get; set; } = [];

    public IList<CategorieDb> Categories { get; set; } = [];

    public IList<PromotionDb> Promotions { get; set; } = [];

    public bool AvailableInCatalogue { get; set; }
}

[Table("ProductsRestaurants")]
public record ProductRestaurantDb
{
    public required string ProductId { get; set; }
    public required ProductDb Product { get; set; }

    public required string RestaurantId { get; set; }
    public required RestaurantDb Restaurant { get; set; }

    public required bool Active { get; set; }

    [Column(TypeName = "decimal(4, 2)")]
    public required double Price { get; set; }
}

[Table("Promotions")]
public record PromotionDb
{
    public required string Id { get; set; }

    public required string Name { get; set; }

    public IList<MenuDb> Menus { get; set; } = [];

    public IList<ProductDb> Products { get; set; } = [];
}

[Table("PromotionsRestaurants")]
public record PromotionRestaurantDb
{
    public required string PromotionId { get; set; }
    public required PromotionDb Promotion { get; set; }

    public required string RestaurantId { get; set; }
    public required RestaurantDb Restaurant { get; set; }

    public bool Active { get; set; } = true;
}

[Table("Restaurants")]
public class RestaurantDb
{
    public required string Id { get; set; }

    public required string Name { get; set; }

    public required string AddressFull { get; set; }

    public required double Lat { get; set; }

    public required double Lng { get; set; }

    public required string Departement { get; set; }

    public bool Opened { get; set; } = true;

    public DateTime? CatalogueUpdate { get; set; }

    public RestaurantDisplay ToDisplay()
    {
        return new RestaurantDisplay(Id, Name, AddressFull, Departement, Lat, Lng, CatalogueUpdate);
    }
}

[Table("Snacks")]
public record SnackDb
{
    public int Id { get; set; }

    public bool Active { get; set; } = true;

    public required string Name { get; set; }
}

[Table("SnackAmounts")]
public record SnackAmountDb
{
    public int Id { get; set; }

    public required SnackDb Snack { get; set; }

    public required int Amount { get; set; }
}

[Table("Steps")]
public record StepDb
{
    public int Id { get; set; }

    public IList<ProductDb> Products { get; set; } = [];

    public IList<ProductDb> ProductsL { get; set; } = [];

    public IList<ProductDb> ProductsXL { get; set; } = [];

    public ProductDb? DefaultProduct { get; set; }

    public required int Type { get; set; }
}

[Table("Update")]
public record UpdateDb
{
    public int Id { get; set; }

    public DateTime? Restaurants { get; set; }

    public DateTime? Offers { get; set; }
}

[Table("Users")]
public record UserDb
{
    public Guid Id { get; set; }

    public required string Name { get; set; }

    public required string Email { get; set; }

    public RestaurantDb? FavoriteRestaurant { get; set; }
}
