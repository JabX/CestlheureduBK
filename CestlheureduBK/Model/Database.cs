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
                    new()
                    {
                        Id = 5,
                        Month = "2025-11-04",
                        Kind = MysteryCampaignKind.Duo,
                        Price = 5,
                    },
                    new()
                    {
                        Id = 6,
                        Month = "2025-11-07",
                        Kind = MysteryCampaignKind.Duo,
                        Price = 5,
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
                    new() { Id = "77", Name = "Chili Cheese (6)" },
                    new() { Id = "84", Name = "Onion Rings (9)" },
                    new() { Id = "213", Name = "Big Fish" },
                    new() { Id = "463", Name = "Wrap Chicken Louisiane" },
                    new() { Id = "544", Name = "Wrap Crousty Chèvre" },
                    new() { Id = "547", Name = "Crousty Chèvre (6)" },
                    new() { Id = "664", Name = "Veggie Whopper" },
                    new() { Id = "666", Name = "Veggie Steakhouse" },
                    new() { Id = "682", Name = "Cheesebuger Bacon" },
                    new() { Id = "702", Name = "Crispy Chicken Cheese" },
                    new() { Id = "801", Name = "Veggie Chicken Louisiane Steakhouse" },
                    new() { Id = "802", Name = "Chicken Louisiane Steakhouse" },
                    new() { Id = "953", Name = "Chicken Spicy" },
                    new() { Id = "1054", Name = "Master Cantal Bacon" },
                    new() { Id = "1055", Name = "Master Poulet Cantal" },
                    new() { Id = "1072", Name = "King Chicken" },
                    new() { Id = "1073", Name = "King Fish" },
                    new() { Id = "1084", Name = "King Nuggets (7)" },
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
                    new
                    {
                        Id = 207,
                        CampaignId = 5,
                        ProductId = "1072",
                        Product2Id = "1072",
                        Chance = 0.033,
                    },
                    new
                    {
                        Id = 32,
                        CampaignId = 5,
                        ProductId = "1072",
                        Product2Id = "1073",
                        Chance = 0.033,
                    },
                    new
                    {
                        Id = 33,
                        CampaignId = 5,
                        ProductId = "1072",
                        Product2Id = "84",
                        Chance = 0.033,
                    },
                    new
                    {
                        Id = 34,
                        CampaignId = 5,
                        ProductId = "1072",
                        Product2Id = "1084",
                        Chance = 0.033,
                    },
                    new
                    {
                        Id = 35,
                        CampaignId = 5,
                        ProductId = "1072",
                        Product2Id = "77",
                        Chance = 0.033,
                    },
                    new
                    {
                        Id = 36,
                        CampaignId = 5,
                        ProductId = "1072",
                        Product2Id = "547",
                        Chance = 0.033,
                    },
                    new
                    {
                        Id = 37,
                        CampaignId = 5,
                        ProductId = "1073",
                        Product2Id = "1073",
                        Chance = 0.033,
                    },
                    new
                    {
                        Id = 38,
                        CampaignId = 5,
                        ProductId = "702",
                        Product2Id = "84",
                        Chance = 0.033,
                    },
                    new
                    {
                        Id = 39,
                        CampaignId = 5,
                        ProductId = "702",
                        Product2Id = "77",
                        Chance = 0.033,
                    },
                    new
                    {
                        Id = 40,
                        CampaignId = 5,
                        ProductId = "682",
                        Product2Id = "682",
                        Chance = 0.013,
                    },
                    new
                    {
                        Id = 41,
                        CampaignId = 5,
                        ProductId = "682",
                        Product2Id = "1072",
                        Chance = 0.013,
                    },
                    new
                    {
                        Id = 42,
                        CampaignId = 5,
                        ProductId = "682",
                        Product2Id = "1073",
                        Chance = 0.013,
                    },
                    new
                    {
                        Id = 43,
                        CampaignId = 5,
                        ProductId = "682",
                        Product2Id = "213",
                        Chance = 0.013,
                    },
                    new
                    {
                        Id = 44,
                        CampaignId = 5,
                        ProductId = "682",
                        Product2Id = "702",
                        Chance = 0.013,
                    },
                    new
                    {
                        Id = 45,
                        CampaignId = 5,
                        ProductId = "1110",
                        Product2Id = "1072",
                        Chance = 0.013,
                    },
                    new
                    {
                        Id = 46,
                        CampaignId = 5,
                        ProductId = "1110",
                        Product2Id = "1073",
                        Chance = 0.013,
                    },
                    new
                    {
                        Id = 47,
                        CampaignId = 5,
                        ProductId = "1110",
                        Product2Id = "84",
                        Chance = 0.013,
                    },
                    new
                    {
                        Id = 48,
                        CampaignId = 5,
                        ProductId = "1110",
                        Product2Id = "77",
                        Chance = 0.013,
                    },
                    new
                    {
                        Id = 49,
                        CampaignId = 5,
                        ProductId = "1110",
                        Product2Id = "547",
                        Chance = 0.013,
                    },
                    new
                    {
                        Id = 50,
                        CampaignId = 5,
                        ProductId = "1072",
                        Product2Id = "213",
                        Chance = 0.013,
                    },
                    new
                    {
                        Id = 51,
                        CampaignId = 5,
                        ProductId = "1072",
                        Product2Id = "702",
                        Chance = 0.013,
                    },
                    new
                    {
                        Id = 52,
                        CampaignId = 5,
                        ProductId = "1073",
                        Product2Id = "213",
                        Chance = 0.013,
                    },
                    new
                    {
                        Id = 53,
                        CampaignId = 5,
                        ProductId = "1073",
                        Product2Id = "702",
                        Chance = 0.013,
                    },
                    new
                    {
                        Id = 54,
                        CampaignId = 5,
                        ProductId = "213",
                        Product2Id = "213",
                        Chance = 0.013,
                    },
                    new
                    {
                        Id = 55,
                        CampaignId = 5,
                        ProductId = "213",
                        Product2Id = "702",
                        Chance = 0.013,
                    },
                    new
                    {
                        Id = 56,
                        CampaignId = 5,
                        ProductId = "2",
                        Product2Id = "84",
                        Chance = 0.013,
                    },
                    new
                    {
                        Id = 57,
                        CampaignId = 5,
                        ProductId = "2",
                        Product2Id = "77",
                        Chance = 0.013,
                    },
                    new
                    {
                        Id = 58,
                        CampaignId = 5,
                        ProductId = "702",
                        Product2Id = "702",
                        Chance = 0.013,
                    },
                    new
                    {
                        Id = 59,
                        CampaignId = 5,
                        ProductId = "702",
                        Product2Id = "1084",
                        Chance = 0.013,
                    },
                    new
                    {
                        Id = 60,
                        CampaignId = 5,
                        ProductId = "702",
                        Product2Id = "547",
                        Chance = 0.013,
                    },
                    new
                    {
                        Id = 61,
                        CampaignId = 5,
                        ProductId = "1101",
                        Product2Id = "84",
                        Chance = 0.013,
                    },
                    new
                    {
                        Id = 62,
                        CampaignId = 5,
                        ProductId = "49",
                        Product2Id = "84",
                        Chance = 0.013,
                    },
                    new
                    {
                        Id = 63,
                        CampaignId = 5,
                        ProductId = "682",
                        Product2Id = "1110",
                        Chance = 0.005,
                    },
                    new
                    {
                        Id = 64,
                        CampaignId = 5,
                        ProductId = "682",
                        Product2Id = "2",
                        Chance = 0.005,
                    },
                    new
                    {
                        Id = 65,
                        CampaignId = 5,
                        ProductId = "682",
                        Product2Id = "1101",
                        Chance = 0.005,
                    },
                    new
                    {
                        Id = 66,
                        CampaignId = 5,
                        ProductId = "682",
                        Product2Id = "49",
                        Chance = 0.005,
                    },
                    new
                    {
                        Id = 67,
                        CampaignId = 5,
                        ProductId = "1110",
                        Product2Id = "1110",
                        Chance = 0.005,
                    },
                    new
                    {
                        Id = 68,
                        CampaignId = 5,
                        ProductId = "1110",
                        Product2Id = "213",
                        Chance = 0.005,
                    },
                    new
                    {
                        Id = 69,
                        CampaignId = 5,
                        ProductId = "1110",
                        Product2Id = "702",
                        Chance = 0.005,
                    },
                    new
                    {
                        Id = 70,
                        CampaignId = 5,
                        ProductId = "1110",
                        Product2Id = "1084",
                        Chance = 0.005,
                    },
                    new
                    {
                        Id = 71,
                        CampaignId = 5,
                        ProductId = "1072",
                        Product2Id = "2",
                        Chance = 0.005,
                    },
                    new
                    {
                        Id = 72,
                        CampaignId = 5,
                        ProductId = "1072",
                        Product2Id = "1101",
                        Chance = 0.005,
                    },
                    new
                    {
                        Id = 73,
                        CampaignId = 5,
                        ProductId = "1072",
                        Product2Id = "49",
                        Chance = 0.005,
                    },
                    new
                    {
                        Id = 74,
                        CampaignId = 5,
                        ProductId = "1073",
                        Product2Id = "2",
                        Chance = 0.005,
                    },
                    new
                    {
                        Id = 75,
                        CampaignId = 5,
                        ProductId = "1073",
                        Product2Id = "1101",
                        Chance = 0.005,
                    },
                    new
                    {
                        Id = 76,
                        CampaignId = 5,
                        ProductId = "1073",
                        Product2Id = "49",
                        Chance = 0.005,
                    },
                    new
                    {
                        Id = 77,
                        CampaignId = 5,
                        ProductId = "213",
                        Product2Id = "2",
                        Chance = 0.005,
                    },
                    new
                    {
                        Id = 78,
                        CampaignId = 5,
                        ProductId = "213",
                        Product2Id = "1101",
                        Chance = 0.005,
                    },
                    new
                    {
                        Id = 79,
                        CampaignId = 5,
                        ProductId = "2",
                        Product2Id = "702",
                        Chance = 0.005,
                    },
                    new
                    {
                        Id = 80,
                        CampaignId = 5,
                        ProductId = "2",
                        Product2Id = "1084",
                        Chance = 0.005,
                    },
                    new
                    {
                        Id = 81,
                        CampaignId = 5,
                        ProductId = "2",
                        Product2Id = "547",
                        Chance = 0.005,
                    },
                    new
                    {
                        Id = 82,
                        CampaignId = 5,
                        ProductId = "702",
                        Product2Id = "1101",
                        Chance = 0.005,
                    },
                    new
                    {
                        Id = 83,
                        CampaignId = 5,
                        ProductId = "702",
                        Product2Id = "49",
                        Chance = 0.005,
                    },
                    new
                    {
                        Id = 84,
                        CampaignId = 5,
                        ProductId = "1101",
                        Product2Id = "1084",
                        Chance = 0.005,
                    },
                    new
                    {
                        Id = 85,
                        CampaignId = 5,
                        ProductId = "1101",
                        Product2Id = "77",
                        Chance = 0.005,
                    },
                    new
                    {
                        Id = 86,
                        CampaignId = 5,
                        ProductId = "1101",
                        Product2Id = "547",
                        Chance = 0.005,
                    },
                    new
                    {
                        Id = 87,
                        CampaignId = 5,
                        ProductId = "49",
                        Product2Id = "1084",
                        Chance = 0.005,
                    },
                    new
                    {
                        Id = 88,
                        CampaignId = 5,
                        ProductId = "49",
                        Product2Id = "77",
                        Chance = 0.005,
                    },
                    new
                    {
                        Id = 89,
                        CampaignId = 5,
                        ProductId = "49",
                        Product2Id = "547",
                        Chance = 0.005,
                    },
                    new
                    {
                        Id = 90,
                        CampaignId = 5,
                        ProductId = "46",
                        Product2Id = "84",
                        Chance = 0.005,
                    },
                    new
                    {
                        Id = 91,
                        CampaignId = 5,
                        ProductId = "802",
                        Product2Id = "84",
                        Chance = 0.005,
                    },
                    new
                    {
                        Id = 92,
                        CampaignId = 5,
                        ProductId = "802",
                        Product2Id = "77",
                        Chance = 0.005,
                    },
                    new
                    {
                        Id = 93,
                        CampaignId = 5,
                        ProductId = "1055",
                        Product2Id = "84",
                        Chance = 0.005,
                    },
                    new
                    {
                        Id = 94,
                        CampaignId = 5,
                        ProductId = "682",
                        Product2Id = "46",
                        Chance = 0.004,
                    },
                    new
                    {
                        Id = 95,
                        CampaignId = 5,
                        ProductId = "682",
                        Product2Id = "802",
                        Chance = 0.004,
                    },
                    new
                    {
                        Id = 96,
                        CampaignId = 5,
                        ProductId = "682",
                        Product2Id = "1055",
                        Chance = 0.004,
                    },
                    new
                    {
                        Id = 97,
                        CampaignId = 5,
                        ProductId = "1110",
                        Product2Id = "2",
                        Chance = 0.004,
                    },
                    new
                    {
                        Id = 98,
                        CampaignId = 5,
                        ProductId = "1110",
                        Product2Id = "1101",
                        Chance = 0.004,
                    },
                    new
                    {
                        Id = 99,
                        CampaignId = 5,
                        ProductId = "1110",
                        Product2Id = "49",
                        Chance = 0.004,
                    },
                    new
                    {
                        Id = 100,
                        CampaignId = 5,
                        ProductId = "1072",
                        Product2Id = "46",
                        Chance = 0.004,
                    },
                    new
                    {
                        Id = 101,
                        CampaignId = 5,
                        ProductId = "1072",
                        Product2Id = "802",
                        Chance = 0.004,
                    },
                    new
                    {
                        Id = 102,
                        CampaignId = 5,
                        ProductId = "1072",
                        Product2Id = "1055",
                        Chance = 0.004,
                    },
                    new
                    {
                        Id = 103,
                        CampaignId = 5,
                        ProductId = "1073",
                        Product2Id = "46",
                        Chance = 0.004,
                    },
                    new
                    {
                        Id = 104,
                        CampaignId = 5,
                        ProductId = "1073",
                        Product2Id = "802",
                        Chance = 0.004,
                    },
                    new
                    {
                        Id = 105,
                        CampaignId = 5,
                        ProductId = "1073",
                        Product2Id = "1055",
                        Chance = 0.004,
                    },
                    new
                    {
                        Id = 106,
                        CampaignId = 5,
                        ProductId = "213",
                        Product2Id = "49",
                        Chance = 0.004,
                    },
                    new
                    {
                        Id = 107,
                        CampaignId = 5,
                        ProductId = "213",
                        Product2Id = "46",
                        Chance = 0.004,
                    },
                    new
                    {
                        Id = 108,
                        CampaignId = 5,
                        ProductId = "213",
                        Product2Id = "802",
                        Chance = 0.004,
                    },
                    new
                    {
                        Id = 109,
                        CampaignId = 5,
                        ProductId = "213",
                        Product2Id = "1055",
                        Chance = 0.004,
                    },
                    new
                    {
                        Id = 110,
                        CampaignId = 5,
                        ProductId = "2",
                        Product2Id = "2",
                        Chance = 0.004,
                    },
                    new
                    {
                        Id = 111,
                        CampaignId = 5,
                        ProductId = "2",
                        Product2Id = "1101",
                        Chance = 0.004,
                    },
                    new
                    {
                        Id = 112,
                        CampaignId = 5,
                        ProductId = "2",
                        Product2Id = "49",
                        Chance = 0.004,
                    },
                    new
                    {
                        Id = 113,
                        CampaignId = 5,
                        ProductId = "702",
                        Product2Id = "46",
                        Chance = 0.004,
                    },
                    new
                    {
                        Id = 114,
                        CampaignId = 5,
                        ProductId = "702",
                        Product2Id = "802",
                        Chance = 0.004,
                    },
                    new
                    {
                        Id = 115,
                        CampaignId = 5,
                        ProductId = "702",
                        Product2Id = "1055",
                        Chance = 0.004,
                    },
                    new
                    {
                        Id = 116,
                        CampaignId = 5,
                        ProductId = "1101",
                        Product2Id = "1101",
                        Chance = 0.004,
                    },
                    new
                    {
                        Id = 117,
                        CampaignId = 5,
                        ProductId = "1101",
                        Product2Id = "49",
                        Chance = 0.004,
                    },
                    new
                    {
                        Id = 118,
                        CampaignId = 5,
                        ProductId = "46",
                        Product2Id = "1084",
                        Chance = 0.004,
                    },
                    new
                    {
                        Id = 119,
                        CampaignId = 5,
                        ProductId = "46",
                        Product2Id = "77",
                        Chance = 0.004,
                    },
                    new
                    {
                        Id = 120,
                        CampaignId = 5,
                        ProductId = "46",
                        Product2Id = "547",
                        Chance = 0.004,
                    },
                    new
                    {
                        Id = 121,
                        CampaignId = 5,
                        ProductId = "802",
                        Product2Id = "1084",
                        Chance = 0.004,
                    },
                    new
                    {
                        Id = 122,
                        CampaignId = 5,
                        ProductId = "802",
                        Product2Id = "547",
                        Chance = 0.004,
                    },
                    new
                    {
                        Id = 123,
                        CampaignId = 5,
                        ProductId = "1055",
                        Product2Id = "1084",
                        Chance = 0.004,
                    },
                    new
                    {
                        Id = 124,
                        CampaignId = 5,
                        ProductId = "1055",
                        Product2Id = "77",
                        Chance = 0.004,
                    },
                    new
                    {
                        Id = 125,
                        CampaignId = 5,
                        ProductId = "1055",
                        Product2Id = "547",
                        Chance = 0.004,
                    },
                    new
                    {
                        Id = 126,
                        CampaignId = 5,
                        ProductId = "682",
                        Product2Id = "16",
                        Chance = 0.002,
                    },
                    new
                    {
                        Id = 127,
                        CampaignId = 5,
                        ProductId = "1110",
                        Product2Id = "3",
                        Chance = 0.002,
                    },
                    new
                    {
                        Id = 128,
                        CampaignId = 5,
                        ProductId = "1110",
                        Product2Id = "17",
                        Chance = 0.002,
                    },
                    new
                    {
                        Id = 129,
                        CampaignId = 5,
                        ProductId = "1110",
                        Product2Id = "15",
                        Chance = 0.002,
                    },
                    new
                    {
                        Id = 130,
                        CampaignId = 5,
                        ProductId = "1110",
                        Product2Id = "16",
                        Chance = 0.002,
                    },
                    new
                    {
                        Id = 131,
                        CampaignId = 5,
                        ProductId = "213",
                        Product2Id = "16",
                        Chance = 0.002,
                    },
                    new
                    {
                        Id = 132,
                        CampaignId = 5,
                        ProductId = "2",
                        Product2Id = "3",
                        Chance = 0.002,
                    },
                    new
                    {
                        Id = 133,
                        CampaignId = 5,
                        ProductId = "2",
                        Product2Id = "17",
                        Chance = 0.002,
                    },
                    new
                    {
                        Id = 134,
                        CampaignId = 5,
                        ProductId = "2",
                        Product2Id = "15",
                        Chance = 0.002,
                    },
                    new
                    {
                        Id = 135,
                        CampaignId = 5,
                        ProductId = "2",
                        Product2Id = "16",
                        Chance = 0.002,
                    },
                    new
                    {
                        Id = 136,
                        CampaignId = 5,
                        ProductId = "1101",
                        Product2Id = "3",
                        Chance = 0.002,
                    },
                    new
                    {
                        Id = 137,
                        CampaignId = 5,
                        ProductId = "1101",
                        Product2Id = "17",
                        Chance = 0.002,
                    },
                    new
                    {
                        Id = 138,
                        CampaignId = 5,
                        ProductId = "1101",
                        Product2Id = "15",
                        Chance = 0.002,
                    },
                    new
                    {
                        Id = 139,
                        CampaignId = 5,
                        ProductId = "1101",
                        Product2Id = "1054",
                        Chance = 0.002,
                    },
                    new
                    {
                        Id = 140,
                        CampaignId = 5,
                        ProductId = "49",
                        Product2Id = "17",
                        Chance = 0.002,
                    },
                    new
                    {
                        Id = 141,
                        CampaignId = 5,
                        ProductId = "49",
                        Product2Id = "1054",
                        Chance = 0.002,
                    },
                    new
                    {
                        Id = 142,
                        CampaignId = 5,
                        ProductId = "802",
                        Product2Id = "1054",
                        Chance = 0.002,
                    },
                    new
                    {
                        Id = 143,
                        CampaignId = 5,
                        ProductId = "1055",
                        Product2Id = "1055",
                        Chance = 0.002,
                    },
                    new
                    {
                        Id = 144,
                        CampaignId = 5,
                        ProductId = "1110",
                        Product2Id = "46",
                        Chance = 0.002,
                    },
                    new
                    {
                        Id = 145,
                        CampaignId = 5,
                        ProductId = "1110",
                        Product2Id = "802",
                        Chance = 0.002,
                    },
                    new
                    {
                        Id = 146,
                        CampaignId = 5,
                        ProductId = "1110",
                        Product2Id = "1055",
                        Chance = 0.002,
                    },
                    new
                    {
                        Id = 147,
                        CampaignId = 5,
                        ProductId = "1072",
                        Product2Id = "1054",
                        Chance = 0.002,
                    },
                    new
                    {
                        Id = 148,
                        CampaignId = 5,
                        ProductId = "1073",
                        Product2Id = "1054",
                        Chance = 0.002,
                    },
                    new
                    {
                        Id = 149,
                        CampaignId = 5,
                        ProductId = "2",
                        Product2Id = "46",
                        Chance = 0.002,
                    },
                    new
                    {
                        Id = 150,
                        CampaignId = 5,
                        ProductId = "2",
                        Product2Id = "802",
                        Chance = 0.002,
                    },
                    new
                    {
                        Id = 151,
                        CampaignId = 5,
                        ProductId = "2",
                        Product2Id = "1055",
                        Chance = 0.002,
                    },
                    new
                    {
                        Id = 152,
                        CampaignId = 5,
                        ProductId = "702",
                        Product2Id = "1054",
                        Chance = 0.002,
                    },
                    new
                    {
                        Id = 153,
                        CampaignId = 5,
                        ProductId = "1101",
                        Product2Id = "46",
                        Chance = 0.002,
                    },
                    new
                    {
                        Id = 154,
                        CampaignId = 5,
                        ProductId = "1101",
                        Product2Id = "802",
                        Chance = 0.002,
                    },
                    new
                    {
                        Id = 155,
                        CampaignId = 5,
                        ProductId = "1101",
                        Product2Id = "1055",
                        Chance = 0.002,
                    },
                    new
                    {
                        Id = 156,
                        CampaignId = 5,
                        ProductId = "49",
                        Product2Id = "49",
                        Chance = 0.002,
                    },
                    new
                    {
                        Id = 157,
                        CampaignId = 5,
                        ProductId = "49",
                        Product2Id = "802",
                        Chance = 0.002,
                    },
                    new
                    {
                        Id = 158,
                        CampaignId = 5,
                        ProductId = "3",
                        Product2Id = "84",
                        Chance = 0.002,
                    },
                    new
                    {
                        Id = 159,
                        CampaignId = 5,
                        ProductId = "17",
                        Product2Id = "84",
                        Chance = 0.002,
                    },
                    new
                    {
                        Id = 160,
                        CampaignId = 5,
                        ProductId = "15",
                        Product2Id = "84",
                        Chance = 0.002,
                    },
                    new
                    {
                        Id = 161,
                        CampaignId = 5,
                        ProductId = "1054",
                        Product2Id = "84",
                        Chance = 0.002,
                    },
                    new
                    {
                        Id = 162,
                        CampaignId = 5,
                        ProductId = "1054",
                        Product2Id = "1084",
                        Chance = 0.002,
                    },
                    new
                    {
                        Id = 163,
                        CampaignId = 5,
                        ProductId = "1054",
                        Product2Id = "77",
                        Chance = 0.002,
                    },
                    new
                    {
                        Id = 164,
                        CampaignId = 5,
                        ProductId = "1054",
                        Product2Id = "547",
                        Chance = 0.002,
                    },
                    new
                    {
                        Id = 165,
                        CampaignId = 5,
                        ProductId = "682",
                        Product2Id = "3",
                        Chance = 0.001,
                    },
                    new
                    {
                        Id = 166,
                        CampaignId = 5,
                        ProductId = "682",
                        Product2Id = "17",
                        Chance = 0.001,
                    },
                    new
                    {
                        Id = 167,
                        CampaignId = 5,
                        ProductId = "682",
                        Product2Id = "15",
                        Chance = 0.001,
                    },
                    new
                    {
                        Id = 168,
                        CampaignId = 5,
                        ProductId = "682",
                        Product2Id = "1054",
                        Chance = 0.001,
                    },
                    new
                    {
                        Id = 169,
                        CampaignId = 5,
                        ProductId = "1110",
                        Product2Id = "1054",
                        Chance = 0.001,
                    },
                    new
                    {
                        Id = 170,
                        CampaignId = 5,
                        ProductId = "1072",
                        Product2Id = "3",
                        Chance = 0.001,
                    },
                    new
                    {
                        Id = 171,
                        CampaignId = 5,
                        ProductId = "1072",
                        Product2Id = "17",
                        Chance = 0.001,
                    },
                    new
                    {
                        Id = 172,
                        CampaignId = 5,
                        ProductId = "1072",
                        Product2Id = "15",
                        Chance = 0.001,
                    },
                    new
                    {
                        Id = 173,
                        CampaignId = 5,
                        ProductId = "1072",
                        Product2Id = "16",
                        Chance = 0.001,
                    },
                    new
                    {
                        Id = 174,
                        CampaignId = 5,
                        ProductId = "1073",
                        Product2Id = "3",
                        Chance = 0.001,
                    },
                    new
                    {
                        Id = 175,
                        CampaignId = 5,
                        ProductId = "1073",
                        Product2Id = "17",
                        Chance = 0.001,
                    },
                    new
                    {
                        Id = 176,
                        CampaignId = 5,
                        ProductId = "1073",
                        Product2Id = "15",
                        Chance = 0.001,
                    },
                    new
                    {
                        Id = 177,
                        CampaignId = 5,
                        ProductId = "1073",
                        Product2Id = "16",
                        Chance = 0.001,
                    },
                    new
                    {
                        Id = 178,
                        CampaignId = 5,
                        ProductId = "213",
                        Product2Id = "3",
                        Chance = 0.001,
                    },
                    new
                    {
                        Id = 179,
                        CampaignId = 5,
                        ProductId = "213",
                        Product2Id = "17",
                        Chance = 0.001,
                    },
                    new
                    {
                        Id = 180,
                        CampaignId = 5,
                        ProductId = "213",
                        Product2Id = "15",
                        Chance = 0.001,
                    },
                    new
                    {
                        Id = 181,
                        CampaignId = 5,
                        ProductId = "213",
                        Product2Id = "1054",
                        Chance = 0.001,
                    },
                    new
                    {
                        Id = 182,
                        CampaignId = 5,
                        ProductId = "2",
                        Product2Id = "1054",
                        Chance = 0.001,
                    },
                    new
                    {
                        Id = 183,
                        CampaignId = 5,
                        ProductId = "702",
                        Product2Id = "3",
                        Chance = 0.001,
                    },
                    new
                    {
                        Id = 184,
                        CampaignId = 5,
                        ProductId = "702",
                        Product2Id = "17",
                        Chance = 0.001,
                    },
                    new
                    {
                        Id = 185,
                        CampaignId = 5,
                        ProductId = "702",
                        Product2Id = "15",
                        Chance = 0.001,
                    },
                    new
                    {
                        Id = 186,
                        CampaignId = 5,
                        ProductId = "702",
                        Product2Id = "16",
                        Chance = 0.001,
                    },
                    new
                    {
                        Id = 187,
                        CampaignId = 5,
                        ProductId = "49",
                        Product2Id = "46",
                        Chance = 0.001,
                    },
                    new
                    {
                        Id = 188,
                        CampaignId = 5,
                        ProductId = "49",
                        Product2Id = "1055",
                        Chance = 0.001,
                    },
                    new
                    {
                        Id = 189,
                        CampaignId = 5,
                        ProductId = "46",
                        Product2Id = "46",
                        Chance = 0.001,
                    },
                    new
                    {
                        Id = 190,
                        CampaignId = 5,
                        ProductId = "46",
                        Product2Id = "802",
                        Chance = 0.001,
                    },
                    new
                    {
                        Id = 191,
                        CampaignId = 5,
                        ProductId = "46",
                        Product2Id = "1055",
                        Chance = 0.001,
                    },
                    new
                    {
                        Id = 192,
                        CampaignId = 5,
                        ProductId = "802",
                        Product2Id = "802",
                        Chance = 0.001,
                    },
                    new
                    {
                        Id = 193,
                        CampaignId = 5,
                        ProductId = "802",
                        Product2Id = "1055",
                        Chance = 0.001,
                    },
                    new
                    {
                        Id = 194,
                        CampaignId = 5,
                        ProductId = "3",
                        Product2Id = "1084",
                        Chance = 0.001,
                    },
                    new
                    {
                        Id = 195,
                        CampaignId = 5,
                        ProductId = "3",
                        Product2Id = "77",
                        Chance = 0.001,
                    },
                    new
                    {
                        Id = 196,
                        CampaignId = 5,
                        ProductId = "3",
                        Product2Id = "547",
                        Chance = 0.001,
                    },
                    new
                    {
                        Id = 197,
                        CampaignId = 5,
                        ProductId = "17",
                        Product2Id = "1084",
                        Chance = 0.001,
                    },
                    new
                    {
                        Id = 198,
                        CampaignId = 5,
                        ProductId = "17",
                        Product2Id = "77",
                        Chance = 0.001,
                    },
                    new
                    {
                        Id = 199,
                        CampaignId = 5,
                        ProductId = "17",
                        Product2Id = "547",
                        Chance = 0.001,
                    },
                    new
                    {
                        Id = 200,
                        CampaignId = 5,
                        ProductId = "15",
                        Product2Id = "1084",
                        Chance = 0.001,
                    },
                    new
                    {
                        Id = 201,
                        CampaignId = 5,
                        ProductId = "15",
                        Product2Id = "77",
                        Chance = 0.001,
                    },
                    new
                    {
                        Id = 202,
                        CampaignId = 5,
                        ProductId = "15",
                        Product2Id = "547",
                        Chance = 0.001,
                    },
                    new
                    {
                        Id = 203,
                        CampaignId = 5,
                        ProductId = "16",
                        Product2Id = "84",
                        Chance = 0.001,
                    },
                    new
                    {
                        Id = 204,
                        CampaignId = 5,
                        ProductId = "16",
                        Product2Id = "1084",
                        Chance = 0.001,
                    },
                    new
                    {
                        Id = 205,
                        CampaignId = 5,
                        ProductId = "16",
                        Product2Id = "77",
                        Chance = 0.001,
                    },
                    new
                    {
                        Id = 206,
                        CampaignId = 5,
                        ProductId = "16",
                        Product2Id = "547",
                        Chance = 0.001,
                    },
                    new
                    {
                        Id = 208,
                        CampaignId = 6,
                        ProductId = "682",
                        Product2Id = "3",
                        Chance = 0.001,
                    },
                    new
                    {
                        Id = 209,
                        CampaignId = 6,
                        ProductId = "682",
                        Product2Id = "17",
                        Chance = 0.001,
                    },
                    new
                    {
                        Id = 210,
                        CampaignId = 6,
                        ProductId = "682",
                        Product2Id = "15",
                        Chance = 0.001,
                    },
                    new
                    {
                        Id = 211,
                        CampaignId = 6,
                        ProductId = "682",
                        Product2Id = "1054",
                        Chance = 0.001,
                    },
                    new
                    {
                        Id = 212,
                        CampaignId = 6,
                        ProductId = "1110",
                        Product2Id = "1054",
                        Chance = 0.001,
                    },
                    new
                    {
                        Id = 213,
                        CampaignId = 6,
                        ProductId = "1072",
                        Product2Id = "3",
                        Chance = 0.001,
                    },
                    new
                    {
                        Id = 214,
                        CampaignId = 6,
                        ProductId = "1072",
                        Product2Id = "17",
                        Chance = 0.001,
                    },
                    new
                    {
                        Id = 215,
                        CampaignId = 6,
                        ProductId = "1072",
                        Product2Id = "15",
                        Chance = 0.001,
                    },
                    new
                    {
                        Id = 216,
                        CampaignId = 6,
                        ProductId = "1072",
                        Product2Id = "16",
                        Chance = 0.001,
                    },
                    new
                    {
                        Id = 217,
                        CampaignId = 6,
                        ProductId = "1073",
                        Product2Id = "3",
                        Chance = 0.001,
                    },
                    new
                    {
                        Id = 218,
                        CampaignId = 6,
                        ProductId = "1073",
                        Product2Id = "17",
                        Chance = 0.001,
                    },
                    new
                    {
                        Id = 219,
                        CampaignId = 6,
                        ProductId = "1073",
                        Product2Id = "15",
                        Chance = 0.001,
                    },
                    new
                    {
                        Id = 220,
                        CampaignId = 6,
                        ProductId = "1073",
                        Product2Id = "16",
                        Chance = 0.001,
                    },
                    new
                    {
                        Id = 221,
                        CampaignId = 6,
                        ProductId = "213",
                        Product2Id = "3",
                        Chance = 0.001,
                    },
                    new
                    {
                        Id = 222,
                        CampaignId = 6,
                        ProductId = "213",
                        Product2Id = "17",
                        Chance = 0.001,
                    },
                    new
                    {
                        Id = 223,
                        CampaignId = 6,
                        ProductId = "213",
                        Product2Id = "15",
                        Chance = 0.001,
                    },
                    new
                    {
                        Id = 224,
                        CampaignId = 6,
                        ProductId = "213",
                        Product2Id = "1054",
                        Chance = 0.001,
                    },
                    new
                    {
                        Id = 225,
                        CampaignId = 6,
                        ProductId = "2",
                        Product2Id = "1054",
                        Chance = 0.001,
                    },
                    new
                    {
                        Id = 226,
                        CampaignId = 6,
                        ProductId = "702",
                        Product2Id = "3",
                        Chance = 0.001,
                    },
                    new
                    {
                        Id = 227,
                        CampaignId = 6,
                        ProductId = "702",
                        Product2Id = "17",
                        Chance = 0.001,
                    },
                    new
                    {
                        Id = 228,
                        CampaignId = 6,
                        ProductId = "702",
                        Product2Id = "15",
                        Chance = 0.001,
                    },
                    new
                    {
                        Id = 229,
                        CampaignId = 6,
                        ProductId = "702",
                        Product2Id = "16",
                        Chance = 0.001,
                    },
                    new
                    {
                        Id = 230,
                        CampaignId = 6,
                        ProductId = "49",
                        Product2Id = "46",
                        Chance = 0.001,
                    },
                    new
                    {
                        Id = 231,
                        CampaignId = 6,
                        ProductId = "49",
                        Product2Id = "1055",
                        Chance = 0.001,
                    },
                    new
                    {
                        Id = 232,
                        CampaignId = 6,
                        ProductId = "46",
                        Product2Id = "46",
                        Chance = 0.001,
                    },
                    new
                    {
                        Id = 233,
                        CampaignId = 6,
                        ProductId = "46",
                        Product2Id = "802",
                        Chance = 0.001,
                    },
                    new
                    {
                        Id = 234,
                        CampaignId = 6,
                        ProductId = "46",
                        Product2Id = "1055",
                        Chance = 0.001,
                    },
                    new
                    {
                        Id = 235,
                        CampaignId = 6,
                        ProductId = "802",
                        Product2Id = "802",
                        Chance = 0.001,
                    },
                    new
                    {
                        Id = 236,
                        CampaignId = 6,
                        ProductId = "802",
                        Product2Id = "1055",
                        Chance = 0.001,
                    },
                    new
                    {
                        Id = 237,
                        CampaignId = 6,
                        ProductId = "3",
                        Product2Id = "1084",
                        Chance = 0.001,
                    },
                    new
                    {
                        Id = 238,
                        CampaignId = 6,
                        ProductId = "3",
                        Product2Id = "77",
                        Chance = 0.001,
                    },
                    new
                    {
                        Id = 239,
                        CampaignId = 6,
                        ProductId = "3",
                        Product2Id = "547",
                        Chance = 0.001,
                    },
                    new
                    {
                        Id = 240,
                        CampaignId = 6,
                        ProductId = "17",
                        Product2Id = "1084",
                        Chance = 0.001,
                    },
                    new
                    {
                        Id = 241,
                        CampaignId = 6,
                        ProductId = "17",
                        Product2Id = "77",
                        Chance = 0.001,
                    },
                    new
                    {
                        Id = 242,
                        CampaignId = 6,
                        ProductId = "17",
                        Product2Id = "547",
                        Chance = 0.001,
                    },
                    new
                    {
                        Id = 243,
                        CampaignId = 6,
                        ProductId = "15",
                        Product2Id = "1084",
                        Chance = 0.001,
                    },
                    new
                    {
                        Id = 244,
                        CampaignId = 6,
                        ProductId = "15",
                        Product2Id = "77",
                        Chance = 0.001,
                    },
                    new
                    {
                        Id = 245,
                        CampaignId = 6,
                        ProductId = "15",
                        Product2Id = "547",
                        Chance = 0.001,
                    },
                    new
                    {
                        Id = 246,
                        CampaignId = 6,
                        ProductId = "16",
                        Product2Id = "84",
                        Chance = 0.001,
                    },
                    new
                    {
                        Id = 247,
                        CampaignId = 6,
                        ProductId = "16",
                        Product2Id = "1084",
                        Chance = 0.001,
                    },
                    new
                    {
                        Id = 248,
                        CampaignId = 6,
                        ProductId = "16",
                        Product2Id = "77",
                        Chance = 0.001,
                    },
                    new
                    {
                        Id = 249,
                        CampaignId = 6,
                        ProductId = "16",
                        Product2Id = "547",
                        Chance = 0.001,
                    },
                    new
                    {
                        Id = 250,
                        CampaignId = 6,
                        ProductId = "1110",
                        Product2Id = "46",
                        Chance = 0.002,
                    },
                    new
                    {
                        Id = 251,
                        CampaignId = 6,
                        ProductId = "1110",
                        Product2Id = "802",
                        Chance = 0.002,
                    },
                    new
                    {
                        Id = 252,
                        CampaignId = 6,
                        ProductId = "1110",
                        Product2Id = "1055",
                        Chance = 0.002,
                    },
                    new
                    {
                        Id = 253,
                        CampaignId = 6,
                        ProductId = "1072",
                        Product2Id = "1054",
                        Chance = 0.002,
                    },
                    new
                    {
                        Id = 254,
                        CampaignId = 6,
                        ProductId = "1073",
                        Product2Id = "1054",
                        Chance = 0.002,
                    },
                    new
                    {
                        Id = 255,
                        CampaignId = 6,
                        ProductId = "2",
                        Product2Id = "46",
                        Chance = 0.002,
                    },
                    new
                    {
                        Id = 256,
                        CampaignId = 6,
                        ProductId = "2",
                        Product2Id = "802",
                        Chance = 0.002,
                    },
                    new
                    {
                        Id = 257,
                        CampaignId = 6,
                        ProductId = "2",
                        Product2Id = "1055",
                        Chance = 0.002,
                    },
                    new
                    {
                        Id = 258,
                        CampaignId = 6,
                        ProductId = "702",
                        Product2Id = "1054",
                        Chance = 0.002,
                    },
                    new
                    {
                        Id = 259,
                        CampaignId = 6,
                        ProductId = "1101",
                        Product2Id = "46",
                        Chance = 0.002,
                    },
                    new
                    {
                        Id = 260,
                        CampaignId = 6,
                        ProductId = "1101",
                        Product2Id = "802",
                        Chance = 0.002,
                    },
                    new
                    {
                        Id = 261,
                        CampaignId = 6,
                        ProductId = "1101",
                        Product2Id = "1055",
                        Chance = 0.002,
                    },
                    new
                    {
                        Id = 262,
                        CampaignId = 6,
                        ProductId = "49",
                        Product2Id = "49",
                        Chance = 0.002,
                    },
                    new
                    {
                        Id = 263,
                        CampaignId = 6,
                        ProductId = "49",
                        Product2Id = "802",
                        Chance = 0.002,
                    },
                    new
                    {
                        Id = 264,
                        CampaignId = 6,
                        ProductId = "3",
                        Product2Id = "84",
                        Chance = 0.002,
                    },
                    new
                    {
                        Id = 265,
                        CampaignId = 6,
                        ProductId = "17",
                        Product2Id = "84",
                        Chance = 0.002,
                    },
                    new
                    {
                        Id = 266,
                        CampaignId = 6,
                        ProductId = "15",
                        Product2Id = "84",
                        Chance = 0.002,
                    },
                    new
                    {
                        Id = 267,
                        CampaignId = 6,
                        ProductId = "1054",
                        Product2Id = "84",
                        Chance = 0.002,
                    },
                    new
                    {
                        Id = 268,
                        CampaignId = 6,
                        ProductId = "1054",
                        Product2Id = "1084",
                        Chance = 0.002,
                    },
                    new
                    {
                        Id = 269,
                        CampaignId = 6,
                        ProductId = "1054",
                        Product2Id = "77",
                        Chance = 0.002,
                    },
                    new
                    {
                        Id = 270,
                        CampaignId = 6,
                        ProductId = "1054",
                        Product2Id = "547",
                        Chance = 0.002,
                    },
                    new
                    {
                        Id = 271,
                        CampaignId = 6,
                        ProductId = "682",
                        Product2Id = "16",
                        Chance = 0.002,
                    },
                    new
                    {
                        Id = 272,
                        CampaignId = 6,
                        ProductId = "1110",
                        Product2Id = "3",
                        Chance = 0.002,
                    },
                    new
                    {
                        Id = 273,
                        CampaignId = 6,
                        ProductId = "1110",
                        Product2Id = "17",
                        Chance = 0.002,
                    },
                    new
                    {
                        Id = 274,
                        CampaignId = 6,
                        ProductId = "1110",
                        Product2Id = "15",
                        Chance = 0.002,
                    },
                    new
                    {
                        Id = 275,
                        CampaignId = 6,
                        ProductId = "1110",
                        Product2Id = "16",
                        Chance = 0.002,
                    },
                    new
                    {
                        Id = 276,
                        CampaignId = 6,
                        ProductId = "213",
                        Product2Id = "16",
                        Chance = 0.002,
                    },
                    new
                    {
                        Id = 277,
                        CampaignId = 6,
                        ProductId = "2",
                        Product2Id = "3",
                        Chance = 0.002,
                    },
                    new
                    {
                        Id = 278,
                        CampaignId = 6,
                        ProductId = "2",
                        Product2Id = "17",
                        Chance = 0.002,
                    },
                    new
                    {
                        Id = 279,
                        CampaignId = 6,
                        ProductId = "2",
                        Product2Id = "15",
                        Chance = 0.002,
                    },
                    new
                    {
                        Id = 280,
                        CampaignId = 6,
                        ProductId = "2",
                        Product2Id = "16",
                        Chance = 0.002,
                    },
                    new
                    {
                        Id = 281,
                        CampaignId = 6,
                        ProductId = "1101",
                        Product2Id = "3",
                        Chance = 0.002,
                    },
                    new
                    {
                        Id = 282,
                        CampaignId = 6,
                        ProductId = "1101",
                        Product2Id = "17",
                        Chance = 0.002,
                    },
                    new
                    {
                        Id = 283,
                        CampaignId = 6,
                        ProductId = "1101",
                        Product2Id = "15",
                        Chance = 0.002,
                    },
                    new
                    {
                        Id = 284,
                        CampaignId = 6,
                        ProductId = "1101",
                        Product2Id = "1054",
                        Chance = 0.002,
                    },
                    new
                    {
                        Id = 285,
                        CampaignId = 6,
                        ProductId = "49",
                        Product2Id = "17",
                        Chance = 0.002,
                    },
                    new
                    {
                        Id = 286,
                        CampaignId = 6,
                        ProductId = "49",
                        Product2Id = "1054",
                        Chance = 0.002,
                    },
                    new
                    {
                        Id = 287,
                        CampaignId = 6,
                        ProductId = "802",
                        Product2Id = "1054",
                        Chance = 0.002,
                    },
                    new
                    {
                        Id = 288,
                        CampaignId = 6,
                        ProductId = "1055",
                        Product2Id = "1055",
                        Chance = 0.002,
                    },
                    new
                    {
                        Id = 289,
                        CampaignId = 6,
                        ProductId = "682",
                        Product2Id = "46",
                        Chance = 0.004,
                    },
                    new
                    {
                        Id = 290,
                        CampaignId = 6,
                        ProductId = "682",
                        Product2Id = "802",
                        Chance = 0.004,
                    },
                    new
                    {
                        Id = 291,
                        CampaignId = 6,
                        ProductId = "682",
                        Product2Id = "1055",
                        Chance = 0.004,
                    },
                    new
                    {
                        Id = 292,
                        CampaignId = 6,
                        ProductId = "1110",
                        Product2Id = "2",
                        Chance = 0.004,
                    },
                    new
                    {
                        Id = 293,
                        CampaignId = 6,
                        ProductId = "1110",
                        Product2Id = "1101",
                        Chance = 0.004,
                    },
                    new
                    {
                        Id = 294,
                        CampaignId = 6,
                        ProductId = "1110",
                        Product2Id = "49",
                        Chance = 0.004,
                    },
                    new
                    {
                        Id = 295,
                        CampaignId = 6,
                        ProductId = "1072",
                        Product2Id = "46",
                        Chance = 0.004,
                    },
                    new
                    {
                        Id = 296,
                        CampaignId = 6,
                        ProductId = "1072",
                        Product2Id = "1055",
                        Chance = 0.004,
                    },
                    new
                    {
                        Id = 297,
                        CampaignId = 6,
                        ProductId = "1073",
                        Product2Id = "46",
                        Chance = 0.004,
                    },
                    new
                    {
                        Id = 298,
                        CampaignId = 6,
                        ProductId = "1073",
                        Product2Id = "802",
                        Chance = 0.004,
                    },
                    new
                    {
                        Id = 299,
                        CampaignId = 6,
                        ProductId = "1073",
                        Product2Id = "1055",
                        Chance = 0.004,
                    },
                    new
                    {
                        Id = 300,
                        CampaignId = 6,
                        ProductId = "213",
                        Product2Id = "49",
                        Chance = 0.004,
                    },
                    new
                    {
                        Id = 301,
                        CampaignId = 6,
                        ProductId = "213",
                        Product2Id = "46",
                        Chance = 0.004,
                    },
                    new
                    {
                        Id = 302,
                        CampaignId = 6,
                        ProductId = "213",
                        Product2Id = "802",
                        Chance = 0.004,
                    },
                    new
                    {
                        Id = 303,
                        CampaignId = 6,
                        ProductId = "213",
                        Product2Id = "1055",
                        Chance = 0.004,
                    },
                    new
                    {
                        Id = 304,
                        CampaignId = 6,
                        ProductId = "2",
                        Product2Id = "2",
                        Chance = 0.004,
                    },
                    new
                    {
                        Id = 305,
                        CampaignId = 6,
                        ProductId = "2",
                        Product2Id = "1101",
                        Chance = 0.004,
                    },
                    new
                    {
                        Id = 306,
                        CampaignId = 6,
                        ProductId = "2",
                        Product2Id = "49",
                        Chance = 0.004,
                    },
                    new
                    {
                        Id = 307,
                        CampaignId = 6,
                        ProductId = "702",
                        Product2Id = "46",
                        Chance = 0.004,
                    },
                    new
                    {
                        Id = 308,
                        CampaignId = 6,
                        ProductId = "702",
                        Product2Id = "802",
                        Chance = 0.004,
                    },
                    new
                    {
                        Id = 309,
                        CampaignId = 6,
                        ProductId = "702",
                        Product2Id = "1055",
                        Chance = 0.004,
                    },
                    new
                    {
                        Id = 310,
                        CampaignId = 6,
                        ProductId = "1101",
                        Product2Id = "1101",
                        Chance = 0.004,
                    },
                    new
                    {
                        Id = 311,
                        CampaignId = 6,
                        ProductId = "1101",
                        Product2Id = "49",
                        Chance = 0.004,
                    },
                    new
                    {
                        Id = 312,
                        CampaignId = 6,
                        ProductId = "46",
                        Product2Id = "1084",
                        Chance = 0.004,
                    },
                    new
                    {
                        Id = 313,
                        CampaignId = 6,
                        ProductId = "46",
                        Product2Id = "77",
                        Chance = 0.004,
                    },
                    new
                    {
                        Id = 314,
                        CampaignId = 6,
                        ProductId = "46",
                        Product2Id = "547",
                        Chance = 0.004,
                    },
                    new
                    {
                        Id = 315,
                        CampaignId = 6,
                        ProductId = "802",
                        Product2Id = "1084",
                        Chance = 0.004,
                    },
                    new
                    {
                        Id = 316,
                        CampaignId = 6,
                        ProductId = "802",
                        Product2Id = "547",
                        Chance = 0.004,
                    },
                    new
                    {
                        Id = 317,
                        CampaignId = 6,
                        ProductId = "1055",
                        Product2Id = "1084",
                        Chance = 0.004,
                    },
                    new
                    {
                        Id = 318,
                        CampaignId = 6,
                        ProductId = "1055",
                        Product2Id = "77",
                        Chance = 0.004,
                    },
                    new
                    {
                        Id = 319,
                        CampaignId = 6,
                        ProductId = "1055",
                        Product2Id = "547",
                        Chance = 0.004,
                    },
                    new
                    {
                        Id = 320,
                        CampaignId = 6,
                        ProductId = "682",
                        Product2Id = "1073",
                        Chance = 0.004,
                    },
                    new
                    {
                        Id = 321,
                        CampaignId = 6,
                        ProductId = "682",
                        Product2Id = "213",
                        Chance = 0.004,
                    },
                    new
                    {
                        Id = 322,
                        CampaignId = 6,
                        ProductId = "1110",
                        Product2Id = "1073",
                        Chance = 0.004,
                    },
                    new
                    {
                        Id = 323,
                        CampaignId = 6,
                        ProductId = "1072",
                        Product2Id = "1073",
                        Chance = 0.004,
                    },
                    new
                    {
                        Id = 324,
                        CampaignId = 6,
                        ProductId = "1072",
                        Product2Id = "213",
                        Chance = 0.004,
                    },
                    new
                    {
                        Id = 325,
                        CampaignId = 6,
                        ProductId = "1073",
                        Product2Id = "702",
                        Chance = 0.004,
                    },
                    new
                    {
                        Id = 326,
                        CampaignId = 6,
                        ProductId = "213",
                        Product2Id = "702",
                        Chance = 0.004,
                    },
                    new
                    {
                        Id = 327,
                        CampaignId = 6,
                        ProductId = "682",
                        Product2Id = "1110",
                        Chance = 0.005,
                    },
                    new
                    {
                        Id = 328,
                        CampaignId = 6,
                        ProductId = "682",
                        Product2Id = "1101",
                        Chance = 0.005,
                    },
                    new
                    {
                        Id = 329,
                        CampaignId = 6,
                        ProductId = "1110",
                        Product2Id = "1110",
                        Chance = 0.005,
                    },
                    new
                    {
                        Id = 330,
                        CampaignId = 6,
                        ProductId = "1110",
                        Product2Id = "213",
                        Chance = 0.005,
                    },
                    new
                    {
                        Id = 331,
                        CampaignId = 6,
                        ProductId = "1110",
                        Product2Id = "702",
                        Chance = 0.005,
                    },
                    new
                    {
                        Id = 332,
                        CampaignId = 6,
                        ProductId = "1110",
                        Product2Id = "1084",
                        Chance = 0.005,
                    },
                    new
                    {
                        Id = 333,
                        CampaignId = 6,
                        ProductId = "1072",
                        Product2Id = "2",
                        Chance = 0.005,
                    },
                    new
                    {
                        Id = 334,
                        CampaignId = 6,
                        ProductId = "1072",
                        Product2Id = "1101",
                        Chance = 0.005,
                    },
                    new
                    {
                        Id = 335,
                        CampaignId = 6,
                        ProductId = "1073",
                        Product2Id = "2",
                        Chance = 0.005,
                    },
                    new
                    {
                        Id = 336,
                        CampaignId = 6,
                        ProductId = "1073",
                        Product2Id = "1101",
                        Chance = 0.005,
                    },
                    new
                    {
                        Id = 337,
                        CampaignId = 6,
                        ProductId = "1073",
                        Product2Id = "49",
                        Chance = 0.005,
                    },
                    new
                    {
                        Id = 338,
                        CampaignId = 6,
                        ProductId = "213",
                        Product2Id = "2",
                        Chance = 0.005,
                    },
                    new
                    {
                        Id = 339,
                        CampaignId = 6,
                        ProductId = "213",
                        Product2Id = "1101",
                        Chance = 0.005,
                    },
                    new
                    {
                        Id = 340,
                        CampaignId = 6,
                        ProductId = "2",
                        Product2Id = "547",
                        Chance = 0.005,
                    },
                    new
                    {
                        Id = 341,
                        CampaignId = 6,
                        ProductId = "1101",
                        Product2Id = "77",
                        Chance = 0.005,
                    },
                    new
                    {
                        Id = 342,
                        CampaignId = 6,
                        ProductId = "682",
                        Product2Id = "1072",
                        Chance = 0.013,
                    },
                    new
                    {
                        Id = 343,
                        CampaignId = 6,
                        ProductId = "682",
                        Product2Id = "702",
                        Chance = 0.013,
                    },
                    new
                    {
                        Id = 344,
                        CampaignId = 6,
                        ProductId = "1110",
                        Product2Id = "1072",
                        Chance = 0.013,
                    },
                    new
                    {
                        Id = 345,
                        CampaignId = 6,
                        ProductId = "1110",
                        Product2Id = "84",
                        Chance = 0.013,
                    },
                    new
                    {
                        Id = 346,
                        CampaignId = 6,
                        ProductId = "1110",
                        Product2Id = "77",
                        Chance = 0.013,
                    },
                    new
                    {
                        Id = 347,
                        CampaignId = 6,
                        ProductId = "1110",
                        Product2Id = "547",
                        Chance = 0.013,
                    },
                    new
                    {
                        Id = 348,
                        CampaignId = 6,
                        ProductId = "1072",
                        Product2Id = "702",
                        Chance = 0.013,
                    },
                    new
                    {
                        Id = 349,
                        CampaignId = 6,
                        ProductId = "1072",
                        Product2Id = "84",
                        Chance = 0.013,
                    },
                    new
                    {
                        Id = 350,
                        CampaignId = 6,
                        ProductId = "1072",
                        Product2Id = "1084",
                        Chance = 0.013,
                    },
                    new
                    {
                        Id = 351,
                        CampaignId = 6,
                        ProductId = "1072",
                        Product2Id = "77",
                        Chance = 0.013,
                    },
                    new
                    {
                        Id = 352,
                        CampaignId = 6,
                        ProductId = "1072",
                        Product2Id = "547",
                        Chance = 0.013,
                    },
                    new
                    {
                        Id = 353,
                        CampaignId = 6,
                        ProductId = "2",
                        Product2Id = "84",
                        Chance = 0.013,
                    },
                    new
                    {
                        Id = 354,
                        CampaignId = 6,
                        ProductId = "2",
                        Product2Id = "77",
                        Chance = 0.013,
                    },
                    new
                    {
                        Id = 355,
                        CampaignId = 6,
                        ProductId = "702",
                        Product2Id = "702",
                        Chance = 0.013,
                    },
                    new
                    {
                        Id = 356,
                        CampaignId = 6,
                        ProductId = "702",
                        Product2Id = "547",
                        Chance = 0.013,
                    },
                    new
                    {
                        Id = 357,
                        CampaignId = 6,
                        ProductId = "1101",
                        Product2Id = "84",
                        Chance = 0.013,
                    },
                    new
                    {
                        Id = 358,
                        CampaignId = 6,
                        ProductId = "1072",
                        Product2Id = "802",
                        Chance = 0.018,
                    },
                    new
                    {
                        Id = 359,
                        CampaignId = 6,
                        ProductId = "682",
                        Product2Id = "2",
                        Chance = 0.019,
                    },
                    new
                    {
                        Id = 360,
                        CampaignId = 6,
                        ProductId = "682",
                        Product2Id = "49",
                        Chance = 0.019,
                    },
                    new
                    {
                        Id = 361,
                        CampaignId = 6,
                        ProductId = "1072",
                        Product2Id = "49",
                        Chance = 0.019,
                    },
                    new
                    {
                        Id = 362,
                        CampaignId = 6,
                        ProductId = "2",
                        Product2Id = "702",
                        Chance = 0.019,
                    },
                    new
                    {
                        Id = 363,
                        CampaignId = 6,
                        ProductId = "2",
                        Product2Id = "1084",
                        Chance = 0.019,
                    },
                    new
                    {
                        Id = 364,
                        CampaignId = 6,
                        ProductId = "702",
                        Product2Id = "1101",
                        Chance = 0.019,
                    },
                    new
                    {
                        Id = 365,
                        CampaignId = 6,
                        ProductId = "702",
                        Product2Id = "49",
                        Chance = 0.019,
                    },
                    new
                    {
                        Id = 366,
                        CampaignId = 6,
                        ProductId = "1101",
                        Product2Id = "1084",
                        Chance = 0.019,
                    },
                    new
                    {
                        Id = 367,
                        CampaignId = 6,
                        ProductId = "1101",
                        Product2Id = "547",
                        Chance = 0.019,
                    },
                    new
                    {
                        Id = 368,
                        CampaignId = 6,
                        ProductId = "49",
                        Product2Id = "1084",
                        Chance = 0.019,
                    },
                    new
                    {
                        Id = 369,
                        CampaignId = 6,
                        ProductId = "49",
                        Product2Id = "77",
                        Chance = 0.019,
                    },
                    new
                    {
                        Id = 370,
                        CampaignId = 6,
                        ProductId = "49",
                        Product2Id = "547",
                        Chance = 0.019,
                    },
                    new
                    {
                        Id = 371,
                        CampaignId = 6,
                        ProductId = "46",
                        Product2Id = "84",
                        Chance = 0.019,
                    },
                    new
                    {
                        Id = 372,
                        CampaignId = 6,
                        ProductId = "802",
                        Product2Id = "84",
                        Chance = 0.019,
                    },
                    new
                    {
                        Id = 373,
                        CampaignId = 6,
                        ProductId = "802",
                        Product2Id = "77",
                        Chance = 0.019,
                    },
                    new
                    {
                        Id = 374,
                        CampaignId = 6,
                        ProductId = "1055",
                        Product2Id = "84",
                        Chance = 0.019,
                    },
                    new
                    {
                        Id = 375,
                        CampaignId = 6,
                        ProductId = "702",
                        Product2Id = "1084",
                        Chance = 0.027,
                    },
                    new
                    {
                        Id = 376,
                        CampaignId = 6,
                        ProductId = "49",
                        Product2Id = "84",
                        Chance = 0.027,
                    },
                    new
                    {
                        Id = 377,
                        CampaignId = 6,
                        ProductId = "702",
                        Product2Id = "84",
                        Chance = 0.033,
                    },
                    new
                    {
                        Id = 378,
                        CampaignId = 6,
                        ProductId = "702",
                        Product2Id = "77",
                        Chance = 0.033,
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
    Duo,
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

    public ProductDb? Product2 { get; set; }

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
