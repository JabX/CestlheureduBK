using CestlheureduBK.Common;
using CestlheureduBK.Model;
using Microsoft.EntityFrameworkCore;

namespace CestlheureduBK.Services;

public class GetDataService(BKDbContext context)
{
    private readonly Dictionary<string, Dictionary<string, double>> _burgerMystereProbabilites = new()
    {
        ["2024-09"] = new()
        {
            ["702"] = 0.14,
            ["463"] = 0.10,
            ["2"] = 0.12,
            ["49"] = 0.12,
            ["447"] = 0.11,
            ["953"] = 0.07,
            ["46"] = 0.10,
            ["802"] = 0.07,
            ["691"] = 0.05,
            ["411"] = 0.05,
            ["17"] = 0.04,
            ["15"] = 0.03
        },
        ["2025-03"] = new()
        {
            ["2"] = 0.16,
            ["1101"] = 0.16,
            ["702"] = 0.14,
            ["49"] = 0.12,
            ["46"] = 0.11,
            ["802"] = 0.11,
            ["1110"] = 0.05,
            ["1055"] = 0.04,
            ["1054"] = 0.03,
            ["213"] = 0.03,
            ["17"] = 0.03,
            ["15"] = 0.02
        }
    };

    private readonly Dictionary<string, Dictionary<string, double>> _veggieMystereProbabilites = new()
    {
        ["2024-09"] = new()
        {
            ["544"] = 0.26,
            ["664"] = 0.26,
            ["666"] = 0.24,
            ["801"] = 0.24
        },
        ["2025-03"] = new()
        {
            ["664"] = 0.36,
            ["666"] = 0.32,
            ["801"] = 0.32
        }
    };

    public async Task<CatalogueDisplay[]> GetCatalogue(string codeRestaurant)
    {
        return
        [
            .. await context.ProductsRestaurants
                .AsSingleQuery()
                .Where(prd => prd.Restaurant.Id == codeRestaurant && prd.Active && prd.Product.AvailableInCatalogue && prd.Price > 0)
                .Select(prd => new CatalogueDisplay(
                    "Produit",
                    prd.Product.Name,
                    prd.Product.Image,
                    prd.Price,
                    prd.Product.Energy ?? 0,
                    prd.Product.Snacks.Select(s => new SnackAmountDisplay(s.Snack.Name, s.Amount)),
                    prd.Product.Categories.OrderBy(c => c.SubCategory).ThenBy(c => c.Name).Select(c => new CategorieDisplay(c.Id, c.Name, c.SubCategory))))
                .ToArrayAsync(),
            .. await context.MenusRestaurants
                .AsSingleQuery()
                .Where(men => men.Restaurant.Id == codeRestaurant && men.Active && men.Menu.AvailableInCatalogue && men.Price > 0)
                .Select(men => new CatalogueDisplay(
                    "Menu",
                    men.Menu.Name,
                    men.Menu.Image,
                    men.Price,
                    men.Menu.Steps.Sum(s => s.DefaultProduct != null && s.DefaultProduct.Energy != null ? s.DefaultProduct.Energy.Value : 0),
                    men.Menu.Snacks.Select(s => new SnackAmountDisplay(s.Snack.Name, s.Amount)),
                    men.Menu.Categories.OrderBy(c => c.SubCategory).ThenBy(c => c.Name).Select(c => new CategorieDisplay(c.Id, c.Name, c.SubCategory))))
                .ToArrayAsync()
        ];
    }

    public async Task<OfferDisplay[]> GetOffers(string codeRestaurant)
    {
        return
        [
            .. await context.ProductsRestaurants
                .AsSingleQuery()
                .Where(p =>
                    p.Restaurant.Id == codeRestaurant
                    && p.Active
                    && context.Offers.Any(o =>
                        o.Promotion.Products.Any(pp => p.Product.Id == pp.Id)
                        && context.PromotionsRestaurants.Any(pr => pr.Restaurant.Id == codeRestaurant && pr.Promotion.Id == o.Promotion.Id && pr.Active)))
                .Select(prd => new OfferDisplay(
                    "Produit",
                    prd.Product.Name,
                    prd.Product.Image,
                    context.Offers.Single(o => o.Promotion.Products.Any(pp => pp.Id == prd.Product.Id)).Points,
                    prd.Price,
                    prd.Product.Energy ?? 0,
                    prd.Product.Snacks.Select(s => new SnackAmountDisplay(s.Snack.Name, s.Amount)),
                    prd.Product.Categories.OrderBy(c => c.SubCategory).ThenBy(c => c.Name).Select(c => new CategorieDisplay(c.Id, c.Name, c.SubCategory))))
                .ToArrayAsync()
,
            .. await context.MenusRestaurants
                .AsSingleQuery()
                .Where(p =>
                    p.Restaurant.Id == codeRestaurant
                    && p.Active
                    && context.Offers.Any(o =>
                        o.Promotion.Menus.Any(pp => p.Menu.Id == pp.Id)
                        && context.PromotionsRestaurants.Any(pr => pr.Restaurant.Id == codeRestaurant && pr.Promotion.Id == o.Promotion.Id && pr.Active)))
                .Select(men => new OfferDisplay(
                    "Menu",
                    men.Menu.Name,
                    men.Menu.Image,
                    context.Offers.Single(o => o.Promotion.Menus.Any(pp => pp.Id == men.Menu.Id)).Points,
                    men.Price,
                    men.Menu.Steps.Sum(s => s.DefaultProduct!.Energy ?? 0),
                    men.Menu.Snacks.Select(s => new SnackAmountDisplay(s.Snack.Name, s.Amount)),
                    men.Menu.Categories.OrderBy(c => c.SubCategory).ThenBy(c => c.Name).Select(c => new CategorieDisplay(c.Id, c.Name, c.SubCategory))))
                .ToArrayAsync(),
        ];
    }

