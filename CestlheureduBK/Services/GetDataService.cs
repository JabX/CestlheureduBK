using CestlheureduBK.Common;
using CestlheureduBK.Model;
using Microsoft.EntityFrameworkCore;

namespace CestlheureduBK.Services;

public class GetDataService(BKDbContext context, UserService userService)
{
    public async Task<IList<string>> GetBurgerMystereMonths()
    {
        return await context.MysteryCampaigns.Select(c => c.Month).Distinct().OrderByDescending(c => c).ToListAsync();
    }

    public async Task<CatalogueDisplay[]> GetCatalogue(string codeRestaurant)
    {
        var catalogue = (
            await context
                .ProductsRestaurants.AsSingleQuery()
                .Where(prd =>
                    prd.Restaurant.Id == codeRestaurant
                    && prd.Active
                    && prd.Product.AvailableInCatalogue
                    && prd.Price > 0
                )
                .Select(prd => new CatalogueDisplay(
                    ItemType.Product,
                    prd.ProductId,
                    prd.Product.Name,
                    prd.Product.Image,
                    prd.Price,
                    prd.Product.Energy ?? 0,
                    prd.Product.Snacks.Select(s => new SnackAmountDisplay(s.Snack.Name, s.Amount)),
                    prd.Product.Categories.OrderBy(c => c.SubCategory)
                        .ThenBy(c => c.Name)
                        .Select(c => new CategorieDisplay(c.Id, c.Name, c.SubCategory))
                ))
                .ToListAsync()
        )
            .Concat(
                await context
                    .MenusRestaurants.AsSingleQuery()
                    .Where(men =>
                        men.Restaurant.Id == codeRestaurant
                        && men.Active
                        && men.Menu.AvailableInCatalogue
                        && men.Price > 0
                    )
                    .Select(men => new CatalogueDisplay(
                        men.Menu.Steps.All(s => s.Type == 1 || s.DefaultProduct!.Id == "1287") // Parce que les Baby Burgers et les Tenders sans menus sont des menus...
                            ? ItemType.ProductAsMenu
                            : ItemType.Menu,
                        men.MenuId,
                        men.Menu.Name,
                        men.Menu.Image,
                        men.Price,
                        men.Menu.Steps.Sum(s =>
                            s.DefaultProduct != null && s.DefaultProduct.Energy != null
                                ? s.DefaultProduct.Energy.Value
                                : 0
                        ),
                        men.Menu.Snacks.Select(s => new SnackAmountDisplay(s.Snack.Name, s.Amount)),
                        men.Menu.Categories.OrderBy(c => c.SubCategory)
                            .ThenBy(c => c.Name)
                            .Select(c => new CategorieDisplay(c.Id, c.Name, c.SubCategory))
                    ))
                    .ToListAsync()
            )
            .ToArray();

        foreach (var item in catalogue)
        {
            if (item.Type == ItemType.ProductAsMenu)
            {
                catalogue[Array.IndexOf(catalogue, item)] = item with
                {
                    Categories = item.Categories.Where(c => c.Name != "Menus"),
                };
            }
        }

        return catalogue;
    }

    public async Task<IList<MysteryRollDisplay>> GetMysteryRolls()
    {
        return await context
            .MysteryRolls.OrderByDescending(m => m.RollTime)
            .Select(mr => new MysteryRollDisplay(
                mr.Id,
                mr.User.Email == "damien.frikha@kleegroup.com"
                    ? "Anonyme"
                    : $"{mr.User.Name} ({mr.User.Email.Split('@', StringSplitOptions.None)[0].Substring(0, 2)}..@{mr.User.Email.Split('@', StringSplitOptions.None)[1].Substring(0, 2)}..)",
                mr.Product.Campaign.Month,
                mr.Product.Product2 != null
                    ? $"{mr.Product.Product.Name} + {mr.Product.Product2.Name}"
                    : mr.Product.Product.Name,
                mr.Price,
                mr.Product.Campaign.Price,
                $"{mr.Restaurant.Name} ({mr.Restaurant.Departement})",
                mr.RollTime
            ))
            .ToListAsync();
    }

