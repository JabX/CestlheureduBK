using CestlheureduBK.Common;
using CestlheureduBK.Model;
using Microsoft.EntityFrameworkCore;

namespace CestlheureduBK.Services;

public class UserService(IHttpContextAccessor httpContextAccessor, BKDbContext context)
{
    public bool IsAuthenticated => httpContextAccessor.HttpContext?.User.Identity?.IsAuthenticated ?? false;

    public Guid Id =>
        Guid.TryParse(
            httpContextAccessor
                .HttpContext?.User.FindFirst("http://schemas.microsoft.com/identity/claims/objectidentifier")
                ?.Value.Split(" ")
                .First(),
            out var id
        )
            ? id
            : default;

    public string Name => httpContextAccessor.HttpContext?.User.FindFirst("name")?.Value.Split(" ").First() ?? "Michel";

    public string Email => httpContextAccessor.HttpContext?.User.Identity?.Name ?? string.Empty;

    public async Task AddMysteryRoll(int mpId, string codeRestaurant)
    {
        var user = await GetUser();
        if (user == null)
        {
            return;
        }

        var mp = await context.MysteryProducts.AsTracking().SingleAsync(p => p.Id == mpId);
        var restaurant = await context.Restaurants.AsTracking().SingleAsync(p => p.Id == codeRestaurant);

        var price = await (
            from mpr in context.MysteryProducts
            join pr in context.ProductsRestaurants on mpr.Product equals pr.Product
            where pr.Restaurant.Id == codeRestaurant
            where mpr.Id == mpId
            select pr.Price
        ).SingleAsync();

        context.MysteryRolls.Add(
            new()
            {
                Price = price,
                Product = mp,
                Restaurant = restaurant,
                RollTime = DateTime.UtcNow,
                User = user,
            }
        );

        await context.SaveChangesAsync();
    }

    public async Task DeleteMysteryRoll(int mrId)
    {
        if (!IsAuthenticated)
        {
            return;
        }

        var mp = await context.MysteryRolls.AsTracking().SingleOrDefaultAsync(p => p.Id == mrId && p.User.Id == Id);
        if (mp != null)
        {
            context.Remove(mp);
            await context.SaveChangesAsync();
        }
    }

    public async Task<RestaurantDisplay?> GetFavoriteRestaurant()
    {
        if (!IsAuthenticated)
        {
            return null;
        }

        var r = (await GetUser())?.FavoriteRestaurant;
        if (r == null)
        {
            return null;
        }

        return r.ToDisplay();
    }

    public async Task<IList<MysteryRollDisplay>> GetMysteryRolls()
    {
        if (IsAuthenticated)
        {
            return await context
                .MysteryRolls.Where(mr => mr.User.Id == Id)
                .OrderByDescending(m => m.RollTime)
                .Select(mr => new MysteryRollDisplay(
                    mr.Id,
                    mr.User.Name,
                    mr.Product.Campaign.Month,
                    mr.Product.Product.Name,
                    mr.Price,
                    mr.Product.Campaign.Price,
                    $"{mr.Restaurant.Name} ({mr.Restaurant.Departement})",
                    mr.RollTime
                ))
                .ToListAsync();
        }

        return [];
    }

    public async Task SetFavoriteRestaurant(string id)
    {
        var restaurant = await context.Restaurants.AsTracking().SingleOrDefaultAsync(r => r.Id == id);
        if (restaurant != null)
        {
            var user = await GetUser();
            if (user != null)
            {
                user.FavoriteRestaurant = restaurant;
                await context.SaveChangesAsync();
            }
        }
    }

    private async Task<UserDb?> GetUser()
    {
        if (!IsAuthenticated)
        {
            return null;
        }

        var user = await context.Users.AsTracking().SingleOrDefaultAsync(r => r.Id == Id);
        if (user != null)
        {
            return user;
        }

        user = new UserDb
        {
            Id = Id,
            Email = Email,
            Name = Name,
        };
        context.Users.Add(user);
        await context.SaveChangesAsync();
        return user;
    }
}
