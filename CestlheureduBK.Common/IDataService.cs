namespace CestlheureduBK.Common;

public interface IDataService
{
    Task<OfferDisplay[]> GetOffers(OfferCriteria criteria);

    Task<RestaurantDisplay> GetRestaurant();

    Task<SnackDisplay[]> GetSnacks(string sortBy, bool asc);

    Task<UpdateDisplay> GetUpdate();
}

