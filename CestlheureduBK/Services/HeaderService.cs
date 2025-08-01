using CestlheureduBK.Common;

namespace CestlheureduBK.Services;

public class HeaderService(GetDataService getDataService, UpdateDataService updateDataService)
{
    public async Task<HeaderData> InitHeader(string? restaurantId)
    {
        var offersUpdate = await getDataService.GetOffersUpdate();
        var restaurants = await getDataService.GetRestaurants();
        var restaurant = await getDataService.GetRestaurant(restaurantId);

        if (restaurant != null)
        {
            if (restaurant.CatalogueUpdate == null)
            {
                await updateDataService.ReloadCatalogue(restaurant.Id);
                restaurant = await getDataService.GetRestaurant(restaurant.Id);
            }
        }

        return new(restaurant, restaurants, offersUpdate);
    }
}

