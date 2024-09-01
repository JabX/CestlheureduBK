using CestlheureduBK.Common;
using CestlheureduBK.Model;
using Microsoft.EntityFrameworkCore;

namespace CestlheureduBK;

public class DataService(BKDbContext context)
{
    public async Task<CatalogueDisplay[]> GetCatalogue()
    {
        var lol = (await context.Products
            .AsSingleQuery()
            .Where(prd => prd.Active && prd.AvailableInCatalogue && prd.Price > 0)
            .Select(prd => new CatalogueDisplay(
                "Produit",
                prd.Name,
                prd.Image,
                prd.Price,
                prd.Energy ?? 0,
                prd.Snacks.Select(s => new SnackAmountDisplay(s.Snack.Name, s.Amount)),
                prd.Categories.OrderBy(c => c.SubCategory).ThenBy(c => c.Name).Select(c => new CategorieDisplay(c.Id, c.Name, c.SubCategory))))
            .ToArrayAsync())
        .Concat(await context.Menus
            .AsSingleQuery()
            .Where(men => men.Active && men.AvailableInCatalogue && men.Price > 0)
            .Select(men => new CatalogueDisplay(
                "Menu",
                men.Name,
                men.Image,
                men.Price,
                men.Steps.Sum(s => s.DefaultProduct != null && s.DefaultProduct.Energy != null ? s.DefaultProduct.Energy.Value : 0),
                men.Snacks.Select(s => new SnackAmountDisplay(s.Snack.Name, s.Amount)),
                men.Categories.OrderBy(c => c.SubCategory).ThenBy(c => c.Name).Select(c => new CategorieDisplay(c.Id, c.Name, c.SubCategory))))
            .ToArrayAsync())
        .ToArray();

        return lol;
    }

    public async Task<OfferDisplay[]> GetOffers()
    {
        return await context.Offers
            .Where(off => off.Promotion.Active)
            .AsSingleQuery()
            .AsAsyncEnumerable()
            .SelectMany(off =>
                 off.Promotion.Products.Where(p => p.Active)
                     .Select(prd => new OfferDisplay(
                         "Produit",
                         prd.Name,
                         prd.Image,
                         off.Points,
                         prd.Price,
                         prd.Energy ?? 0,
                         prd.Snacks.Select(s => new SnackAmountDisplay(s.Snack.Name, s.Amount)),
                         prd.Categories.OrderBy(c => c.SubCategory).ThenBy(c => c.Name).Select(c => new CategorieDisplay(c.Id, c.Name, c.SubCategory))))
                .Concat(off.Promotion.Menus.Where(p => p.Active)
                    .Select(men => new OfferDisplay(
                        "Menu",
                        men.Name,
                        men.Image,
                        off.Points,
                        men.Price,
                        men.Steps.Sum(s => s.DefaultProduct?.Energy ?? 0),
                        men.Snacks.Select(s => new SnackAmountDisplay(s.Snack.Name, s.Amount)),
                        men.Categories.OrderBy(c => c.SubCategory).ThenBy(c => c.Name).Select(c => new CategorieDisplay(c.Id, c.Name, c.SubCategory)))))
            .ToAsyncEnumerable())
            .ToArrayAsync();
    }

    public async Task<RestaurantDisplay> GetRestaurant()
    {
        return await context.Products.Include(r => r.Restaurant).Take(1).Select(r => new RestaurantDisplay(r.Restaurant.Id, r.Restaurant.Name, r.Restaurant.AddressFull, r.Restaurant.Departement, r.Restaurant.Lat, r.Restaurant.Lng)).SingleAsync();
    }

    public async Task<SnackDisplay[]> GetSnacks()
    {
        var allProducts = await context.Products.Where(p => p.Active && p.Snacks.Any(s => s.Snack.Active))
            .ToListAsync();

        return allProducts
            .SelectMany(p => p.Snacks.Select(s =>
            {
                var ratio = 1d;

                if (p.Snacks.Count > 1)
                {
                    var prices = p.Snacks.Select(s2 =>
                    {
                        var bestProduct = allProducts
                            .Where(p2 => p2.Snacks.Count == 1 && p2.Snacks.Single().Snack.Name == s2.Snack.Name && p2.Snacks.Single().Amount < p.Snacks.Sum(s3 => s3.Amount))
                            .OrderByDescending(p2 => p2.Snacks.Single().Amount)
                            .First();

                        return new { s2.Snack.Name, Price = bestProduct.Price / bestProduct.Snacks.Single().Amount };
                    }).ToDictionary(s2 => s2.Name, s2 => s2.Price);

                    ratio = s.Amount * prices[s.Snack.Name] / p.Snacks.Sum(s2 => s2.Amount * prices[s2.Snack.Name]);
                }

                return new
                {
                    SnackName = s.Snack.Name,
                    s.Amount,
                    ProductName = p.Name,
                    p.Image,
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

    public async Task<UpdateDisplay> GetUpdate()
    {
        var update = await context.Updates.SingleAsync();
        return new UpdateDisplay(update.Catalogue, update.Offers);
    }
}

