using CestlheureduBK.Common;
using CestlheureduBK.Model;
using Microsoft.EntityFrameworkCore;

namespace CestlheureduBK;

public class BackDataService(BKDbContext context) : IDataService
{
    public async Task<OfferDisplay[]> GetOffers(OfferCriteria criteria)
    {
        var query = context.Offers
            .AsSingleQuery()
            .Where(off => criteria.Points == null || criteria.Points.Contains(off.Points))
            .AsAsyncEnumerable()
            .SelectMany(off =>
                off.Promotion.Products.Where(p => p.Available).Select(prd => new OfferDisplay("Produit", prd.Name, prd.Image, off.Points, prd.Price, prd.Snacks.Select(s => new SnackAmountDisplay(s.Snack.Name, s.Amount)), prd.Categories.OrderBy(c => c.SubCategory).ThenBy(c => c.Name).Select(c => new CategorieDisplay(c.Id, c.Name, c.SubCategory))))
                .Concat(off.Promotion.Menus.Where(p => p.Available).Select(men => new OfferDisplay("Menu", men.Name, men.Image, off.Points, men.Price, men.Snacks.Select(s => new SnackAmountDisplay(s.Snack.Name, s.Amount)), men.Categories.OrderBy(c => c.SubCategory).ThenBy(c => c.Name).Select(c => new CategorieDisplay(c.Id, c.Name, c.SubCategory)))))
            .ToAsyncEnumerable());

        if (!string.IsNullOrEmpty(criteria.Name))
        {
            query = query.Where(off => off.Name.Contains(criteria.Name, StringComparison.CurrentCultureIgnoreCase));
        }

        var catFilter = criteria.Categories?.Select(c => c.Id).ToList();
        if (catFilter != null)
        {
            query = query.Where(m => m.Categories.Any(c => catFilter.Contains(c.Id)));
        }

        return await ((criteria.SortBy, criteria.Asc) switch
        {
            ("name", false) => query.OrderByDescending(off => off.Name).ThenByDescending(off => off.Type),
            ("name", true) => query.OrderBy(off => off.Name).ThenByDescending(off => off.Type),
            ("price", false) => query.OrderByDescending(off => off.Price).ThenBy(off => off.Points),
            ("price", true) => query.OrderBy(off => off.Price).ThenBy(off => off.Points),
            ("points", false) => query.OrderByDescending(off => off.Points).ThenByDescending(off => off.Price),
            ("points", true) => query.OrderBy(off => off.Points).ThenBy(off => off.Price),
            ("value", false) => query.OrderByDescending(off => off.Value).ThenBy(off => off.Points),
            ("value", true) => query.OrderBy(off => off.Value).ThenBy(off => off.Points),
            _ => throw new InvalidOperationException()
        })
            .ToArrayAsync();
    }

    public async Task<RestaurantDisplay> GetRestaurant()
    {
        return await context.Products.Include(r => r.Restaurant).Take(1).Select(r => new RestaurantDisplay(r.Restaurant.Id, r.Restaurant.Name, r.Restaurant.AddressFull, r.Restaurant.Departement)).SingleAsync();
    }

    public async Task<SnackDisplay[]> GetSnacks(string sortBy, bool asc)
    {
        var allProducts = await context.Products.Where(p => p.Snacks.Any(s => s.Snack.Available))
            .ToListAsync();

        return allProducts
            .SelectMany(p => p.Snacks.Select(s =>
            {
                var ratio = 1m;

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
                return new SnackDisplay(
                    s.Key,
                    ((sortBy, asc) switch
                    {
                        ("amount", false) => products.OrderByDescending(off => off.Amount).ThenByDescending(off => off.Price),
                        ("amount", true) => products.OrderBy(off => off.Amount).ThenBy(off => off.Price),
                        ("price", false) => products.OrderByDescending(off => off.Price).ThenBy(off => off.Value),
                        ("price", true) => products.OrderBy(off => off.Price).ThenBy(off => off.Value),
                        ("value", false) => products.OrderByDescending(off => off.Value).ThenBy(off => off.Amount),
                        ("value", true) => products.OrderBy(off => off.Value).ThenBy(off => off.Amount),
                        _ => throw new InvalidOperationException()
                    }).ToArray());
            })
                .ToArray();
    }

    public async Task<UpdateDisplay> GetUpdate()
    {
        var update = await context.Updates.SingleAsync();
        return new UpdateDisplay(update.Catalogue, update.Offers);
    }
}