    public async Task<OfferDisplay[]> GetOffers(string codeRestaurant)
    {
        var offers = (
            await context
                .ProductsRestaurants.AsSingleQuery()
                .Where(p =>
                    p.Restaurant.Id == codeRestaurant
                    && p.Active
                    && context.Offers.Any(o =>
                        o.Promotion.Products.Any(pp => p.Product.Id == pp.Id)
                        && context.PromotionsRestaurants.Any(pr =>
                            pr.Restaurant.Id == codeRestaurant && pr.Promotion.Id == o.Promotion.Id && pr.Active
                        )
                    )
                )
                .Select(prd => new OfferDisplay(
                    ItemType.Product,
                    prd.Product.Name,
                    prd.Product.Image,
                    context.Offers.Single(o => o.Promotion.Products.Any(pp => pp.Id == prd.Product.Id)).Points,
                    prd.Price,
                    prd.Product.Energy ?? 0,
                    prd.Product.Snacks.Select(s => new SnackAmountDisplay(s.Snack.Name, s.Amount)),
                    prd.Product.Categories.OrderBy(c => c.SubCategory)
                        .ThenBy(c => c.Name)
                        .Select(c => new CategorieDisplay(c.Id, c.Name, c.SubCategory))
                ))
                .ToListAsync()
        )
            .Concat(
                await context
                    .MenusRestaurants.AsSingleQuery()
                    .Where(p =>
                        p.Restaurant.Id == codeRestaurant
                        && p.Active
                        && context.Offers.Any(o =>
                            o.Promotion.Menus.Any(pp => p.Menu.Id == pp.Id)
                            && context.PromotionsRestaurants.Any(pr =>
                                pr.Restaurant.Id == codeRestaurant && pr.Promotion.Id == o.Promotion.Id && pr.Active
                            )
                        )
                    )
                    .Select(men => new OfferDisplay(
                        men.Menu.Steps.All(s => s.Type == 1 || s.DefaultProduct!.Id == "1287") // Parce que les Baby Burgers et les Tenders sans menus sont des menus...
                            ? ItemType.ProductAsMenu
                            : ItemType.Menu,
                        men.Menu.Name,
                        men.Menu.Image,
                        context.Offers.Single(o => o.Promotion.Menus.Any(pp => pp.Id == men.Menu.Id)).Points,
                        men.Price,
                        men.Menu.Steps.Sum(s => s.DefaultProduct!.Energy ?? 0),
                        men.Menu.Snacks.Select(s => new SnackAmountDisplay(s.Snack.Name, s.Amount)),
                        men.Menu.Categories.OrderBy(c => c.SubCategory)
                            .ThenBy(c => c.Name)
                            .Select(c => new CategorieDisplay(c.Id, c.Name, c.SubCategory))
                    ))
                    .ToListAsync()
            )
            .ToArray();

        foreach (var item in offers)
        {
            if (item.Type == ItemType.ProductAsMenu)
            {
                offers[Array.IndexOf(offers, item)] = item with
                {
                    Categories = item.Categories.Where(c => c.Name != "Menus"),
                };
            }
        }

        return offers;
    }

    public async Task<RestaurantDisplay?> GetRestaurant(string? codeRestaurant = null)
    {
        RestaurantDisplay? r;

        if (codeRestaurant != null)
        {
            r = (await context.Restaurants.SingleOrDefaultAsync(r => r.Id == codeRestaurant))?.ToDisplay();
        }
        else
        {
            r = await userService.GetFavoriteRestaurant();

            if (r == null)
            {
                r = (
                    await context
                        .Restaurants.OrderByDescending(r => r.CatalogueUpdate)
                        .FirstOrDefaultAsync(r => r.CatalogueUpdate != null)
                )?.ToDisplay();
            }
        }

        return r;
    }

    public async Task<RestaurantDisplay[]> GetRestaurants()
    {
        return await context
            .Restaurants.Where(r => r.Opened)
            .OrderBy(r => r.Departement)
            .ThenBy(r => r.Name)
            .Select(r => new RestaurantDisplay(
                r.Id,
                r.Name,
                r.AddressFull,
                r.Departement,
                r.Lat,
                r.Lng,
                r.CatalogueUpdate
            ))
            .ToArrayAsync();
    }