    public async Task<RestaurantDisplay?> GetRestaurant(string? codeRestaurant = null)
    {
        var r = codeRestaurant != null
            ? await context.Restaurants.SingleOrDefaultAsync(r => r.Id == codeRestaurant)
            : await context.Restaurants.OrderByDescending(r => r.CatalogueUpdate).FirstOrDefaultAsync(r => r.CatalogueUpdate != null);

        if (r == null)
        {
            return null;
        }

        return new RestaurantDisplay(r.Id, r.Name, r.AddressFull, r.Departement, r.Lat, r.Lng, r.CatalogueUpdate);
    }

    public async Task<RestaurantDisplay[]> GetRestaurants()
    {
        return await context.Restaurants
            .Where(r => r.Opened && r.CatalogueUpdate != null)
            .OrderBy(r => r.Departement)
            .ThenBy(r => r.Name)
            .Select(r => new RestaurantDisplay(r.Id, r.Name, r.AddressFull, r.Departement, r.Lat, r.Lng, r.CatalogueUpdate))
            .ToArrayAsync();
    }

    public async Task<SnackDisplay[]> GetSnacks(string codeRestaurant)
    {
        var allProducts = await context.ProductsRestaurants
            .Include(p => p.Product)
            .ThenInclude(p => p.Snacks)
            .ThenInclude(p => p.Snack)
            .AsSingleQuery()
            .Where(p => p.Restaurant.Id == codeRestaurant && p.Active && p.Product.Snacks.Any(s => s.Snack.Active))
            .ToListAsync();

        return allProducts
            .SelectMany(p => p.Product.Snacks.Select(s =>
            {
                var ratio = 1d;

                if (p.Product.Snacks.Count > 1)
                {
                    var prices = p.Product.Snacks.Select(s2 =>
                    {
                        var bestProduct = allProducts
                            .Where(p2 => p2.Product.Snacks.Count == 1 && p2.Product.Snacks.Single().Snack.Name == s2.Snack.Name && p2.Product.Snacks.Single().Amount < p.Product.Snacks.Sum(s3 => s3.Amount))
                            .OrderByDescending(p2 => p2.Product.Snacks.Single().Amount)
                            .First();

                        return new { s2.Snack.Name, Price = bestProduct.Price / bestProduct.Product.Snacks.Single().Amount };
                    }).ToDictionary(s2 => s2.Name, s2 => s2.Price);

                    ratio = s.Amount * prices[s.Snack.Name] / p.Product.Snacks.Sum(s2 => s2.Amount * prices[s2.Snack.Name]);
                }

                return new
                {
                    SnackName = s.Snack.Name,
                    s.Amount,
                    ProductName = p.Product.Name,
                    p.Product.Image,
                    p.Price,
                    Ratio = ratio
                };
            }))
            .GroupBy(s => s.SnackName)
            .Select(s =>
            {
                var products = s.DistinctBy(p => p.ProductName.ToLower().Replace("&", "+")).Select(t => new SnackProductDisplay(t.ProductName, t.Image, t.Amount, t.Price, t.Ratio));
                return new SnackDisplay(s.Key, products.ToArray());
            })
                .ToArray();
    }

    public async Task<BurgerMystereListDisplay[]?> GetBurgerMystere(string month, string codeRestaurant)
    {
        if (!_burgerMystereProbabilites.TryGetValue(month, out var meatProbs))
        {
            return null;
        }

        var meat = await context.ProductsRestaurants
            .AsSingleQuery()
            .Where(prd => prd.Restaurant.Id == codeRestaurant && meatProbs.Keys.Contains(prd.Product.Id))
            .Select(prd => new BurgerMystereDisplay(
                prd.Product.Name,
                prd.Product.Image,
                prd.Price,
                prd.Product.Energy ?? 0,
                meatProbs[prd.Product.Id]))
            .ToArrayAsync();

        var veggieProbs = _veggieMystereProbabilites[month];

        var veggie = await context.ProductsRestaurants
            .AsSingleQuery()
            .Where(prd => prd.Restaurant.Id == codeRestaurant && veggieProbs.Keys.Contains(prd.Product.Id))
            .Select(prd => new BurgerMystereDisplay(
                prd.Product.Name,
                prd.Product.Image,
                prd.Price,
                prd.Product.Energy ?? 0,
                veggieProbs[prd.Product.Id]))
            .ToArrayAsync();

        return [new("Burger Mystère", meat), new("Veggie Mystère", veggie)];
    }

    public async Task<DateTime?> GetOffersUpdate()
    {
        return (await context.Updates.SingleOrDefaultAsync())?.Offers;
    }
}

