using System.Globalization;
using System.Net;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;
using CestlheureduBK.Model;
using Microsoft.EntityFrameworkCore;

namespace CestlheureduBK.Services;

public class UpdateDataService(BKDbContext context)
{
    public async Task CheckAccessToken(string? accessToken)
    {
        var client = GetClient(accessToken);
        var result = await client.GetAsync("https://webapi.burgerking.fr/blossom/api/v13/kingdom/points");
        result.EnsureSuccessStatusCode();
    }

    public async Task<(string Message, bool Error)> ReloadCatalogue(string codeRestaurant)
    {
        using var client = GetClient();

        try
        {
            var result = await client.GetAsync($"https://ecoceabkstorageprdnorth.blob.core.windows.net/catalog/pick-up.{codeRestaurant}.json");
            result.EnsureSuccessStatusCode();
            var catalogue = (await result.Content.ReadFromJsonAsync<Catalogue>())!;

            var restaurant = await context.Restaurants.AsTracking().SingleAsync(r => r.Id == codeRestaurant);

            var categories = catalogue.Categories.Select(cat => new CategorieDb { Id = cat.Id, Name = cat.Name, Image = cat.Image })
                .Concat(catalogue.SubCategories.Select(cat => new CategorieDb { Id = cat.Id, Name = cat.Name, Image = cat.Image, SubCategory = true }))
                .ToList();

            var snackRegex = new Regex(@"(.+)\((\d+)\)");
            var kingboxRegex = new Regex(@"kingbox (\d+) ([a-z ]+)([ +&]*(\d+) ([a-z ]+))?", RegexOptions.IgnoreCase);

            var products = catalogue.Products.Select(prd => new ProductRestaurantDb
            {
                ProductId = prd.Id,
                Product = new()
                {
                    Id = prd.Id,
                    Name = prd.Name
                        .Replace("®", "")
                        .Replace("Lousiane", "Louisiane")
                        .Replace("(6) King Nuggets", "King Nuggets (6)"),
                    Image = prd.Image,
                    Categories = prd.Categories?.Select(c => c.Id).Concat(prd.SubCategories ?? []).Select(c => categories.Single(cat => c == cat.Id)).ToList() ?? []
                },
                Active = prd.Active,
                Price = prd.Price,
                RestaurantId = restaurant.Id,
                Restaurant = restaurant
            }).ToList();
            var menus = catalogue.Menus.Select(men => new MenuRestaurantDb
            {
                MenuId = men.Id,
                Menu = new()
                {
                    Id = men.Id,
                    Name = men.Name
                        .Replace("®", "")
                        .Replace("Steakhouse Louisiane", "Louisiane Steakhouse")
                        .Replace("[kingdom]", "", StringComparison.InvariantCultureIgnoreCase)
                        .Replace("[kd blason]", "", StringComparison.InvariantCultureIgnoreCase)
                        .Replace("menu", "", StringComparison.InvariantCultureIgnoreCase)
                        .Trim()
                        .Trim('-')
                        .Trim(),
                    Image = men.Image,
                    Steps = men.Steps.Select(stp => new StepDb
                    {
                        Products = products.Select(p => p.Product).Where(prd => stp.ProductIds.Contains(prd.Id)).ToList(),
                        ProductsL = stp.ProductLIds != null ? products.Select(p => p.Product).Where(prd => stp.ProductLIds.Contains(prd.Id)).ToList() : [],
                        ProductsXL = stp.ProductXLIds != null ? products.Select(p => p.Product).Where(prd => stp.ProductXLIds.Contains(prd.Id)).ToList() : [],
                        DefaultProduct = products.Select(p => p.Product).SingleOrDefault(prd => prd.Id == stp.DefaultId),
                        Type = stp.StepType
                    }).ToList(),
                    Categories = men.Categories?.Select(c => c.Id).Concat(men.SubCategories ?? []).Select(c => categories.Single(cat => c == cat.Id)).ToList() ?? [],
                },
                Active = men.Active,
                Price = men.Price,
                PriceL = men.PriceL,
                PriceXL = men.PriceXL,
                RestaurantId = restaurant.Id,
                Restaurant = restaurant
            }).ToList();

            var snacks = products
                .Select(p => p.Product)
                .Where(p => snackRegex.IsMatch(p.Name))
                .Select(p => new SnackDb { Name = snackRegex.Match(p.Name).Groups[1].Value.Trim() })
                .DistinctBy(p => p.Name)
                .ToList();

            foreach (var product in products.Select(p => p.Product).Where(prd => prd.Image == null))
            {
                product.Image = products.FirstOrDefault(prd => prd.Product.Name.StartsWith(product.Name, StringComparison.InvariantCultureIgnoreCase) && prd.Product.Image != null)?.Product.Image;
            }

            var productsDb = await context.Products.ToDictionaryAsync(p => p.Id);

            foreach (var product in products.Select(p => p.Product))
            {
                if (productsDb.TryGetValue(product.Id, out var productDb) && productDb.Energy != null)
                {
                    product.Energy = productDb.Energy;
                }
                else
                {
                    var productResult = await client.GetAsync($"https://webapi.burgerking.fr/blossom/api/v13/public/produit/{catalogue.Products.Single(prd => prd.Id == product.Id).RouteId}");
                    if (productResult.IsSuccessStatusCode)
                    {
                        var productDetail = (await productResult.Content.ReadFromJsonAsync<ProductResult>())!;
                        var energy = productDetail.Product.Nutrition.SingleOrDefault(n => n.Item == "product.nutritional.energy")?.Portion;
                        if (!string.IsNullOrEmpty(energy))
                        {
                            product.Energy = double.Parse(energy.Replace(",", "."), CultureInfo.InvariantCulture);
                        }
                    }
                }

                product.AvailableInCatalogue = product.Categories.Any();
                product.Categories = product.Categories.Concat(products.Where(prd => prd.Product.Name.StartsWith(product.Name, StringComparison.InvariantCultureIgnoreCase)).SelectMany(prd => prd.Product.Categories ?? [])).ToList();

                var match = snackRegex.Match(product.Name);
                if (match.Success)
                {
                    product.Snacks.Add(new()
                    {
                        Snack = snacks.Single(s => s.Name == match.Groups[1].Value.Trim()),
                        Amount = int.Parse(match.Groups[2].Value)
                    });
                }
                else
                {
                    var match2 = kingboxRegex.Match(product.Name);
                    if (match2.Success)
                    {
                        product.Snacks.Add(new()
                        {
                            Snack = snacks.Single(s => s.Name == match2.Groups[2].Value.Trim()),
                            Amount = int.Parse(match2.Groups[1].Value.Trim())
                        });

                        if (match2.Groups[3].Success)
                        {
                            product.Snacks.Add(new()
                            {
                                Snack = snacks.Single(s => s.Name == match2.Groups[5].Value.Trim()),
                                Amount = int.Parse(match2.Groups[4].Value.Trim())
                            });
                        }
                    }
                }
            }

            foreach (var menu in menus.Select(m => m.Menu).Where(men => men.Image == null))
            {
                menu.Image = menus.FirstOrDefault(men => men.Menu.Name.StartsWith(menu.Name, StringComparison.InvariantCultureIgnoreCase) && men.Menu.Image != null)?.Menu.Image;
            }

            foreach (var menu in menus.Select(m => m.Menu))
            {
                menu.AvailableInCatalogue = menu.Categories.Any();
                menu.Categories = menu.Categories.Concat(menus.Where(men => men.Menu.Name.StartsWith(menu.Name, StringComparison.InvariantCultureIgnoreCase)).SelectMany(men => men.Menu.Categories ?? [])).ToList();

                var match = snackRegex.Match(menu.Name);
                if (match.Success)
                {
                    var n = menu.Name;
                    menu.Snacks.Add(new()
                    {
                        Snack = snacks.Single(s => s.Name == match.Groups[1].Value.Trim()),
                        Amount = int.Parse(match.Groups[2].Value)
                    });
                }
            }

            var promotions = catalogue.Promotions.Select(prm => new PromotionRestaurantDb
            {
                PromotionId = prm.Id,
                Promotion = new()
                {
                    Id = prm.Id,
                    Name = prm.Name,
                    Products = products.Select(p => p.Product).Where(prd => prm.ProductIds.Contains(prd.Id)).ToList(),
                    Menus = menus.Select(m => m.Menu).Where(men => prm.MenuIds.Contains(men.Id)).ToList()
                },
                RestaurantId = restaurant.Id,
                Restaurant = restaurant
            }).ToList();

            await context.Database.ExecuteSqlRawAsync(@"
                delete from StepProducts;
                delete from StepProductsL;
                delete from StepProductsXL;
                delete from Steps;
                delete from SnackAmounts;
                delete from CategorieDbProductDb;
                delete from CategorieDbMenuDb;
                delete from MenuDbPromotionDb;
                delete from ProductDbPromotionDb;
            ");

            var snacksDb = await context.Snacks.ToDictionaryAsync(p => p.Name);
            foreach (var snack in snacks)
            {
                snack.Id = snacksDb.TryGetValue(snack.Name, out var s) ? s.Id : 0;
            }

            var categoriesDb = await context.Categories.ToDictionaryAsync(p => p.Id);
            var menusDb = await context.Menus.ToDictionaryAsync(p => p.Id);
            var promotionsDb = await context.Promotions.ToDictionaryAsync(p => p.Id);

            context.UpdateRange(snacks);
            context.AddRange(categories.Where(r => !categoriesDb.ContainsKey(r.Id)));
            context.UpdateRange(categories.Where(r => categoriesDb.ContainsKey(r.Id)));
            context.AddRange(menus.Select(p => p.Menu).Where(r => !menusDb.ContainsKey(r.Id)));
            context.UpdateRange(menus.Select(p => p.Menu).Where(r => menusDb.ContainsKey(r.Id)));
            context.AddRange(products.Select(p => p.Product).Where(r => !productsDb.ContainsKey(r.Id)));
            context.UpdateRange(products.Select(p => p.Product).Where(r => productsDb.ContainsKey(r.Id)));
            context.AddRange(promotions.Select(p => p.Promotion).Where(r => !promotionsDb.ContainsKey(r.Id)));
            context.UpdateRange(promotions.Select(p => p.Promotion).Where(r => promotionsDb.ContainsKey(r.Id)));

            var menusRestaurantsDb = await context.MenusRestaurants.Where(m => m.Restaurant.Id == codeRestaurant).ToDictionaryAsync(p => (p.MenuId, p.RestaurantId));
            var productsRestaurantsDb = await context.ProductsRestaurants.Where(m => m.Restaurant.Id == codeRestaurant).ToDictionaryAsync(p => (p.ProductId, p.RestaurantId));
            var promotionsRestaurantsDb = await context.PromotionsRestaurants.Where(m => m.Restaurant.Id == codeRestaurant).ToDictionaryAsync(p => (p.PromotionId, p.RestaurantId));

            context.AddRange(menus.Where(r => !menusRestaurantsDb.ContainsKey((r.Menu.Id, r.Restaurant.Id))));
            context.UpdateRange(menus.Where(r => menusRestaurantsDb.ContainsKey((r.Menu.Id, r.Restaurant.Id))));
            context.AddRange(products.Where(r => !productsRestaurantsDb.ContainsKey((r.Product.Id, r.Restaurant.Id))));
            context.UpdateRange(products.Where(r => productsRestaurantsDb.ContainsKey((r.Product.Id, r.Restaurant.Id))));
            context.AddRange(promotions.Where(r => !promotionsRestaurantsDb.ContainsKey((r.Promotion.Id, r.Restaurant.Id))));
            context.UpdateRange(promotions.Where(r => promotionsRestaurantsDb.ContainsKey((r.Promotion.Id, r.Restaurant.Id))));

            await context.SaveChangesAsync();

            await context.Snacks
                .Where(r => !snacks.Select(re => re.Id).Contains(r.Id))
                .ExecuteUpdateAsync(e => e.SetProperty(r => r.Active, false));
            await context.ProductsRestaurants
                .Where(r => r.Restaurant.Id == codeRestaurant && !products.Select(re => re.Product.Id).Contains(r.ProductId))
                .ExecuteUpdateAsync(e => e.SetProperty(r => r.Active, false));
            await context.MenusRestaurants
                .Where(r => r.Restaurant.Id == codeRestaurant && !menus.Select(re => re.Menu.Id).Contains(r.MenuId))
                .ExecuteUpdateAsync(e => e.SetProperty(r => r.Active, false));
            await context.PromotionsRestaurants
                .Where(r => r.Restaurant.Id == codeRestaurant && !promotions.Select(re => re.Promotion.Id).Contains(r.PromotionId))
                .ExecuteUpdateAsync(e => e.SetProperty(r => r.Active, false));

            await context.Restaurants.Where(r => r.Id == codeRestaurant)
                .ExecuteUpdateAsync(u => u.SetProperty(v => v.CatalogueUpdate, DateTime.UtcNow));

            return ("Catalogue rechargé avec succès !", false);
        }
        catch (Exception e)
        {
            return ($"Une erreur est survenue lors de l'actualisation des données : {e.Message}", true);
        }
        finally
        {
            context.ChangeTracker.Clear();
        }
    }

    public async Task<(string Message, bool Error)> ReloadOffers(string accessToken)
    {
        using var client = GetClient(accessToken);

        try
        {
            var result = await client.GetAsync("https://webapi.burgerking.fr/blossom/api/v13/kingdom/points");
            result.EnsureSuccessStatusCode();
            var points = (await result.Content.ReadFromJsonAsync<Points>())!;

            var promotions = await context.Promotions.AsTracking().ToDictionaryAsync(p => p.Id);

            var offers = points.Levels.SelectMany(lvl => lvl.Offers.Select(off => new OfferDb
            {
                Id = off.TransformationId,
                Title = off.Title,
                Points = off.Points,
                Promotion = promotions[off.PromotionId]
            })).ToList();

            await context.Offers.ExecuteDeleteAsync();
            context.AddRange(offers);
            await context.SaveChangesAsync();

            await context.Updates.ExecuteUpdateAsync(u => u.SetProperty(v => v.Offers, DateTime.UtcNow));

            return ("Offres rechargées avec succès !", false);
        }
        catch (Exception e)
        {
            return ($"Une erreur est survenue lors de l'actualisation des données : {e.Message}", true);
        }
        finally
        {
            context.ChangeTracker.Clear();
        }
    }

    public async Task<(string Message, bool Error)> ReloadRestaurants()
    {
        using var client = GetClient();

        try
        {
            var storeLocator = await client.GetAsync("https://webapi.burgerking.fr/blossom/api/v13/public/store-locator");
            storeLocator.EnsureSuccessStatusCode();
            var stores = (await storeLocator.Content.ReadFromJsonAsync<StoreLocator>())!;

            var restaurantsDb = await context.Restaurants.ToDictionaryAsync(r => r.Id);

            var restaux = await stores.Markers.ToAsyncEnumerable().SelectAwait(async store =>
            {
                if (restaurantsDb.TryGetValue(store.Id, out var restaurantDb))
                {
                    return restaurantDb;
                }
                else
                {
                    await Task.Delay(200); // L'API nous jette au bout d'un moment sinon :(
                    var restaurant = await client.GetAsync($"https://webapi.burgerking.fr/blossom/api/v13/public/restaurant/{store.Id}");
                    restaurant.EnsureSuccessStatusCode();
                    var restaurantData = (await restaurant.Content.ReadFromJsonAsync<Restaurant>())!;
                    return new RestaurantDb
                    {
                        AddressFull = restaurantData.AddressFull,
                        Id = restaurantData.Id,
                        Name = restaurantData.Name,
                        Lat = restaurantData.Lat,
                        Lng = restaurantData.Lng,
                        Departement = restaurantData.AddressFull.Split("- ").Last().Trim()[..2]
                    };
                }
            }).ToArrayAsync();

            context.AddRange(restaux.Where(r => !restaurantsDb.ContainsKey(r.Id)));
            context.UpdateRange(restaux.Where(r => restaurantsDb.ContainsKey(r.Id)));
            await context.SaveChangesAsync();

            await context.Restaurants
                .Where(r => !restaux.Select(re => re.Id).Contains(r.Id))
                .ExecuteUpdateAsync(e => e.SetProperty(r => r.Opened, false));

            await context.Updates.ExecuteUpdateAsync(u => u.SetProperty(v => v.Restaurants, DateTime.UtcNow));

            return ("Restaurants rechargés avec succès !", false);
        }
        catch (Exception e)
        {
            return ($"Une erreur est survenue lors de l'actualisation des données : {e.Message}", true);
        }
        finally
        {
            context.ChangeTracker.Clear();
        }
    }

    private static HttpClient GetClient(string? accessToken = null)
    {
        var client = new HttpClient(new HttpClientHandler { AutomaticDecompression = DecompressionMethods.GZip });
        client.DefaultRequestHeaders.Accept.Add(new("application/json"));

        if (!string.IsNullOrEmpty(accessToken))
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
        }

        return client;
    }
}