    public async Task<SnackDisplay[]> GetSnacks(string codeRestaurant)
    {
        var allProducts = await context
            .ProductsRestaurants.Include(p => p.Product)
            .ThenInclude(p => p.Snacks)
            .ThenInclude(p => p.Snack)
            .AsSingleQuery()
            .Where(p => p.Restaurant.Id == codeRestaurant && p.Active && p.Product.Snacks.Any(s => s.Snack.Active))
            .ToListAsync();

        return allProducts
            .SelectMany(p =>
                p.Product.Snacks.Select(s =>
                {
                    var ratio = 1d;

                    if (p.Product.Snacks.Count > 1)
                    {
                        var prices = p
                            .Product.Snacks.Select(s2 =>
                            {
                                var bestProduct = allProducts
                                    .Where(p2 =>
                                        p2.Product.Snacks.Count == 1
                                        && p2.Product.Snacks.Single().Snack.Name == s2.Snack.Name
                                        && p2.Product.Snacks.Single().Amount < p.Product.Snacks.Sum(s3 => s3.Amount)
                                    )
                                    .OrderByDescending(p2 => p2.Product.Snacks.Single().Amount)
                                    .First();

                                return new
                                {
                                    s2.Snack.Name,
                                    Price = bestProduct.Price / bestProduct.Product.Snacks.Single().Amount,
                                };
                            })
                            .ToDictionary(s2 => s2.Name, s2 => s2.Price);

                        ratio =
                            s.Amount
                            * prices[s.Snack.Name]
                            / p.Product.Snacks.Sum(s2 => s2.Amount * prices[s2.Snack.Name]);
                    }

                    return new
                    {
                        SnackName = s.Snack.Name,
                        s.Amount,
                        ProductName = p.Product.Name,
                        p.Product.Image,
                        p.Price,
                        Ratio = ratio,
                    };
                })
            )
            .GroupBy(s => s.SnackName)
            .Select(s =>
            {
                var products = s.DistinctBy(p => p.ProductName.ToLower().Replace("&", "+"))
                    .Select(t => new SnackProductDisplay(t.ProductName, t.Image, t.Amount, t.Price, t.Ratio));
                return new SnackDisplay(s.Key, products.ToArray());
            })
            .ToArray();
    }

    public async Task<IList<BurgerMystereListDisplay>> GetBurgerMystere(string month, string codeRestaurant)
    {
        return await (
            from mp in context.MysteryProducts
            join pr in context.ProductsRestaurants on mp.Product equals pr.Product
            from pr2 in context.ProductsRestaurants.Where(pr => mp.Product2 == pr.Product).DefaultIfEmpty()
            where mp.Campaign.Month == month
            where pr.Restaurant.Id == codeRestaurant
            where pr2 == null || pr2.Restaurant.Id == codeRestaurant
            group new
            {
                pr,
                pr2,
                mp,
            } by mp.Campaign into g
            select new BurgerMystereListDisplay(
                g.Key.Kind == MysteryCampaignKind.Classic ? "Burger Mystère"
                    : g.Key.Kind == MysteryCampaignKind.Veggie ? "Veggie Mystère"
                    : "Duo Mystère",
                g.Key.Price,
                g.Select(c => new BurgerMystereDisplay(
                        c.mp.Id,
                        c.pr.Product.Name,
                        c.pr.Product.Image,
                        c.pr2.Product.Name,
                        c.pr2.Product.Image,
                        c.pr.Price,
                        c.pr.Product.Energy ?? 0,
                        c.pr2 != null ? c.pr2.Price : 0,
                        c.pr2 != null ? (c.pr2.Product.Energy ?? 0) : 0,
                        c.mp.Chance,
                        context.MysteryRolls.Count(mr => mr.Product == c.mp && mr.User.Id == userService.Id),
                        context.MysteryRolls.Count(mr => mr.Product == c.mp)
                    ))
                    .ToList()
            )
        ).ToListAsync();
    }

    public async Task<DateTime?> GetOffersUpdate()
    {
        return (await context.Updates.SingleOrDefaultAsync())?.Offers;
    }

    public async Task<HeaderDisplay> GetHeaderData(string? restaurantId)
    {
        var offersUpdate = await GetOffersUpdate();
        var restaurants = await GetRestaurants();
        var restaurant = await GetRestaurant(restaurantId);
        var favoriteRestaurant = await userService.GetFavoriteRestaurant();

        return new(restaurant, restaurants, offersUpdate, userService.IsAuthenticated, favoriteRestaurant);
    }
}
