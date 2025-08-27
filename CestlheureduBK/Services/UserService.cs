using CestlheureduBK.Common;
using CestlheureduBK.Model;
using Microsoft.EntityFrameworkCore;

namespace CestlheureduBK.Services;

public class UserService(IHttpContextAccessor httpContextAccessor, BKDbContext context)
{
    public bool IsAuthenticated => httpContextAccessor.HttpContext?.User.Identity?.IsAuthenticated ?? false;

    public Guid Id => Guid.TryParse(httpContextAccessor.HttpContext?.User.FindFirst("http://schemas.microsoft.com/identity/claims/objectidentifier")?.Value.Split(" ").First(), out var id) ? id : default;

    public string Name => httpContextAccessor.HttpContext?.User.FindFirst("name")?.Value.Split(" ").First() ?? "Michel";

    public string Email => httpContextAccessor.HttpContext?.User.Identity?.Name ?? string.Empty;

    public async Task<RestaurantDisplay?> GetFavoriteRestaurant()
    {
        if (!IsAuthenticated)
        {
            return null;
        }

        var r = (await GetUser()).FavoriteRestaurant;
        if (r == null)
        {
            return null;
        }

        return r.ToDisplay();
    }

    private async Task<UserDb> GetUser()
    {
        var user = await context.Users.AsTracking().SingleOrDefaultAsync(r => r.Id == Id);
        if (user != null)
        {
            return user;
        }

        user = new UserDb { Id = Id, Email = Email, Name = Name };
        context.Users.Add(user);
        await context.SaveChangesAsync();
        return user;
    }

    public async Task SetFavoriteRestaurant(string id)
    {
        var restaurant = await context.Restaurants.AsTracking().SingleOrDefaultAsync(r => r.Id == id);
        if (restaurant != null)
        {
            var user = await GetUser();
            user.FavoriteRestaurant = restaurant;
            await context.SaveChangesAsync();
        }
    }
}
