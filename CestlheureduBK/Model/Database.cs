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

        modelBuilder.Entity<UpdateDb>().HasData(new UpdateDb { Id = 1 });

        modelBuilder
            .Entity<MysteryCampaignDb>()
            .HasData(
                [
                    new()
                    {
                        Id = 1,
                        Start = new DateOnly(2024, 9, 3),
                        End = new DateOnly(2024, 9, 30),
                        Kind = MysteryCampaignKind.Classic,
                        Price = 2.9,
                    },
                    new()
                    {
                        Id = 2,
                        Start = new DateOnly(2024, 9, 3),
                        End = new DateOnly(2024, 9, 30),
                        Kind = MysteryCampaignKind.Veggie,
                        Price = 2.9,
                    },
                    new()
                    {
                        Id = 3,
                        Start = new DateOnly(2025, 3, 4),
                        End = new DateOnly(2025, 3, 31),
                        Kind = MysteryCampaignKind.Classic,
                        Price = 2.9,
                    },
                    new()
                    {
                        Id = 4,
                        Start = new DateOnly(2025, 3, 4),
                        End = new DateOnly(2025, 3, 31),
                        Kind = MysteryCampaignKind.Veggie,
                        Price = 2.9,
                    },
                    new()
                    {
                        Id = 5,
                        Start = new DateOnly(2025, 11, 4),
                        End = new DateOnly(2025, 11, 6),
                        Kind = MysteryCampaignKind.Duo,
                        Price = 5,
                    },
                    new()
                    {
                        Id = 6,
                        Start = new DateOnly(2025, 11, 7),
                        End = new DateOnly(2025, 11, 24),
                        Kind = MysteryCampaignKind.Duo,
                        Price = 5,
                    },
                    new()
                    {
                        Id = 7,
                        Start = new DateOnly(2026, 1, 20),
                        End = new DateOnly(2026, 2, 9),
                        Kind = MysteryCampaignKind.Classic,
                        Price = 3,
                    },
                    new()
                    {
                        Id = 8,
                        Start = new DateOnly(2026, 1, 20),
                        End = new DateOnly(2026, 2, 9),
                        Kind = MysteryCampaignKind.Veggie,
                        Price = 3,
                    },
                    new()
                    {
                        Id = 9,
                        Start = new DateOnly(2026, 11, 3),
                        End = new DateOnly(2026, 11, 23),
                        Kind = MysteryCampaignKind.Box,
                        Price = 10,
                    },
                ]
            );

        modelBuilder
            .Entity<ProductDb>()
            .HasData(
                [
                    new() { Id = "2", Name = "Big King" },
                    new() { Id = "3", Name = "Big King XXL" },
                    new() { Id = "15", Name = "Double Cheese Bacon XXL" },
                    new() { Id = "16", Name = "Double Steakhouse" },
                    new() { Id = "17", Name = "Double Whopper Cheese" },
                    new() { Id = "46", Name = "Steakhouse" },
                    new() { Id = "49", Name = "Whopper" },
                    new() { Id = "53", Name = "Moyennes frites" },
                    new() { Id = "73", Name = "King Nuggets (4)" },
                    new() { Id = "76", Name = "Chili Cheese (4)" },
                    new() { Id = "77", Name = "Chili Cheese (6)" },
                    new() { Id = "83", Name = "Onion Rings (6)" },
                    new() { Id = "84", Name = "Onion Rings (9)" },
                    new() { Id = "213", Name = "Big Fish" },
                    new() { Id = "433", Name = "Wrap Chicken Cheese and Bacon" },
                    new() { Id = "463", Name = "Wrap Chicken Louisiane" },
                    new() { Id = "508", Name = "Wrap Crousty Emmental" },
                    new() { Id = "544", Name = "Wrap Crousty Chèvre" },
                    new() { Id = "547", Name = "Crousty Chèvre (6)" },
                    new() { Id = "658", Name = "Master Montagnard" },
                    new() { Id = "664", Name = "Veggie Whopper" },
                    new() { Id = "666", Name = "Veggie Steakhouse" },
                    new() { Id = "682", Name = "Cheesebuger Bacon" },
                    new() { Id = "702", Name = "Crispy Chicken Cheese" },
                    new() { Id = "801", Name = "Veggie Chicken Louisiane Steakhouse" },
                    new() { Id = "802", Name = "Chicken Louisiane Steakhouse" },
                    new() { Id = "953", Name = "Chicken Spicy" },
                    new() { Id = "1053", Name = "Master Montagnard Poulet" },
                    new() { Id = "1054", Name = "Master Cantal Bacon" },
                    new() { Id = "1055", Name = "Master Poulet Cantal" },
                    new() { Id = "1072", Name = "King Chicken" },
                    new() { Id = "1073", Name = "King Fish" },
                    new() { Id = "1084", Name = "King Nuggets (7)" },
                    new() { Id = "1101", Name = "Double Cheese Bacon" },
                    new() { Id = "1110", Name = "Double King" },
                    new() { Id = "1276", Name = "Krispper Tenders x2" },
                    new() { Id = "1290", Name = "Whopper Rings" },
                    new() { Id = "1328", Name = "Tortilla Cheese & Bacon" },
                    new() { Id = "1396", Name = "Tortilla Extra Cheddar" },
                    new() { Id = "1398", Name = "Smoky Chicken" },
                    new() { Id = "1400", Name = "King Bacon" },
                    new() { Id = "1401", Name = "King Chicken Bacon" },
                    new() { Id = "1402", Name = "King Fish" },
                    new() { Id = "1511", Name = "CBK" },
                    new() { Id = "1512", Name = "Double CBK" },
                    new() { Id = "1602", Name = "Master Poulet Raclette Poivre" },
                ]
            );
        var mysteryProducts = new[]
            {
                    new
                    {
                        CampaignId = 1,
                        ProductIds = new[] { "702" },
                        Chance = 0.14,
                    },
                    new
                    {
                        CampaignId = 1,
                        ProductIds = new[] { "2" },
                        Chance = 0.12,
                    },
                    new
                    {
                        CampaignId = 1,
                        ProductIds = new[] { "49" },
                        Chance = 0.12,
                    },
                    new
                    {
                        CampaignId = 1,
                        ProductIds = new[] { "1101" },
                        Chance = 0.11,
                    },
                    new
                    {
                        CampaignId = 1,
                        ProductIds = new[] { "463" },
                        Chance = 0.1,
                    },
                    new
                    {
                        CampaignId = 1,
                        ProductIds = new[] { "46" },
                        Chance = 0.1,
                    },
                    new
                    {
                        CampaignId = 1,
                        ProductIds = new[] { "953" },
                        Chance = 0.07,
                    },
                    new
                    {
                        CampaignId = 1,
                        ProductIds = new[] { "802" },
                        Chance = 0.07,
                    },
                    new
                    {
                        CampaignId = 1,
                        ProductIds = new[] { "1055" },
                        Chance = 0.05,
                    },
                    new
                    {
                        CampaignId = 1,
                        ProductIds = new[] { "1054" },
                        Chance = 0.05,
                    },
                    new
                    {
                        CampaignId = 1,
                        ProductIds = new[] { "17" },
                        Chance = 0.04,
                    },
                    new
                    {
                        CampaignId = 1,
                        ProductIds = new[] { "15" },
                        Chance = 0.03,
                    },
                    new
                    {
                        CampaignId = 2,
                        ProductIds = new[] { "664" },
                        Chance = 0.26,
                    },
                    new
                    {
                        CampaignId = 2,
                        ProductIds = new[] { "544" },
                        Chance = 0.26,
                    },
                    new
                    {
                        CampaignId = 2,
                        ProductIds = new[] { "666" },
                        Chance = 0.24,
                    },
                    new
                    {
                        CampaignId = 2,
                        ProductIds = new[] { "801" },
                        Chance = 0.24,
                    },
                    new
                    {
                        CampaignId = 3,
                        ProductIds = new[] { "2" },
                        Chance = 0.16,
                    },
                    new
                    {
                        CampaignId = 3,
                        ProductIds = new[] { "1101" },
                        Chance = 0.16,
                    },
                    new
                    {
                        CampaignId = 3,
                        ProductIds = new[] { "702" },
                        Chance = 0.14,
                    },
                    new
                    {
                        CampaignId = 3,
                        ProductIds = new[] { "49" },
                        Chance = 0.12,
                    },
                    new
                    {
                        CampaignId = 3,
                        ProductIds = new[] { "46" },
                        Chance = 0.11,
                    },
                    new
                    {
                        CampaignId = 3,
                        ProductIds = new[] { "802" },
                        Chance = 0.11,
                    },
                    new
                    {
                        CampaignId = 3,
                        ProductIds = new[] { "1110" },
                        Chance = 0.05,
                    },
                    new
                    {
                        CampaignId = 3,
                        ProductIds = new[] { "1055" },
                        Chance = 0.04,
                    },
                    new
                    {
                        CampaignId = 3,
                        ProductIds = new[] { "1054" },
                        Chance = 0.03,
                    },
                    new
                    {
                        CampaignId = 3,
                        ProductIds = new[] { "213" },
                        Chance = 0.03,
                    },
                    new
                    {
                        CampaignId = 3,
                        ProductIds = new[] { "17" },
                        Chance = 0.03,
                    },
                    new
                    {
                        CampaignId = 3,
                        ProductIds = new[] { "15" },
                        Chance = 0.02,
                    },
                    new
                    {
                        CampaignId = 4,
                        ProductIds = new[] { "664" },
                        Chance = 0.36,
                    },
                    new
                    {
                        CampaignId = 4,
                        ProductIds = new[] { "666" },
                        Chance = 0.32,
                    },
                    new
                    {
                        CampaignId = 4,
                        ProductIds = new[] { "801" },
                        Chance = 0.32,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "1072", "1073" },
                        Chance = 0.033,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "1072", "84" },
                        Chance = 0.033,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "1072", "1084" },
                        Chance = 0.033,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "1072", "77" },
                        Chance = 0.033,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "1072", "547" },
                        Chance = 0.033,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "1073", "1073" },
                        Chance = 0.033,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "702", "84" },
                        Chance = 0.033,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "702", "77" },
                        Chance = 0.033,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "682", "682" },
                        Chance = 0.013,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "682", "1072" },
                        Chance = 0.013,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "682", "1073" },
                        Chance = 0.013,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "682", "213" },
                        Chance = 0.013,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "682", "702" },
                        Chance = 0.013,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "1110", "1072" },
                        Chance = 0.013,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "1110", "1073" },
                        Chance = 0.013,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "1110", "84" },
                        Chance = 0.013,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "1110", "77" },
                        Chance = 0.013,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "1110", "547" },
                        Chance = 0.013,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "1072", "213" },
                        Chance = 0.013,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "1072", "702" },
                        Chance = 0.013,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "1073", "213" },
                        Chance = 0.013,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "1073", "702" },
                        Chance = 0.013,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "213", "213" },
                        Chance = 0.013,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "213", "702" },
                        Chance = 0.013,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "2", "84" },
                        Chance = 0.013,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "2", "77" },
                        Chance = 0.013,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "702", "702" },
                        Chance = 0.013,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "702", "1084" },
                        Chance = 0.013,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "702", "547" },
                        Chance = 0.013,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "1101", "84" },
                        Chance = 0.013,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "49", "84" },
                        Chance = 0.013,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "682", "1110" },
                        Chance = 0.005,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "682", "2" },
                        Chance = 0.005,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "682", "1101" },
                        Chance = 0.005,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "682", "49" },
                        Chance = 0.005,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "1110", "1110" },
                        Chance = 0.005,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "1110", "213" },
                        Chance = 0.005,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "1110", "702" },
                        Chance = 0.005,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "1110", "1084" },
                        Chance = 0.005,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "1072", "2" },
                        Chance = 0.005,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "1072", "1101" },
                        Chance = 0.005,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "1072", "49" },
                        Chance = 0.005,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "1073", "2" },
                        Chance = 0.005,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "1073", "1101" },
                        Chance = 0.005,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "1073", "49" },
                        Chance = 0.005,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "213", "2" },
                        Chance = 0.005,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "213", "1101" },
                        Chance = 0.005,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "2", "702" },
                        Chance = 0.005,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "2", "1084" },
                        Chance = 0.005,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "2", "547" },
                        Chance = 0.005,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "702", "1101" },
                        Chance = 0.005,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "702", "49" },
                        Chance = 0.005,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "1101", "1084" },
                        Chance = 0.005,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "1101", "77" },
                        Chance = 0.005,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "1101", "547" },
                        Chance = 0.005,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "49", "1084" },
                        Chance = 0.005,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "49", "77" },
                        Chance = 0.005,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "49", "547" },
                        Chance = 0.005,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "46", "84" },
                        Chance = 0.005,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "802", "84" },
                        Chance = 0.005,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "802", "77" },
                        Chance = 0.005,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "1055", "84" },
                        Chance = 0.005,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "682", "46" },
                        Chance = 0.004,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "682", "802" },
                        Chance = 0.004,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "682", "1055" },
                        Chance = 0.004,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "1110", "2" },
                        Chance = 0.004,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "1110", "1101" },
                        Chance = 0.004,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "1110", "49" },
                        Chance = 0.004,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "1072", "46" },
                        Chance = 0.004,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "1072", "802" },
                        Chance = 0.004,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "1072", "1055" },
                        Chance = 0.004,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "1073", "46" },
                        Chance = 0.004,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "1073", "802" },
                        Chance = 0.004,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "1073", "1055" },
                        Chance = 0.004,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "213", "49" },
                        Chance = 0.004,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "213", "46" },
                        Chance = 0.004,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "213", "802" },
                        Chance = 0.004,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "213", "1055" },
                        Chance = 0.004,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "2", "2" },
                        Chance = 0.004,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "2", "1101" },
                        Chance = 0.004,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "2", "49" },
                        Chance = 0.004,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "702", "46" },
                        Chance = 0.004,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "702", "802" },
                        Chance = 0.004,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "702", "1055" },
                        Chance = 0.004,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "1101", "1101" },
                        Chance = 0.004,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "1101", "49" },
                        Chance = 0.004,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "46", "1084" },
                        Chance = 0.004,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "46", "77" },
                        Chance = 0.004,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "46", "547" },
                        Chance = 0.004,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "802", "1084" },
                        Chance = 0.004,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "802", "547" },
                        Chance = 0.004,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "1055", "1084" },
                        Chance = 0.004,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "1055", "77" },
                        Chance = 0.004,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "1055", "547" },
                        Chance = 0.004,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "682", "16" },
                        Chance = 0.002,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "1110", "3" },
                        Chance = 0.002,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "1110", "17" },
                        Chance = 0.002,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "1110", "15" },
                        Chance = 0.002,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "1110", "16" },
                        Chance = 0.002,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "213", "16" },
                        Chance = 0.002,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "2", "3" },
                        Chance = 0.002,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "2", "17" },
                        Chance = 0.002,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "2", "15" },
                        Chance = 0.002,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "2", "16" },
                        Chance = 0.002,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "1101", "3" },
                        Chance = 0.002,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "1101", "17" },
                        Chance = 0.002,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "1101", "15" },
                        Chance = 0.002,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "1101", "1054" },
                        Chance = 0.002,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "49", "17" },
                        Chance = 0.002,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "49", "1054" },
                        Chance = 0.002,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "802", "1054" },
                        Chance = 0.002,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "1055", "1055" },
                        Chance = 0.002,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "1110", "46" },
                        Chance = 0.002,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "1110", "802" },
                        Chance = 0.002,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "1110", "1055" },
                        Chance = 0.002,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "1072", "1054" },
                        Chance = 0.002,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "1073", "1054" },
                        Chance = 0.002,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "2", "46" },
                        Chance = 0.002,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "2", "802" },
                        Chance = 0.002,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "2", "1055" },
                        Chance = 0.002,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "702", "1054" },
                        Chance = 0.002,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "1101", "46" },
                        Chance = 0.002,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "1101", "802" },
                        Chance = 0.002,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "1101", "1055" },
                        Chance = 0.002,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "49", "49" },
                        Chance = 0.002,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "49", "802" },
                        Chance = 0.002,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "3", "84" },
                        Chance = 0.002,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "17", "84" },
                        Chance = 0.002,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "15", "84" },
                        Chance = 0.002,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "1054", "84" },
                        Chance = 0.002,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "1054", "1084" },
                        Chance = 0.002,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "1054", "77" },
                        Chance = 0.002,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "1054", "547" },
                        Chance = 0.002,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "682", "3" },
                        Chance = 0.001,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "682", "17" },
                        Chance = 0.001,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "682", "15" },
                        Chance = 0.001,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "682", "1054" },
                        Chance = 0.001,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "1110", "1054" },
                        Chance = 0.001,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "1072", "3" },
                        Chance = 0.001,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "1072", "17" },
                        Chance = 0.001,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "1072", "15" },
                        Chance = 0.001,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "1072", "16" },
                        Chance = 0.001,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "1073", "3" },
                        Chance = 0.001,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "1073", "17" },
                        Chance = 0.001,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "1073", "15" },
                        Chance = 0.001,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "1073", "16" },
                        Chance = 0.001,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "213", "3" },
                        Chance = 0.001,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "213", "17" },
                        Chance = 0.001,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "213", "15" },
                        Chance = 0.001,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "213", "1054" },
                        Chance = 0.001,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "2", "1054" },
                        Chance = 0.001,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "702", "3" },
                        Chance = 0.001,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "702", "17" },
                        Chance = 0.001,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "702", "15" },
                        Chance = 0.001,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "702", "16" },
                        Chance = 0.001,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "49", "46" },
                        Chance = 0.001,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "49", "1055" },
                        Chance = 0.001,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "46", "46" },
                        Chance = 0.001,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "46", "802" },
                        Chance = 0.001,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "46", "1055" },
                        Chance = 0.001,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "802", "802" },
                        Chance = 0.001,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "802", "1055" },
                        Chance = 0.001,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "3", "1084" },
                        Chance = 0.001,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "3", "77" },
                        Chance = 0.001,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "3", "547" },
                        Chance = 0.001,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "17", "1084" },
                        Chance = 0.001,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "17", "77" },
                        Chance = 0.001,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "17", "547" },
                        Chance = 0.001,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "15", "1084" },
                        Chance = 0.001,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "15", "77" },
                        Chance = 0.001,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "15", "547" },
                        Chance = 0.001,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "16", "84" },
                        Chance = 0.001,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "16", "1084" },
                        Chance = 0.001,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "16", "77" },
                        Chance = 0.001,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "16", "547" },
                        Chance = 0.001,
                    },
                    new
                    {
                        CampaignId = 5,
                        ProductIds = new[] { "1072", "1072" },
                        Chance = 0.033,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "682", "3" },
                        Chance = 0.001,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "682", "17" },
                        Chance = 0.001,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "682", "15" },
                        Chance = 0.001,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "682", "1054" },
                        Chance = 0.001,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "1110", "1054" },
                        Chance = 0.001,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "1072", "3" },
                        Chance = 0.001,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "1072", "17" },
                        Chance = 0.001,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "1072", "15" },
                        Chance = 0.001,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "1072", "16" },
                        Chance = 0.001,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "1073", "3" },
                        Chance = 0.001,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "1073", "17" },
                        Chance = 0.001,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "1073", "15" },
                        Chance = 0.001,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "1073", "16" },
                        Chance = 0.001,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "213", "3" },
                        Chance = 0.001,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "213", "17" },
                        Chance = 0.001,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "213", "15" },
                        Chance = 0.001,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "213", "1054" },
                        Chance = 0.001,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "2", "1054" },
                        Chance = 0.001,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "702", "3" },
                        Chance = 0.001,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "702", "17" },
                        Chance = 0.001,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "702", "15" },
                        Chance = 0.001,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "702", "16" },
                        Chance = 0.001,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "49", "46" },
                        Chance = 0.001,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "49", "1055" },
                        Chance = 0.001,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "46", "46" },
                        Chance = 0.001,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "46", "802" },
                        Chance = 0.001,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "46", "1055" },
                        Chance = 0.001,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "802", "802" },
                        Chance = 0.001,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "802", "1055" },
                        Chance = 0.001,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "3", "1084" },
                        Chance = 0.001,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "3", "77" },
                        Chance = 0.001,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "3", "547" },
                        Chance = 0.001,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "17", "1084" },
                        Chance = 0.001,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "17", "77" },
                        Chance = 0.001,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "17", "547" },
                        Chance = 0.001,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "15", "1084" },
                        Chance = 0.001,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "15", "77" },
                        Chance = 0.001,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "15", "547" },
                        Chance = 0.001,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "16", "84" },
                        Chance = 0.001,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "16", "1084" },
                        Chance = 0.001,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "16", "77" },
                        Chance = 0.001,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "16", "547" },
                        Chance = 0.001,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "1110", "46" },
                        Chance = 0.002,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "1110", "802" },
                        Chance = 0.002,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "1110", "1055" },
                        Chance = 0.002,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "1072", "1054" },
                        Chance = 0.002,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "1073", "1054" },
                        Chance = 0.002,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "2", "46" },
                        Chance = 0.002,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "2", "802" },
                        Chance = 0.002,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "2", "1055" },
                        Chance = 0.002,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "702", "1054" },
                        Chance = 0.002,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "1101", "46" },
                        Chance = 0.002,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "1101", "802" },
                        Chance = 0.002,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "1101", "1055" },
                        Chance = 0.002,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "49", "49" },
                        Chance = 0.002,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "49", "802" },
                        Chance = 0.002,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "3", "84" },
                        Chance = 0.002,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "17", "84" },
                        Chance = 0.002,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "15", "84" },
                        Chance = 0.002,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "1054", "84" },
                        Chance = 0.002,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "1054", "1084" },
                        Chance = 0.002,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "1054", "77" },
                        Chance = 0.002,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "1054", "547" },
                        Chance = 0.002,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "682", "16" },
                        Chance = 0.002,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "1110", "3" },
                        Chance = 0.002,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "1110", "17" },
                        Chance = 0.002,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "1110", "15" },
                        Chance = 0.002,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "1110", "16" },
                        Chance = 0.002,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "213", "16" },
                        Chance = 0.002,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "2", "3" },
                        Chance = 0.002,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "2", "17" },
                        Chance = 0.002,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "2", "15" },
                        Chance = 0.002,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "2", "16" },
                        Chance = 0.002,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "1101", "3" },
                        Chance = 0.002,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "1101", "17" },
                        Chance = 0.002,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "1101", "15" },
                        Chance = 0.002,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "1101", "1054" },
                        Chance = 0.002,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "49", "17" },
                        Chance = 0.002,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "49", "1054" },
                        Chance = 0.002,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "802", "1054" },
                        Chance = 0.002,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "1055", "1055" },
                        Chance = 0.002,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "682", "46" },
                        Chance = 0.004,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "682", "802" },
                        Chance = 0.004,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "682", "1055" },
                        Chance = 0.004,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "1110", "2" },
                        Chance = 0.004,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "1110", "1101" },
                        Chance = 0.004,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "1110", "49" },
                        Chance = 0.004,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "1072", "46" },
                        Chance = 0.004,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "1072", "1055" },
                        Chance = 0.004,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "1073", "46" },
                        Chance = 0.004,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "1073", "802" },
                        Chance = 0.004,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "1073", "1055" },
                        Chance = 0.004,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "213", "49" },
                        Chance = 0.004,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "213", "46" },
                        Chance = 0.004,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "213", "802" },
                        Chance = 0.004,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "213", "1055" },
                        Chance = 0.004,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "2", "2" },
                        Chance = 0.004,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "2", "1101" },
                        Chance = 0.004,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "2", "49" },
                        Chance = 0.004,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "702", "46" },
                        Chance = 0.004,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "702", "802" },
                        Chance = 0.004,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "702", "1055" },
                        Chance = 0.004,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "1101", "1101" },
                        Chance = 0.004,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "1101", "49" },
                        Chance = 0.004,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "46", "1084" },
                        Chance = 0.004,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "46", "77" },
                        Chance = 0.004,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "46", "547" },
                        Chance = 0.004,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "802", "1084" },
                        Chance = 0.004,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "802", "547" },
                        Chance = 0.004,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "1055", "1084" },
                        Chance = 0.004,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "1055", "77" },
                        Chance = 0.004,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "1055", "547" },
                        Chance = 0.004,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "682", "1073" },
                        Chance = 0.004,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "682", "213" },
                        Chance = 0.004,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "1110", "1073" },
                        Chance = 0.004,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "1072", "1073" },
                        Chance = 0.004,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "1072", "213" },
                        Chance = 0.004,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "1073", "702" },
                        Chance = 0.004,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "213", "702" },
                        Chance = 0.004,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "682", "1110" },
                        Chance = 0.005,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "682", "1101" },
                        Chance = 0.005,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "1110", "1110" },
                        Chance = 0.005,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "1110", "213" },
                        Chance = 0.005,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "1110", "702" },
                        Chance = 0.005,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "1110", "1084" },
                        Chance = 0.005,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "1072", "2" },
                        Chance = 0.005,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "1072", "1101" },
                        Chance = 0.005,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "1073", "2" },
                        Chance = 0.005,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "1073", "1101" },
                        Chance = 0.005,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "1073", "49" },
                        Chance = 0.005,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "213", "2" },
                        Chance = 0.005,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "213", "1101" },
                        Chance = 0.005,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "2", "547" },
                        Chance = 0.005,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "1101", "77" },
                        Chance = 0.005,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "682", "1072" },
                        Chance = 0.013,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "682", "702" },
                        Chance = 0.013,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "1110", "1072" },
                        Chance = 0.013,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "1110", "84" },
                        Chance = 0.013,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "1110", "77" },
                        Chance = 0.013,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "1110", "547" },
                        Chance = 0.013,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "1072", "702" },
                        Chance = 0.013,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "1072", "84" },
                        Chance = 0.013,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "1072", "1084" },
                        Chance = 0.013,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "1072", "77" },
                        Chance = 0.013,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "1072", "547" },
                        Chance = 0.013,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "2", "84" },
                        Chance = 0.013,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "2", "77" },
                        Chance = 0.013,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "702", "702" },
                        Chance = 0.013,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "702", "547" },
                        Chance = 0.013,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "1101", "84" },
                        Chance = 0.013,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "1072", "802" },
                        Chance = 0.018,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "682", "2" },
                        Chance = 0.019,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "682", "49" },
                        Chance = 0.019,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "1072", "49" },
                        Chance = 0.019,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "2", "702" },
                        Chance = 0.019,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "2", "1084" },
                        Chance = 0.019,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "702", "1101" },
                        Chance = 0.019,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "702", "49" },
                        Chance = 0.019,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "1101", "1084" },
                        Chance = 0.019,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "1101", "547" },
                        Chance = 0.019,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "49", "1084" },
                        Chance = 0.019,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "49", "77" },
                        Chance = 0.019,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "49", "547" },
                        Chance = 0.019,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "46", "84" },
                        Chance = 0.019,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "802", "84" },
                        Chance = 0.019,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "802", "77" },
                        Chance = 0.019,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "1055", "84" },
                        Chance = 0.019,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "702", "1084" },
                        Chance = 0.027,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "49", "84" },
                        Chance = 0.027,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "702", "84" },
                        Chance = 0.033,
                    },
                    new
                    {
                        CampaignId = 6,
                        ProductIds = new[] { "702", "77" },
                        Chance = 0.033,
                    },
                    new
                    {
                        CampaignId = 7,
                        ProductIds = new[] { "702" },
                        Chance = 0.15,
                    },
                    new
                    {
                        CampaignId = 7,
                        ProductIds = new[] { "213" },
                        Chance = 0.03,
                    },
                    new
                    {
                        CampaignId = 7,
                        ProductIds = new[] { "1110" },
                        Chance = 0.08,
                    },
                    new
                    {
                        CampaignId = 7,
                        ProductIds = new[] { "2" },
                        Chance = 0.09,
                    },
                    new
                    {
                        CampaignId = 7,
                        ProductIds = new[] { "1101" },
                        Chance = 0.05,
                    },
                    new
                    {
                        CampaignId = 7,
                        ProductIds = new[] { "49" },
                        Chance = 0.08,
                    },
                    new
                    {
                        CampaignId = 7,
                        ProductIds = new[] { "46" },
                        Chance = 0.07,
                    },
                    new
                    {
                        CampaignId = 7,
                        ProductIds = new[] { "802" },
                        Chance = 0.1,
                    },
                    new
                    {
                        CampaignId = 7,
                        ProductIds = new[] { "1290" },
                        Chance = 0.05,
                    },
                    new
                    {
                        CampaignId = 7,
                        ProductIds = new[] { "15" },
                        Chance = 0.02,
                    },
                    new
                    {
                        CampaignId = 7,
                        ProductIds = new[] { "658" },
                        Chance = 0.025,
                    },
                    new
                    {
                        CampaignId = 7,
                        ProductIds = new[] { "1053" },
                        Chance = 0.025,
                    },
                    new
                    {
                        CampaignId = 7,
                        ProductIds = new[] { "463" },
                        Chance = 0.11,
                    },
                    new
                    {
                        CampaignId = 7,
                        ProductIds = new[] { "433" },
                        Chance = 0.12,
                    },
                    new
                    {
                        CampaignId = 8,
                        ProductIds = new[] { "664" },
                        Chance = 0.2,
                    },
                    new
                    {
                        CampaignId = 8,
                        ProductIds = new[] { "666" },
                        Chance = 0.2,
                    },
                    new
                    {
                        CampaignId = 8,
                        ProductIds = new[] { "801" },
                        Chance = 0.3,
                    },
                    new
                    {
                        CampaignId = 8,
                        ProductIds = new[] { "508" },
                        Chance = 0.3,
                    },
                    new
                    {
                        CampaignId = 9,
                        ProductIds = new[] { "49", "1400", "1276", "53" },
                        Chance = 0.043,
                    },
                    new
                    {
                        CampaignId = 9,
                        ProductIds = new[] { "49", "1400", "83", "53" },
                        Chance = 0.057,
                    },
                    new
                    {
                        CampaignId = 9,
                        ProductIds = new[] { "49", "1398", "73", "53" },
                        Chance = 0.06,
                    },
                    new
                    {
                        CampaignId = 9,
                        ProductIds = new[] { "49", "1402", "76", "53" },
                        Chance = 0.01,
                    },
                    new
                    {
                        CampaignId = 9,
                        ProductIds = new[] { "49", "1328", "83", "53" },
                        Chance = 0.03,
                    },
                    new
                    {
                        CampaignId = 9,
                        ProductIds = new[] { "2", "1400", "83", "53" },
                        Chance = 0.06,
                    },
                    new
                    {
                        CampaignId = 9,
                        ProductIds = new[] { "2", "1398", "73", "53" },
                        Chance = 0.059,
                    },
                    new
                    {
                        CampaignId = 9,
                        ProductIds = new[] { "2", "1398", "1276", "53" },
                        Chance = 0.015,
                    },
                    new
                    {
                        CampaignId = 9,
                        ProductIds = new[] { "2", "1401", "83", "53" },
                        Chance = 0.06,
                    },
                    new
                    {
                        CampaignId = 9,
                        ProductIds = new[] { "2", "1401", "76", "53" },
                        Chance = 0.047,
                    },
                    new
                    {
                        CampaignId = 9,
                        ProductIds = new[] { "1511", "1400", "83", "53" },
                        Chance = 0.06,
                    },
                    new
                    {
                        CampaignId = 9,
                        ProductIds = new[] { "1511", "1400", "73", "53" },
                        Chance = 0.043,
                    },
                    new
                    {
                        CampaignId = 9,
                        ProductIds = new[] { "1511", "1398", "76", "53" },
                        Chance = 0.034,
                    },
                    new
                    {
                        CampaignId = 9,
                        ProductIds = new[] { "1511", "1402", "76", "53" },
                        Chance = 0.056,
                    },
                    new
                    {
                        CampaignId = 9,
                        ProductIds = new[] { "1511", "1101", "83", "53" },
                        Chance = 0.014,
                    },
                    new
                    {
                        CampaignId = 9,
                        ProductIds = new[] { "1511", "1101", "83", "53" },
                        Chance = 0.04,
                    },
                    new
                    {
                        CampaignId = 9,
                        ProductIds = new[] { "1396", "1398", "73", "53" },
                        Chance = 0.04,
                    },
                    new
                    {
                        CampaignId = 9,
                        ProductIds = new[] { "46", "1398", "73", "53" },
                        Chance = 0.02,
                    },
                    new
                    {
                        CampaignId = 9,
                        ProductIds = new[] { "46", "1401", "76", "53" },
                        Chance = 0.05,
                    },
                    new
                    {
                        CampaignId = 9,
                        ProductIds = new[] { "802", "1400", "83", "53" },
                        Chance = 0.037,
                    },
                    new
                    {
                        CampaignId = 9,
                        ProductIds = new[] { "802", "1328", "73", "53" },
                        Chance = 0.035,
                    },
                    new
                    {
                        CampaignId = 9,
                        ProductIds = new[] { "3", "1400", "76", "53" },
                        Chance = 0.005,
                    },
                    new
                    {
                        CampaignId = 9,
                        ProductIds = new[] { "15", "1400", "76", "53" },
                        Chance = 0.005,
                    },
                    new
                    {
                        CampaignId = 9,
                        ProductIds = new[] { "16", "1401", "83", "53" },
                        Chance = 0.02,
                    },
                    new
                    {
                        CampaignId = 9,
                        ProductIds = new[] { "17", "1398", "83", "53" },
                        Chance = 0.02,
                    },
                    new
                    {
                        CampaignId = 9,
                        ProductIds = new[] { "1512", "1398", "76", "53" },
                        Chance = 0.06,
                    },
                    new
                    {
                        CampaignId = 9,
                        ProductIds = new[] { "658", "1400", "83", "53" },
                        Chance = 0.01,
                    },
                    new
                    {
                        CampaignId = 9,
                        ProductIds = new[] { "1602", "1398", "76", "53" },
                        Chance = 0.01,
                    },
                }
                .Select((p, index) => new { Id = index + 1, p.CampaignId, p.ProductIds, p.Chance })
                .ToArray();

        modelBuilder.Entity<MysteryProductDb>().HasData(mysteryProducts.Select(p => new { p.Id, p.CampaignId, p.Chance }));
        modelBuilder.Entity<MysteryProductItemDb>().HasData(mysteryProducts.SelectMany(p =>
            p.ProductIds.Select(productId => new { MysteryProductId = p.Id, ProductId = productId }))
            .Select((p, index) => new { Id = index + 1, p.MysteryProductId, p.ProductId }));
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
    Duo,
    Box,
}

[Table("MysteryCampaigns")]
public record MysteryCampaignDb
{
    public int Id { get; set; }

    public required DateOnly Start { get; set; }

    public required DateOnly End { get; set; }

    public required MysteryCampaignKind Kind { get; set; }

    public required double Price { get; set; }
}

[Table("MysteryProducts")]
public record MysteryProductDb
{
    public int Id { get; set; }

    public required MysteryCampaignDb Campaign { get; set; }

    public IList<MysteryProductItemDb> Products { get; set; } = [];

    [Column(TypeName = "decimal(4, 2)")]
    public required double Chance { get; set; }
}

[Table("MysteryProductItems")]
public record MysteryProductItemDb
{
    public int Id { get; set; }

    public required MysteryProductDb MysteryProduct { get; set; }

    public required ProductDb Product { get; set; }
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
