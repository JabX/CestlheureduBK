using System.ComponentModel.DataAnnotations.Schema;
using CestlheureduBK.Common;
using Microsoft.EntityFrameworkCore;

namespace CestlheureduBK.Model;

public class BKDbContext(DbContextOptions<BKDbContext> options) : DbContext(options)
{
    public DbSet<CategorieDb> Categories { get; set; }

    public DbSet<MenuDb> Menus { get; set; }

    public DbSet<MenuRestaurantDb> MenusRestaurants { get; set; }

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