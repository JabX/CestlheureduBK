using CestlheureduBK.Common;
using CestlheureduBK.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Mvc;

namespace CestlheureduBK;

public static class ApiRoutes
{
    public static void MapApiRoutes(this WebApplication app)
    {
        app.MapPut(
            "api/energy/{type}/{id}",
            (ItemType type, string id, [FromServices] UpdateDataService updateDataService) =>
            {
                return updateDataService.ReloadEnergy(type, id).Distinct();
            }
        );

        app.MapPut(
            "api/update/{codeRestaurant}",
            async (string codeRestaurant, [FromServices] UpdateDataService updateDataService) =>
            {
                var (_, error) = await updateDataService.ReloadCatalogue(codeRestaurant);
                return error ? Results.BadRequest() : Results.Ok();
            }
        );

        app.MapPut(
            "api/favorite/{codeRestaurant}",
            async (string codeRestaurant, [FromServices] UserService userService) =>
            {
                await userService.SetFavoriteRestaurant(codeRestaurant);
                return Results.Ok();
            }
        );

        app.MapPut(
            "api/mystery/me/{mpId}/{codeRestaurant}",
            async (int mpId, string codeRestaurant, [FromServices] UserService userService) =>
            {
                await userService.AddMysteryRollMe(mpId, codeRestaurant);
                return Results.Ok();
            }
        );

        app.MapPut(
            "api/mystery/anonymous/{mpId}/{codeRestaurant}",
            async (int mpId, string codeRestaurant, [FromServices] UserService userService) =>
            {
                await userService.AddMysteryRollAnonymous(mpId, codeRestaurant);
                return Results.Ok();
            }
        );

        app.MapDelete(
            "api/mystery/{mrId}",
            async (int mrId, [FromServices] UserService userService) =>
            {
                await userService.DeleteMysteryRoll(mrId);
                return Results.Ok();
            }
        );

        app.MapGet(
            "/login",
            async context =>
            {
                if (context.User.Identity?.IsAuthenticated != true)
                {
                    await context.ChallengeAsync(OpenIdConnectDefaults.AuthenticationScheme);
                }
                else
                {
                    context.Response.Redirect("/");
                }
            }
        );

        app.MapGet(
            "/logout",
            async context =>
            {
                await context.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                await context.SignOutAsync(OpenIdConnectDefaults.AuthenticationScheme, new() { RedirectUri = "/" });
            }
        );
    }
}
