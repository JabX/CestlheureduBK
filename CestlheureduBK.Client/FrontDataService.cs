using System.Net.Http.Json;
using CestlheureduBK.Common;

namespace CestlheureduBK.Client;

public class FrontDataService(HttpClient client) : IDataService
{
    public async Task<OfferDisplay[]> GetOffers(OfferCriteria criteria)
    {
        using var res = await client.PostAsJsonAsync("/api/offers", criteria);
        return (await res.Content.ReadFromJsonAsync<OfferDisplay[]>())!;
    }

    public Task<RestaurantDisplay> GetRestaurant()
    {
        return client.GetFromJsonAsync<RestaurantDisplay>("/api/restaurant")!;
    }

    public Task<SnackDisplay[]> GetSnacks(string sortBy, bool asc)
    {
        return client.GetFromJsonAsync<SnackDisplay[]>($"/api/snacks?sortBy={sortBy}&asc={asc}")!;
    }

    public Task<UpdateDisplay> GetUpdate()
    {
        return client.GetFromJsonAsync<UpdateDisplay>("/api/update")!;
    }
}
