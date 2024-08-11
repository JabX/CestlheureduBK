using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace CestlheureduBK.Model;

public class BKDbContext(DbContextOptions<BKDbContext> options) : DbContext(options)
{
    public DbSet<MenuDb> Menus { get; set; }

    public DbSet<OfferDb> Offers { get; set; }

    public DbSet<ProductDb> Products { get; set; }

    public DbSet<PromotionDb> Promotions { get; set; }

    public DbSet<RestaurantDb> Restaurants { get; set; }
}

[Table("Menus")]
public record MenuDb
{
    public required string Id { get; set; }

    public required string Name { get; set; }

    public string? Image { get; set; }

    [Column(TypeName = "decimal(4, 2)")]
    public required decimal Price { get; set; }

    [Column(TypeName = "decimal(4, 2)")]
    public decimal? PriceL { get; set; }

    [Column(TypeName = "decimal(4, 2)")]
    public decimal? PriceXL { get; set; }

    public IList<PromotionDb>? Promotions { get; set; } = [];

    public required RestaurantDb Restaurant { get; set; }

    public bool Available { get; set; } = true;
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


    [Column(TypeName = "decimal(4, 2)")]
    public required decimal Price { get; set; }

    public IList<PromotionDb>? Promotions { get; set; } = [];

    public required RestaurantDb Restaurant { get; set; }

    public bool Available { get; set; } = true;
}

[Table("Promotions")]
public record PromotionDb
{
    public required string Id { get; set; }

    public required string Name { get; set; }

    public IList<MenuDb> Menus { get; set; } = [];

    public IList<ProductDb> Products { get; set; } = [];

    public required RestaurantDb Restaurant { get; set; }

    public bool Available { get; set; } = true;
}

[Table("Restaurants")]
public class RestaurantDb
{
    public required string Id { get; set; }

    public required string Name { get; set; }

    public required string AddressFull { get; set; }

    public required string Departement { get; set; }

    public bool Opened { get; set; } = true;
}