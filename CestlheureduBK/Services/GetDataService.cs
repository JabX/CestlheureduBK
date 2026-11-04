using CestlheureduBK.Common;
using CestlheureduBK.Model;
using Microsoft.EntityFrameworkCore;

namespace CestlheureduBK.Services;

public class GetDataService(BKDbContext context, UserService userService)
{
    public async Task<IList<BurgerMysterePeriodDisplay>> GetBurgerMystereCampaigns()
    {
        return (
            await context
                .MysteryCampaigns.Select(c => new BurgerMysterePeriodDisplay(c.Start, c.End))
                .Distinct()
                .ToListAsync()
        )
            .OrderByDescending(c => c.Start)
            .ToList();
    }

    public async Task<CatalogueDisplay[]> GetCatalogue(string codeRestaurant)
    {
        var favoriteRestaurant = await userService.GetFavoriteRestaurant();

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
                    favoriteRestaurant != null && favoriteRestaurant.Id != codeRestaurant
                        ? context
                            .ProductsRestaurants.SingleOrDefault(pr =>
                                pr.Restaurant.Id == favoriteRestaurant.Id && pr.Product.Id == prd.Product.Id
                            )!
                            .Price
                        : null,
                    prd.Product.Energy ?? 0,
                    null,
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
                        favoriteRestaurant != null && favoriteRestaurant.Id != codeRestaurant
                            ? context
                                .MenusRestaurants.SingleOrDefault(mr =>
                                    mr.Restaurant.Id == favoriteRestaurant.Id && mr.Menu.Id == men.Menu.Id
                                )!
                                .Price
                            : null,
                        men.Menu.Steps.Sum(s =>
                            s.Products.Where(p => !p.RouteId.Replace("-", string.Empty).ToLower().Contains("kingfries"))
                                .Max(p => p.Energy ?? 0)
                        ),
                        men.Menu.Steps.Sum(s => s.Products.Min(p => p.Energy ?? 0)),
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
                new(mr.Product.Campaign.Start, mr.Product.Campaign.End),
                string.Join(" + ", mr.Product.Products.Select(p => p.Product.Name)),
                mr.Price,
                mr.Product.Campaign.Price,
                $"{mr.Restaurant.Name} ({mr.Restaurant.Departement})",
                mr.RollTime
            ))
            .ToListAsync();
    }

    public async Task<OfferDisplay[]> GetOffers(string codeRestaurant)
    {
        var favoriteRestaurant = await userService.GetFavoriteRestaurant();
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
                    favoriteRestaurant != null && favoriteRestaurant.Id != codeRestaurant
                        ? context
                            .ProductsRestaurants.SingleOrDefault(pr =>
                                pr.Restaurant.Id == favoriteRestaurant.Id && pr.Product.Id == prd.Product.Id
                            )!
                            .Price
                        : null,
                    prd.Product.Energy ?? 0,
                    null,
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
                        favoriteRestaurant != null && favoriteRestaurant.Id != codeRestaurant
                            ? context
                                .MenusRestaurants.SingleOrDefault(mr =>
                                    mr.Restaurant.Id == favoriteRestaurant.Id && mr.Menu.Id == men.Menu.Id
                                )!
                                .Price
                            : null,
                        men.Menu.Steps.Sum(s =>
                            s.Products.Where(p => !p.RouteId.Replace("-", string.Empty).ToLower().Contains("kingfries"))
                                .Max(p => p.Energy ?? 0)
                        ),
                        men.Menu.Steps.Sum(s => s.Products.Min(p => p.Energy ?? 0)),
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

    public async Task<IList<BurgerMystereListDisplay>> GetBurgerMystere(DateOnly start, string codeRestaurant)
    {
        var combinations = await context
            .MysteryProducts.Where(mp =>
                mp.Campaign.Start == start
                && mp.Products.Any()
                && mp.Products.All(p =>
                    context.ProductsRestaurants.Any(pr =>
                        pr.ProductId == p.Product.Id && pr.RestaurantId == codeRestaurant
                    )
                )
            )
            .Select(mp => new
            {
                mp.Campaign,
                Burger = new BurgerMystereDisplay(
                    mp.Id,
                    mp.Products.Select(p => new MysteryProductDisplay(
                            p.Product.Name,
                            p.Product.Image,
                            context
                                .ProductsRestaurants.Single(pr =>
                                    pr.ProductId == p.Product.Id && pr.RestaurantId == codeRestaurant
                                )
                                .Price,
                            p.Product.Energy ?? 0,
                            p.Type
                        ))
                        .ToList(),
                    mp.Chance,
                    context.MysteryRolls.Count(mr => mr.Product == mp && mr.User.Id == userService.Id),
                    context.MysteryRolls.Count(mr => mr.Product == mp)
                ),
            })
            .ToListAsync();

        return combinations
            .GroupBy(c => c.Campaign.Id)
            .Select(g =>
            {
                var campaign = g.First().Campaign;
                return new BurgerMystereListDisplay(
                    campaign.Kind switch
                    {
                        MysteryCampaignKind.Classic => "Burger Mystère",
                        MysteryCampaignKind.Veggie => "Veggie Mystère",
                        MysteryCampaignKind.Duo => "Duo Mystère",
                        MysteryCampaignKind.Box => "Box Mystère",
                        _ => throw new InvalidOperationException($"Type de campagne inconnu : {campaign.Kind}"),
                    },
                    campaign.Price,
                    g.Select(c => c.Burger).ToList()
                );
            })
            .ToList();
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
